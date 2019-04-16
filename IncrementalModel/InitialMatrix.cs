using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternLab.Matrix;

namespace PatternLab.IncrementalModel
{
    class InitialMatrix : ACommand
    {
        private IMatrix _matrix = null;
        private int _matrixSize = 0;

        public InitialMatrix(IMatrix matrix, int matrixSize)
        {
            _matrix = matrix;
            _matrixSize = matrixSize;
        }

        protected override void DoExecute()
        {
            if (_matrix == null || _matrixSize == 0)
            {
                throw new NullReferenceException();
            }
            else
            {
                for (int i = 0; i < _matrixSize; i++)
                {
                    for (int j = 0; j < _matrixSize; j++)
                    {
                        _matrix.SetVal(i, j, i + j);
                    }
                }
            }
        }
    }
}
