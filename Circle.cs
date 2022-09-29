using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Circle : Figure
{
    private double _Radius;
    private double _CenterOX, _CenterOY;
    public double Radius
    {
        get { return _Radius; }
        set
        {
            if (value >= 0)
                _Radius = value;
            else throw new ArgumentOutOfRangeException("Radius is out of bounds");
        }
    }
    public double CenterOX
    {
        get { return _CenterOX; }
        set
        { _CenterOX = value; }
    }

    public double CenterOY
    {
        get { return _CenterOY; }
        set
        { _CenterOY = value; }
    }

    public Circle(double radius, double centerOX, double centerOY, Color fillColorRGBA, Color contourColorRGBA)
        : base(fillColorRGBA, contourColorRGBA)
    {
        if (radius >= 0)
            _Radius = radius;
        else throw new SystemException("Radius is out of bounds");
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

    public void ShiftOXOY(double shiftOX, double shiftOY)
    {
        _CenterOX += shiftOX;
        _CenterOY += shiftOY;
    }
}