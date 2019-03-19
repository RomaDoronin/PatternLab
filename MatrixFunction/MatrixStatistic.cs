using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pattern_lab.Matrix;

namespace Pattern_lab.MatrixFunction
{
    class MatrixStatistic
    {
        private IMatrix matrix;

        public MatrixStatistic(IMatrix _matrix)
        {
            matrix = _matrix;
        }

        public int GetSumValues()
        {
            int sum = 0;

            for (int i = 0; i < matrix.GetRowSize(); i++)
            {
                for (int j = 0; j < matrix.GetColumnSize(); j++)
                {
                    sum += matrix.GetVal(i, j);
                }
            }

            return sum;
        }

        public float GetAverageValue()
        {
            int sum = GetSumValues();
            int numberOfElem = matrix.GetRowSize() * matrix.GetColumnSize();

            return Convert.ToSingle(sum) / numberOfElem;
        }

        public int GetMaxValue()
        {
            int max = matrix.GetVal(0, 0);

            for (int i = 0; i < matrix.GetRowSize(); i++)
            {
                for (int j = 0; j < matrix.GetColumnSize(); j++)
                {
                    if (max < matrix.GetVal(i, j))
                    {
                        max = matrix.GetVal(i, j);
                    }
                }
            }

            return max;
        }

        public int GetNotNullValuesNumber()
        {
            int count = 0;

            for (int i = 0; i < matrix.GetRowSize(); i++)
            {
                for (int j = 0; j < matrix.GetColumnSize(); j++)
                {
                    if (0 != matrix.GetVal(i, j))
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
