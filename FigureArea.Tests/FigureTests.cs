using FigureArea;

namespace FigureAreaTests;

public class FigureTests
{
	public void GetArea_Test()
	{
		IFigure figure = new Triangle(3, 4, 5);
		figure.TryGetArea(out var area);
	}
}