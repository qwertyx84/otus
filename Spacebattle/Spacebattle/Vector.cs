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
                return 0; // Это заглушка, чтобы компилировался код
            }
        }

        public static implicit operator Vector<T>(T[] a)
        {
            //Задача 3
            return null; // Это заглушка, чтобы компилировался код
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            //Задача 4
            return null; // Это заглушка, чтобы компилировался код
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //Задача 4
            return null; // Это заглушка, чтобы компилировался код
        }

        public override string ToString()
        {
            //Задача 5
            return string.Empty; // Это заглушка, чтобы компилировался код
        }

        public static T[] Parse(string value, Func<string, T> parse)
        {
            //Задача 6
            return new T[0]; // Это заглушка, чтобы компилировался код
        }

        public static Vector<T> operator +(Vector<T> a, Vector<T> b)
        {
            //Задача 7
            return null; // Это заглушка, чтобы компилировался код
        }

    }
}