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
        T GetVal(int index);
        int GetSize();
    }

    class NormalVector<T> : IVector<T>
    {
        List<T> valList = new List<T>();

        public void SetVal(int index, T val)
        {
            Console.WriteLine("Set value in normal vector");

            valList[index] = val;
        }

        public T GetVal(int index)
        {
            Console.WriteLine("Get value from normal vector");

            return valList[index];
        }

        public int GetSize()
        {
            Console.WriteLine("Set size from normal vector");

            return valList.Count;
        }
    }

    class SparseVector<T> : IVector<T>
    {
        List<T> valList = new List<T>();

        public void SetVal(int index, T val)
        {
            Console.WriteLine("Set value in sparse vector");

            valList[index] = val;
        }

        public T GetVal(int index)
        {
            Console.WriteLine("Get value from sparse vector");

            return valList[index];
        }

        public int GetSize()
        {
            Console.WriteLine("Set size from sparse vector");

            return valList.Count;
        }
    }

    interface IMatrix
    {
        void SetVal(int indexI, int indexJ, int val);
        int GetVal(int indexI, int indexJ);
        int GetColumnsSize();
        int GetRowsSize();
    }

    abstract class SomeMatrix : IMatrix
    {
        public abstract void SetVal(int indexI, int indexJ, int val);
        public abstract int GetVal(int indexI, int indexJ);
        public abstract int GetColumnsSize();
        public abstract int GetRowsSize();
    }

    class NormalMatrix : SomeMatrix
    {
        NormalVector<NormalVector<int>> valMatrix = new NormalVector<NormalVector<int>>();

        public override void SetVal(int indexI, int indexJ, int val)
        {
            NormalVector<int> insideVec = valMatrix.GetVal(indexI);
            insideVec.SetVal(indexJ, val);
            valMatrix.SetVal(indexI, insideVec);
        }

        public override int GetVal(int indexI, int indexJ)
        {
            return valMatrix.GetVal(indexI).GetVal(indexJ);
        }

        public override int GetColumnsSize()
        {
            return valMatrix.GetVal(0).GetSize();
        }

        public override int GetRowsSize()
        {
            return valMatrix.GetSize();
        }
    }

    class SparseMatrix : SomeMatrix
    {
        SparseVector<SparseVector<int>> valMatrix = new SparseVector<SparseVector<int>>();

        public override void SetVal(int indexI, int indexJ, int val)
        {
            SparseVector<int> insideVec = valMatrix.GetVal(indexI);
            insideVec.SetVal(indexJ, val);
            valMatrix.SetVal(indexI, insideVec);
        }

        public override int GetVal(int indexI, int indexJ)
        {
            return valMatrix.GetVal(indexI).GetVal(indexJ);
        }

        public override int GetColumnsSize()
        {
            return valMatrix.GetVal(0).GetSize();
        }

        public override int GetRowsSize()
        {
            return valMatrix.GetSize();
        }
    }

    class MatrixInitializer
    {
        static void InitMatrix(SomeMatrix someMatrix, int notNullNumber, int maxNumber)
        {
            int numOfNumbers = someMatrix.GetRowsSize() * someMatrix.GetColumnsSize();
            Random rand = new Random();

            for (int i = 0; i < someMatrix.GetRowsSize(); i++)
            {
                for (int j = 0; j < someMatrix.GetColumnsSize(); j++)
                {
                    int val;

                    if (rand.Next(1, numOfNumbers) <= notNullNumber)
                    {
                        val = rand.Next(100);
                        notNullNumber--;
                    }
                    else
                    {
                        val = 0;
                    }
                    numOfNumbers--;

                    someMatrix.SetVal(i, j, val);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
