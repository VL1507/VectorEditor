namespace VectorEditor.Shapes;

// базовый класс фигуры
public abstract class Shape
{
    // цвета
    public Color _fillColor = Color.BlueViolet;
    public Color _outlineColor = Color.Black;
    public Color _dotColor = Color.Crimson;

    // размеры
    public int _dotRadius = 5;
    public int _outlineWidth = 1;

    // угол поворота
    public int rotationAngle = 0;

    // список точек из которых состоит фигура
    public List<Point> _points = new List<Point>();

    // список точек для рамки во время выделения
    public List<Point> _dotss = new List<Point>();

    // проверка принадлежит ли точка фигуре. нужно для выделения
    public abstract bool Contains(Point p);

    // рисование фигуры
    public abstract void Draw(Graphics g);
    // public abstract void Fill(Graphics g);

    // рисование во время выделения
    public abstract void Select(Graphics g);

    // перемещение фигуры на dx dy
    public abstract void Move(int dx, int dy);

    // рисование точки
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

    // перевод градусов в радианы
    private float ToRadians(float degrees)
    {
        return degrees * MathF.PI / 180;
    }
}