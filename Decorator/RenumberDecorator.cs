using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pattern_lab.Matrix;
using Pattern_lab.Visualizator;

namespace Pattern_lab.Decorator
{
    class RenumberDecorator : BaseDecorator
    {
        private Dictionary<int, int> renumColumnIndex;
        private Dictionary<int, int> renumRowIndex;

        public RenumberDecorator(IMatrix matrix) : base(matrix)
        {
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

        // Декорированные методы
        public override void SetVal(int indexI, int indexJ, int val)
        {
            CheckRowColumnNum(ref indexI, ref indexJ);
            _matrix.SetVal(indexI, indexJ, val); 
        }

        public override int GetVal(int indexI, int indexJ)
        {
            CheckRowColumnNum(ref indexI, ref indexJ);
            return _matrix.GetVal(indexI, indexJ);
        }

        // TODO: Наверное можно как-то правильно сделать вывод. Сейчас если делать правильно, то программа использует не наши методы. Скорей всего проблема в несовместимости МОСТА и ДЕКОРАТОРА
        public override void VisualizationMatrix(IVisualizator _visualizator)
        {
            Console.WriteLine("Visualization Renumber Matrix");
            _visualizator.DrawBorder(this);
            for (int i = 0; i < GetRowSize(); i++)
            {
                for (int j = 0; j < GetColumnSize(); j++)
                {
                    _visualizator.DrawCellVal(this, i, j);
                }
            }
        }
    }
}
