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
		private int count = 0;

        public void DrawBorder(IMatrix matrix)
        {
            Console.WriteLine("ConsoleVisualizator: Draw Border");
            border = '|';
        }

        public void DrawCellVal(IMatrix matrix, int i, int j)
        {
            if (count % matrix.GetColumnSize() == 0)
                Console.Write(border + "	");

            Console.Write(matrix.GetValToStr(i, j) + "	");

            if (count % matrix.GetColumnSize() == (matrix.GetColumnSize() - 1))
                Console.WriteLine(border);
			
			count++;
        }
    }
}
