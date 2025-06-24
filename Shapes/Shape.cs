namespace VectorEditor.Shapes;

public abstract class Shape
{
    public int rotationAngle = 0;
    public Color _fillColor = Color.BlueViolet;
    public Color _outlineColor = Color.Black;
    public Color _dotColor = Color.Crimson;
    public int _dotRadius = 5;
    public int _outlineWidth = 1;
    public List<Point> _points = new List<Point>();
    public List<Point> _dotss = new List<Point>();

    public abstract bool Contains(Point p);
    public abstract void Draw(Graphics g);
    // public abstract void Fill(Graphics g);

    public abstract void Select(Graphics g);
    public abstract void Move(int dx, int dy);

    public Bitmap Dot(int radius, Color color)
    {
        Bitmap map = new Bitmap(radius * 2 + 1, radius * 2 + 1);
        for (int x = -radius; x <= radius; x++)
        {
            for (int y = -radius; y <= radius; y++)
            {
                if ((x * x) + (y * y) <= (radius * radius))
                {
                    map.SetPixel(x + radius, y + radius, color);
                }
            }
        }

        return map;
    }

    private float ToRadians(float degrees)
    {
        return degrees * MathF.PI / 180;
    }
}