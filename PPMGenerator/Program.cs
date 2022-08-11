using System;
using PPMGenerator.ImageSpace;

int rows = 600;
int cols = 600;
Image image = new(cols, rows);

int area = rows * cols;
double radius = Math.Sqrt(area / Math.PI);
Color pencilColor = new(128, 128, 128);

image.ClearCanvas(new Color(255, 255, 255));

System.Console.WriteLine("Drawing Face Circle");
image.DrawCircle(rows / 2, cols / 2, (int)radius / 2, pencilColor);

System.Console.WriteLine("Drawing Left Eye Circle");
image.DrawCircle(220, 240, (int)radius / 8, pencilColor);


System.Console.WriteLine("Drawing Left Eye Circle");
image.DrawCircle(rows - 220, 240, (int)radius / 8, pencilColor);


System.Console.WriteLine("Drawing Nose Circle");
image.DrawCircle(300, cols / 2, (int)radius / 30, pencilColor);


System.Console.WriteLine("Drawing mouth  Circle");
image.DrawCircle(rows / 2, 400, (int)radius / 8, pencilColor);

string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

image.ToPpmImage(filePath);
