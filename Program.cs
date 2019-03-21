using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Pattern_lab.Matrix;
using Pattern_lab.MatrixFunction;
using Pattern_lab.Visualizator;
using Pattern_lab.Decorator;

namespace Pattern_lab
{
    class Program
    {
        /* Configurator Code Start */

        private static void PrintMatrixStatistic(IMatrix matrix)
        {
            MatrixStatistic matrixStatistic = new MatrixStatistic(matrix);

            Console.WriteLine("Sum elements                : " + matrixStatistic.GetSumValues());
            Console.WriteLine("Average of elements         : " + matrixStatistic.GetAverageValue());
            Console.WriteLine("Max element                 : " + matrixStatistic.GetMaxValue());
            Console.WriteLine("Number of not null elements : " + matrixStatistic.GetNotNullValuesNumber() + "\n");
        }

        // ----------------------------------------------------------------------- LAB 2
        private static void PrintMatrix(IMatrix matrix)
        {
            matrix.VisualizationMatrix(new ConsoleVisualizator());
            //matrix.VisualizationMatrix(new XSMLVisualizator());
            Console.WriteLine();
        }

        // ----------------------------------------------------------------------- LAB 3
        private static void Renumber(ref IMatrix matrix)
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            RenumberDecorator decoratorMatrix = new RenumberDecorator(matrix);

            decoratorMatrix.RenumberRow(rand.Next(matrix.GetRowSize()), rand.Next(matrix.GetRowSize()));
            decoratorMatrix.RenumberColumn(rand.Next(matrix.GetColumnSize()), rand.Next(matrix.GetColumnSize()));

            matrix = decoratorMatrix;
        }

        private static void Recover(ref IMatrix matrix)
        {
            try
            {
                while (true)
                {
                    RenumberDecorator decoratorMatrix = (RenumberDecorator)matrix;
                    matrix = decoratorMatrix.GetBase();
                }
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("Recover is ready");
            }
        }

        /* Configurator Code End */

        static void Main(string[] args)
        {
            Console.WriteLine("Client start working... \n");

            /* Client Code Start */

            //IMatrix matrix = new NormalMatrix();
            IMatrix matrix = new SparseMatrix();

            MatrixInitializer.InitMatrix(matrix, 7, 10, 4);
            PrintMatrixStatistic(matrix);
            PrintMatrix(matrix);


            // ------------------------------------------------------------------- LAB 3
            Renumber(ref matrix);
            PrintMatrix(matrix);

            Renumber(ref matrix);
            PrintMatrix(matrix);

            Recover(ref matrix);
            PrintMatrix(matrix);

            /* Client Code End */
        }
    }
}
