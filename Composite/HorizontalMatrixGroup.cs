﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternLab.Matrix;
using PatternLab.Visualizator;

namespace PatternLab.Composite
{
    class HorizontalMatrixGroup : IMatrix
    {
        private List<IMatrix> matrixList = new List<IMatrix>();

        // Новый функционал
        public void AddMatrix(IMatrix matrix)
        {
            matrixList.Add(matrix);
        }

        // Поддержка интерфейса IMatrix
        public void EnumerationElements(IMatrix matrix, SomeFunction func)
        {
            matrixList[0].EnumerationElements(matrix, func);
            //foreach (var interMatrix in matrixList)
            //{
            //    interMatrix.EnumerationElements(matrix, func);
            //}
        }

        public int GetColumnSize()
        {
            int sum = 0;

            foreach (var matrix in matrixList)
            {
                sum += matrix.GetColumnSize();
            }

            return sum;
        }

        public int GetRowSize()
        {
            int max = 0;

            foreach (var matrix in matrixList)
            {
                if (matrix.GetRowSize() > max)
                {
                    max = matrix.GetRowSize();
                }
            }

            return max;
        }

        public int GetVal(int indexI, int indexJ)
        {
            foreach (var matrix in matrixList)
            {
                if (matrix.GetColumnSize() > indexJ)
                {
                    if (indexI < matrix.GetRowSize())
                    {
                        return matrix.GetVal(indexI, indexJ);
                    }
                    else if (indexJ < GetRowSize())
                    {
                        return 0;
                    }
                }
                else
                {
                    indexJ -= matrix.GetColumnSize();
                }
            }

            throw new IndexOutOfRangeException();
        }

        public void SetVal(int indexI, int indexJ, int val)
        {
            foreach (var matrix in matrixList)
            {
                if (matrix.GetColumnSize() > indexJ)
                {
                    if (indexI < matrix.GetRowSize())
                    {
                        matrix.SetVal(indexI, indexJ, val);
                    }
                    else if (indexJ < GetRowSize())
                    {
                        throw new NullReferenceException();
                    }
                }
                else
                {
                    indexJ -= matrix.GetColumnSize();
                }
            }

            throw new IndexOutOfRangeException();
        }

        // TODO: Чтобы сделать красивый вывод необходимо сделать метод: вывод отдельной строки
        public void VisualizationMatrix(IVisualizator _visualizator)
        {
            Console.WriteLine("Horizontal Matrix Group");
            _visualizator.DrawBorder(this);
            EnumerationElements(this, _visualizator.DrawCellVal);

            //foreach (var matrix in matrixList)
            //{
            //    matrix.VisualizationMatrix(_visualizator);
            //}
        }

        public bool IsComposite()
        {
            return true;
        }
    }
}
