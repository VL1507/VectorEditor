using VectorEditor.Shapes;

namespace VectorEditor;

public partial class MainForm : Form
{
    // Параметры фигуры. Нужны при создании и изменении
    private Color _fillColor = Color.Aqua;
    private Color _outlineColor = Color.Brown;
    private int _outlineWidth;

    // Точка начала создания или перемещения фигуры
    private Point _startPoint;

    // Список всех фигур на экране
    private List<Shape> _shapes = new List<Shape>();

    // Выбранная фигура
    private Shape _selectedShape;

    // Фигура которую сейчас создают
    private Shape _currentShape;

    // Режим работы
    private EditMode _editMode = EditMode.Stub;

    // Тип фигуры которую сейчас могут сделать. Выбирается по кнопке
    private ShapeType _selectedShapeType = ShapeType.None;

    // Инит. Выполняется один раз
    public MainForm()
    {
        DoubleBuffered = true;
        InitializeComponent();
        InitColor();
        _outlineWidth = (int)numericUpDown1.Value;
        InitActiveControl();
        UpdateEditModeLabel();
        this.KeyPreview = true;
    }

    // Нужно, чтобы при зупуске не было выделенных кнопок
    private void InitActiveControl()
    {
        Label invisibleLabel = new Label();
        invisibleLabel.Size = new Size(0, 0);
        invisibleLabel.TabStop = false;
        this.Controls.Add(invisibleLabel);
        this.ActiveControl = invisibleLabel;
    }

    // Покраска кнопок в начальные значения цветов
    private void InitColor()
    {
        fillColorButton.BackColor = _fillColor;
        outlineColorButton.BackColor = _outlineColor;
        colorDialog1.Color = _fillColor;
        colorDialog2.Color = _outlineColor;
    }

    // Изменение цвета заливки. Если фигура выбрана, то цвет изменяется и у нее
    private void FillColorButton_Click(object sender, EventArgs e)
    {
        if (colorDialog1.ShowDialog() == DialogResult.OK)
        {
            _fillColor = colorDialog1.Color;
            fillColorButton.BackColor = _fillColor;

            if (_selectedShape != null)
            {
                _selectedShape._fillColor = _fillColor;
                this.Invalidate();
            }
        }
    }

    // Изменение цвета границы. Если фигура выбрана, то цвет изменяется и у нее
    private void OutlineColorButton_Click(object sender, EventArgs e)
    {
        if (colorDialog2.ShowDialog() == DialogResult.OK)
        {
            _outlineColor = colorDialog2.Color;
            outlineColorButton.BackColor = _outlineColor;

            if (_selectedShape != null)
            {
                _selectedShape._outlineColor = _outlineColor;
                this.Invalidate();
            }
        }
    }

    // Изменение значения ширины границы фигуры. Если фигура выбрана, то ширина и у нее
    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
        _outlineWidth = (int)numericUpDown1.Value;
        if (_selectedShape != null)
        {
            _selectedShape._outlineWidth = _outlineWidth;
            this.Invalidate();
        }
    }

    // Рисует все фигуры
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

    // Кнопка создания прямоугольника
    private void RectangleButton_Click(object sender, EventArgs e)
    {
        _selectedShapeType = ShapeType.Rectangle;
        _editMode = EditMode.Stub;
        UpdateEditModeLabel();
        _selectedShape = null;
        Invalidate();
    }

    // отвечает за передвижение мышки
    private void MainForm_MouseMove(object sender, MouseEventArgs e)
    {
        UpdateCoordinatesLabel(e.Location);

        // рисование фигуры
        if (_editMode == EditMode.Draw)
        {
            // рисование прямоугольника
            if (_selectedShapeType == ShapeType.Rectangle)
            {
                _currentShape = new RectangleShape(_startPoint.X, _startPoint.Y, e.X, e.Y);
            }

            // надо заново задать значения потому что пересоздали фигуру
            _currentShape._fillColor = _fillColor;
            _currentShape._outlineColor = _outlineColor;
            _currentShape._outlineWidth = _outlineWidth;

            this.Invalidate();
        }

        // перемещение фигуры
        else if (_editMode == EditMode.Select && _selectedShape != null && e.Button == MouseButtons.Left)
        {
            int dx = e.X - _startPoint.X;
            int dy = e.Y - _startPoint.Y;
            _selectedShape.Move(dx, dy);
            this.Invalidate();
            // чтобы не накапливалось перемещение (а то улетит)
            _startPoint = e.Location;
        }
    }

    // клик, опускание мыши
    private void MainForm_MouseDown(object sender, MouseEventArgs e)
    {
        // точка куда кликнули
        _startPoint = e.Location;

        // _selectedShape = null;

        // конец выделения
        if (e.Button == MouseButtons.Right)
        {
            _selectedShape = null;
            _editMode = EditMode.Stub;
            UpdateEditModeLabel();
            this.Invalidate();
            return;
        }

        // TODO
        if (_selectedShapeType != ShapeType.None && _selectedShapeType != ShapeType.None)
        {
            _editMode = EditMode.Draw;
            UpdateEditModeLabel();
            return;
        }

        // проверка на нажатие по фигуре
        foreach (var shape in _shapes)
        {
            if (shape.Contains(e.Location))
            {
                _editMode = EditMode.Select;
                UpdateEditModeLabel();
                _selectedShape = shape;
                this.Invalidate();
                return;
            }
        }
    }

    // поднятие мыши
    private void MainForm_MouseUp(object sender, MouseEventArgs e)
    {
        // завершение создания фигуры
        if (_editMode == EditMode.Draw)
        {
            _editMode = EditMode.Stub;
            UpdateEditModeLabel();

            _selectedShapeType = ShapeType.None;

            _shapes.Add(_currentShape);
            _currentShape = null;

            this.Invalidate();
        }
    }

    private void UpdateCoordinatesLabel(Point p)
    {
        coordinatesLabel.Text = $"Координаты мышки: {p.X}, {p.Y}";
    }

    private void UpdateEditModeLabel()
    {
        editModeLabel.Text = $"Режим: {_editMode}";
    }

    private void MainForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
        {
            if (_selectedShape != null)
            {
                _shapes.Remove(_selectedShape);
                _selectedShape = null;
                _editMode = EditMode.Stub;
                UpdateEditModeLabel();
                Invalidate();
            }
        }
    }
}