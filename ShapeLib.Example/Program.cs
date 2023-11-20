using ShapeLib;

var circle = new Circle(radius: 10);
var orthogonalTriangle = new Triangle(sideLength1: 3, sideLength2: 4, sideLength3: 5);
var regularTriangle = new Triangle(sideLength1: 2, sideLength2: 3, sideLength3: 4);

var shapes = new Shape[] { circle, regularTriangle, orthogonalTriangle };

foreach (var shape in shapes)
{
  Console.WriteLine($"Square of {shape}: {shape.Square}");
}
Console.WriteLine();

var triangles = shapes.OfType<Triangle>();
foreach (var triangle in triangles)
{
  Console.WriteLine(triangle.IsOrthogonal ? $"{triangle} is orthogonal" : $"{triangle} is not orthogonal");
}