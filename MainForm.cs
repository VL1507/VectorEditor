using VectorEditor.Shapes;

namespace VectorEditor;

public partial class MainForm : Form
{
    private Color _fillColor = Color.Aqua;
    private Color _outlineColor = Color.Brown;
    
    private int _outlineWidth;

    private List<Shape> _shapes = new List<Shape>();
    private Shape _selectedShape;

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
        }
    }

    private void OutlineColorButton_Click(object sender, EventArgs e)
    {
        if (colorDialog2.ShowDialog() == DialogResult.OK)
        {
            _outlineColor = colorDialog2.Color;
            outlineColorButton.BackColor = _outlineColor;
        }
    }

    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
        _outlineWidth = (int)numericUpDown1.Value;
    }
}