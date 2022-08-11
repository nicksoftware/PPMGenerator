using System.IO;
using System.Text;

namespace PPMGenerator.ImageSpace;

/**
* Image class
* 
* @author Nicolas Maluleke 
* @version 1.0
*/
public class Image
{
    private readonly int _rows;
    private readonly int _cols;
    private readonly Color[,] _pixels;

    /**
    * Image constructor
    *   
    * @param rows number of pixels in the image horizontally
    * @param cols number of pixels in the image vertically
    */

    public Image(int cols, int rows)
    {
        _cols = cols;
        _rows = rows;

        // Create an array of pixels
        _pixels = new Color[_rows, _cols];
    }

    /**
    * Set Pixel method
    *
    * @param x x-coordinate of the pixel
    * @param y y-coordinate of the pixel
    * @param color color of the pixel
    */
    public void SetPixel(int row, int col, Color pixel)
    {
        _pixels[row, col] = pixel;
    }

    /**
    * Get Pixel method
    *
    * @param x x-coordinate of the pixel
    * @param y y-coordinate of the pixel
    * @return color of the pixel
    */
    private Color GetPixel(int row, int col)
    {
        return _pixels[row, col];
    }

    /**
     * ClearCanvas method
     */
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

    /**
    * ClearCanvas method override 
    *
    * @param color the color to fill the image with
    */
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

    /**
    * ToPpmImage method
    *
    * @param filePath the path to the file to save the image to
    * @param fileName the name of the file to save the image to
    */
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