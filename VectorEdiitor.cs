using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class VectorPainting
{
    double _CanvasSizeX, _CanvasSizeY;
    Figure[] _FiguresArray = new Figure[0];
    public VectorPainting()
    {
        Figure[] _FiguresArray = new Figure[0];
        _CanvasSizeX = 0; _CanvasSizeY = 0;
    }

    public VectorPainting(Figure figure)
    {
        Figure[] _FiguresArray = new Figure[1];
        _FiguresArray[0] = figure;
        _CanvasSizeX = Convert.ToDouble(Math.Ceiling(figure is Circle ? ((Circle)figure).Radius * 2 : ((Triangle)figure).CircumscribedCircleRadiusCalculate() * 2));
        _CanvasSizeY = _CanvasSizeX;
    }

    public void AddFigureToPainting(Figure figure)
    {
        if (figure == null) throw new SystemException("Invalid figure");
        if ((figure is Circle ? ((Circle)figure).Radius * 2 : ((Triangle)figure).CircumscribedCircleRadiusCalculate() * 2) > CanvasSizeX)
        {

        }
        Array.Resize(ref _FiguresArray, _FiguresArray.Length + 1);
        _FiguresArray[_FiguresArray.Length - 1] = figure;
    }

    public double CanvasSizeX
    {
        get { return _CanvasSizeX; }
        set { _CanvasSizeX = value; }
    }

    public double CanvasSizeY
    {
        get { return _CanvasSizeY; }
        set { _CanvasSizeY = value; }
    }

}