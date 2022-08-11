using System;
using PPMGenerator.ImageSpace;
using static System.Console;

namespace PPMGenerator
{
    public class FaceDrawer
    {
        private readonly int rows;
        private readonly int cols;
        private readonly Image image;
        private readonly int area = int.MinValue;
        private readonly double radius = double.MinValue;
        private readonly Color pencilColor = new(128, 128, 128);

        public FaceDrawer(int rows = 600, int cols = 600)
        {
            this.rows = rows;
            this.cols = cols;
            area = rows * cols;
            radius = Math.Sqrt(area / Math.PI);
            image = new(cols, rows);
        }

        public FaceDrawer WithFace(Color color)
        {
            WriteLine("Drawing Face Circle");
            image.DrawCircle(rows / 2, cols / 2, (int)radius / 2, pencilColor);
            return this;
        }

        public FaceDrawer WithEye(int row, int col, Color color, string eye = "left")
        {
            WriteLine($"Drawing {eye} Eye Circle");
            image.DrawCircle(row, col, (int)radius / 8, color);
            return this;
        }
        public FaceDrawer WithNose(Color color)
        {
            WriteLine("Drawing Nose Circle");
            image.DrawCircle(rows / 2, cols / 2, (int)radius / 30, color);
            return this;
        }

        public FaceDrawer WithMouth(Color color)
        {
            WriteLine("Drawing mouth  Circle");

            image.DrawCircle(rows / 2, 400, (int)radius / 8, color);
            return this;
        }

        public void ToPpmImage(string filePath, string fileName = "face.ppm")
        {
            image.ToPpmImage(filePath, fileName);
        }

        public FaceDrawer ClearCanvas(Color color)
        {
            image.ClearCanvas(color);
            return this;
        }

        public Image ToImage()
        {
            return image;
        }
    }
}