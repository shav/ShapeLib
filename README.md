# ShapeLib
Библиотека предназначена для:
* описания различных геометрических фигур
* вычисления площади фигур
* проверки различных характеристик, которыми обладают фигуры

## Геометрическая фигура "Круг"
Круг задаётся своим радиусом (должен быть больше нуля):
```csharp
var circle = new Circle(radius: 10);
```
Для круга можно получить площадь фигуры:
```csharp
var square = circle.Square;
```
## Геометрическая фигура "Треугольник"
Треугольник задаётся длинами всех своих сторон.  
Все стороны должны иметь длину больше нуля. А также должно выполняться "неравенство треугольника": длина любой стороны треугольника не должна превышать сумму длин двух других сторон.
```csharp
var triangle = new Triangle(sideLength1: 3, sideLength2: 4, sideLength3: 5)
```
Для треугольника можно получить площадь фигуры:
```csharp
var square = triangle.Square;
```
А также можно проверить, является ли треугольник прямоугольным:
```csharp
triangle.IsOrthogonal;
```

## Разработка кастомных фигур
Для того, чтобы создать свою геометрическую фигуру, используя библиотеку ShapeLib, нужно отнаследовать класс кастомной фигуры от базового класса геометрических фигур **Shape** и переопределить свойство для получения площади фигуры **Square**.
```csharp
/// <summary>
/// Геометрическая фигура "Прямоугольник".
/// </summary>
public class Rectangle : Shape
{
  /// <summary>
  /// Ширина.
  /// </summary>
  public double Width { get; }
  
  /// <summary>
  /// Высота.
  /// </summary>
  public double Height { get; }
  
  /// <summary>
  /// Площадь фигуры.
  /// </summary>
  public override double Square => this.Width * this.Height;
  
  /// <summary>
  /// Создать прямоугольник.
  /// </summary>
  /// <param name="width">Ширина.</param>
  /// <param name="height">Высота.</param>
  /// <exception cref="ArgumentOutOfRangeException">Если стороны прямоугольника меньше либо равны нулю.</exception>
  public Rectangle(double width, double height)
  {
    if (width <= 0)
      throw new ArgumentOutOfRangeException(nameof(width), "Width of rectangle should be positive");
    
    if (height <= 0)
      throw new ArgumentOutOfRangeException(nameof(height), "Height of rectangle should be positive");
  
    this.Width = width;
    this.Height = height;
  }
}
```
