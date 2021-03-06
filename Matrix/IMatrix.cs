﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternLab.Visualizator;

namespace PatternLab.Matrix
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
        void EnumerationElements(SomeFunction func);

        // LAB 4
        bool IsComposite();
        string GetValToStr(int indexI, int indexJ);

        // LAB 5
        void ClearMatrix();
        IMatrix GetBase(out bool isDecorator);
    }
}
