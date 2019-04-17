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
            if (columnSize != 0 && rowSize != 0)
            {
                _visualizator.DrawBorder(this);
                EnumerationElements(_visualizator.DrawCellVal);
            }
        }

        // LAB 3
        public abstract void EnumerationElements(SomeFunction func);

        public bool IsComposite()
        {
            return false;
        }

        // LAB 4
        public abstract string GetValToStr(int indexI, int indexJ);

        // LAB 5
        public abstract IMatrix CopyMatrix();

        public void ClearMatrix()
        {
            valMatrix.ClearVector();
            columnSize = 0;
            rowSize = 0;
        }

        public IMatrix GetBase(out bool isDecorator)
        {
            isDecorator = false;
            return this;
        }
    }
}
