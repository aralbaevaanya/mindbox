using FigureArea;
namespace FigureAreaTests;

public class TriangleTests
{
	[TestCase(3, 3, 3, TestName = "Create equilateral triangle")]
	[TestCase(5.5, 5.5, 5.5, TestName = "Create equilateral triangle with non-integer sides")]
	[TestCase(2.1, 2.8, 3.5, TestName = "Create right triangle")]
	public void CreateTriangle_SuccessfullyTest(double a, double b, double c)
	{
		var triangle = new Triangle(a, b, c);
		Assert.That(triangle, Is.Not.Null);
	}
	
	[TestCase(-3, -3, -3, TestName = "Try to create triangle with negative side lengths")]
	[TestCase(2, 3, 5, TestName = "Try to create non-existent triangle")]
	[TestCase(0, 3, 5, TestName = "Try to create non-existent triangle with zero side length")]
	public void CreateTriangle_ThrowExceptionTest(double a, double b, double c)
	{
		Assert.Throws<InvalidDataException>(delegate { var triangle = new Triangle(a, b, c); });
	}

	[TestCase(3, 3, 3, false, TestName = "Not right triangle")]
	[TestCase(2.1, 2.8, 3.5, true, TestName = "Right triangle")]
	public void IsRightTriangle_Test(double a, double b, double c, bool expectedResult)
	{
		var triangle = new Triangle(a, b, c);
		Assert.That(triangle.IsRightTriangle(), Is.False);
	}

	[TestCase(3, 4, 5, 6, true, TestName = "Try to get area of right triangle")]
	[TestCase(Double.MaxValue, Double.MaxValue-1, Double.MaxValue-2, 0, false, TestName = "Try to get area, double overflow during calculation")]
	public void TryGetArea_Test(double a, double b, double c, double expectedAreaValue, bool isSuccessExpected)
	{
		var triangle = new Triangle(a, b, c);
		var result = triangle.TryGetArea(out var area);
		if (isSuccessExpected)
        {
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(area, Is.EqualTo(expectedAreaValue));
            });
        }
		else
		{
			Assert.That(result, Is.False);
		}
    }
}