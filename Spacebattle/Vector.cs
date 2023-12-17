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

    public static class FuncGenerator<T>
    {
        private static Func<T, T, T> ExpressionToFunc(Func<ParameterExpression, ParameterExpression, BinaryExpression> f)
        {
                ParameterExpression ap = Expression.Parameter(typeof(T), "a");
                ParameterExpression bp = Expression.Parameter(typeof(T), "b");
                Expression operationResult = f(ap, bp);

                Expression<Func<T, T, T>> lambda = Expression.Lambda<Func<T, T, T>>(operationResult, ap, bp);
                return lambda.Compile();
            }

            private static Func<T[], T[], T[]> ArrayExpressionToFunc(Func<IndexExpression, IndexExpression, BinaryExpression> f)
            {
                ParameterExpression apA = Expression.Parameter(typeof(T[]), "a");
                ParameterExpression bpA = Expression.Parameter(typeof(T[]), "b");
                ParameterExpression operationResult = Expression.Parameter(typeof(T[]), "c");
                ParameterExpression iA = Expression.Parameter(typeof(int), "i");

                LabelTarget labelReturn = Expression.Label(typeof(T[]));

                Expression innerBlock = Expression.Block(
                    Expression.SubtractAssign(iA, Expression.Constant(1)),
                    Expression.IfThen(Expression.Equal(iA, Expression.Constant(-1)),
                    Expression.Return(labelReturn, operationResult)),
                    Expression.Assign(Expression.ArrayAccess(operationResult, iA), f(Expression.ArrayAccess(apA, iA), Expression.ArrayAccess(bpA, iA)))
                    );

                Expression<Func<int, T[]>> newTA = (i) => new T[i];

                Expression addeA = Expression.Block(
                    new[] { iA, operationResult },
                    Expression.Assign(iA, Expression.ArrayLength(apA)),
                    //Expression.Assign(cpA, Expression.NewArrayInit(typeof(T), Expression.Constant(0d), Expression.Constant(0d), Expression.Constant(0d))),
                    Expression.Assign(operationResult, Expression.Invoke(newTA, iA)),
                    Expression.Loop(innerBlock, labelReturn)
                    );

                //Compilation to get result.
                Expression<Func<T[], T[], T[]>> lambdaA = Expression.Lambda<Func<T[], T[], T[]>>(addeA, apA, bpA);
                return lambdaA.Compile();
        }

        public static Func<T, T, T> CreateOperatorFuncAdd()
        {
            return ExpressionToFunc((a, b) => Expression.Add(a, b));
        }

        public static Func<T[], T[], T[]> CreateArrayOperatorFuncAdd()
        {
            return ArrayExpressionToFunc((a, b) => Expression.Add(a, b));
        }
    }
}