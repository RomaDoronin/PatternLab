﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternLab.Matrix;

namespace PatternLab.IncrementalModel
{
    class InitApp : ACommand
    {
        private List<IMatrix> _matrixList;

        public InitApp(List<IMatrix> matrixList)
        {
            _matrixList = matrixList;
        }

        protected override void DoExecute()
        {
            for (int i = 0; i < _matrixList.Count; i++)
            {
                _matrixList[i] = new NormalMatrix();
            }
        }
    }
}
