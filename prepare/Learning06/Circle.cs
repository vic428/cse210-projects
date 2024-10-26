using System.Reflection.Metadata;

public class Cirlce: Shape
{
    private double _radius;

    public Cirlce(string color, double radius): base (color)
    {
        _radius = radius;
    }

    public override double GetArea()
    {
        return _radius * _radius * Math.PI;
    }

}