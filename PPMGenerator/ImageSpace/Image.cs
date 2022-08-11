using System;
using System.IO;
using System.Text;

namespace PPMGenerator.ImageSpace
{
    public class Image
    {
        private readonly int _rows;
        private readonly int _cols;
        private readonly Color[,] _pixels;

        public Image(int cols, int rows)
        {
            _cols = cols;
            _rows = rows;
            _pixels = new Color[_rows, _cols];
        }

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
                    if (drawX >= 0 && drawX < _rows && drawY >= 0 && drawY < _cols)
                    {
                        _pixels[drawX, drawY] = color;
                    }
                }
            }
        }
        public void SetPixel(int row, int col, Color pixel)
        {
            _pixels[row, col] = pixel;
        }

        private Color GetPixel(int row, int col)
        {
            return _pixels[row, col];
        }

        public void ClearCanvas()
        {
            Color color = new(255, 255, 255);

            for (int row = 0; row < _rows; row++)
            {
                for (int col = 0; col < _cols; col++)
                {

                    SetPixel(row, col, color);
                }
            }
        }
        public void ClearCanvas(Color color)
        {
            for (int row = 0; row < _rows; row++)
            {
                for (int col = 0; col < _cols; col++)
                {
                    SetPixel(row, col, color);
                }
            }
        }

        public void ToPpmImage(string filePath, string fileName = "ppmImage")
        {
            StringBuilder sb = new();
            sb.AppendLine("P3");
            sb.AppendLine($"{_cols} {_rows}");
            sb.AppendLine("255"); //Highest Color intensity

            string space = " ";
            for (int r = 0; r < _rows; r++)
            {
                for (int c = 0; c < _cols; c++)
                {
                    Color pixel = GetPixel(r, c);
                    sb.Append(pixel.Red);
                    sb.Append(space);
                    sb.Append(pixel.Green);
                    sb.Append(space);
                    sb.Append(pixel.Blue);
                    sb.AppendLine();
                }
            }
            string text = sb.ToString();
            string finalName = Path.Join(filePath, $"{fileName}.ppm");
            File.WriteAllText(finalName, text);
        }
    }
}