using System;
namespace Lab1
{
    public enum Color {red, green, blue, cyan, magenta, yellow, black, white};
    public abstract class Figure
    {
        private Color _FillColorRGBA = Color.black;
        private Color _ContourColorRGBA = Color.black;
        public Color FillColorRGBA
        {
            get { return _FillColorRGBA; }
            set { _FillColorRGBA = value; }
        }

        public Color ContourColorRGBA
        {
            get { return _ContourColorRGBA; }
            set { _ContourColorRGBA = value; }
        }
        public Figure(Color fillColorRGBA, Color contourColorRGBA)
        {
            _FillColorRGBA = fillColorRGBA;
            _ContourColorRGBA = contourColorRGBA;
        }

        public Figure()
        {
            _FillColorRGBA = Color.black;
            _ContourColorRGBA = Color.black;
        }
    }

    public class Circle : Figure
    {
        private uint _Radius;
        private int _CenterOX, _CenterOY;
        public uint Radius 
        { 
            get { return _Radius; } 
            set { _Radius = value; }
        }
        public int CenterOX
        {
            get { return _CenterOX; }
            set { _CenterOX = value; }
        }

        public int CenterOY
        {
            get { return _CenterOY; }
            set { _CenterOY = value; }
        }

        public Circle(uint radius, int centerOX, int centerOY, Color fillColorRGBA, Color contourColorRGBA) 
            : base (fillColorRGBA, contourColorRGBA)
        {
            _Radius = radius;
            _CenterOX = centerOX;
            _CenterOY = centerOY;
        }

        public Circle()
        {
            _Radius = 0;
            _CenterOX = 0;
            _CenterOY = 0;
        }

        public double PerimeterCalculate()
        {
            return 2 * Math.PI * _Radius;
        }

        public double SquareCalculate()
        {
            return Math.PI * Math.Pow(_Radius, 2.0);
        }

        public void ShiftOXOY(int shiftOX, int shiftOY)
        {
            _CenterOX += shiftOX;
            _CenterOY += shiftOY;
        }
    }

    public class Triangle : Figure
    {
        Tuple<int, int> _FirstVertex; 
        Tuple<int, int> _SecondVertex; 
        Tuple<int, int> _ThirdVertex;
        public Tuple<int, int> FirstVertex
        {
            get { return _FirstVertex; }
            set { _FirstVertex = value; }
        }

        public Tuple<int, int> SecondVertex
        {
            get { return _SecondVertex; }
            set { _SecondVertex = value; }
        }

        public Tuple<int, int> ThirdVertex
        {
            get { return _ThirdVertex; }
            set { _ThirdVertex = value; }
        }

        public Triangle(Tuple<int, int> FirstVertex, Tuple<int, int> SecondVertex, Tuple<int, int> ThirdVertex, Color fillColorRGBA, Color contourColorRGBA)
            : base(fillColorRGBA, contourColorRGBA)
        {
            _FirstVertex = FirstVertex;
            _SecondVertex = SecondVertex;
            _ThirdVertex = ThirdVertex;
        }

        public Triangle()
        {
            FirstVertex = new Tuple<int, int>(0, 0);
            SecondVertex = new Tuple<int, int>(0, 0);
            ThirdVertex = new Tuple<int, int>(0, 0);
        }

        public double PerimeterCalculate()
        {
            Tuple<int, int> FirstSide = new Tuple<int, int>(_SecondVertex.Item1 - _FirstVertex.Item1, _SecondVertex.Item2 - _FirstVertex.Item2);
            Tuple<int, int> SecondSide = new Tuple<int, int>(_ThirdVertex.Item1 - _SecondVertex.Item1, _ThirdVertex.Item2 - _SecondVertex.Item2);
            Tuple<int, int> ThirdSide = new Tuple<int, int>(_FirstVertex.Item1 - _ThirdVertex.Item1, _FirstVertex.Item2 - _ThirdVertex.Item2);
            double FirstSideLength = Math.Sqrt(Math.Pow(FirstSide.Item1, 2) + Math.Pow(FirstSide.Item2, 2));
            double SecondSideLength = Math.Sqrt(Math.Pow(SecondSide.Item1, 2) + Math.Pow(SecondSide.Item2, 2));
            double ThirdSideLength = Math.Sqrt(Math.Pow(ThirdSide.Item1, 2) + Math.Pow(ThirdSide.Item2, 2));
            return FirstSideLength+SecondSideLength+ThirdSideLength;
        }

