//#define LAB
#if (LAB)
#define LAB3
#endif
//#define LAB4_VAR1
//#define LAB4_VAR2
#define LAB5

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
using PatternLab.IncrementalModel;

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
            bool isDecorator = true;
            do
            {
                matrix = matrix.GetBase(out isDecorator);
            } while (isDecorator);
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

        // ----------------------------------------------------------------------- LAB 5
        private static void InitializeApplivation(ref List<IMatrix> matrixList)
        {
            InitApp command = new InitApp(ref matrixList);
            command.Execute();
        }

        private static void InitMatrix(ref List<IMatrix> matrixList, int matrixNum, int matrixSize)
        {
            InitialMatrix command = new InitialMatrix(ref matrixList, matrixNum, matrixSize);
            command.Execute();
        }

        private static void ButtonTRANSMATRIX(ref List<IMatrix> matrixList, int matrixNum)
        {
            Console.WriteLine(" ----------------------------------------------------- Button TRANSMATRIX press");
            DecorMatrixTrans command = new DecorMatrixTrans(ref matrixList, matrixNum);
            command.Execute();
        }

        private static void ButtonCHANGE(List<IMatrix> matrixList, int matrixNum, int indexI, int indexJ, int settingVal)
        {
            Console.WriteLine(" ----------------------------------------------------- Button CHANGE press");
            SetValInMatrix command = new SetValInMatrix(matrixList, matrixNum, indexI, indexJ, settingVal);
            command.Execute();
        }

        private static void ButtonUNDO()
        {
            Console.WriteLine(" ----------------------------------------------------- Button UNDO press");
            CommandManager CM = CommandManager.GetInstance();
            CM.Undo();
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

            IMatrix matrix0 = new NormalMatrix();
            MatrixInitializer.InitMatrix(matrix0, 2, 10, 2, 2);
            IMatrix matrix1 = new SparseMatrix();
            MatrixInitializer.InitMatrix(matrix1, 4, 10, 3, 3);
            IMatrix matrix3 = new NormalMatrix();
            MatrixInitializer.InitMatrix(matrix3, 2, 10, 5, 1);
            IMatrix matrix4 = new SparseMatrix();
            MatrixInitializer.InitMatrix(matrix4, 1, 10, 1, 1);
            List<IMatrix> matrixList = new List<IMatrix>() {
                matrix0, matrix1, matrix3, matrix4
            };
            GroupMatrix(ref groupMatrix, matrixList);
            PrintMatrix(groupMatrix);

            groupMatrix = new TransposingDecorator(groupMatrix);
            PrintMatrix(groupMatrix);

#elif (LAB4_VAR2)
            // Клиенская часть LAB 4
            IMatrix groupmatrix0 = new HorizontalMatrixGroup();
            IMatrix matrix0 = new SparseMatrix();
            MatrixInitializer.InitMatrix(matrix0, 7, 10, 2, 2, LAB_MODE.LAB4, 1);
            IMatrix matrix1 = new NormalMatrix();
            MatrixInitializer.InitMatrix(matrix1, 7, 10, 4, 3, LAB_MODE.LAB4, 2);
            IMatrix matrix3 = new SparseMatrix();
            MatrixInitializer.InitMatrix(matrix3, 7, 10, 1, 3, LAB_MODE.LAB4, 3);
            
            List<IMatrix> matrixList1 = new List<IMatrix>() { matrix0, matrix1, matrix3 };
            GroupMatrix(ref groupmatrix0, matrixList1);
            PrintMatrix(groupmatrix0);
            groupmatrix0 = new TransposingDecorator(groupmatrix0);
            PrintMatrix(groupmatrix0);

            IMatrix groupmatrix1 = new HorizontalMatrixGroup();
            IMatrix matrix4 = new NormalMatrix();
            MatrixInitializer.InitMatrix(matrix4, 7, 10, 2, 4, LAB_MODE.LAB4, 4);
            IMatrix matrix5 = new SparseMatrix();
            MatrixInitializer.InitMatrix(matrix5, 7, 10, 2, 3, LAB_MODE.LAB4, 5);
            List<IMatrix> matrixList2 = new List<IMatrix>() { matrix4, matrix5 };
            GroupMatrix(ref groupmatrix1, matrixList2);
            groupmatrix1 = new TransposingDecorator(groupmatrix1);

            PrintMatrix(groupmatrix1);

            IMatrix groupMatrix3 = new HorizontalMatrixGroup();
            IMatrix matrix6 = new NormalMatrix();
            MatrixInitializer.InitMatrix(matrix6, 7, 10, 1, 1, LAB_MODE.LAB4, 6);
            List<IMatrix> matrixList3 = new List<IMatrix>() { matrix6 };
            GroupMatrix(ref groupMatrix3, matrixList3);

            PrintMatrix(groupMatrix3);

            IMatrix groupsMatrix = new HorizontalMatrixGroup();
            List<IMatrix> groupList = new List<IMatrix>() { groupmatrix0, groupmatrix1, groupMatrix3 };
            GroupMatrix(ref groupsMatrix, groupList);
            groupsMatrix = new TransposingDecorator(groupsMatrix);

            PrintMatrix(groupsMatrix);

#endif
            // ------------------------------------------------------------------- LAB 5

#if (LAB5)
            int commandCount = 0;
            IMatrix matrix0 = new NormalMatrix();
            IMatrix matrix1 = new SparseMatrix();
            List<IMatrix> matrixList = new List<IMatrix> { matrix0, matrix1 };
            InitializeApplivation(ref matrixList); commandCount++;

            // Work with "matrix1"
            InitMatrix(ref matrixList, 0, 4); commandCount++;
            PrintMatrix(matrixList[0]);

            ButtonCHANGE(matrixList, 0, 2, 1, -7); commandCount++;
            PrintMatrix(matrixList[0]);
            
            ButtonCHANGE(matrixList, 0, 3, 0, -6); commandCount++;
            PrintMatrix(matrixList[0]);

            for (int j = 0; j < matrixList[0].GetColumnSize(); j++)
            {
                ButtonCHANGE(matrixList, 0, 3, j, 0); commandCount++;
            }
            PrintMatrix(matrixList[0]);

            ButtonTRANSMATRIX(ref matrixList, 0); commandCount++;
            PrintMatrix(matrixList[0]);

            // Work with "matrix2"

            InitMatrix(ref matrixList, 1, 3); commandCount++;
            PrintMatrix(matrixList[1]);

            ButtonCHANGE(matrixList, 1, 1, 0, -4); commandCount++;
            PrintMatrix(matrixList[1]);

            ButtonCHANGE(matrixList, 1, 2, 0, -3); commandCount++;
            PrintMatrix(matrixList[1]);

            ButtonTRANSMATRIX(ref matrixList, 1); commandCount++;
            PrintMatrix(matrixList[1]);

            for (int i = 0; i < commandCount; i++)
            {
                ButtonUNDO();
                PrintMatrix(matrixList[0]);
                PrintMatrix(matrixList[1]);
            }
#endif

            /* Client Code End */
        }
    }
}
