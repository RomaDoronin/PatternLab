using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternLab.Matrix;

namespace PatternLab.Visualizator
{
    class GraphicsContextVisualizator : IVisualizator
    {
        public void DrawBorder(IMatrix matrix)
        {
            Console.WriteLine("GraphicsContextVisualizator: Draw Border");
        }

        public void DrawCellVal(IMatrix matrix, int i, int j)
        {
            Console.WriteLine("GraphicsContextVisualizator: Draw Cell Val i:" + i + ", j:" + j);
        }
    }
}
