using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternLab.Matrix;

namespace PatternLab.IncrementalModel
{
    class SetValInMatrix : ACommand
    {
        private List<IMatrix> _matrixList;
        private int _matrixNum;
        private int _indexI;
        private int _indexJ;
        private int _settingVal;

        public SetValInMatrix(List<IMatrix> matrixList, int matrixNum, int indexI, int indexJ, int settingVal)
        {
            _matrixList = matrixList;
            _matrixNum = matrixNum;
            _indexI = indexI;
            _indexJ = indexJ;
            _settingVal = settingVal;
        }

        protected override void DoExecute()
        {
            _matrixList[_matrixNum].SetVal(_indexI, _indexJ, _settingVal);
        }
    }
}
