using System;
using PPMGenerator;
using PPMGenerator.ImageSpace;

int imageWidth = 400;
int imageHeight = 400;

Color faceColor = new(128, 128, 128);
Color eyeColor = new(99, 78, 52);
Color pupilColor = new(50, 26, 24);
Color noseColor = eyeColor;
Color mouthColor = new(102, 51, 0);
string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

new FaceDrawer(imageWidth, imageHeight)
    .ClearCanvas(new Color(255, 255, 255))
    .WithFace(faceColor)
    .WithEye(eyeColor, pupilColor, Eye.Left)
    .WithEye(eyeColor, pupilColor, Eye.Right)
    .WithNose(noseColor)
    .WithMouth(mouthColor, Mouth.Open)
    .ToPpmImage(filePath);