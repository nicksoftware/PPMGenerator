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
            DrawCircle(rows / 2, cols / 2, (int)radius / 2, color);
            return this;
        }

        public FaceDrawer WithEye(int row, int col, Color color, string eye = "left")
        {
            WriteLine($"Drawing {eye} Eye Circle");
            DrawCircle(row, col, (int)radius / 8, color);
            return this;
        }
        public FaceDrawer WithNose(Color color)
        {
            WriteLine("Drawing Nose Circle");
            DrawCircle(rows / 2, cols / 2, (int)radius / 30, color);
            return this;
        }

        public FaceDrawer WithMouth(Color color)
        {
            WriteLine("Drawing mouth  Circle");

            DrawCircle(rows / 2, 400, (int)radius / 8, color);
            return this;
        }

        public void ToPpmImage(string filePath, string fileName = "face")
        {
            WriteLine("Writing PPM Image");
            image.ToPpmImage(filePath, fileName);
            WriteLine("Done");
        }

        public FaceDrawer ClearCanvas(Color color)
        {
            WriteLine("Clearing Canvas...");
            image.ClearCanvas(color);
            WriteLine("Canvas Cleared...");
            return this;
        }

        public Image ToImage()
        {
            WriteLine("Converting to Image...");
            return image;
        }

        /**
        * DrawCircle method
        *
        * @param x x-coordinate of the center of the circle
        * @param y y-coordinate of the center of the circle
        * @param radius radius of the circle
        * @param color color of the circle
        */
        public void DrawCircle(int row, int col, int radius, Color color)
        {
            const double PI = Math.PI;
            double d, angle, x1, y1;

            for (int i = row - radius; i <= row + radius; i++)
            {
                for (d = 0; d < 360; d += 0.1)
                {
                    angle = d;
                    x1 = radius * Math.Cos(angle * PI / 180);
                    y1 = radius * Math.Sin(angle * PI / 180);

                    int drawX = (int)(col + y1);
                    int drawY = (int)(row + x1);
                    if (drawX >= 0 && drawX < rows && drawY >= 0 && drawY < cols)
                    {
                        image.SetPixel(drawX, drawY, color);
                    }
                }
            }
        }
    }
}