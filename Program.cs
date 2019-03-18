using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_lab
{
    /* System Code Start */

    // ------------------------------------------------------- VECTOR
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

    // ------------------------------------------------------- MATRIX
    interface IMatrix
    {
        void SetVal(int indexI, int indexJ, int val);
        int GetVal(int indexI, int indexJ);
        int GetColumnSize();
        int GetRowSize();

        // LAB 2
        void SetVisualizator(IVisualizator _visualizator);
        void VisualizationMatrix();
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

        // LAB 2
        private IVisualizator visualizator;

        public void SetVisualizator(IVisualizator _visualizator)
        {
            visualizator = _visualizator;
        }

        public abstract void VisualizationMatrix();

        protected void DrawBorder()
        {
            visualizator.DrawBorder(this);
        }

        protected void DrawCellVal()
        {
            visualizator.DrawCellVal(this);
        }
    }

    class NormalMatrix : AMatrix
    {
        protected override IVector Create()
        {
            return new NormalVector();
        }

        public override void VisualizationMatrix()
        {
            Console.WriteLine("Visualization Normal Matrix");
            DrawBorder();
            DrawCellVal();
        }
    }

    class SparseMatrix : AMatrix
    {
        protected override IVector Create()
        {
            return new SparseVector();
        }

        public override void VisualizationMatrix()
        {
            Console.WriteLine("Visualization Sparse Matrix");
            DrawBorder();
            DrawCellVal();
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

    // ------------------------------------------------------- VISUALIZATOR
    interface IVisualizator
    {
        void DrawBorder(IMatrix matrix);
        void DrawCellVal(IMatrix matrix);
    }

    class ConsoleVisualizator : IVisualizator
    {
        public void DrawBorder(IMatrix matrix)
        {
            Console.WriteLine("ConsoleVisualizator: Draw Border");
        }

        public void DrawCellVal(IMatrix matrix)
        {
            Console.WriteLine("ConsoleVisualizator: Draw Cell Val");
        }
    }

    class GraphicsContextVisualizator : IVisualizator
    {
        public void DrawBorder(IMatrix matrix)
        {
            Console.WriteLine("GraphicsContextVisualizator: Draw Border");
        }

        public void DrawCellVal(IMatrix matrix)
        {
            Console.WriteLine("GraphicsContextVisualizator: Draw Cell Val");
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
            matrix.SetVisualizator(new ConsoleVisualizator());
            matrix.VisualizationMatrix();

            matrix.SetVisualizator(new GraphicsContextVisualizator());
            matrix.VisualizationMatrix();

            Console.WriteLine();
        }

        /* Configurator Code End */

        static void Main(string[] args)
        {
            Console.WriteLine("Client start working... \n");

            /* Client Code Start */

            IMatrix normalMatrix = new NormalMatrix();
            MatrixInitializer.InitMatrix(normalMatrix, 7, 10);
            PrintMatrixStatistic(normalMatrix);
            PrintMatrix(normalMatrix);

            IMatrix sparseMatrix = new SparseMatrix();
            MatrixInitializer.InitMatrix(sparseMatrix, 7, 10);
            PrintMatrixStatistic(sparseMatrix);
            PrintMatrix(sparseMatrix);

            // LAB 3
            RenumberDecorator tempMat = new RenumberDecorator(normalMatrix);
            // Как создать IMatrix с новыми методами?
            tempMat.RenumberRow(0, 2);

            /* Client Code End */
        }
    }
}
