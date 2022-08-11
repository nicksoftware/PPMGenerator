using System;
using PPMGenerator;
using PPMGenerator.ImageSpace;

int rows = 600;
int cols = 600;

Color pencilColor = new(128, 128, 128);
string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

new FaceDrawer(rows, cols)
.ClearCanvas(new Color(255, 255, 255))
.WithFace(pencilColor)
.WithEye(rows - 220, 240, pencilColor, "left")
.WithEye(220, 240, pencilColor, "right")
.WithNose(pencilColor)
.WithMouth(pencilColor)
.ToPpmImage(filePath);