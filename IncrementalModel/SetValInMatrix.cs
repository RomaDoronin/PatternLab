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
        private IMatrix _matrix;
        private int _indexI;
        private int _indexJ;
        private int _settingVal;

        public SetValInMatrix(IMatrix matrix, int indexI, int indexJ, int settingVal)
        {
            _matrix = matrix;
            _indexI = indexI;
            _indexJ = indexJ;
            _settingVal = settingVal;
        }

        protected override void DoExecute()
        {
            _matrix.SetVal(_indexI, _indexJ, _settingVal);
        }

        public override ICommand CopyCommand()
        {
            return new SetValInMatrix(_matrix.CopyMatrix(), _indexI, _indexJ, _settingVal);
        }
    }
}
