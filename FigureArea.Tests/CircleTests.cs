using FigureArea;

namespace FigureAreaTests;

public class CircleTests
{
	private const double TOLERANCE = 0.00001;
	
	[TestCase(3, TestName = "Create circle")]
	[TestCase(Math.E, TestName = "Create circle with non-integer radius")]
	public void CreateCircle_SuccessfullyTest(double r)
	{
		var circle = new Circle(r);
		Assert.That(circle.Radius, Is.EqualTo(r));
	}
	
	[TestCase(-3, TestName = "Try to create circle with negative radius")]
	public void CreateCircle_ThrowExceptionTest(double r)
	{
		Assert.Throws<InvalidDataException>(delegate { var circle = new Circle(r); });
	}

	[TestCase(4, 50.26548, true, TestName = "Try to get area of circle")]
	[TestCase(Double.MaxValue/2,  0, false,
		TestName = "Try to get area, double overflow during calculation")]
	public void TryGetArea_Test(double r, double expectedValue, bool isSuccessExpected)
	{
		var circle = new Circle(r);
		var result = circle.TryGetArea(out var area);
		if (isSuccessExpected)
		{
			Assert.Multiple(() =>
			{
				Assert.That(result, Is.True);
				Assert.That(Math.Abs(area - expectedValue), Is.LessThan(TOLERANCE));
			});
		}
		else
		{
			Assert.That(result, Is.False);
		}
	}
}