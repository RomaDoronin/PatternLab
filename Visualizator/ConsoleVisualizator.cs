using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternLab.Matrix;

namespace PatternLab.Visualizator
{
    class ConsoleVisualizator : IVisualizator
    {
        private char border = ' ';

        public void DrawBorder(IMatrix matrix)
        {
            Console.WriteLine("ConsoleVisualizator: Draw Border");
            border = '|';
        }

        public void DrawCellVal(IMatrix matrix, int i, int j)
        {
            if (j == 0)
                Console.Write(border + "	");

            Console.Write(matrix.GetValToStr(i, j) + "	");

            if (j == (matrix.GetColumnSize() - 1))
                Console.WriteLine(border);
        }
    }
}
