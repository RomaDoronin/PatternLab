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
        public override void EnumerationElements(IMatrix matrix, SomeFunction func)
        {
            for (int i = 0; i < matrix.GetRowSize(); i++)
            {
                for (int j = 0; j < matrix.GetColumnSize(); j++)
                {
                    if (matrix.GetVal(i, j) != 0)
                        func(matrix, i, j);
                    else
                        func(matrix, -1, j);
                }
            }
        }
    }
}
