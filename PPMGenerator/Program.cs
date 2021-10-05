using System;
using System.IO;
using System.Threading.Tasks;
using PPMGenerator.ImageSpace;

namespace PPMGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = 400;
            int cols = 200;
            var image = new Image(cols, rows);
            var rollDice = new Random();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    var red = rollDice.Next(0, 255);
                    var green = rollDice.Next(0, 255);
                    var blue = rollDice.Next(0, 255);
                    Colour pixel = new Colour(red, green,blue);
                    image.SetPixel(row, col, pixel);
                }
            }
            var filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            image.ToPpmImage(filePath);
        }
    }
}