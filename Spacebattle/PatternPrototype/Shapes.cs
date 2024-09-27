using BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    /// <summary>
    /// Класс Rectangle , наследуемый от Shape
    /// </summary>
    public class Rectangle : Shape, ICloneable, IMyCloneable<Rectangle>
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public override Rectangle Clone() => new Rectangle(Width, Height);

        object ICloneable.Clone() => Clone();

    }
    /// <summary>
    /// Класс Square, наследуемый от Shape.Rectangle
    /// </summary>
    public class Square : Rectangle
    {
        public int Side { get; set; }

        public Square(int side) : base(side, side)
        {
            Side = side;
        }

        public override Square Clone()
        {
            return new Square(Side);
        }

    }

}
