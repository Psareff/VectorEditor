using System;
namespace Lab1
{
    public class Lab1
    {
        public static void Main()
        {
            try
            {
                Circle b = new Circle(25.0, 15.0, 10.0, Color.cyan, Color.magenta);
                Triangle c = new Triangle ((10.0, 10.0), (1.0, 1.0), (2.0, 2.0), Color.cyan, Color.magenta);
                VectorPainting a = new VectorPainting(c);
                //a.AddFigureToPainting (null);
                Console.WriteLine(a.CanvasSizeX);
            }

            catch (SystemException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
