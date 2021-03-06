﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternLab.Matrix;
using PatternLab.Visualizator;

namespace PatternLab.Decorator
{
    class RenumberDecorator : IMatrix
    {
        private IMatrix _matrix;
        private Dictionary<int, int> renumColumnIndex;
        private Dictionary<int, int> renumRowIndex;

        public RenumberDecorator(IMatrix matrix)
        {
            _matrix = matrix;
            renumColumnIndex = new Dictionary<int, int>();
            renumRowIndex = new Dictionary<int, int>();
        }

        // Дополнительная функциональность
        public void RenumberRow(int rowIndex1, int rowIndex2)
        {
            renumRowIndex[rowIndex1] = rowIndex2;
            renumRowIndex[rowIndex2] = rowIndex1;
        }

        public void RenumberColumn(int columnIndex1, int columnIndex2)
        {
            renumColumnIndex[columnIndex1] = columnIndex2;
            renumColumnIndex[columnIndex2] = columnIndex1;
        }

        private void CheckRowColumnNum(int indexI, int indexJ)
        {
            if (renumRowIndex.ContainsKey(indexI))
                indexI = renumRowIndex[indexI];

            if (renumColumnIndex.ContainsKey(indexJ))
                indexJ = renumColumnIndex[indexJ];
        }

        public void SetMatrix(IMatrix matrix)
        {
            _matrix = matrix;
        }

        public IMatrix GetBase(out bool isDecorator)
        {
            isDecorator = true;
            return _matrix;
        }

        // Декорированные методы
        public virtual int GetColumnSize()
        {
            return _matrix.GetColumnSize();
        }

        public virtual int GetRowSize()
        {
            return _matrix.GetRowSize();
        }

        public void SetVal(int indexI, int indexJ, int val)
        {
            CheckRowColumnNum(indexI, indexJ);
            _matrix.SetVal(indexI, indexJ, val); 
        }

        public int GetVal(int indexI, int indexJ)
        {
            CheckRowColumnNum(indexI, indexJ);
            return _matrix.GetVal(indexI, indexJ);
        }
        
        public void VisualizationMatrix(IVisualizator _visualizator)
        {
            Console.WriteLine("Visualization Renumber Matrix");
            _visualizator.DrawBorder(this);
            EnumerationElements(_visualizator.DrawCellVal);
        }
		
		SomeFunction func;

        public void EnumerationElements(SomeFunction func)
        {
			this.func = func;
            _matrix.EnumerationElements(funcDecor);
        }

        public bool IsComposite()
        {
            return false;
        }

        public string GetValToStr(int indexI, int indexJ)
        {
            return GetVal(indexI, indexJ).ToString();
        }

        void funcDecor(IMatrix matrix, int i, int j)
        {
			CheckRowColumnNum(i, j);
            func(matrix, i, j); 
        }

        public void ClearMatrix()
        {
            throw new NotImplementedException();
        }
    }
}
