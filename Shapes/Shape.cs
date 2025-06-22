namespace VectorEditor.Shapes;

public abstract class Shape
{
    public int rotationAngle = 0;
    
    
    
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