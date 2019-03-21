using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pattern_lab.Vectror;
using Pattern_lab.Visualizator;

namespace Pattern_lab.Matrix
{
    class NormalMatrix : AMatrix
    {
        protected override IVector Create()
        {
            return new NormalVector();
        }

        // LAB 3
        public override void EnumerationElements(IMatrix matrix, SomeFunction func)
        {
            for (int i = 0; i < GetRowSize(); i++)
            {
                for (int j = 0; j < GetColumnSize(); j++)
                {
                    func(matrix, i, j);
                }
            }
        }
    }
}
