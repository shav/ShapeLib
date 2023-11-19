namespace ShapeLib
{
  /// <summary>
  /// Круг.
  /// </summary>
  public class Circle : Shape
  {
    /// <summary>
    /// Сообщение валидации о том, что радиус треугольника должен быть положительным.
    /// </summary>
    private const string RadiusPositiveValidationMessage = "Sides of triangle should be positive";

    // ВОПРОС: Для полноценного описания круга просто радиуса недостаточно, нужно указать еще центр круга.
    // Но для решения текущей задачи вычисления площади круга просто радиуса достаточно.
    // Предполагается ли дальнейшее развитие данной библиотеки для каких либо других задач,
    // в которых нужно было бы идентифицировать круг более точно (т.е. с указанием центра)?

    /// <summary>
    /// Радиус круга.
    /// </summary>
    public double Radius { get; }

    /// <summary>
    /// Площадь круга.
    /// </summary>
    public override double Square => Math.PI * Math.Pow(this.Radius, 2);

    /// <summary>
    /// Создать круг.
    /// </summary>
    /// <param name="radius">Радиус.</param>
    /// <exception cref="ArgumentOutOfRangeException">Если указан радиус меньше либо равный нулю.</exception>
    public Circle(double radius)
    {
      if (radius <= 0)
        throw new ArgumentOutOfRangeException(nameof(radius), RadiusPositiveValidationMessage);

      this.Radius = radius;
    }
  }
}
