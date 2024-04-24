using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClass
{
    // Базовый класс Shape
    public abstract class Shape : IMyCloneable<Shape>
    {
        public abstract Shape Clone();
    }

}