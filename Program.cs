using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_lab
{
    /* System Code Start */

    interface IVector
    {
        void SetVal(int index, int val);
        int GetVal(int index);
        int GetSize();
    }

    class NormalVector : IVector
    {
        private List<int> valList = new List<int>();

        public void SetVal(int index, int val)
        {
            for (int i = GetSize(); i <= index; i++)
            {
                valList.Add(0);
            }

            valList[index] = val;
        }

        public int GetVal(int index)
        {
            if (index >= GetSize())
            {
                Console.WriteLine("ERROR: Going beyond vector. Return -1");
                return -1;
            }

            return valList[index];
        }

        public int GetSize()
        {
            return valList.Count;
        }
    }

    class SparseVector : IVector
    {
        private Dictionary<int, int> valDict = new Dictionary<int, int>();

        public void SetVal(int index, int val)
        {
            valDict[index] = val;
        }

        public int GetVal(int index)
        {
            if (valDict.ContainsKey(index))
            {
                return valDict[index];
            }
            else
            {
                return 0;
            }
        }

        public int GetSize()
        {
            return valDict.Keys.Max();
        }
    }

    interface IMatrix
    {
        void SetVal(int indexI, int indexJ, int val);
        int GetVal(int indexI, int indexJ);
        int GetColumnSize();
        int GetRowSize();
    }

    abstract class AMatrix : IMatrix
    {
        private IVector valMatrix;
        private int columnSize;
        private int rowSize;

        protected abstract IVector Create();

        public AMatrix()
        {
            valMatrix = Create();
            columnSize = 0;
            rowSize = 0;
        }

        public void SetVal(int indexI, int indexJ, int val)
        {
            rowSize = Math.Max(indexI + 1, rowSize);
            columnSize = Math.Max(indexI + 1, columnSize);

            valMatrix.SetVal(indexI * GetColumnSize() + indexJ, val);
        }

        public int GetVal(int indexI, int indexJ)
        {
            return valMatrix.GetVal(indexI * GetColumnSize() + indexJ);
        }

        public int GetColumnSize()
        {
            return columnSize;
        }

        public int GetRowSize()
        {
            return rowSize;
        }
    }

    class NormalMatrix : AMatrix
    {
        protected override IVector Create()
        {
            return new NormalVector();
        }
    }

    class SparseMatrix : AMatrix
    {
        protected override IVector Create()
        {
            return new SparseVector();
        }
    }

    class MatrixInitializer
    {
        public static void InitMatrix(IMatrix matrix, int notNullNumber, int maxNumber)
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            /* Set matrix size for rand value */
            matrix.SetVal(rand.Next(2, 5), rand.Next(2, 5), 0);

            int numOfNumbers = matrix.GetRowSize() * matrix.GetColumnSize();

            for (int i = 0; i < matrix.GetRowSize(); i++)
            {
                for (int j = 0; j < matrix.GetColumnSize(); j++)
                {
                    int val;

                    if (rand.Next(1, numOfNumbers) <= notNullNumber)
                    {
                        val = rand.Next(1, maxNumber + 1);
                        notNullNumber--;
                    }
                    else
                    {
                        val = 0;
                    }
                    numOfNumbers--;

                    matrix.SetVal(i, j, val);
                }
            }
        }
    }

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

    class MatrixPrint
    {
        private IMatrix matrix;

        public MatrixPrint(IMatrix _matrix)
        {
            matrix = _matrix;
        }

        public void Print()
        {
            Console.WriteLine("Matrix");
            for (int indexI = 0; indexI < matrix.GetRowSize(); indexI++)
            {
                for (int indexJ = 0; indexJ < matrix.GetColumnSize(); indexJ++)
                {
                    Console.Write(matrix.GetVal(indexI, indexJ) + "	");
                }
                Console.WriteLine("|");
            }
        }
    }

    /* System Code End */

    class Program
    {
        /* Configurator Code Start */

        private static void PrintMatrixStatistic(IMatrix matrix)
        {
            MatrixStatistic matrixStatistic = new MatrixStatistic(matrix);

            Console.WriteLine("Sum elements                : " + matrixStatistic.GetSumValues());
            Console.WriteLine("Average of elements         : " + matrixStatistic.GetAverageValue());
            Console.WriteLine("Max element                 : " + matrixStatistic.GetMaxValue());
            Console.WriteLine("Number of not null elements : " + matrixStatistic.GetNotNullValuesNumber() + "\n");
        }

        private static void PrintMatrix(IMatrix matrix)
        {
            MatrixPrint matrixPrint = new MatrixPrint(matrix);

            matrixPrint.Print();
        }

        /* Configurator Code End */

        static void Main(string[] args)
        {
            Console.WriteLine("Client start working...");

            /* Client Code Start */

            IMatrix normalMatrix = new NormalMatrix();
            MatrixInitializer.InitMatrix(normalMatrix, 7, 10);
            PrintMatrix(normalMatrix);
            PrintMatrixStatistic(normalMatrix);

            IMatrix sparseMatrix = new SparseMatrix();
            MatrixInitializer.InitMatrix(sparseMatrix, 7, 10);
            PrintMatrix(sparseMatrix);
            PrintMatrixStatistic(sparseMatrix);

            /* Client Code End */
        }
    }
}
