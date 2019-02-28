using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_lab
{
    interface IVector<T>
    {
        void SetVal(int index, T val);
        void AddVal(T val);
        T GetVal(int index);
        int GetSize();
    }

    class NormalVector<T> : IVector<T>
    {
        List<T> valList = new List<T>();

        public void SetVal(int index, T val)
        {
            valList[index] = val;
        }

        public void AddVal(T val)
        {
            valList.Add(val);
        }

        public T GetVal(int index)
        {
            return valList[index];
        }

        public int GetSize()
        {
            return valList.Count;
        }
    }

    class SparseVector<T> : IVector<T>
    {
        List<T> valList = new List<T>();

        public void SetVal(int index, T val)
        {
            valList[index] = val;
        }

        public void AddVal(T val)
        {
            valList.Add(val);
        }

        public T GetVal(int index)
        {
            return valList[index];
        }

        public int GetSize()
        {
            return valList.Count;
        }
    }

    interface IMatrix
    {
        void SetVal(int indexI, int indexJ, int val);
        void SetMatrixSize(int RowSize, int ColumnSize); // Not really seting :)
        int GetVal(int indexI, int indexJ);
        int GetColumnSize();
        int GetRowSize();
        void Print();
    }

    abstract class SomeMatrix : IMatrix
    {
        protected IVector<IVector<int>> valMatrix;

        public abstract void SetVal(int indexI, int indexJ, int val);
        public void SetMatrixSize(int RowSize, int ColumnSize)
        {
            AddRow(RowSize);
            AddColumn(ColumnSize);
        }
        protected abstract void AddColumn(int num);
        protected abstract void AddRow(int num);
        public int GetVal(int indexI, int indexJ)
        {
            return valMatrix.GetVal(indexI).GetVal(indexJ);
        }
        public int GetColumnSize()
        {
            return valMatrix.GetVal(0).GetSize();
        }
        public int GetRowSize()
        {
            return valMatrix.GetSize();
        }
        public abstract void Print();
    }

    class NormalMatrix : SomeMatrix
    {
        //private NormalVector<NormalVector<int>> valMatrix = new NormalVector<NormalVector<int>>();

        public NormalMatrix()
        {
            valMatrix = new NormalVector<IVector<int>>();
        }

        public override void SetVal(int indexI, int indexJ, int val)
        {
            NormalVector<int> insideVec = (NormalVector<int>)valMatrix.GetVal(indexI);
            insideVec.SetVal(indexJ, val);
            valMatrix.SetVal(indexI, insideVec);
        }

        protected override void AddColumn(int num)
        {
            for (int count = 0; count < num; count++)
            {
                for (int indexI = 0; indexI < valMatrix.GetSize(); indexI++)
                {
                    NormalVector<int> insideVec = (NormalVector<int>)valMatrix.GetVal(indexI);
                    insideVec.AddVal(0);
                    valMatrix.SetVal(indexI, insideVec);
                }
            }
        }

        protected override void AddRow(int num)
        {
            for (int count = 0; count < num; count++)
            {
                valMatrix.AddVal(new NormalVector<int>());
            }
        }

        //public override int GetVal(int indexI, int indexJ)
        //{
        //    return valMatrix.GetVal(indexI).GetVal(indexJ);
        //}

        //public override int GetColumnSize()
        //{
        //    return valMatrix.GetVal(0).GetSize();
        //}

        //public override int GetRowSize()
        //{
        //    return valMatrix.GetSize();
        //}

        public override void Print()
        {
            Console.WriteLine("Normal matrix");
            for (int indexI = 0; indexI < GetRowSize(); indexI++)
            {
                for (int indexJ = 0; indexJ < GetColumnSize(); indexJ++)
                {
                    Console.Write(GetVal(indexI, indexJ) + " ");
                }
                Console.WriteLine("|");
            }
        }
    }

    class SparseMatrix : SomeMatrix
    {
        //SparseVector<SparseVector<int>> valMatrix = new SparseVector<SparseVector<int>>();

        public SparseMatrix()
        {
            valMatrix = new SparseVector<IVector<int>>();
        }

        public override void SetVal(int indexI, int indexJ, int val)
        {
            SparseVector<int> insideVec = (SparseVector<int>)valMatrix.GetVal(indexI);
            insideVec.SetVal(indexJ, val);
            valMatrix.SetVal(indexI, insideVec);
        }

        protected override void AddColumn(int num)
        {
            for (int count = 0; count < num; count++)
            {
                for (int indexI = 0; indexI < valMatrix.GetSize(); indexI++)
                {
                    SparseVector<int> insideVec = (SparseVector<int>)valMatrix.GetVal(indexI);
                    insideVec.AddVal(0);
                    valMatrix.SetVal(indexI, insideVec);
                }
            }
        }

        protected override void AddRow(int num)
        {
            for (int count = 0; count < num; count++)
            {
                valMatrix.AddVal(new SparseVector<int>());
            }
        }

        //public override int GetVal(int indexI, int indexJ)
        //{
        //    return valMatrix.GetVal(indexI).GetVal(indexJ);
        //}

        //public override int GetColumnSize()
        //{
        //    return valMatrix.GetVal(0).GetSize();
        //}

        //public override int GetRowSize()
        //{
        //    return valMatrix.GetSize();
        //}

        public override void Print()
        {
            Console.WriteLine("Sparse matrix");
            for (int indexI = 0; indexI < GetRowSize(); indexI++)
            {
                for (int indexJ = 0; indexJ < GetColumnSize(); indexJ++)
                {
                    Console.Write(GetVal(indexI, indexJ) + " ");
                }
                Console.WriteLine("|");
            }
        }
    }

    class MatrixInitializer
    {
        public static void InitMatrix(IMatrix matrix, int notNullNumber, int maxNumber)
        {
            int numOfNumbers = matrix.GetRowSize() * matrix.GetColumnSize();
            Random rand = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < matrix.GetRowSize(); i++)
            {
                for (int j = 0; j < matrix.GetColumnSize(); j++)
                {
                    int val;

                    if (rand.Next(1, numOfNumbers) <= notNullNumber)
                    {
                        val = rand.Next(1, maxNumber);
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

    class Program
    {
        private static void PrintStatistic(MatrixStatistic matrixStatistic)
        {
            Console.WriteLine("Sum elements                : " + matrixStatistic.GetSumValues());
            Console.WriteLine("Average of elements         : " + matrixStatistic.GetAverageValue());
            Console.WriteLine("Max element                 : " + matrixStatistic.GetMaxValue());
            Console.WriteLine("Number of not null elements : " + matrixStatistic.GetNotNullValuesNumber());
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Client start working");

            IMatrix normalMatrix = new NormalMatrix();
            normalMatrix.SetMatrixSize(5, 3);
            MatrixInitializer.InitMatrix(normalMatrix, 5, 10);
            normalMatrix.Print();
            PrintStatistic(new MatrixStatistic(normalMatrix));

            IMatrix sparseMatrix = new SparseMatrix();
            sparseMatrix.SetMatrixSize(3, 3);
            MatrixInitializer.InitMatrix(sparseMatrix, 5, 10);
            sparseMatrix.Print();
            PrintStatistic(new MatrixStatistic(sparseMatrix));

        }
    }
}