        public double SquareCalculate()
        {
            Tuple<int, int> FirstSide = new Tuple<int, int>(_SecondVertex.Item1 - _FirstVertex.Item1, _SecondVertex.Item2 - _FirstVertex.Item2);
            Tuple<int, int> SecondSide = new Tuple<int, int>(_ThirdVertex.Item1 - _SecondVertex.Item1, _ThirdVertex.Item2 - _SecondVertex.Item2);
            Tuple<int, int> ThirdSide = new Tuple<int, int>(_FirstVertex.Item1 - _ThirdVertex.Item1, _FirstVertex.Item2 - _ThirdVertex.Item2);
            double FirstSideLength = Math.Sqrt(Math.Pow(FirstSide.Item1, 2) + Math.Pow(FirstSide.Item2, 2));
            double SecondSideLength = Math.Sqrt(Math.Pow(SecondSide.Item1, 2) + Math.Pow(SecondSide.Item2, 2));
            double ThirdSideLength = Math.Sqrt(Math.Pow(ThirdSide.Item1, 2) + Math.Pow(ThirdSide.Item2, 2));
            return Math.Sqrt(PerimeterCalculate()/2*(PerimeterCalculate() / 2 - FirstSideLength) * (PerimeterCalculate() / 2 - SecondSideLength) * (PerimeterCalculate() / 2 - ThirdSideLength));
        }

        public double CircumscribedCircleRadiusCalculate()
        {
            Tuple<int, int> FirstSide = new Tuple<int, int>(_SecondVertex.Item1 - _FirstVertex.Item1, _SecondVertex.Item2 - _FirstVertex.Item2);
            Tuple<int, int> SecondSide = new Tuple<int, int>(_ThirdVertex.Item1 - _SecondVertex.Item1, _ThirdVertex.Item2 - _SecondVertex.Item2);
            Tuple<int, int> ThirdSide = new Tuple<int, int>(_FirstVertex.Item1 - _ThirdVertex.Item1, _FirstVertex.Item2 - _ThirdVertex.Item2);
            double FirstSideLength = Math.Sqrt(Math.Pow(FirstSide.Item1, 2) + Math.Pow(FirstSide.Item2, 2));
            double SecondSideLength = Math.Sqrt(Math.Pow(SecondSide.Item1, 2) + Math.Pow(SecondSide.Item2, 2));
            double ThirdSideLength = Math.Sqrt(Math.Pow(ThirdSide.Item1, 2) + Math.Pow(ThirdSide.Item2, 2));
            return FirstSideLength * SecondSideLength * ThirdSideLength / (4 * SquareCalculate());
        }
        public void ShiftOXOY(int shiftOX, int shiftOY)
        {
            _FirstVertex = new Tuple<int, int>(_FirstVertex.Item1 + shiftOX, _FirstVertex.Item2 + shiftOY);
            _SecondVertex = new Tuple<int, int>(_SecondVertex.Item1 + shiftOX, _SecondVertex.Item2 + shiftOY);
            _ThirdVertex = new Tuple<int, int>(_ThirdVertex.Item1 + shiftOX, _ThirdVertex.Item2 + shiftOY);
        }
    }

    public class VectorPainting
    {
        uint _CanvasSizeX, _CanvasSizeY;
        Figure[] _FiguresArray = new Figure[0];
        public VectorPainting() {
            Figure[] _FiguresArray = new Figure[0];
            _CanvasSizeX = 0; _CanvasSizeY = 0;
        }

        public VectorPainting(Figure figure)
        {
            Figure[] _FiguresArray = new Figure[1];
            _FiguresArray[0] = figure;
            _CanvasSizeX = Convert.ToUInt32(Math.Ceiling(figure is Circle ? ((Circle)figure).Radius * 2 : ((Triangle)figure).CircumscribedCircleRadiusCalculate()*2));
            _CanvasSizeY = _CanvasSizeX;
        }

        public void AddFigureToPainting(Figure figure)
        {
            if (figure == null) throw new SystemException("Invalid figure");
            Array.Resize(ref _FiguresArray, _FiguresArray.Length + 1);
            _FiguresArray[_FiguresArray.Length - 1] = figure;
        }

        public uint CanvasSizeX{
            get { return _CanvasSizeX; }
            set { _CanvasSizeX = value; }
        }

        public uint CanvasSizeY
        {
            get { return _CanvasSizeY; }
            set { _CanvasSizeY = value; }
        }

    }

    public class Lab1
    {
        public static void Main()
        {
            try
            {
                Circle b = new Circle(25, 15, 10, Color.cyan, Color.magenta);
                Triangle c = new Triangle (Tuple.Create(5, 10), Tuple.Create(2, 8), Tuple.Create(3, 4), Color.cyan, Color.magenta);
                VectorPainting a = new VectorPainting(b);
                a.AddFigureToPainting (c);
                Console.WriteLine(a.CanvasSizeX);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
