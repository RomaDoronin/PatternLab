using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternLab.Matrix;
using PatternLab.Decorator;
using PatternLab.Visualizator;

namespace PatternLab.IncrementalModel
{
    class DecorMatrixTrans : ACommand
    {
        private List<IMatrix> _matrixList;
        private int _matrixNum;

        public DecorMatrixTrans(ref List<IMatrix> matrixList, int matrixNum)
        {
            _matrixList = matrixList;
            _matrixNum = matrixNum;
        }

        private IMatrix _matrix;
        public DecorMatrixTrans(ref IMatrix matrix)
        {
            _matrix = matrix;
        }

        protected override void DoExecute()
        {
            //IMatrix matrix = new TransposingDecorator(_matrix);
            _matrixList[_matrixNum] = new TransposingDecorator(_matrixList[_matrixNum]);
        }
    }
}
