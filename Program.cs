using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
        //void SetVisualizator(IVisualizator _visualizator);
        void VisualizationMatrix(IVisualizator _visualizator);
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

        /*public void SetVisualizator(IVisualizator _visualizator)
        {
            visualizator = _visualizator;
        }*/

        public abstract void VisualizationMatrix(IVisualizator _visualizator);

        /*protected void DrawBorder()
        {
            visualizator.DrawBorder(this);
        }

        protected void DrawCellVal(int i, int j)
        {
            visualizator.DrawCellVal(this, i, j);
        }*/
    }

    class NormalMatrix : AMatrix
    {
        protected override IVector Create()
        {
            return new NormalVector();
        }

        public override void VisualizationMatrix(IVisualizator _visualizator)
        {			
            Console.WriteLine("Visualization Normal Matrix");
            _visualizator.DrawBorder(this);
            for (int i = 0; i < GetRowSize(); i++)
            {
                for (int j = 0; j < GetColumnSize(); j++)
                {
                    _visualizator.DrawCellVal(this, i, j);
                }
            }
            
        }
    }

    class SparseMatrix : AMatrix
    {
        protected override IVector Create()
        {
            return new SparseVector();
        }

        public override void VisualizationMatrix(IVisualizator _visualizator)
        {
            Console.WriteLine("Visualization Sparse Matrix");
            _visualizator.DrawBorder(this);
            for (int i = 0; i < GetRowSize(); i++)
                for (int j = 0; j < GetColumnSize(); j++)
                {
                    if (GetVal(i,j) != 0)
                        _visualizator.DrawCellVal(this, i, j);
					else
						_visualizator.DrawCellVal(this, -1, j);
                }
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
        void DrawCellVal(IMatrix matrix, int i, int j);
    }

    class ConsoleVisualizator : IVisualizator
    {
		char border = ' ';
		
        public void DrawBorder(IMatrix matrix)
        {
            Console.WriteLine("ConsoleVisualizator: Draw Border");
			border = '|';
        }

        public void DrawCellVal(IMatrix matrix, int i, int j)
        {
			if (j == 0)
				Console.Write(border + "	");
			
			if (i == -1)
				Console.Write("_	");
			else
				Console.Write(matrix.GetVal(i,j) + "	");
			
			if (j == (matrix.GetColumnSize() - 1))
				Console.WriteLine(border);
        }
    }

    class GraphicsContextVisualizator : IVisualizator
    {
        public void DrawBorder(IMatrix matrix)
        {
            Console.WriteLine("GraphicsContextVisualizator: Draw Border");
        }

        public void DrawCellVal(IMatrix matrix, int i, int j)
        {
            Console.WriteLine("GraphicsContextVisualizator: Draw Cell Val i:" + i + ", j:" + j);
        }
    }
	
    class XSMLVisualizator : IVisualizator
    {
		char border = ' ';
		
        public void DrawBorder(IMatrix matrix)
        {
			border = '|';
			File.WriteAllText("visual.txt", "");
        }

        public void DrawCellVal(IMatrix matrix, int i, int j)
        {
			string str = "";
			
			if (j == 0)
				str += border.ToString() + "	";
			
			if (i == -1)
				str += "_	";
			else
				str += matrix.GetVal(i,j).ToString() + "	";
			
			if (j == (matrix.GetColumnSize() - 1))
				str += border.ToString() + "\n";
			
			File.AppendAllText("visual.txt", str);
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
            //matrix.SetVisualizator(new XSMLVisualizator());
            matrix.VisualizationMatrix(new ConsoleVisualizator());

            Console.WriteLine();
        }

        /* Configurator Code End */

        static void Main(string[] args)
        {
            Console.WriteLine("Client start working...");

            /* Client Code Start */

            IMatrix normalMatrix = new NormalMatrix();
            MatrixInitializer.InitMatrix(normalMatrix, 7, 10);
            //PrintMatrixStatistic(normalMatrix);
            PrintMatrix(normalMatrix);

            IMatrix sparseMatrix = new SparseMatrix();
            MatrixInitializer.InitMatrix(sparseMatrix, 7, 10);
            //PrintMatrixStatistic(sparseMatrix);
            PrintMatrix(sparseMatrix);

            /* Client Code End */
        }
    }
}
