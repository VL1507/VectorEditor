namespace VectorEditor.Shapes;

public abstract class Shape
{
    public int rotationAngle = 0;
    public Color _fillColor = Color.BlueViolet;
    public Color _outlineColor = Color.Black;
    public int _outlineWidth = 1;

    public abstract bool Contains(Point p);
    public abstract void Draw(Graphics g);
    public abstract void Fill(Graphics g);
    

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
}