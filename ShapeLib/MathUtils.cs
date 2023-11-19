namespace ShapeLib
{
  /// <summary>
  /// Математические функции.
  /// </summary>
  internal static class MathUtils
  {
    /// <summary>
    /// Проверить, являются ли два вещественных числа равными (с некоторой точностью).
    /// </summary>
    /// <param name="value1">Первое число.</param>
    /// <param name="value2">Второе число.</param>
    /// <param name="accuracy">Точность сравнения.</param>
    /// <returns>True - если числа равны (с указанной точностью), False - иначе.</returns>
    public static bool IsApproximatelyEqual(double value1, double value2, double accuracy = 2 * double.Epsilon)
    {
      return Math.Abs(value1 - value2) < accuracy;
    }
  }
}
