﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pattern_lab.Vectror;
using Pattern_lab.Visualizator;

namespace Pattern_lab.Matrix
{
    abstract class AMatrix : IMatrix
    {
        private IVector valMatrix;
        private int columnSize;
        private int rowSize;

        protected abstract IVector Create();

        public AMatrix()
        {
            valMatrix = Create();
            columnSize = 0;
            rowSize = 0;
        }

        public void SetVal(int indexI, int indexJ, int val)
        {
            rowSize = Math.Max(indexI + 1, rowSize);
            columnSize = Math.Max(indexI + 1, columnSize);

            valMatrix.SetVal(indexI * GetColumnSize() + indexJ, val);
        }

        public int GetVal(int indexI, int indexJ)
        {
            return valMatrix.GetVal(indexI * GetColumnSize() + indexJ);
        }

        public int GetColumnSize()
        {
            return columnSize;
        }

        public int GetRowSize()
        {
            return rowSize;
        }

        // LAB 2
        private IVisualizator visualizator;

        /*public void SetVisualizator(IVisualizator _visualizator)
        {
            visualizator = _visualizator;
        }*/

        public abstract void VisualizationMatrix(IVisualizator _visualizator);

        /*protected void DrawBorder()
        {
            visualizator.DrawBorder(this);
        }

        protected void DrawCellVal(int i, int j)
        {
            visualizator.DrawCellVal(this, i, j);
        }*/
    }
}
