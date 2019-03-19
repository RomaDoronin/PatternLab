using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pattern_lab.Vectror;
using Pattern_lab.Visualizator;

namespace Pattern_lab.Matrix
{
    class SparseMatrix : AMatrix
    {
        protected override IVector Create()
        {
            return new SparseVector();
        }

        public override void VisualizationMatrix(IVisualizator _visualizator)
        {
            Console.WriteLine("Visualization Sparse Matrix");
            _visualizator.DrawBorder(this);
            for (int i = 0; i < GetRowSize(); i++)
                for (int j = 0; j < GetColumnSize(); j++)
                {
                    if (GetVal(i, j) != 0)
                        _visualizator.DrawCellVal(this, i, j);
                    else
                        _visualizator.DrawCellVal(this, -1, j);
                }
        }
    }
}
