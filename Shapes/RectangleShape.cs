namespace VectorEditor.Shapes;

public class RectangleShape : Shape
{
    public Rectangle _rectangle;

    public int x;
    public int y;
    public int width;
    public int height;

    public RectangleShape(int x, int y, int width, int height)
    {
        _rectangle = new Rectangle(x, y, width, height);
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }


    public override bool Contains(Point p)
    {
        return _rectangle.Contains(p);
    }

    public override void Draw(Graphics g)
    {
        using (Pen pen = new Pen(_outlineColor, _outlineWidth))
        {
            g.DrawRectangle(pen, _rectangle);
        }
        Fill(g);
    }

    public override void Fill(Graphics g)
    {
        using (Brush brush = new SolidBrush(_fillColor))
        {
            g.FillRectangle(brush, _rectangle);
        }
    }
}