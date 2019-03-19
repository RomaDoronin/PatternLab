using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pattern_lab.Matrix;
using Pattern_lab.Visualizator;

namespace Pattern_lab.Decorator
{
    abstract class BaseDecorator : IMatrix
    {
        protected IMatrix _matrix;

        public BaseDecorator(IMatrix matrix)
        {
            _matrix = matrix;
        }

        public void SetMatrix(IMatrix matrix)
        {
            _matrix = matrix;
        }

        public IMatrix GetBase()
        {
            return _matrix;
        }

        // Декорированные методы
        public virtual int GetColumnSize()
        {
            return _matrix.GetColumnSize();
        }

        public virtual int GetRowSize()
        {
            return _matrix.GetRowSize();
        }

        public virtual int GetVal(int indexI, int indexJ)
        {
            return _matrix.GetVal(indexI, indexJ);
        }

        public virtual void SetVal(int indexI, int indexJ, int val)
        {
            _matrix.SetVal(indexI, indexJ, val);
        }

        public virtual void VisualizationMatrix(IVisualizator _visualizator)
        {
            _matrix.VisualizationMatrix(_visualizator);
        }
    }
}
