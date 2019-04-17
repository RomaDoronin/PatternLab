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
        SomeFunction func;

        public void EnumerationElements(SomeFunction func)
        {
            //this.func = func;
            //_matrix.EnumerationElements(funcDecor);
            
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
            func(this, i, j); 
        }*/

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
            EnumerationElements(_visualizator.DrawCellVal);
        }

        public string GetValToStr(int indexI, int indexJ)
        {
            return _matrix.GetValToStr(indexJ, indexI);
        }
        
        public IMatrix GetBase(out bool isDecorator)
        {
            isDecorator = true;
            return _matrix;
        }

        public void ClearMatrix()
        {
            _matrix.ClearMatrix();
        }
    }
}
