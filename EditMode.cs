namespace VectorEditor;

// режимы работы редактора
public enum EditMode
{
    // Заглушка. Ничего не происходит
    Stub,

    // рисование новой фигуры
    Draw,

    // выделение фигуры
    Select,

    // поворот
    Rotate,
}