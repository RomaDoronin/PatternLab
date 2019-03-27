//#define LAB
#if (LAB)
#define LAB3
#endif
#define LAB4_VAR1
//#define LAB4_VAR2

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

        private static void GroupMatrix(ref IMatrix matrix, List<IMatrix> matrixList)
        {
            HorizontalMatrixGroup groupMatrix = new HorizontalMatrixGroup();
            
            foreach (var iterMatrix in matrixList)
            {
                groupMatrix.AddMatrix(iterMatrix);
            }

            matrix = groupMatrix;
        }

        /* Configurator Code End */

        static void Main(string[] args)
        {
            Console.WriteLine("Client start working... \n");

            /* Client Code Start */

#if (LAB)
            //IMatrix matrix = new NormalMatrix();
            IMatrix matrix = new SparseMatrix();

            MatrixInitializer.InitMatrix(matrix, 7, 10, 4, 4/*, LAB_MODE.LAB4, 1*/);
            PrintMatrixStatistic(matrix);
            PrintMatrix(matrix);

            // Транспонирование ТЕСТ
            matrix = new TransposingDecorator(matrix);
            PrintMatrix(matrix);
#endif
            // ------------------------------------------------------------------- LAB 3
#if (LAB3)
            Renumber(ref matrix);
            PrintMatrix(matrix);

            Renumber(ref matrix);
            PrintMatrix(matrix);

            Recover(ref matrix);
            PrintMatrix(matrix);
#endif
            // ------------------------------------------------------------------- LAB 4

#if (LAB4_VAR1)
            IMatrix groupMatrix = new HorizontalMatrixGroup();

            IMatrix matrix1 = new NormalMatrix();
            MatrixInitializer.InitMatrix(matrix1, 2, 10, 2, 2);
            IMatrix matrix2 = new SparseMatrix();
            MatrixInitializer.InitMatrix(matrix2, 4, 10, 3, 3);
            IMatrix matrix3 = new NormalMatrix();
            MatrixInitializer.InitMatrix(matrix3, 2, 10, 5, 1);
            IMatrix matrix4 = new SparseMatrix();
            MatrixInitializer.InitMatrix(matrix4, 1, 10, 1, 1);
            List<IMatrix> matrixList = new List<IMatrix>() {
                matrix1, matrix2, matrix3, matrix4
            };
            GroupMatrix(ref groupMatrix, matrixList);
            PrintMatrix(groupMatrix);

            groupMatrix = new TransposingDecorator(groupMatrix);
            PrintMatrix(groupMatrix);

#elif (LAB4_VAR2)
            // Клиенская часть LAB 4
            IMatrix groupMatrix1 = new HorizontalMatrixGroup();
            IMatrix matrix1 = new SparseMatrix();
            MatrixInitializer.InitMatrix(matrix1, 7, 10, 2, 2, LAB_MODE.LAB4, 1);
            IMatrix matrix2 = new NormalMatrix();
            MatrixInitializer.InitMatrix(matrix2, 7, 10, 4, 3, LAB_MODE.LAB4, 2);
            IMatrix matrix3 = new SparseMatrix();
            MatrixInitializer.InitMatrix(matrix3, 7, 10, 1, 3, LAB_MODE.LAB4, 3);
            
            List<IMatrix> matrixList1 = new List<IMatrix>() { matrix1, matrix2, matrix3 };
            GroupMatrix(ref groupMatrix1, matrixList1);
            PrintMatrix(groupMatrix1);
            groupMatrix1 = new TransposingDecorator(groupMatrix1);
            PrintMatrix(groupMatrix1);

            IMatrix groupMatrix2 = new HorizontalMatrixGroup();
            IMatrix matrix4 = new NormalMatrix();
            MatrixInitializer.InitMatrix(matrix4, 7, 10, 2, 4, LAB_MODE.LAB4, 4);
            IMatrix matrix5 = new SparseMatrix();
            MatrixInitializer.InitMatrix(matrix5, 7, 10, 2, 3, LAB_MODE.LAB4, 5);
            List<IMatrix> matrixList2 = new List<IMatrix>() { matrix4, matrix5 };
            GroupMatrix(ref groupMatrix2, matrixList2);
            groupMatrix2 = new TransposingDecorator(groupMatrix2);

            PrintMatrix(groupMatrix2);

            IMatrix groupMatrix3 = new HorizontalMatrixGroup();
            IMatrix matrix6 = new NormalMatrix();
            MatrixInitializer.InitMatrix(matrix6, 7, 10, 1, 1, LAB_MODE.LAB4, 6);
            List<IMatrix> matrixList3 = new List<IMatrix>() { matrix6 };
            GroupMatrix(ref groupMatrix3, matrixList3);

            PrintMatrix(groupMatrix3);

            IMatrix groupsMatrix = new HorizontalMatrixGroup();
            List<IMatrix> groupList = new List<IMatrix>() { groupMatrix1, groupMatrix2, groupMatrix3 };
            GroupMatrix(ref groupsMatrix, groupList);
            groupsMatrix = new TransposingDecorator(groupsMatrix);

            PrintMatrix(groupsMatrix);

#endif

            /* Client Code End */
        }
    }
}
