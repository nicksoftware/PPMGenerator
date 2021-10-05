using System;
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
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Colour pixel = new Colour(rollDice.Next(0,255), rollDice.Next(0,255), rollDice.Next(0,255));
                    image.SetPixel(r, c, pixel);
                }
            }

            image.ToPpmImage();
        }
    }
}