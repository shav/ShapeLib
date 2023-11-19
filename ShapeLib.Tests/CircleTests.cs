using NUnit.Framework;

namespace ShapeLib.Tests
{
  /// <summary>
  /// Тесты на фигуру "Круг".
  /// </summary>
  [TestFixture]
  public class CircleTests
  {
    [Test]
    [TestCase(0)]
    [TestCase(-0.0001)]
    [TestCase(-2)]
    [TestCase(double.MinValue)]
    public void CreatingCircle_ShouldThrowException_WhenRadiusIsNotPositive(double radius)
    {
      Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(radius));
    }

    [Test]
    [TestCase(0.0001)]
    [TestCase(2)]
    [TestCase(double.MaxValue)]
    public void CreatingCircle_ShouldNotThrowException_WhenRadiusIsPositive(double radius)
    {
      Assert.DoesNotThrow(() => new Circle(radius));
    }

    public static IEnumerable<(double radius, double expectedSquare)> CircleSquareTestCases = new[]
    {
      (radius: 0.00001, expectedSquare: 0.000000000314159265358979323846),
      (radius: 1.0, expectedSquare: Math.PI),
      (radius: 7.77, expectedSquare: 189.6670591159),
      (radius: 1000, expectedSquare: 3141592.65358979323846),
      (radius: 123456.789, expectedSquare: 47882831830.7088432141),
      (radius: 7.56e+153, expectedSquare: 1.7955332988620959E+308),
    };

    [Test]
    [TestCaseSource(nameof(CircleSquareTestCases))]
    public void GetCircleSquare_ShouldReturnRightValue((double radius, double expectedSquare) args)
    {
      var circle = new Circle(args.radius);
      Assert.That(circle.Square, Is.EqualTo(args.expectedSquare).Within(MathUtils.DoubleNumbersEqualityTolerance));
    }

    [Test]
    [TestCase(double.MaxValue)]
    [TestCase(7.57e+153)]
    [TestCase(1.2345678e+200)]
    public void GetCircleSquare_ShouldReturnOverflowedValue_WhenCircleRadiusIsLarge(double radius)
    {
      var ddd = Math.Sqrt(double.MaxValue) / Math.PI;
      var circle = new Circle(radius);
      Assert.AreEqual(double.PositiveInfinity, circle.Square);
    }
  }
}
