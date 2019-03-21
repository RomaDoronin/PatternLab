using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PatternLab.Matrix;
using PatternLab.MatrixFunction;
using PatternLab.Visualizator;
using PatternLab.Decorator;
using PatternLab.Composite;

namespace PatternLab
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

        private static void GroupMatrix(ref IMatrix matrix)
        {
            HorizontalMatrixGroup groupMatrix = new HorizontalMatrixGroup();

            IMatrix matrix1 = new NormalMatrix();
            MatrixInitializer.InitMatrix(matrix1, 7, 10, 2, 2, LAB_MODE.LAB4, 1);
            IMatrix matrix2 = new NormalMatrix();
            MatrixInitializer.InitMatrix(matrix2, 7, 10, 3, 3, LAB_MODE.LAB4, 2);
            IMatrix matrix3 = new NormalMatrix();
            MatrixInitializer.InitMatrix(matrix3, 7, 10, 5, 1, LAB_MODE.LAB4, 3);
            IMatrix matrix4 = new NormalMatrix();
            MatrixInitializer.InitMatrix(matrix4, 7, 10, 1, 1, LAB_MODE.LAB4, 4);

            groupMatrix.AddMatrix(matrix1);
            groupMatrix.AddMatrix(matrix2);
            groupMatrix.AddMatrix(matrix3);
            groupMatrix.AddMatrix(matrix4);
            PrintMatrix(groupMatrix);

            matrix = groupMatrix;
        }

        /* Configurator Code End */

        static void Main(string[] args)
        {
            Console.WriteLine("Client start working... \n");

            /* Client Code Start */

            //IMatrix matrix = new NormalMatrix();
            //IMatrix matrix = new SparseMatrix();

            //MatrixInitializer.InitMatrix(matrix, 7, 10, 4, 4/*, LAB_MODE.LAB4, 1*/);
            //PrintMatrixStatistic(matrix);
            //PrintMatrix(matrix);

            // Транспонирование ТЕСТ
            /*matrix = new TransposingDecorator(matrix);
            PrintMatrix(matrix);*/


            // ------------------------------------------------------------------- LAB 3
            /*Renumber(ref matrix);
            PrintMatrix(matrix);

            Renumber(ref matrix);
            PrintMatrix(matrix);

            Recover(ref matrix);
            PrintMatrix(matrix);*/

            // ------------------------------------------------------------------- LAB 4

            IMatrix groupMatrix = new HorizontalMatrixGroup();
            GroupMatrix(ref groupMatrix);

            groupMatrix = new TransposingDecorator(groupMatrix);
            PrintMatrix(groupMatrix);

            // TODO: Доработать клиенскую часть

            /* Client Code End */
        }
    }
}
