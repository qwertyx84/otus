using System.Linq;
using System;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;


namespace Spacebattle
{
    public class Vector<T> : IEnumerable<T>
    {
        private T[] _values;

        public Vector(IEnumerable<T> initialValues)
        {
            // Задача 1.
        }

        public int Size
        {
            get
            {
                //Задача 2
            }
        }

        public static implicit operator Vector<T>(T[] a)
        {
            //Задача 3
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            //Задача 4
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //Задача 4
        }

        public override string ToString()
        {
            //Задача 5
        }

        public static T[] Parse(string value, Func<string, T> parse)
        {
            //Задача 6
        }

        public static Vector<T> operator +(Vector<T> a, Vector<T> b)
        {
            //Задача 7
        }

    }
}