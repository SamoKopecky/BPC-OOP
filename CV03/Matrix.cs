using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CV03
{
    class Matrix
    {
        public double[,] Data { get; set; }
        private readonly int _rows;
        private readonly int _columns;

        public Matrix(double[,] data)
        {
            Data = data;
            _rows = data.GetLength(0);
            _columns = data.GetLength(1);
        }


        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a._rows != b._rows || a._columns != b._columns)
            {
                throw new Exception("Matrix sizes have to be the same.");
            }

            var result = new Matrix(new double[a._rows, a._columns]);
            for (int i = 0; i < a._rows; i++)
            {
                for (int j = 0; j < a._columns; j++)
                {
                    result.Data[i, j] = a.Data[i, j] + b.Data[i, j];
                }
            }

            return result;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a._rows != b._rows || a._columns != b._columns)
            {
                throw new Exception("Matrix sizes have to be the same.");
            }

            var result = new Matrix(new double[a._rows, a._columns]);
            for (int i = 0; i < a._rows; i++)
            {
                for (int j = 0; j < a._columns; j++)
                {
                    result.Data[i, j] = a.Data[i, j] - b.Data[i, j];
                }
            }

            return result;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a._columns != b._rows)
            {
                throw new Exception(
                    "The number of columns in the first matrix and number" +
                    " of rows in the second have to be equal");
            }

            var result = new Matrix(new double[a._rows, b._columns]);
            double number = 0;
            for (int i = 0; i < a._rows; i++)
            {
                for (int j = 0; j < b._columns; j++)
                {
                    for (int k = 0; k < a._columns; k++)
                    {
                        number += a.Data[i, k] * b.Data[k, j];
                    }

                    result.Data[i, j] = number;
                    number = 0;
                }
            }

            return result;
        }

        public static bool operator ==(Matrix a, Matrix b)
        {
            if (a._columns != b._columns || a._rows != b._rows)
            {
                return false;
            }

            for (int i = 0; i < a._rows; i++)
            {
                for (int j = 0; j < a._columns; j++)
                {
                    if (Math.Abs(a.Data[i, j] - b.Data[i, j]) > double.Epsilon)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator !=(Matrix a, Matrix b)
        {
            if (a._columns != b._columns || a._rows != b._rows)
            {
                return true;
            }

            for (int i = 0; i < a._rows; i++)
            {
                for (int j = 0; j < a._columns; j++)
                {
                    if (Math.Abs(a.Data[i, j] - b.Data[i, j]) > double.Epsilon)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static Matrix operator -(Matrix a)
        {
            var result = new Matrix(new double[a._rows, a._columns]);
            for (int i = 0; i < a._rows; i++)
            {
                for (int j = 0; j < a._columns; j++)
                {
                    result.Data[i, j] = -a.Data[i, j];
                }
            }

            return result;
        }

        public double Determinant()
        {
            if (_columns != _rows)
            {
                throw new Exception("Matrix has to be square.");
            }
            else if (_columns > 3)
            {
                throw new Exception("Side length of the matrix has to be smaller then 3.");
            }

            switch (_columns)
            {
                case 1:
                    return Data[0, 0];
                case 2:
                    return DeterminantForSize2();
                case 3:
                    return DeterminantForSize3();
                default:
                    return 0f;
            }
        }

        private double DeterminantForSize2()
        {
            return GetIAndJ(0) * GetIAndJ(3) - GetIAndJ(1) * GetIAndJ(2);
        }

        /// <summary>
        /// Implementation of a wikipedia definition of a determinant for 3x3 matrix.
        /// </summary>
        /// <returns>De</returns>
        private double DeterminantForSize3()
        {
            return GetIAndJ(0) * GetIAndJ(4) * GetIAndJ(8) +
                   GetIAndJ(1) * GetIAndJ(5) * GetIAndJ(6) +
                   GetIAndJ(2) * GetIAndJ(3) * GetIAndJ(7) -
                   GetIAndJ(2) * GetIAndJ(4) * GetIAndJ(6) -
                   GetIAndJ(1) * GetIAndJ(3) * GetIAndJ(8) -
                   GetIAndJ(0) * GetIAndJ(5) * GetIAndJ(7);
        }

        /// <summary>
        /// Returns the i and j coordinates from the position of an element.
        /// Position is counted from the top left corner to bottom right
        /// corner and starts from 0.
        /// Example:
        /// { 3[0], 5[1]},
        /// { 7[2], 2[3]}
        ///
        /// The numbers in [] are the positions of the elements.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>
        /// The coordinates of the position.
        /// </returns>
        public double GetIAndJ(int position)
        {
            int i = position % _columns;
            int j = (position - i) / _columns;
            return Data[j, i];
        }


        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    result += $"{Data[i, j],-6:F1}";
                }

                result += '\n';
            }

            return result;
        }
    }
}