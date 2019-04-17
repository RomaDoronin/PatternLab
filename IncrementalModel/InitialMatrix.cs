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
        private List<IMatrix> _matrixList;
        private int _matrixNum;
        private int _matrixSize = 0;

        public InitialMatrix(ref List<IMatrix> matrixList, int matrixNum, int matrixSize)
        {
            _matrixList = matrixList;
            _matrixNum = matrixNum;
            _matrixSize = matrixSize;
        }

        protected override void DoExecute()
        {
            for (int i = 0; i < _matrixSize; i++)
            {
                for (int j = 0; j < _matrixSize; j++)
                {
                    _matrixList[_matrixNum].SetVal(i, j, i + j);
                }
            }
        }
    }
}
