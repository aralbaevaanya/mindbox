namespace FigureArea;

public class Circle : IFigure
{
	public double Radius { get; }
	
	public Circle (double radius)
	{
		Radius = radius;
		if (radius <= 0)
		{
			throw new InvalidDataException("The radius of the circle must be non-negative");
		}
	}

	public double GetArea()
	{
		return Math.PI * (Radius * Radius);
	}
	public bool TryGetArea(out double area)
	{
		area = GetArea();
		return double.IsFinite(area);
	}
}