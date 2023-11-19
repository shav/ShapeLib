namespace ShapeLib
{
  /// <summary>
  /// Треугольник.
  /// </summary>
  public class Triangle : Shape
  {
    /// <summary>
    /// Сообщение валидации о том, что стороны треугольника должны быть положительной длины.
    /// </summary>
    private const string SidePositiveValidationMessage = "Sides of triangle should be positive";

    /// <summary>
    /// Длина первой стороны треугольника.
    /// </summary>
    public double SideLength1 { get; }

    /// <summary>
    /// Длина второй стороны треугольника.
    /// </summary>
    public double SideLength2 { get; }

    /// <summary>
    /// Длина третьей стороны треугольника.
    /// </summary>
    public double SideLength3 { get; }

    private bool? isOrthogonal;

    /// <summary>
    /// Признак того, что треугольник является прямоугольным.
    /// </summary>
    public bool IsOrthogonal => this.isOrthogonal ??= CheckIsOrthogonalByPythagoreanTheorem(this);

    private double? square;

    /// <summary>
    /// Площадь треугольника.
    /// </summary>
    public override double Square => this.square ??= CalculateSquareBySidesLength(this);

    /// <summary>
    /// Вычислить площадь треугольника по трём сторонам (по формуле Герона).
    /// </summary>
    /// <param name="triangle">Треугольник.</param>
    /// <returns>Площадь треугольника.</returns>
    private static double CalculateSquareBySidesLength(Triangle triangle)
    {
      var semiPerimeter = (triangle.SideLength1 + triangle.SideLength2 + triangle.SideLength3) / 2;
      return Math.Sqrt(semiPerimeter *
        (semiPerimeter - triangle.SideLength1) *
        (semiPerimeter - triangle.SideLength2) *
        (semiPerimeter - triangle.SideLength3));
    }

    /// <summary>
    /// Проверить является ли треугольник прямоугольным.
    /// </summary>
    /// <param name="triangle">Треугольник.</param>
    /// <returns>True - если треугольник является прямоугольным, False - иначе.</returns>
    private static bool CheckIsOrthogonalByPythagoreanTheorem(Triangle triangle)
    {
      Span<double> sideLengths = stackalloc double[3] { triangle.SideLength1, triangle.SideLength2, triangle.SideLength3 };
      sideLengths.Sort();
      double cathet1 = sideLengths[0], cathet2 = sideLengths[1], hypothenuse = sideLengths[2];
      return Math.Pow(cathet1, 2) + Math.Pow(cathet2, 2) == Math.Pow(hypothenuse, 2);
    }

    // ВОПРОС: Кажется немного странноватым описывать треугольник с помощью длин его сторон.
    // Но для решения текущей задачи нахождения площади этого достаточно.
    // Может быть стоит использовать более естественный и точный способ описания треугольника на плоскости - по трём его вершинам?

    /// <summary>
    /// Создать треугольник.
    /// </summary>
    /// <param name="sideLength1">Длина первой стороны треугольника.</param>
    /// <param name="sideLength2">Длина второй стороны треугольника.</param>
    /// <param name="sideLength3">Длина третьей стороны треугольника.</param>
    /// <exception cref="ArgumentOutOfRangeException">Если указан сторона длиной меньше либо равной нулю.</exception>
    public Triangle(double sideLength1, double sideLength2, double sideLength3)
    {
      if (sideLength1 <= 0)
        throw new ArgumentOutOfRangeException(nameof(sideLength1), SidePositiveValidationMessage);
      
      if (sideLength2 <= 0)
        throw new ArgumentOutOfRangeException(nameof(sideLength2), SidePositiveValidationMessage);

      if (sideLength3 <= 0)
        throw new ArgumentOutOfRangeException(nameof(sideLength3), SidePositiveValidationMessage);

      this.SideLength1 = sideLength1;
      this.SideLength2 = sideLength2;
      this.SideLength3 = sideLength3;
    }
  }
}
