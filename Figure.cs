using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Color { red, green, blue, cyan, magenta, yellow, black, white };
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