using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pattern_lab.Matrix;
using Pattern_lab.Visualizator;

namespace Pattern_lab.Decorator
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

        private void CheckRowColumnNum(ref int indexI, ref int indexJ)
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

        public IMatrix GetBase()
        {
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
            CheckRowColumnNum(ref indexI, ref indexJ);
            _matrix.SetVal(indexI, indexJ, val); 
        }

        public int GetVal(int indexI, int indexJ)
        {
            CheckRowColumnNum(ref indexI, ref indexJ);
            return _matrix.GetVal(indexI, indexJ);
        }
        
        public void VisualizationMatrix(IVisualizator _visualizator)
        {
            Console.WriteLine("Visualization Renumber Matrix");
            _visualizator.DrawBorder(this);
            EnumerationElements(this, _visualizator.DrawCellVal);
        }

        public void EnumerationElements(IMatrix matrix, SomeFunction func)
        {
            _matrix.EnumerationElements(matrix, func);
        }
    }
}
