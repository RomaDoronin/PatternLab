using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternLab.Matrix;
using PatternLab.Visualizator;

namespace PatternLab.Decorator
{
    class TransposingDecorator : IMatrix
    {
        private IMatrix _matrix;

        public TransposingDecorator(IMatrix matrix)
        {
            _matrix = matrix;
        }

        // Поддержка интерфейса IMatrix
        public void EnumerationElements(IMatrix matrix, SomeFunction func)
        {
            _matrix.EnumerationElements(matrix, func);
        }

        public int GetColumnSize()
        {
            return _matrix.GetRowSize();
        }

        public int GetRowSize()
        {
            return _matrix.GetColumnSize();
        }

        public int GetVal(int indexI, int indexJ)
        {
            return _matrix.GetVal(indexJ, indexI);
        }

        public bool IsComposite()
        {
            return false;
        }

        public void SetVal(int indexI, int indexJ, int val)
        {
            _matrix.SetVal(indexJ, indexI, val);
        }

        public void VisualizationMatrix(IVisualizator _visualizator)
        {
            Console.WriteLine("Visualization Transposing Matrix");
            _visualizator.DrawBorder(this);
            EnumerationElements(this, _visualizator.DrawCellVal);
        }
    }
}
