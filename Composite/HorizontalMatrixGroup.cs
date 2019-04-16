using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternLab.Matrix;
using PatternLab.Visualizator;

namespace PatternLab.Composite
{
    class HorizontalMatrixGroup : IMatrix
    {
        private List<IMatrix> matrixList = new List<IMatrix>();

        // Новый функционал
        public void AddMatrix(IMatrix matrix)
        {
            matrixList.Add(matrix);
        }

        // Поддержка интерфейса IMatrix
		//SomeFunction func;
		
        public void EnumerationElements(SomeFunction func)
        {
			//this.func = func;
			/*foreach (var matrix in matrixList)
                matrix.EnumerationElements(funcDecor);*/
			
			for (int i = 0; i < GetRowSize(); i++)
			{
				for (int j = 0; j < GetColumnSize(); j++)
				{
					func(this, i, j);
				}
			}
        }

        /*void funcDecor(IMatrix matrix, int i, int j)
        {
            func(matrix, i, j); 
        }*/

        public int GetColumnSize()
        {
            int sum = 0;

            foreach (var matrix in matrixList)
            {
                sum += matrix.GetColumnSize();
            }

            return sum;
        }

        public int GetRowSize()
        {
            int max = 0;

            foreach (var matrix in matrixList)
            {
                if (matrix.GetRowSize() > max)
                {
                    max = matrix.GetRowSize();
                }
            }

            return max;
        }

        public int GetVal(int indexI, int indexJ)
        {
            foreach (var matrix in matrixList)
            {
                if (matrix.GetColumnSize() > indexJ)
                {
                    if (indexI < matrix.GetRowSize())
                    {
                        return matrix.GetVal(indexI, indexJ);
                    }
                    else if (indexI < GetRowSize())
                    {
                        return 0;
                    }
                }
                else
                {
                    indexJ -= matrix.GetColumnSize();
                }
            }

            throw new IndexOutOfRangeException();
        }

        public void SetVal(int indexI, int indexJ, int val)
        {
            foreach (var matrix in matrixList)
            {
                if (matrix.GetColumnSize() > indexJ)
                {
                    if (indexI < matrix.GetRowSize())
                    {
                        matrix.SetVal(indexI, indexJ, val);
                    }
                    else if (indexJ < GetRowSize())
                    {
                        throw new NullReferenceException();
                    }
                }
                else
                {
                    indexJ -= matrix.GetColumnSize();
                }
            }

            throw new IndexOutOfRangeException();
        }
        
        public void VisualizationMatrix(IVisualizator _visualizator)
        {
            Console.WriteLine("Horizontal Matrix Group");
            _visualizator.DrawBorder(this);
            EnumerationElements(_visualizator.DrawCellVal);
        }

        public bool IsComposite()
        {
            return true;
        }

        public string GetValToStr(int indexI, int indexJ)
        {
            foreach (var matrix in matrixList)
            {
                if (matrix.GetColumnSize() > indexJ)
                {
                    if (indexI < matrix.GetRowSize())
                    {
                        return matrix.GetValToStr(indexI, indexJ);
                    }
                    else if (indexI < GetRowSize())
                    {
                        return " ";
                    }
                }
                else
                {
                    indexJ -= matrix.GetColumnSize();
                }
            }

            throw new IndexOutOfRangeException();
        }

        public void ClearMatrix()
        {
            throw new NotImplementedException();
        }
    }
}
