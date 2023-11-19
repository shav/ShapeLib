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

    // ВОПРОС: На сколько часто в реальном приложении предполагается обращение к площади одного и того же треугольника?
    // Если часто, то стоит закешировать вычисленный результат.

    /// <summary>
    /// Площадь треугольника.
    /// </summary>
    public override double Square
    {
      get
      {
        var semiPerimeter = (this.SideLength1 + this.SideLength2 + this.SideLength3) / 2;
        return Math.Sqrt(semiPerimeter * (semiPerimeter - this.SideLength1) * (semiPerimeter - this.SideLength2) * (semiPerimeter - this.SideLength3));
      }
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
