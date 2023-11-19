using ShapeLib;

var circle = new Circle(10);
var orthogonalTriangle = new Triangle(3, 4, 5);
var regularTriangle = new Triangle(2, 3, 4);

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