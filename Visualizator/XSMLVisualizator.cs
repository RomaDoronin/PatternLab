using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternLab.Matrix;
using System.IO;

namespace PatternLab.Visualizator
{
    class XSMLVisualizator : IVisualizator
    {
        private char border = ' ';

        public void DrawBorder(IMatrix matrix)
        {
            border = '|';
            File.WriteAllText("visual.txt", "");
        }

        public void DrawCellVal(IMatrix matrix, int i, int j)
        {
            string str = "";

            if (j == 0)
                str += border.ToString() + "	";

            if (i == -1)
                str += "_	";
            else
                str += matrix.GetValToStr(i, j) + "	";

            if (j == (matrix.GetColumnSize() - 1))
                str += border.ToString() + "\n";

            File.AppendAllText("visual.txt", str);
        }
    }
}
