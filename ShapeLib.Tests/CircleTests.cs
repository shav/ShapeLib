using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;

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
      (radius: 123456.789, expectedSquare: 47882831830.7088432141),
      (radius: 1000, expectedSquare: 3141592.65358979323846),
    };

    [Test]
    [TestCaseSource(nameof(CircleSquareTestCases))]
    public void GetCircleSquare_ShouldReturnRightValue((double radius, double expectedSquare) args)
    {
      const double tolerance = 1e-10;

      var circle = new Circle(args.radius);
      Assert.That(circle.Square, Is.EqualTo(args.expectedSquare).Within(tolerance));
    }
  }
}
