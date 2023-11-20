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
    [TestCase(1, 2, 3)]
    [TestCase(10, 13, 25)]
    [TestCase(10001, 12345, 7)]
    [TestCase(1.5e+153, 2e+153, 1e+200)]
    [TestCase(double.MaxValue, 10, 1)]
    public void CreatingTriangle_ShouldThrowException_WhenSidesNotSatisfyTriangleInequality(double sideLength1, double sideLength2, double sideLength3)
    {
      Assert.Throws<ArgumentException>(() => new Triangle(sideLength1, sideLength2, sideLength3));
    }

    [Test]
    [TestCase(0.00001, 0.1, 0.1)]
    [TestCase(1, 2, 2.5)]
    [TestCase(3000, 4000, 5000)]
    [TestCase(1.5e+153, 2e+153, 1e+153)]
    [TestCase(double.MaxValue, double.MaxValue, double.MaxValue)]
    public void CreatingTriangle_ShouldNotThrowException_WhenAllSideLengthsArePositiveAndSatisfyTriangleInequality(double sideLength1, double sideLength2, double sideLength3)
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

    [Test]
    public void TriangleSquare_ShouldBeImmutable_WhenGetMultipleTimes()
    {
      const double expectedSquare = 6;
      var triangle = new Triangle(3, 4, 5);

      for (int i = 0; i < 10; i++)
      {
        Assert.That(triangle.Square, Is.EqualTo(expectedSquare).Within(MathUtils.DoubleNumbersEqualityTolerance));
      }
    }

    [Test]
    [TestCase(5, 4, 3)]
    [TestCase(6, 10, 8)]
    [TestCase(1.414213562373095, 1, 1)]
    [TestCase(1.23, 4.56, 4.72297575687)]
    [TestCase(1e+153, 1.414213562373095e+153, 1e+153)]
    // При еще бОльших длинах сторон треугольника, к сожалению, IsOrthogonal из-за переполнения возвращает False,
    // даже несмотря на выполнение теоремы Пифагора для них.
    // Но тесты на эти кейсы добавлять не хочется, т.к. это скорее баг, нежели требование к проверке прямоугольного треугольника.
    public void TriangleIsOrthogonal_ShouldReturnTrue_WhenSidesOfTriangleSatisfyToPythagoreusTheoreme(double sideLength1, double sideLength2, double sideLength3)
    {
      var triangle = new Triangle(sideLength1, sideLength2, sideLength3);
      Assert.IsTrue(triangle.IsOrthogonal);
    }

    [Test]
    [TestCase(10, 20, 25)]
    [TestCase(3, 4, 6)]
    [TestCase(5e+153, 3e+153, 7e+153)]
    [TestCase(double.MaxValue, double.MaxValue, double.MaxValue)]
    public void TriangleIsOrthogonal_ShouldReturnFalse_WhenSidesOfTriangleNotSatisfyToPythagoreusTheoreme(double sideLength1, double sideLength2, double sideLength3)
    {
      var triangle = new Triangle(sideLength1, sideLength2, sideLength3);
      Assert.IsFalse(triangle.IsOrthogonal);
    }
  }
}
