using NUnit.Framework;

namespace ShapeLib.Tests
{
  /// <summary>
  /// Тесты на фигуру "Треугольник".
  /// </summary>
  [TestFixture]
  public class TriangleTests
  {
    [Test]
    [TestCase(0, 0, 0)]
    [TestCase(1, 0, 0)]
    [TestCase(0, 1, 0)]
    [TestCase(0, 0, 1)]
    [TestCase(1, 2, 0)]
    [TestCase(0, 1, 2)]
    [TestCase(1, 0, 2)]
    [TestCase(-6, -7, -8)]
    [TestCase(1, -6, -7)]
    [TestCase(-6, 1, -7)]
    [TestCase(-6, -7, 1)]
    [TestCase(1, 2, -6)]
    [TestCase(-6, 1, 2)]
    [TestCase(1, -6, 2)]
    public void CreatingTriangle_ShouldThrowException_WhenAnySideLengthIsNotPositive(double sideLength1, double sideLength2, double sideLength3)
    {
      Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(sideLength1, sideLength2, sideLength3));
    }

    [Test]
    [TestCase(0.00001, double.Epsilon, 0.1)]
    [TestCase(1, 2, 3)]
    [TestCase(1, 2, double.MaxValue)]
    [TestCase(double.MaxValue, double.MaxValue, double.MaxValue)]
    public void CreatingTriangle_ShouldNotThrowException_WhenAllSideLengthsArePositive(double sideLength1, double sideLength2, double sideLength3)
    {
      Assert.DoesNotThrow(() => new Triangle(sideLength1, sideLength2, sideLength3));
    }

    public static IEnumerable<(double s1, double s2, double s3, double expectedSquare)> TriangleSquareTestCases = new[]
    {
      (s1: 0.01, s2: 0.02, s3: 0.025, expectedSquare: 0.00009499177595981665),
      (s1: 3, s2: 4, s3: 5, expectedSquare: 6),
      (s1: 123.777, s2: 456.777, s3: 389.111, expectedSquare: 21681.863153953938),
      (s1: 1e+100, s2: 1e+100, s3: 1e+100, expectedSquare: 4.3301270189221958e+199),
      (s1: 1e+154, s2: 1e+154, s3: 1e+154, expectedSquare: 4.3301270189221936e+307),
    };

    [Test]
    [TestCaseSource(nameof(TriangleSquareTestCases))]
    public void GetTriangleSquare_ShouldReturnRightValue((double s1, double s2, double s3, double expectedSquare) args)
    {
      var triangle = new Triangle(args.s1, args.s2, args.s3);
      Assert.That(triangle.Square, Is.EqualTo(args.expectedSquare).Within(MathUtils.DoubleNumbersEqualityTolerance));
    }

    [Test]
    [TestCase(double.MaxValue, double.MaxValue, double.MaxValue)]
    [TestCase(double.MaxValue/3, double.MaxValue/3, double.MaxValue/3)]
    [TestCase(1e+155, 1e+155, 1e+155)]
    public void GetTriangleSquare_ShouldReturnOverflowedValue_WhenTriangleSidesAreLarge(double sideLength1, double sideLength2, double sideLength3)
    {
      var triangle = new Triangle(sideLength1, sideLength2, sideLength3);
      Assert.AreEqual(double.PositiveInfinity, triangle.Square);
    }
  }
}
