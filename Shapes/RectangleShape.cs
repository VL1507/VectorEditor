namespace VectorEditor.Shapes;

public class RectangleShape : Shape
{
    public RectangleShape(int x1, int y1, int x2, int y2)
    {
        _points.Add(new Point(x1, y1));
        _points.Add(new Point(x1, y2));
        _points.Add(new Point(x2, y2));
        _points.Add(new Point(x2, y1));
    }


    public override bool Contains(Point p)
    {
        bool inside = false;
        for (int i = 0, j = _points.Count - 1; i < _points.Count; j = i++)
        {
            if (((_points[i].Y > p.Y) != (_points[j].Y > p.Y)) &&
                (p.X < (_points[j].X - _points[i].X) * (p.Y - _points[i].Y) / (_points[j].Y - _points[i].Y) +
                    _points[i].X))
            {
                inside = !inside;
            }
        }

        return inside;
    }

    public override void Select(Graphics g)
    {
        Draw(g);
        DrawDots(g);
    }

    public override void Draw(Graphics g)
    {
        int minX = _points.Min(p => p.X);
        int maxX = _points.Max(p => p.X);
        int minY = _points.Min(p => p.Y);
        int maxY = _points.Max(p => p.Y);

        Bitmap bitmap = new Bitmap(maxX - minX + 1, maxY - minY + 1);

        // Fill(bitmap, _fillColor, minX, minY, maxX, maxY);
        ScanlineFill(bitmap, _fillColor, minX, minY, maxX, maxY);

        DrawLine(bitmap, _outlineColor, new Point(0, 0), new Point(0, maxY - minY), _outlineWidth);
        DrawLine(bitmap, _outlineColor, new Point(0, maxY - minY), new Point(maxX - minX, maxY - minY), _outlineWidth);
        DrawLine(bitmap, _outlineColor, new Point(maxX - minX, maxY - minY), new Point(maxX - minX, 0), _outlineWidth);
        DrawLine(bitmap, _outlineColor, new Point(maxX - minX, 0), new Point(0, 0), _outlineWidth);

        // DrawLine(bitmap, _outlineColor, new Point(maxX - minX, maxY - minY), new Point(0, 0), _outlineWidth);


        g.DrawImageUnscaled(bitmap, minX, minY);

        // DrawDots(g);
    }

    private void DrawLine(Bitmap bitmap, Color color, Point start, Point end, int lineWidth)
    {
        if (lineWidth == 0)
        {
            return;
        }

        int x0 = start.X;
        int y0 = start.Y;
        int x1 = end.X;
        int y1 = end.Y;

        // Рисуем центральную линию (добавляем точки центральной линии в список)
        List<Point> linePoints = new List<Point>();
        bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
        if (steep)
        {
            (x0, y0) = (y0, x0);
            (x1, y1) = (y1, x1);
        }

        if (x0 > x1)
        {
            (x0, x1) = (x1, x0);
            (y0, y1) = (y1, y0);
        }

        int dx = x1 - x0;
        int dy = Math.Abs(y1 - y0);
        int error = dx / 2;
        int ystep = (y0 < y1) ? 1 : -1;
        int y = y0;

        for (int x = x0; x <= x1; x++)
        {
            if (steep)
            {
                linePoints.Add(new Point(y, x));
            }
            else
            {
                linePoints.Add(new Point(x, y));
            }

            error -= dy;
            if (error < 0)
            {
                y += ystep;
                error += dx;
            }
        }
        
        // По основным точкам находим дополнительные и рисуем все.
        foreach (Point point in linePoints)
        {
            for (int offsetX = -lineWidth / 2; offsetX <= lineWidth / 2; offsetX++)
            {
                for (int offsetY = -lineWidth / 2; offsetY <= lineWidth / 2; offsetY++)
                {
                    int newX = point.X + offsetX;
                    int newY = point.Y + offsetY;
                    if (newX >= 0 && newX < bitmap.Width && newY >= 0 && newY < bitmap.Height)
                    {
                        bitmap.SetPixel(newX, newY, color);
                    }
                }
            }
        }
    }


    public void Fill(Bitmap bitmap, Color fillColor, int minX, int minY, int maxX, int maxY)
    {
        for (int x = 1; x < bitmap.Width - 1; x++)
        {
            for (int y = 1; y < bitmap.Height - 1; y++)
            {
                bitmap.SetPixel(x, y, fillColor);
            }
        }
    }

    private void ScanlineFill(Bitmap bitmap, Color fillColor, int minX, int minY, int maxX, int maxY)
    {
        // Определяем границы сканирования
        for (int y = 1; y < bitmap.Height - 1; y++)
        {
            // Находим пересечения с границами прямоугольника
            List<int> intersections = new List<int>();

            for (int i = 0; i < _points.Count; i++)
            {
                Point start = new Point(_points[i].X - minX, _points[i].Y - minY);
                Point end = new Point(_points[(i + 1) % _points.Count].X - minX,
                    _points[(i + 1) % _points.Count].Y - minY);

                if ((start.Y <= y && end.Y > y) || (end.Y <= y && start.Y > y))
                {
                    // Вычисляем пересечение с горизонтальной линией
                    double x = start.X + (double)(y - start.Y) / (end.Y - start.Y) * (end.X - start.X);
                    intersections.Add((int)x);
                }
            }

            // Сортируем пересечения
            intersections.Sort();

            // Закрашиваем пиксели между парами пересечений
            for (int i = 0; i < intersections.Count; i += 2)
            {
                if (i + 1 < intersections.Count)
                {
                    int startX = intersections[i];
                    int endX = intersections[i + 1];

                    for (int x = startX; x <= endX; x++)
                    {
                        if (x >= 0 && x < bitmap.Width)
                        {
                            bitmap.SetPixel(x, y, fillColor);
                        }
                    }
                }
            }
        }
    }

    private void DrawDots(Graphics g)
    {
        foreach (Point point in _points)
        {
            g.DrawImageUnscaled(Dot(_dotRadius, _dotColor), point.X - _dotRadius, point.Y - _dotRadius);
        }
    }

    public override void Move(int dx, int dy)
    {
        for (int i = 0; i < _points.Count; i++)
        {
            _points[i] = new Point(_points[i].X + dx, _points[i].Y + dy);
        }
    }
}