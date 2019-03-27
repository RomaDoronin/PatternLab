using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternLab.Vectror;
using PatternLab.Visualizator;

namespace PatternLab.Matrix
{
    class NormalMatrix : AMatrix
    {
        protected override IVector Create()
        {
            return new NormalVector();
        }

        // LAB 3
        public override string GetValToStr(int indexI, int indexJ)
        {
            return GetVal(indexI, indexJ).ToString();
        }

        public override void EnumerationElements(SomeFunction func)
        {
            for (int i = 0; i < GetRowSize(); i++)
            {
                for (int j = 0; j < GetColumnSize(); j++)
                {
                    func(this, i, j);
                }
            }
        }
    }
}
