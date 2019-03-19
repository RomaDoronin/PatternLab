using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pattern_lab.Matrix;

namespace Pattern_lab.Visualizator
{
    interface IVisualizator
    {
        void DrawBorder(IMatrix matrix);
        void DrawCellVal(IMatrix matrix, int i, int j);
    }
}
