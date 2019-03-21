using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pattern_lab.Visualizator;

namespace Pattern_lab.Matrix
{
    delegate void SomeFunction(IMatrix matrix, int i, int j);

    interface IMatrix
    {
        void SetVal(int indexI, int indexJ, int val);
        int GetVal(int indexI, int indexJ);
        int GetColumnSize();
        int GetRowSize();

        // LAB 2
        // Сильный мост
        /* void SetVisualizator(IVisualizator _visualizator); */
        // Слабый мост
        void VisualizationMatrix(IVisualizator _visualizator);

        // LAB 3
        // Перебор элементов
        void EnumerationElements(IMatrix matrix, SomeFunction func);
    }
}
