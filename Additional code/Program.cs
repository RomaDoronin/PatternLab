using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharpProj
{
    /* ========================================================================================================= */
    public struct SCoordinate
    {
        public float x;
        public float y;

        public SCoordinate(float _x, float _y)
        {
            x = _x;
            y = _y;
        }
    }

    enum ShapeType
    {
        Rectangle,
        Triangle,
        Circle,
        Hexagon,
        Pentagon,
    }

    enum LibType
    {
        Lib1,
        Lib2,
        Lib3,
        Lib4,
    }

    /* ========================================================================================================= */
    interface IDraw
    {
        void Draw(List<Object> argsList);
        void SetLibType(LibType libType);
    }

    abstract class Shape : IDraw
    {
        private IDrawer drawer;

        public void SetLibType(LibType libType)
        {
            switch (libType)
            {
                case LibType.Lib1:
                    drawer = new UseLib1ToDraw();
                    break;
                case LibType.Lib2:
                    drawer = new UseLib2ToDraw();
                    break;
                case LibType.Lib3:
                    drawer = new UseLib3ToDraw();
                    break;
                case LibType.Lib4:
                    drawer = new UseLib4ToDraw();
                    break;
            }
        }

        protected void DrawLine(int x, int y)
        {
            drawer.DrawLine(x, y);
        }

        public virtual void Draw(List<Object> argsList)
        {}
    }

    class Rectangle : Shape
    {
        SCoordinate startDot;
        float width;
        float height;

        private bool IsArgumentCorrect(List<Object> argsList)
        {
            if (argsList.Count != 3)
            {
                return false;
            }
            else
            {
                if (argsList[0].GetType() != (new SCoordinate().GetType()))
                    return false;
                if (argsList[1].GetType() != (new float()).GetType() && argsList[1].GetType() != (new int()).GetType() && argsList[1].GetType() != (new double()).GetType())
                    return false;
                if (argsList[2].GetType() != (new float()).GetType() && argsList[2].GetType() != (new int()).GetType() && argsList[2].GetType() != (new double()).GetType())
                    return false;

                return true;
            }
        }

        public override void Draw(List<Object> argsList)
        {
            if (!IsArgumentCorrect(argsList))
            {
                throw new ArgumentNullException("Incorrect input");
            }

            startDot = (SCoordinate)argsList[0];
            width = Convert.ToSingle(argsList[1]);
            height = Convert.ToSingle(argsList[2]);

            DrawLine(1, 2);
            Console.WriteLine(" --- Draw Rectangle --- ");
            Console.WriteLine("Start Dot X  : " + startDot.x);
            Console.WriteLine("Start Dot Y  : " + startDot.y);
            Console.WriteLine("Width        : " + width);
            Console.WriteLine("Height       : " + height);
        }
    }

    class Triangle : Shape
    {
        SCoordinate firstDot;
        SCoordinate secondDot;
        SCoordinate thirdDot;

        private bool IsArgumentCorrect(List<Object> argsList)
        {
            if (argsList.Count != 3)
            {
                return false;
            }
            else
            {
                if (argsList[0].GetType() != (new SCoordinate().GetType()))
                    return false;
                if (argsList[1].GetType() != (new SCoordinate().GetType()))
                    return false;
                if (argsList[2].GetType() != (new SCoordinate().GetType()))
                    return false;

                return true;
            }
        }

        public override void Draw(List<Object> argsList)
        {
            if (!IsArgumentCorrect(argsList))
            {
                throw new ArgumentNullException("Incorrect input");
            }

            firstDot = (SCoordinate)argsList[0];
            secondDot = (SCoordinate)argsList[1];
            thirdDot = (SCoordinate)argsList[2];

            DrawLine(1, 2);
            Console.WriteLine(" --- Draw Triangle --- ");
            Console.WriteLine("First Dot X  : " + firstDot.x);
            Console.WriteLine("First Dot Y  : " + firstDot.y);
            Console.WriteLine("Second Dot X : " + secondDot.x);
            Console.WriteLine("Second Dot Y : " + secondDot.y);
            Console.WriteLine("Third Dot X  : " + thirdDot.x);
            Console.WriteLine("Third Dot Y  : " + thirdDot.y);
        }
    }

    class Circle : Shape
    {
        SCoordinate centerDot;
        float radius;

        private bool IsArgumentCorrect(List<Object> argsList)
        {
            if (argsList.Count != 2)
            {
                return false;
            }
            else
            {
                if (argsList[0].GetType() != (new SCoordinate().GetType()))
                    return false;
                if (argsList[1].GetType() != (new float()).GetType() && argsList[1].GetType() != (new int()).GetType() && argsList[1].GetType() != (new double()).GetType())
                    return false;

                return true;
            }
        }

        public override void Draw(List<Object> argsList)
        {
            if (!IsArgumentCorrect(argsList))
            {
                throw new ArgumentNullException("Incorrect input");
            }

            centerDot = (SCoordinate)argsList[0];
            radius = Convert.ToSingle(argsList[1]);

            DrawLine(1, 2);
            Console.WriteLine(" --- Draw Circle --- ");
            Console.WriteLine("Center Dot X : " + centerDot.x);
            Console.WriteLine("Center Dot Y : " + centerDot.y);
            Console.WriteLine("Radius       : " + radius);
        }
    }

    class Hexagon : Shape
    {
        SCoordinate centerDot;
        float radius;
        int inclination;

        private bool IsArgumentCorrect(List<Object> argsList)
        {
            if (argsList.Count != 3)
            {
                return false;
            }
            else
            {
                if (argsList[0].GetType() != (new SCoordinate().GetType()))
                    return false;
                if (argsList[1].GetType() != (new float()).GetType() && argsList[1].GetType() != (new int()).GetType() && argsList[1].GetType() != (new double()).GetType())
                    return false;
                if (argsList[2].GetType() != (new int()).GetType())
                    return false;

                return true;
            }
        }

        public override void Draw(List<Object> argsList)
        {
            if (!IsArgumentCorrect(argsList))
            {
                throw new ArgumentNullException("Incorrect input");
            }

            centerDot = (SCoordinate)argsList[0];
            radius = Convert.ToSingle(argsList[1]);
            inclination = Convert.ToInt32(argsList[2]);

            DrawLine(1, 2);
            Console.WriteLine(" --- Draw Hexagon --- ");
            Console.WriteLine("Center Dot X : " + centerDot.x);
            Console.WriteLine("Center Dot Y : " + centerDot.y);
            Console.WriteLine("Radius       : " + radius);
            Console.WriteLine("Inclination  : " + inclination);
        }
    }

    class Pentagon : Shape
    {
        SCoordinate centerDot;
        float radius;
        int inclination;

        private bool IsArgumentCorrect(List<Object> argsList)
        {
            if (argsList.Count != 3)
            {
                return false;
            }
            else
            {
                if (argsList[0].GetType() != (new SCoordinate().GetType()))
                    return false;
                if (argsList[1].GetType() != (new float()).GetType() && argsList[1].GetType() != (new int()).GetType() && argsList[1].GetType() != (new double()).GetType())
                    return false;
                if (argsList[2].GetType() != (new int()).GetType())
                    return false;

                return true;
            }
        }

        public override void Draw(List<Object> argsList)
        {
            if (!IsArgumentCorrect(argsList))
            {
                throw new ArgumentNullException("Incorrect input");
            }

            centerDot = (SCoordinate)argsList[0];
            radius = Convert.ToSingle(argsList[1]);
            inclination = Convert.ToInt32(argsList[2]);

            DrawLine(1, 2);
            Console.WriteLine(" --- Draw Pentagon --- ");
            Console.WriteLine("Center Dot X : " + centerDot.x);
            Console.WriteLine("Center Dot Y : " + centerDot.y);
            Console.WriteLine("Radius       : " + radius);
            Console.WriteLine("Inclination  : " + inclination);
        }
    }

    /* ========================================================================================================= */
    interface IDrawer
    {
        void DrawLine(int x, int y);
    }

    class UseLib1ToDraw : IDrawer
    {
        public void DrawLine(int x, int y)
        {
            Console.WriteLine("Draw line with using LIB_1");
        }
    }

    class UseLib2ToDraw : IDrawer
    {
        public void DrawLine(int x, int y)
        {
            Console.WriteLine("Draw line with using LIB_2");
        }
    }

    class UseLib3ToDraw : IDrawer
    {
        public void DrawLine(int x, int y)
        {
            Console.WriteLine("Draw line with using LIB_3");
        }
    }

    class UseLib4ToDraw : IDrawer
    {
        public void DrawLine(int x, int y)
        {
            Console.WriteLine("Draw line with using LIB_4");
        }
    }

    /* ========================================================================================================= */
    class Parser
    {
        private IDraw draw;

        public void Draw(List<Object> argsList)
        {
            draw.Draw(argsList);
        }

        public void SetLibType(LibType libType)
        {
            draw.SetLibType(libType);
        }

        public void GetShape(ShapeType shapeType, LibType libType)
        {
            switch (shapeType)
            {
                case ShapeType.Rectangle:
                    draw = new Rectangle();
                    break;
                case ShapeType.Triangle:
                    draw = new Triangle();
                    break;
                case ShapeType.Circle:
                    draw = new Circle();
                    break;
                case ShapeType.Hexagon:
                    draw = new Hexagon();
                    break;
                case ShapeType.Pentagon:
                    draw = new Pentagon();
                    break;
            }

            draw.SetLibType(libType);
        }
    }

    /* ========================================================================================================= */

    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();
            bool ok;

            /* 01 */
            try
            {
                Console.WriteLine("[ TEST 1 ]");
                parser.GetShape(ShapeType.Circle, LibType.Lib3);
                parser.Draw(new List<object>() { new SCoordinate(2, 0.5f), 15.6f });
            }
            catch
            {
                Console.WriteLine("[ FAILED ]");
            }
            finally
            {
                Console.WriteLine("[ OK ]");
            }

            /* 02 */
            ok = false;
            try
            {
                Console.WriteLine("\n[ TEST 2 ]");
                parser.GetShape(ShapeType.Circle, LibType.Lib3);
                parser.Draw(new List<object>() { new SCoordinate(2, 0.5f), 15.6f, 12 });
            }
            catch
            {
                Console.WriteLine("[ OK ]");
                ok = true;
            }
            finally
            {
                if (!ok)
                {
                    Console.WriteLine("[ FAILED ]");
                }
            }

            /* 03 */
            try
            {
                Console.WriteLine("\n[ TEST 3 ]");
                parser.GetShape(ShapeType.Hexagon, LibType.Lib2);
                parser.Draw(new List<object>() { new SCoordinate(2, 0.5f), 15.6f, 12 });
            }
            catch
            {
                Console.WriteLine("[ FAILED ]");
            }
            finally
            {
                Console.WriteLine("[ OK ]");
            }

            /* 04 */
            ok = false;
            try
            {
                Console.WriteLine("\n[ TEST 4 ]");
                parser.GetShape(ShapeType.Hexagon, LibType.Lib2);
                parser.Draw(new List<object>() { new SCoordinate(2, 0.5f), 15.6f });
            }
            catch
            {
                Console.WriteLine("[ OK ]");
                ok = true;
            }
            finally
            {
                if (!ok)
                {
                    Console.WriteLine("[ FAILED ]");
                }
            }

            /* 05 */
            try
            {
                Console.WriteLine("\n[ TEST 5 ]");
                parser.GetShape(ShapeType.Rectangle, LibType.Lib1);
                parser.Draw(new List<object>() { new SCoordinate(2, 0.5f), 15.6f, 12 });
            }
            catch
            {
                Console.WriteLine("[ FAILED ]");
            }
            finally
            {
                Console.WriteLine("[ OK ]");
            }

            /* 06 */
            ok = false;
            try
            {
                Console.WriteLine("\n[ TEST 6 ]");
                parser.GetShape(ShapeType.Rectangle, LibType.Lib1);
                parser.Draw(new List<object>() { new SCoordinate(2, 0.5f), 15.6f });
            }
            catch
            {
                Console.WriteLine("[ OK ]");
                ok = true;
            }
            finally
            {
                if (!ok)
                {
                    Console.WriteLine("[ FAILED ]");
                }
            }

            /* 07 */
            try
            {
                Console.WriteLine("\n[ TEST 7 ]");
                parser.GetShape(ShapeType.Triangle, LibType.Lib2);
                parser.Draw(new List<object>() { new SCoordinate(2, 0.5f), new SCoordinate(0.6f, 0.5f), new SCoordinate(2, 14) });
            }
            catch
            {
                Console.WriteLine("[ FAILED ]");
            }
            finally
            {
                Console.WriteLine("[ OK ]");
            }

            /* 08 */
            ok = false;
            try
            {
                Console.WriteLine("\n[ TEST 8 ]");
                parser.GetShape(ShapeType.Triangle, LibType.Lib3);
                parser.Draw(new List<object>() { new SCoordinate(2, 0.5f), 15.6f });
            }
            catch
            {
                Console.WriteLine("[ OK ]");
                ok = true;
            }
            finally
            {
                if (!ok)
                {
                    Console.WriteLine("[ FAILED ]");
                }
            }

            /* 09 */
            try
            {
                Console.WriteLine("\n[ TEST 9 ]");
                parser.GetShape(ShapeType.Pentagon, LibType.Lib4);
                parser.Draw(new List<object>() { new SCoordinate(2, 0.5f), 15.6f, 15 });
            }
            catch
            {
                Console.WriteLine("[ FAILED ]");
            }
            finally
            {
                Console.WriteLine("[ OK ]");
            }

            /* 10 */
            ok = false;
            try
            {
                Console.WriteLine("\n[ TEST 10 ]");
                parser.GetShape(ShapeType.Pentagon, LibType.Lib4);
                parser.Draw(new List<object>() { new SCoordinate(2, 0.5f), new SCoordinate(0.6f, 0.5f), new SCoordinate(2, 14) });
            }
            catch
            {
                Console.WriteLine("[ OK ]");
                ok = true;
            }
            finally
            {
                if (!ok)
                {
                    Console.WriteLine("[ FAILED ]");
                }
            }
        }
    }
}
