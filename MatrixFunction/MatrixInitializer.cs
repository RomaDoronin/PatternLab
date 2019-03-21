using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternLab.Matrix;

namespace PatternLab.MatrixFunction
{
    enum LAB_MODE
    {
        LAB1,
        LAB2,
        LAB3,
        LAB4,
    }

    class MatrixInitializer
    {
        public static void InitMatrix(IMatrix matrix, int notNullNumber, int maxNumber, int sizeI, int sizeJ, LAB_MODE labMode = LAB_MODE.LAB1, int matrixNum = 0)
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            /* Set matrix size for rand value */
            matrix.SetVal(/*rand.Next(2, 5), rand.Next(2, 5),*/ sizeI - 1, sizeJ - 1, 0);

            int numOfNumbers = matrix.GetRowSize() * matrix.GetColumnSize();

            for (int i = 0; i < matrix.GetRowSize(); i++)
            {
                for (int j = 0; j < matrix.GetColumnSize(); j++)
                {
                    int val;
                    if (labMode == LAB_MODE.LAB4)
                    {
                        val = matrixNum;
                    }
                    else
                    {
                        if (rand.Next(1, numOfNumbers) <= notNullNumber)
                        {
                            val = rand.Next(1, maxNumber + 1);
                            notNullNumber--;
                        }
                        else
                        {
                            val = 0;
                        }
                    }
                    numOfNumbers--;

                    matrix.SetVal(i, j, val);
                }
            }
        }
    }
}
