using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternLab.Vectror;
using PatternLab.Visualizator;

namespace PatternLab.Matrix
{
    class SparseMatrix : AMatrix
    {
        protected override IVector Create()
        {
            return new SparseVector();
        }

        // LAB 3
        public override string GetValToStr(int indexI, int indexJ)
        {
            int val = GetVal(indexI, indexJ);
            if (val != 0)
                return GetVal(indexI, indexJ).ToString();
            else
                return "_";
        }
    }
}
