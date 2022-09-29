using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Triangle : Figure
{
    Tuple<double, double> _FirstVertex, _SecondVertex, _ThirdVertex;
    Tuple<double, double> _FirstSide, _SecondSide, _ThirdSide;
    double FirstSideLength, SecondSideLength, ThirdSideLength;
    const double EPSILON = 0.001;

    public Tuple<double, double> FirstVertex
    {
        get { return _FirstVertex; }
        set 
        { 
            _FirstVertex = value; 
        }
    }

    public Tuple<double, double> SecondVertex
    {
        get { return _SecondVertex; }
        set
        {
            if (value == _FirstVertex)
                throw new SystemException("Second vertex should not be the same one as first");
            else _SecondVertex = value;
        }
    }

    public Tuple<double, double> ThirdVertex
    {
        get { return _ThirdVertex; }
        set
        {
            _ThirdVertex = value;
        }
    }
    public Triangle((double, double) FirstVertex, (double, double) SecondVertex, (double, double) ThirdVertex, Color fillColorRGBA, Color contourColorRGBA)
        : base(fillColorRGBA, contourColorRGBA)
    {
        _FirstVertex = Tuple.Create(FirstVertex.Item1, FirstVertex.Item2);
        if (SecondVertex != FirstVertex)
            _SecondVertex = Tuple.Create(SecondVertex.Item1, SecondVertex.Item2);
        else throw new SystemException("Second vertex should not be the same one as first");
        _FirstSide = new Tuple<double, double>(_SecondVertex.Item1 - _FirstVertex.Item1, _SecondVertex.Item2 - _FirstVertex.Item2);

        Tuple<double, double> ThirdVertexBuffer = Tuple.Create(ThirdVertex.Item1, ThirdVertex.Item2);
        Tuple<double, double> SecondSideBuffer = Tuple.Create(ThirdVertexBuffer.Item1 - _SecondVertex.Item1, ThirdVertexBuffer.Item2 - _SecondVertex.Item2);
        Tuple<double, double> ThirdSideBuffer = Tuple.Create(_FirstVertex.Item1 - ThirdVertexBuffer.Item1, _FirstVertex.Item2 - ThirdVertexBuffer.Item2);

        if (FirstSideLength + SecondSideLength - ThirdSideLength <= EPSILON ||
            FirstSideLength + ThirdSideLength - SecondSideLength <= EPSILON ||
            SecondSideLength + ThirdSideLength - FirstSideLength <= EPSILON)
            throw new SystemException("Invalid vertexes, sum of two sides length must be bigger than the last side");

        _ThirdVertex = Tuple.Create(ThirdVertex.Item1, ThirdVertex.Item2);

        _SecondSide = new Tuple<double, double>(_ThirdVertex.Item1 - _SecondVertex.Item1, _ThirdVertex.Item2 - _SecondVertex.Item2);
        _ThirdSide = new Tuple<double, double>(_FirstVertex.Item1 - _ThirdVertex.Item1, _FirstVertex.Item2 - _ThirdVertex.Item2);

        FirstSideLength = Math.Sqrt(Math.Pow(_FirstSide.Item1, 2) + Math.Pow(_FirstSide.Item2, 2));
        SecondSideLength = Math.Sqrt(Math.Pow(_SecondSide.Item1, 2) + Math.Pow(_SecondSide.Item2, 2));
        ThirdSideLength = Math.Sqrt(Math.Pow(_ThirdSide.Item1, 2) + Math.Pow(_ThirdSide.Item2, 2));




    }
    public Triangle()
    {
        _FirstVertex = new Tuple<double, double>(0, 0);
        _SecondVertex = new Tuple<double, double>(0, 0);
        _ThirdVertex = new Tuple<double, double>(0, 0);

        _FirstSide = new Tuple<double, double>(0, 0);
        _SecondSide = new Tuple<double, double>(0, 0);
        _ThirdSide = new Tuple<double, double>(0, 0);

    }

    public double PerimeterCalculate()
    {
        return FirstSideLength + SecondSideLength + ThirdSideLength;
    }

    public double SquareCalculate()
    {
        return Math.Sqrt(PerimeterCalculate() / 2 * (PerimeterCalculate() / 2 - FirstSideLength) * (PerimeterCalculate() / 2 - SecondSideLength) * (PerimeterCalculate() / 2 - ThirdSideLength));
    }

    public double CircumscribedCircleRadiusCalculate()
    {
        return FirstSideLength * SecondSideLength * ThirdSideLength / (4 * SquareCalculate());
    }
    public void ShiftOXOY(double shiftOX, double shiftOY)
    {
        _FirstVertex = new Tuple<double, double>(_FirstVertex.Item1 + shiftOX, _FirstVertex.Item2 + shiftOY);
        _SecondVertex = new Tuple<double, double>(_SecondVertex.Item1 + shiftOX, _SecondVertex.Item2 + shiftOY);
        _ThirdVertex = new Tuple<double, double>(_ThirdVertex.Item1 + shiftOX, _ThirdVertex.Item2 + shiftOY);
    }
}
