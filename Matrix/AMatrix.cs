using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternLab.Vectror;
using PatternLab.Visualizator;

namespace PatternLab.Matrix
{
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
            columnSize = Math.Max(indexJ + 1, columnSize);

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
        public void VisualizationMatrix(IVisualizator _visualizator)
        {
            _visualizator.DrawBorder(this);
            EnumerationElements(this, _visualizator.DrawCellVal);
        }

        // LAB 3
        public void EnumerationElements(IMatrix matrix, SomeFunction func)
        {
            for (int i = 0; i < matrix.GetRowSize(); i++)
            {
                for (int j = 0; j < matrix.GetColumnSize(); j++)
                {
                    func(matrix, i, j);
                }
            }
        }

        public bool IsComposite()
        {
            return false;
        }

        // LAB 4
        public abstract string GetValToStr(int indexI, int indexJ);
    }
}
