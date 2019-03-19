using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pattern_lab.Matrix;

namespace Pattern_lab.MatrixFunction
{
    class MatrixInitializer
    {
        public static void InitMatrix(IMatrix matrix, int notNullNumber, int maxNumber)
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            /* Set matrix size for rand value */
            matrix.SetVal(rand.Next(2, 5), rand.Next(2, 5), 0);

            int numOfNumbers = matrix.GetRowSize() * matrix.GetColumnSize();

            for (int i = 0; i < matrix.GetRowSize(); i++)
            {
                for (int j = 0; j < matrix.GetColumnSize(); j++)
                {
                    int val;

                    if (rand.Next(1, numOfNumbers) <= notNullNumber)
                    {
                        val = rand.Next(1, maxNumber + 1);
                        notNullNumber--;
                    }
                    else
                    {
                        val = 0;
                    }
                    numOfNumbers--;

                    matrix.SetVal(i, j, val);
                }
            }
        }
    }
}
