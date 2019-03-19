using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Pattern_lab.Matrix;
using Pattern_lab.MatrixFunction;
using Pattern_lab.Visualizator;

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

        private static void PrintMatrix(IMatrix matrix)
        {
            //matrix.SetVisualizator(new XSMLVisualizator());
            matrix.VisualizationMatrix(new ConsoleVisualizator());
            matrix.VisualizationMatrix(new XSMLVisualizator());

            Console.WriteLine();
        }

        /* Configurator Code End */

        static void Main(string[] args)
        {
            Console.WriteLine("Client start working... \n");

            /* Client Code Start */

            IMatrix normalMatrix = new NormalMatrix();
            MatrixInitializer.InitMatrix(normalMatrix, 7, 10);
            PrintMatrixStatistic(normalMatrix);
            PrintMatrix(normalMatrix);

            IMatrix sparseMatrix = new SparseMatrix();
            MatrixInitializer.InitMatrix(sparseMatrix, 7, 10);
            PrintMatrixStatistic(sparseMatrix);
            PrintMatrix(sparseMatrix);

            // LAB 3
            //RenumberDecorator tempMat = new RenumberDecorator(normalMatrix);
            // Как создать IMatrix с новыми методами?
            //tempMat.RenumberRow(0, 2);

            /* Client Code End */
        }
    }
}
