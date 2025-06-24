using VectorEditor.Shapes;

namespace VectorEditor;

public partial class MainForm : Form
{
    private Color _fillColor = Color.Aqua;
    private Color _outlineColor = Color.Brown;
    private int _outlineWidth;

    private List<Shape> _shapes = new List<Shape>();
    private Shape _selectedShape;
    private Shape _currentShape;

    private EditMode _editMode = EditMode.Stub;
    private ShapeType _selectedShapeType = ShapeType.None;
    private Point _startPoint;

    public MainForm()
    {
        DoubleBuffered = true;
        InitializeComponent();
        InitColor();
        _outlineWidth = (int)numericUpDown1.Value;
        InitActiveControl();
    }

    private void InitActiveControl()
    {
        Label invisibleLabel = new Label();
        invisibleLabel.Size = new Size(0, 0);
        invisibleLabel.TabStop = false;
        this.Controls.Add(invisibleLabel);
        this.ActiveControl = invisibleLabel;
    }

    private void InitColor()
    {
        fillColorButton.BackColor = _fillColor;
        outlineColorButton.BackColor = _outlineColor;
        colorDialog1.Color = _fillColor;
        colorDialog2.Color = _outlineColor;
    }

    private void FillColorButton_Click(object sender, EventArgs e)
    {
        if (colorDialog1.ShowDialog() == DialogResult.OK)
        {
            _fillColor = colorDialog1.Color;
            fillColorButton.BackColor = _fillColor;

            if (_currentShape != null)
            {
                _currentShape._fillColor = _fillColor;
                this.Invalidate();
            }
        }
    }

    private void OutlineColorButton_Click(object sender, EventArgs e)
    {
        if (colorDialog2.ShowDialog() == DialogResult.OK)
        {
            _outlineColor = colorDialog2.Color;
            outlineColorButton.BackColor = _outlineColor;

            if (_currentShape != null)
            {
                _currentShape._outlineColor = _outlineColor;
                this.Invalidate();
            }
        }
    }

    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
        _outlineWidth = (int)numericUpDown1.Value;
        if (_currentShape != null)
        {
            _currentShape._outlineWidth = _outlineWidth;
            this.Invalidate();
        }
    }

    private void MainForm_Paint(object sender, PaintEventArgs e)
    {
        foreach (var shape in _shapes)
        {
            shape.Draw(e.Graphics);
        }


        if (_selectedShape != null)
        {
            _selectedShape.Select(e.Graphics);
        }

        if (_editMode == EditMode.Draw && _currentShape != null)
        {
            _currentShape.Draw(e.Graphics);
        }
    }

    private void RectangleButton_Click(object sender, EventArgs e)
    {
        _selectedShapeType = ShapeType.Rectangle;
        _editMode = EditMode.Stub;
    }

    private void MainForm_MouseMove(object sender, MouseEventArgs e)
    {
        coordinatesLabel.Text = $"Координаты мышки: {e.X}, {e.Y}";

        if (_editMode == EditMode.Draw)
        {
            if (_selectedShapeType == ShapeType.Rectangle)
            {
                _currentShape = new RectangleShape(_startPoint.X, _startPoint.Y, e.X, e.Y);
            }

            _currentShape._fillColor = _fillColor;
            _currentShape._outlineColor = _outlineColor;
            _currentShape._outlineWidth = _outlineWidth;

            this.Invalidate();
        }

        else if (_editMode == EditMode.Select && _selectedShape != null && e.Button == MouseButtons.Left)
        {
            int dx = e.X - _startPoint.X;
            int dy = e.Y - _startPoint.Y;
            _selectedShape.Move(dx, dy);
            this.Invalidate();
            _startPoint = e.Location;
        }
    }

    private void MainForm_MouseDown(object sender, MouseEventArgs e)
    {
        _startPoint = e.Location;
        _selectedShape = null;
        
        if (e.Button == MouseButtons.Right)
        {
            _selectedShape = null;
            this.Invalidate(); 
            return;
        }
        
        
        if (_selectedShapeType != ShapeType.None)
        {
            _editMode = EditMode.Draw;
            return;
        }

        foreach (var shape in _shapes)
        {
            if (shape.Contains(e.Location))
            {
                shape._dotColor = Color.BlueViolet;
                _editMode = EditMode.Select;
                _selectedShape = shape;
                this.Invalidate();
                return;
            }
        }
        
    }

    private void MainForm_MouseUp(object sender, MouseEventArgs e)
    {
        if (_editMode == EditMode.Draw)
        {
            _editMode = EditMode.Stub;
            _selectedShapeType = ShapeType.None;
            _shapes.Add(_currentShape);
            this.Invalidate();
        }
    }
}