namespace FigureArea;

public interface IFigure
{
	/// <summary>
	/// Calculates the area of the figure
	/// </summary>
	/// <returns>Returns the area value or infinity if occurred overflow of double type during the calculation</returns>
	public double GetArea();
	
	/// <summary>
	/// Calculates the area of the figure
	/// </summary>
	/// <param name="area">variable which will be assigned the value of the calculated area of the figure</param>
	/// <returns>A return value indicates whether the calculation succeeded or failed</returns>
	public bool TryGetArea(out double area);

	
}