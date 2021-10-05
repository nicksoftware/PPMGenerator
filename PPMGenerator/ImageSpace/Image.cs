using System;
using System.IO;
using System.Text;

namespace PPMGenerator.ImageSpace
{
    public class Image
    {
        private readonly int _rows;
        private readonly int _cols;
        private readonly Colour[,] _pixels;

        public Image(int cols, int rows)
        {
            _cols = cols;
            _rows = rows;
            _pixels = new Colour[_rows,_cols];
        }
        public void SetPixel(int row, int col, Colour pixel) => _pixels[row, col] = pixel;
        private Colour GetPixel(int row, int col) => _pixels[row, col];
        public void  ToPpmImage(string filePath,string fileName = "ppmImage")
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("P3");
            sb.AppendLine($"{_cols} {_rows}");
            sb.AppendLine("255"); //Highest Color intensity

            string space = " ";
            for (int r = 0; r < _rows; r++)
            {
                for (int c = 0; c < _cols; c++)
                {
                    var pixel = GetPixel(r, c);
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
            File.WriteAllText(finalName,text);
        }
    }
}