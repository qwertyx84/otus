using BaseClass;
using Shapes;
using System.Drawing;
using Rectangle = Shapes.Rectangle;

internal class Program
{
    private static void Main(string[] args)
    {
        // Ориг фигура
        Square square = new(10);


        // Клонируем фигуру через IMyCloneable
        Shape clonedShape = square.Clone();

        // Клонировать объект с помощью интерфейса ICloneable
        object objectClone = ((ICloneable)square).Clone();

        // Выводим исходную и клонированную фигуры
        Console.WriteLine($"Оригинальная фигура: {square}, хэш {square.GetHashCode()}");
        Console.WriteLine($"Клон IMyCloneable: {clonedShape}, хэш {clonedShape.GetHashCode()}");
        Console.WriteLine($"Клон ICloneable: {objectClone}, хэш {objectClone.GetHashCode()}");

        /*
        IMyCloneable обеспечивает специфичную типизацию для возвращаемого типа клонированных объектов, что делает код более понятным и безопасным от ошибок.
        ICloneable возвращает объект типа object, что может привести к ошибкам приведения типов 
        */
    }
}
