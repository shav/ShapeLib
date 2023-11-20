namespace ShapeLib
{
  /// <summary>
  /// Треугольник.
  /// </summary>
  public class Triangle : Shape
  {
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

    public override string ToString()
    {
      return $"Triangle (side1 = {this.SideLength1}, side2 = {this.SideLength2}, side3 = {this.SideLength3})";
    }

    /// <summary>
    /// Вычислить площадь треугольника по трём сторонам (по формуле Герона).
    /// </summary>
    /// <param name="triangle">Треугольник.</param>
    /// <returns>Площадь треугольника.</returns>
    private static double CalculateSquareBySidesLength(Triangle triangle)
    {
      var semiPerimeter = triangle.SideLength1 / 2 + triangle.SideLength2 / 2 + triangle.SideLength3 / 2;
      return Math.Sqrt(semiPerimeter) *
        Math.Sqrt(semiPerimeter - triangle.SideLength1) *
        Math.Sqrt(semiPerimeter - triangle.SideLength2) *
        Math.Sqrt(semiPerimeter - triangle.SideLength3);
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
      return MathUtils.IsApproximatelyEqual(Math.Sqrt(Math.Pow(cathet1, 2) + Math.Pow(cathet2, 2)), hypothenuse);
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
      TriangleValidator.ValidatePositiveSidesLength(sideLength1, sideLength2, sideLength3);
      TriangleValidator.ValidateTriangleSidesLengthInequalityRule(sideLength1, sideLength2, sideLength3);

      this.SideLength1 = sideLength1;
      this.SideLength2 = sideLength2;
      this.SideLength3 = sideLength3;
    }

    /// <summary>
    /// Валидатор настроек треугольника.
    /// </summary>
    private static class TriangleValidator
    {
      /// <summary>
      /// Сообщение валидации о том, что стороны треугольника должны быть положительной длины.
      /// </summary>
      private const string SidePositiveValidationMessage = "Sides of triangle should be positive";

      /// <summary>
      /// Сообщение валидации о невыполнении неравенства треугольника между сторонами.
      /// </summary>
      private const string SidesLengthInequalityValidationMessage = "For any side of triangle its length should be less than sum of other sides length";

      /// <summary>
      /// Проверить, что все стороны треугольника имеют положителную длину.
      /// </summary>
      /// <param name="sideLength1">Длина первой стороны треугольника.</param>
      /// <param name="sideLength2">Длина второй стороны треугольника.</param>
      /// <param name="sideLength3">Длина третьей стороны треугольника.</param>
      /// <exception cref="ArgumentOutOfRangeException">Если указан сторона длиной меньше либо равной нулю.</exception>
      public static void ValidatePositiveSidesLength(double sideLength1, double sideLength2, double sideLength3)
      {
        if (sideLength1 <= 0)
          throw new ArgumentOutOfRangeException(nameof(sideLength1), SidePositiveValidationMessage);

        if (sideLength2 <= 0)
          throw new ArgumentOutOfRangeException(nameof(sideLength2), SidePositiveValidationMessage);

        if (sideLength3 <= 0)
          throw new ArgumentOutOfRangeException(nameof(sideLength3), SidePositiveValidationMessage);
      }

      /// <summary>
      /// Проверить соотношение между сторонами треугольника:
      /// длина каждой стороны треугольника не должна превышать сумму длин двух других сторон.
      /// </summary>
      /// <param name="sideLength1">Длина первой стороны треугольника.</param>
      /// <param name="sideLength2">Длина второй стороны треугольника.</param>
      /// <param name="sideLength3">Длина третьей стороны треугольника.</param>
      /// <exception cref="ArgumentException">Если соотношение между сторонами треугольника не выполняется.</exception>
      public static void ValidateTriangleSidesLengthInequalityRule(double sideLength1, double sideLength2, double sideLength3)
      {
        if (sideLength1 >= sideLength2 + sideLength3)
          throw new ArgumentException(SidesLengthInequalityValidationMessage);

        if (sideLength2 >= sideLength1 + sideLength3)
          throw new ArgumentException(SidesLengthInequalityValidationMessage);

        if (sideLength3 >= sideLength1 + sideLength2)
          throw new ArgumentException(SidesLengthInequalityValidationMessage);
      }
    }
  }
}