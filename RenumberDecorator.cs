using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_lab
{
    class RenumberDecorator : IMatrix
    {
        private IMatrix matrix;
        private Dictionary<int, int> renumColumnIndex;
        private Dictionary<int, int> renumRowIndex;

        public RenumberDecorator(IMatrix _matrix)
        {
            matrix = _matrix;
            renumColumnIndex = new Dictionary<int, int>();
            renumRowIndex = new Dictionary<int, int>();
        }

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

        // Декорированные методы
        public void SetVal(int indexI, int indexJ, int val)
        {
            CheckRowColumnNum(ref indexI, ref indexJ);

            matrix.SetVal(indexI, indexJ, val);
        }

        public int GetVal(int indexI, int indexJ)
        {
            CheckRowColumnNum(ref indexI, ref indexJ);

            return matrix.GetVal(indexI, indexJ);
        }

        public int GetColumnSize()
        {
            return matrix.GetColumnSize();
        }

        public int GetRowSize()
        {
            return matrix.GetRowSize();
        }

        public void SetVisualizator(IVisualizator _visualizator)
        {
            matrix.SetVisualizator(_visualizator);
        }

        public void VisualizationMatrix()
        {
            matrix.VisualizationMatrix();
        }

    }
}
