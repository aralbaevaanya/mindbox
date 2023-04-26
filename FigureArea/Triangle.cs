namespace FigureArea;

public class Triangle : IFigure
{
	public double Side1 { get; }
	public double Side2 { get; }
	public double Side3 { get; }

	public Triangle(double side1, double side2, double side3)
	{
		Side1 = side1;
		Side2 = side2;
		Side3 = side3;
		if (!IsTriangleExist(side1, side2, side3))
		{
			throw new InvalidDataException(
				$"A triangle with side lengths {side1}, {side2} and {side3} cannot exist according to the triangle inequality theorem");
		}
	}

	//use Heron's formula https://en.wikipedia.org/wiki/Heron%27s_formula
	public double GetArea()
	{
		return Math.Sqrt((Side1 + Side2 + Side3) * (Side2 - Side1 + Side3)
												* (Side1 - Side2 + Side3) * (Side1 + Side2 - Side3)) / 4;
	}
	public bool TryGetArea(out double area)
	{
		area = GetArea();
		return double.IsFinite(area);
	}

	/// <summary>
	/// checks if a triangle is a right triangle according to the Pythagorean theorem
	/// </summary>
	/// <param name="tolerance">allowable calculation error</param>
	/// <returns></returns>
	public bool IsRightTriangle(double tolerance = 0.00001)
	{
		// c >= a >= b
		var c = Math.Max(Side1, Math.Max(Side2, Side3));
		var a = Math.Min(Side1, Math.Max(Side2, Side3));
		var b = Math.Min(Side1, Math.Min(Side2, Side3));
		return Math.Abs(c * c - (a * a + b * b)) < tolerance;
	}

	private static bool IsTriangleExist(double a, double b, double c)
	{
		return (a + b > c) && (a + c > b) && (b + c > a);
	}
}