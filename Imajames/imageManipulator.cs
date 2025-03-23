﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Imajames
{
    public partial class imageManipulator : Form
    {
        public Bitmap usedImage;
        public imageManipulator()
        {
            InitializeComponent();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    imageBox.Image = new Bitmap(openFile.FileName);
                    usedImage = (Bitmap)imageBox.Image;
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void uploadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    imageBox.Image = new Bitmap(openFile.FileName);
                    usedImage = (Bitmap)imageBox.Image;
                }
            }
        }

        private void clearImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageBox.Image = null;
        }

        private void greyScaleButton_Click(object sender, EventArgs e)
        {
            toolControl.SelectedIndex = 0;
            label3.Text = "GREYSCALE PANEL";
        }


        private void blackAndWhiteButton_Click(object sender, EventArgs e)
        {
            toolControl.SelectedIndex = 1;
            label3.Text = "BLACK AND WHITE PANEL";
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            toolControl.SelectedIndex = 2;
            label3.Text = "FILTER PANEL";
        }
        private void rgbButton_Click(object sender, EventArgs e)
        {
            toolControl.SelectedIndex = 4;
            label3.Text = "RGB CONTROL PANEL";
        }
        private void imageEnhancerButton_Click(object sender, EventArgs e)
        {
            toolControl.SelectedIndex = 3;
            label3.Text = "IMAGE ENHANCER PANEL";
        }
        private void abButton_Click(object sender, EventArgs e)
        {
            toolControl.SelectedIndex = 5;
            label3.Text = "ADAPTIVE BINARIZATION PANEL";
        }
        private void segmentButton_Click(object sender, EventArgs e)
        {
            toolControl.SelectedIndex = 6;
            label3.Text = "SEGMENTATION PANEL";
        }

        private void gpButton_Click(object sender, EventArgs e)
        {
            toolControl.SelectedIndex = 7;
            label3.Text = "GEOMETRIC PROPERTIES PANEL";
        }

        private void sdButton_Click(object sender, EventArgs e)
        {
            toolControl.SelectedIndex = 8;
            label3.Text = "DETECTION TOOL PANEL";
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            label6.Text = imageBitCounter().ToString();
            Bitmap grayScaleBP = new System.Drawing.Bitmap(2, 2, System.Drawing.Imaging.PixelFormat.Format16bppGrayScale);
            Bitmap picture = new Bitmap(imageBox.Image);
            int x, y;
            for (x = 0; x < picture.Width; x++)
            {
                for (y = 0; y < picture.Height; y++)
                {
                    Color oldColor = picture.GetPixel(x, y);
                    int col = (int)((oldColor.R * 0.299) + (oldColor.G * 0.587) + (oldColor.B * 0.114));
                    Color newColor = Color.FromArgb(col, col, col);
                    picture.SetPixel(x, y, newColor);
                }
            }
            imageBox.Image = picture;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            label6.Text = imageBitCounter().ToString();
            Bitmap picture = new Bitmap(imageBox.Image);
            int x, y;

            for (x = 0; x < picture.Width; x++)
            {
                for (y = 0; y < picture.Height; y++)
                {
                    Color oldColor = picture.GetPixel(x, y);
                    int threshold = (int)((oldColor.R + oldColor.G + oldColor.B) / 3);
                    Color newColor = Color.FromArgb(threshold, threshold, threshold);
                    picture.SetPixel(x, y, newColor);

                }
            }
            imageBox.Image = picture;
        }

        private void bnaButton_Click(object sender, EventArgs e)
        {
            label7.Text = imageBitCounter().ToString();
            Bitmap imageBoxPicture = new Bitmap(imageBox.Image);
            int rows, cols;
            int blackCount = 0;
            int whiteCount = 0;
            //access the left to right part of the matrix
            for (rows = 0; rows < imageBoxPicture.Width; rows++)
            {
                //access the top to bottom part of the matrix
                for (cols = 0; cols < imageBoxPicture.Height; cols++)
                {
                    //create formula
                    Color newColor = imageBoxPicture.GetPixel(rows, cols);
                    int threshold = (int)((newColor.R + newColor.G + newColor.B) / 3);
                    if (threshold < 130)
                    {
                        imageBoxPicture.SetPixel(rows, cols, Color.Black);
                        blackCount++;
                    }
                    else
                    {
                        imageBoxPicture.SetPixel(rows, cols, Color.White);
                        whiteCount++;
                    }
                }
            }
            Bitmap finalImage = imageBoxPicture;
            imageBox.Image = finalImage;
            label11.Text = blackCount.ToString();
            label12.Text = whiteCount.ToString();
        }
        double colorR;
        double colorG;
        double colorB;
        private void randoFilter_Click(object sender, EventArgs e)
        {
            label17.Text = imageBitCounter().ToString();
            Random rand = new Random();

            Bitmap imageUse = new Bitmap(imageBox.Image);
            int rows, cols;
            int count = 0;


            for (count = 1; count <= 3; count++)
            {

                if (count == 1)
                {
                    this.colorR = rand.NextDouble() + 0.1;
                }
                else if (count == 2)
                {
                    this.colorG = rand.NextDouble() + 0.1;
                }
                else if (count == 3)
                {
                    this.colorB = rand.NextDouble() + 0.1;
                }
            }
            label14.Text = colorR.ToString("F3");
            label25.Text = colorR.ToString("F3");
            label26.Text = colorB.ToString("F3");
            for (rows = 0; rows < imageUse.Width; rows++)
            {
                for (cols = 0; cols < imageUse.Height; cols++)
                {
                    Color setColor = imageUse.GetPixel(rows, cols);
                    int threshold = (int)((setColor.R + setColor.G + setColor.B) / 3);

                    Color newColor = Color.FromArgb((int)(Math.Min(255, setColor.R * colorR)), (int)(Math.Min(255, setColor.G * colorG)), (int)(Math.Min(255, setColor.B * colorB)));
                    imageUse.SetPixel(rows, cols, newColor);
                    count = 0;
                }
            }
            imageBox.Image = imageUse;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            label17.Text = imageBitCounter().ToString();
            Bitmap newPicture = new Bitmap(imageBox.Image);
            int rows, cols;

            double red = (rBar.Value / 100);
            double green = (gBar.Value / 100);
            double blue = (bBar.Value / 100);
            for (rows = 0; rows < newPicture.Width; rows++)
            {
                for (cols = 0; cols < newPicture.Height; cols++)
                {
                    Color newColor = newPicture.GetPixel(rows, cols);
                    Color uploadColor = Color.FromArgb(Math.Min(255, (int)(red * newColor.R)), Math.Min(255, (int)(green * newColor.G)), Math.Min(255, (int)(blue * newColor.B)));
                    newPicture.SetPixel(rows, cols, uploadColor);
                }
            }
            imageBox.Image = newPicture;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label33.Text = imageBitCounter().ToString();
            Bitmap imageHolder = new Bitmap(imageBox.Image);
            imageBox.Image = opacityAdjuster(imageHolder, opacityBar.Value);
        }
        public static Bitmap opacityAdjuster(Bitmap bmp, int alphaValue)
        {
            int rows, cols;
            for (rows = 0; rows < bmp.Height; rows++)
            {
                for (cols = 0; cols < bmp.Width; cols++)
                {
                    Color newColor = bmp.GetPixel(cols, rows);
                    //bago pako kahibaw na naa diay alpha, change the alpha value for opacity
                    Color opacityChange = Color.FromArgb(alphaValue, newColor.R, newColor.G, newColor.B);
                    bmp.SetPixel(cols, rows, opacityChange);
                }
            }
            return bmp;
        }
        private void button7_Click_2(object sender, EventArgs e)
        {
            label33.Text = imageBitCounter().ToString();
            Bitmap imageHolder = new Bitmap(imageBox.Image);
            imageBox.Image = brightnessAdjuster(imageHolder, brightnessBar.Value);
        }
        public static Bitmap brightnessAdjuster(Bitmap bmpBrightness, int brightValue)
        {
            int rows, cols;

            for (rows = 0; rows < bmpBrightness.Width; rows++)
            {
                for (cols = 0; cols < bmpBrightness.Height; cols++)
                {
                    //funny kaayo ang solution, add ra diay para mo mas duol sa 255(white)
                    //additional note: ayaw pag chat gpt kay hsl gihatag, ga lisod lisod
                    Color currentColor = bmpBrightness.GetPixel(rows, cols);
                    int newR = currentColor.R + (brightValue);
                    int newG = currentColor.G + (brightValue);
                    int newB = currentColor.B + (brightValue);
                    (newR, newG, newB) = Checker(newR, newG, newB);
                    Color newColor = Color.FromArgb(newR, newG, newB);
                    bmpBrightness.SetPixel(rows, cols, newColor); ;

                }
            }

            return bmpBrightness;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            label33.Text = imageBitCounter().ToString();
            Bitmap imageHolder = new Bitmap(imageBox.Image);
            imageBox.Image = contrastAdjuster(imageHolder, contrastBar.Value);
        }
        public static Bitmap contrastAdjuster(Bitmap bmpContrast, float contValue)
        {
            int rows, cols;

            for (rows = 0; rows < bmpContrast.Height; rows++)
            {
                for (cols = 0; cols < bmpContrast.Width; cols++)
                {
                    Color newColor = bmpContrast.GetPixel(cols, rows);

                    //formula found online, basta subtract current color by half of 255 and multiply by contrast plus half of 255 again
                    int newR = (int)((newColor.R - (255 / 2)) * contValue + (255 / 2));
                    newR = Math.Min(255, Math.Max(0, newR));
                    int newG = (int)((newColor.G - (255 / 2)) * contValue + (255 / 2));
                    newG = Math.Min(255, Math.Max(0, newG));
                    int newB = (int)((newColor.B - (255 / 2)) * contValue + (255 / 2));
                    newB = Math.Min(255, Math.Max(0, newB));

                    bmpContrast.SetPixel(cols, rows, Color.FromArgb(newR, newG, newB));
                }
            }
            return bmpContrast;
        }
        private void button9_Click_1(object sender, EventArgs e)
        {
            label33.Text = imageBitCounter().ToString();
            Bitmap imageHolder = new Bitmap(imageBox.Image);
            imageBox.Image = saturationAdjuster(imageHolder, saturationBar.Value);
        }
        public static Bitmap saturationAdjuster(Bitmap bmpSaturation, float satValue)
        {
            if (satValue == 0)
            {
                return bmpSaturation;
            }
            int rows, cols;
            for (rows = 0; rows < bmpSaturation.Height; rows++)
            {
                for (cols = 0; cols < bmpSaturation.Width; cols++)
                {
                    Color newColor = bmpSaturation.GetPixel(cols, rows);
                    int newR = newColor.R;
                    int newG = newColor.G;
                    int newB = newColor.B;
                    float greyLuminance = 0.3f * newColor.R + 0.59f * newColor.G + 0.11f * newColor.B;
                    newR = (int)(greyLuminance + (newR - greyLuminance) * satValue);
                    newG = (int)(greyLuminance + (newG - greyLuminance) * satValue);
                    newB = (int)(greyLuminance + (newB - greyLuminance) * satValue);
                    //laziness by jems
                    (newR, newG, newB) = Checker(newR, newG, newB);

                    Color newColor1 = Color.FromArgb(newR, newG, newB);
                    bmpSaturation.SetPixel(cols, rows, newColor1); ;
                }
            }
            return bmpSaturation;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            label33.Text = imageBitCounter().ToString();
            Bitmap imageHolder = new Bitmap(imageBox.Image);
            imageBox.Image = applyBlur(imageHolder, blurBar.Value);
        }
        //public static Bitmap blurAdjuster(Bitmap bmpBlur, int blurValue)
        //{
        //    if (blurValue == 0)
        //    {
        //        return bmpBlur;
        //    }
        //    int rows, cols;
        //    for (rows = 1; rows < bmpBlur.Height - 1; rows++)
        //    {
        //        for (cols = 1; cols < bmpBlur.Width - 1; cols++)
        //        {
        //            //gaussian blurrr mah g

        //            float[,] matrixData = new float[3, 3]
        //            {
        //                { 0.0625f, 0.125f, 0.0625f },
        //                { 0.125f, 0.25f, 0.125f },
        //                { 0.0625f, 0.125f, 0.0625f }
        //            };
        //            float newR = 0;
        //            float newG = 0;
        //            float newB = 0;

        //            for (int kernelRow = -1; kernelRow <= 1; kernelRow++)
        //            {
        //                for (int kernelCol = -1; kernelCol <= 1; kernelCol++)
        //                {
        //                    Color pixelColor = bmpBlur.GetPixel(cols + kernelCol, rows + kernelRow);
        //                    float kernelValue = matrixData[kernelRow + 1, kernelCol + 1];

        //                    newR += (pixelColor.R * kernelValue);
        //                    newG += (pixelColor.G * kernelValue);
        //                    newB += (pixelColor.B * kernelValue);
        //                }
        //                (newR, newG, newB) = Checker(newR, newG, newB);

        //                bmpBlur.SetPixel(cols, rows, Color.FromArgb((int)newR, (int)newG, (int)newB));
        //            }
        //        }
        //    }
        //    return bmpBlur;
        //}
        public Bitmap applyBlur(Bitmap image, int blurValue)
        {
            int width = image.Width;
            int height = image.Height;
            Bitmap blurredImage = new Bitmap(width, height);

            int kernelSize = (int)(blurValue / 17);
            kernelSize = Math.Max(1, Math.Min(kernelSize, 15));

            int kernelArea = kernelSize * kernelSize;

            int[,] kernel = new int[kernelSize, kernelSize];
            for (int i = 0; i < kernelSize; i++)
            {
                for (int j = 0; j < kernelSize; j++)
                {
                    kernel[i, j] = 1;
                }
            }

            for (int x = kernelSize / 2; x < width - (kernelSize / 2); x++)
            {
                for (int y = kernelSize / 2; y < height - (kernelSize / 2); y++)
                {
                    int r = 0, g = 0, b = 0;

                    for (int dx = -kernelSize / 2; dx <= kernelSize / 2; dx++)
                    {
                        for (int dy = -kernelSize / 2; dy <= kernelSize / 2; dy++)
                        {
                            int kernelX = dx + kernelSize / 2;
                            int kernelY = dy + kernelSize / 2;

                            if (kernelX >= 0 && kernelX < kernelSize && kernelY >= 0 && kernelY < kernelSize)
                            {
                                Color pixelColor = image.GetPixel(x + dx, y + dy);
                                r += pixelColor.R * kernel[kernelX, kernelY];
                                g += pixelColor.G * kernel[kernelX, kernelY];
                                b += pixelColor.B * kernel[kernelX, kernelY];
                            }
                        }
                    }

                    r /= kernelArea;
                    g /= kernelArea;
                    b /= kernelArea;

                    blurredImage.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return blurredImage;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label53.Text = imageBitCounter().ToString();
            Bitmap imageUse = new Bitmap(imageBox.Image);
            int matrixDim = 3;
            int blackCount = 0;
            int whiteCount = 0;
            for (int rows = 0; rows < imageUse.Width; rows++)
            {
                for (int cols = 0; cols < imageUse.Height; cols++)
                {
                    int localSum = 0;
                    int counter = 0;

                    for (int i = -matrixDim; i <= matrixDim; i++)
                    {
                        for (int j = -matrixDim; j <= matrixDim; j++)
                        {
                            int x = rows + i;
                            int y = cols + j;
                            //the formulas are chatGPT'd, I didnt get what the expected output was at first
                            //i thought we would dynamicaly change the threshold while processing
                            //i now realize that di siya mao, thanks chatGPT for clarifying
                            //structure of logic was made by student, the formulas were not
                            if ((x >= 0) && (x < imageUse.Width) && (y >= 0) && (y < imageUse.Height))
                            {
                                Color neighborColor = imageUse.GetPixel(x, y);
                                int intensity = (neighborColor.R + neighborColor.G + neighborColor.B) / 3;
                                localSum += intensity;
                                counter++;
                            }
                        }
                    }

                    int localThreshold = localSum / counter;

                    Color originalColor = imageUse.GetPixel(rows, cols);
                    int pixelIntensity = (originalColor.R + originalColor.G + originalColor.B) / 3;

                    if (pixelIntensity > localThreshold)
                    {
                        imageUse.SetPixel(rows, cols, Color.White);
                        whiteCount++;
                    }
                    else
                    {
                        imageUse.SetPixel(rows, cols, Color.Black);
                        blackCount++;
                    }
                }
            }
            label51.Text = blackCount.ToString();
            label52.Text = whiteCount.ToString();
            imageBox.Image = imageUse;
        }

        //OVERALL FUNCTIONS
        private int imageBitCounter()
        {
            Bitmap pictureCount = new Bitmap(imageBox.Image);

            int x, y, count;
            count = 0;
            for (x = 0; x < pictureCount.Width; x++)
            {
                for (y = 0; y < pictureCount.Height; y++)
                {
                    count++;
                }
            }
            return count;
        }
        private static (int, int) imageBitMiddleCounter(Bitmap bmp)
        {
            
            int x, y;
            int xCount=0, yCount=0;
            for (x = 0; x < bmp.Width; x++)
            {
                xCount++;
                for (y = 0; y < bmp.Height; y++)
                {
                    yCount++;
                }
            }
            return (xCount, yCount);
        }

        private void removeEdigtsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageBox.Image = usedImage;
        }
        public static (int, int, int) Checker(int newR, int newG, int newB)
        {
            //values na gi butangan ug min max
            newR = Math.Min(255, Math.Max(0, newR));
            newG = Math.Min(255, Math.Max(0, newG));
            newB = Math.Min(255, Math.Max(0, newB));
            //values na i hatag, karon pa ni nako na discover na pwede multiple returns, lamat chatgpt sa idea  
            return (newR, newG, newB);
        }
        public static (float, float, float) Checker(float newR, float newG, float newB)
        {
            //values na gi butangan ug min max
            newR = Math.Min(255, Math.Max(0, newR));
            newG = Math.Min(255, Math.Max(0, newG));
            newB = Math.Min(255, Math.Max(0, newB));
            //values na i hatag, karon pa ni nako na discover na pwede multiple returns, lamat chatgpt sa idea  
            return (newR, newG, newB);
        }


        //SCROLL BARS
        private void rBar_Scroll(object sender, EventArgs e)
        {
            label39.Text = rBar.Value.ToString();
        }

        private void gBar_Scroll(object sender, EventArgs e)
        {
            label36.Text = gBar.Value.ToString();
        }

        private void bBar_Scroll(object sender, EventArgs e)
        {
            label28.Text = bBar.Value.ToString();
        }
        private void opacityBar_Scroll(object sender, EventArgs e)
        {
            label31.Text = opacityBar.Value.ToString();
        }
        private void brightnessBar_Scroll(object sender, EventArgs e)
        {
            label35.Text = brightnessBar.Value.ToString();
        }

        private void contrastBar_Scroll(object sender, EventArgs e)
        {
            label27.Text = contrastBar.Value.ToString();
        }

        private void saturationBar_Scroll(object sender, EventArgs e)
        {
            label43.Text = saturationBar.Value.ToString();
        }

        private void blurBar_Scroll(object sender, EventArgs e)
        {
            label45.Text = blurBar.Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap newImage = new Bitmap(imageBox.Image);
            double averageLumen = luminousityDetector(newImage);
            for (int cols = 0; cols < newImage.Height; cols++)
            {
                for (int rows = 0; rows < newImage.Width; rows++)
                {
                    Color pixelColor = newImage.GetPixel(rows, cols);

                    int luminosity = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);

                    if (averageLumen > luminosity)
                    {
                        //Color setColor = newImage.GetPixel(rows, cols);
                        //int threshold = (int)((setColor.R + setColor.G + setColor.B) / 3);
                        //int colorR = (int)(setColor.R * 0.3);
                        //int colorG = (int)(setColor.G * 0.45);
                        //int colorB = (int)(setColor.B * 0.99);
                        //Color newColor = Color.FromArgb(colorR, colorG, colorB);
                        //newImage.SetPixel(rows, cols, newColor);
                        newImage.SetPixel(rows, cols, Color.Black);
                    }
                    else
                    {
                    }
                }
            }
            imageBox.Image = newImage;
        }
        private static double luminousityDetector(Bitmap bmp)
        {
            long totalLuminosity = 0;
            int pixelCount = 0;

            for (int cols = 0; cols < bmp.Height; cols++)
            {
                for (int rows = 0; rows < bmp.Width; rows++)
                {
                    Color pixelColor = bmp.GetPixel(rows, cols);

                    int luminosity = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);

                    totalLuminosity += luminosity;
                    pixelCount++;
                }
            }

            double averageLuminosity = (double)totalLuminosity / pixelCount;
            return averageLuminosity;
        }

        //MIDTERMS 
        public class ShapeProperties
        {
            public int Width { get; set; }
            public int Height { get; set; }
            public double AspectRatio { get; set; }
            public int Area { get; set; }
            public int Perimeter { get; set; }
            public Rectangle BoundingBox { get; set; }
        }
        private Dictionary<string, int> CountColors(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;

            // Dictionary to store color counts
            Dictionary<string, int> colorCounts = new Dictionary<string, int>();

            // Loop over each pixel in the image
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);

                    // Convert color to a string key (you can use the ARGB value or RGB)
                    string colorKey = $"{pixelColor.R},{pixelColor.G},{pixelColor.B}";

                    // Increment color count in the dictionary
                    if (colorCounts.ContainsKey(colorKey))
                    {
                        colorCounts[colorKey]++;
                    }
                    else
                    {
                        colorCounts[colorKey] = 1;
                    }
                }
            }

            return colorCounts;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(imageBox.Image);
            int width = image.Width;
            int height = image.Height;
            int kernelSize = 3;
            int offset = kernelSize / 2; 

            Bitmap newImage = new Bitmap(image); 

            // Loop over each pixel in the image
            for (int y = offset; y < height - offset; y++)
            {
                for (int x = offset; x < width - offset; x++)
                {
                    Color centerColor = image.GetPixel(x, y);
                    bool allPixelsSimilar = true;

                    // Check all pixels in the kernel around the center pixel
                    for (int ky = -offset; ky <= offset; ky++)
                    {
                        for (int kx = -offset; kx <= offset; kx++)
                        {
                            Color neighborColor = image.GetPixel(x + kx, y + ky);

                            // If any neighboring pixel is different from the center, break the loop
                            if (!AreColorsSimilar(centerColor, neighborColor))
                            {
                                allPixelsSimilar = false;
                                break;
                            }
                        }
                        if (!allPixelsSimilar)
                        {
                            break;
                        }
                    }

                    // If the kernel contains only similar colors, change the center color and its neighbors to black
                    if (!allPixelsSimilar)
                    {
                        for (int ky = -offset; ky <= offset; ky++)
                        {
                            for (int kx = -offset; kx <= offset; kx++)
                            {
                                newImage.SetPixel(x + kx, y + ky, Color.Black);
                            }
                        }
                    }
                }
            }

            int circleCount, squareCount, rectangleCount, triangleCount;
            (circleCount, squareCount, rectangleCount, triangleCount) = CountShapes(newImage);

            

            label58.Text = circleCount.ToString();
            label60.Text = squareCount.ToString();
            label62.Text = triangleCount.ToString();
            label64.Text = rectangleCount.ToString();
            label55.Text = (squareCount + circleCount + rectangleCount + triangleCount).ToString();


            imageBox.Image = newImage;

        }
        private List<(string shapeType, string generalizedColor)> GetShapeColors(Bitmap image)
        {
            List<(string shapeType, string generalizedColor)> shapeColors = new List<(string, string)>();

            int width = image.Width;
            int height = image.Height;
            bool[,] visited = new bool[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (image.GetPixel(x, y).ToArgb() == Color.Black.ToArgb() && !visited[x, y])
                    {
                        List<Point> shapePixels = new List<Point>();
                        FloodFillAndRecord(image, x, y, visited, shapePixels);

                        ShapeProperties shape = ExtractShapeFeatures(shapePixels);

                        string shapeType = DetermineShapeType(shape);

                        string generalizedColor = GetAverageArgbColor(shapePixels, image);

                        shapeColors.Add((shapeType, generalizedColor));
                    }
                }
            }

            return shapeColors;
        }
        private string GetAverageArgbColor(List<Point> shapePixels, Bitmap image)
        {
            if (shapePixels.Count == 0)
            {
                return "0, 0, 0, 0";  
            }

            long totalA = 0, totalR = 0, totalG = 0, totalB = 0;
            int validPixelCount = 0; 

            foreach (var point in shapePixels)
            {
                Color color = image.GetPixel(point.X, point.Y);
                
                
                if (IsBlack(color))
                {
                    continue;  // Ignore black pixels (or nearly black pixels)
                }

                // Accumulate the ARGB values for averaging
                totalA += color.A;
                totalR += color.R;
                totalG += color.G;
                totalB += color.B;
                validPixelCount++;  // Increment for valid pixel
            }

            // If no valid (non-black) pixels were found, return a default color
            if (validPixelCount == 0)
            {
                return "0, 0, 0, 1";  // Transparent black or fallback color
            }

            // Calculate the average ARGB values for non-black pixels
            int avgA = (int)(totalA / validPixelCount);
            int avgR = (int)(totalR / validPixelCount);
            int avgG = (int)(totalG / validPixelCount);
            int avgB = (int)(totalB / validPixelCount);

            // Debug: Print the final average color

            // Return the average color as a string
            return $"{avgA}, {avgR}, {avgG}, {avgB}";
        }

        private bool IsBlack(Color color)
        {
            // Allow for a tolerance in RGB values for "black" pixels (e.g., very dark pixels)
            return (color.R < 10 && color.G < 10 && color.B < 10);  // Customize this threshold as needed
        }

        private string DetermineShapeType(ShapeProperties shape)
        {
            if (shape.AspectRatio > 0.9 && shape.AspectRatio < 1.1 && shape.Width == shape.Height)
            {
                return "Square";
            }
            else if (shape.AspectRatio > 0.9 && shape.AspectRatio < 1.1)
            {
                return "Circle";
            }
            else if (shape.Width != shape.Height)
            {
                return "Rectangle";
            }
            else
            {
                return "Triangle";  
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            Bitmap newImage = new Bitmap(imageBox.Image);
            List<(string shapeType, string generalizedColor)> shapeColors = GetShapeColors(newImage);

            // Clear previous rows in DataGridView
            dataGridView1.Rows.Clear();

            // Add each shape's type and its generalized ARGB color to the DataGridView
            foreach (var shapeColor in shapeColors)
            {
                dataGridView1.Rows.Add(shapeColor.shapeType, shapeColor.generalizedColor);
            }
        }

        private (int circleCount, int squareCount, int rectangleCount, int triangleCount) CountShapes(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;
            bool[,] visited = new bool[width, height];

            int circleCount = 0;
            int squareCount = 0;
            int rectangleCount = 0;
            int triangleCount = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (image.GetPixel(x, y).ToArgb() == Color.Black.ToArgb() && !visited[x, y])
                    {
                        List<Point> shapePixels = new List<Point>();
                        FloodFillAndRecord(image, x, y, visited, shapePixels);

                        ShapeProperties shape = ExtractShapeFeatures(shapePixels);

                        // Classification based on area and aspect ratio
                        if (shape.AspectRatio > 0.9 && shape.AspectRatio < 1.1 && shape.Width == shape.Height)
                        {
                            // It's a square
                            squareCount++;
                        }
                        else if (shape.AspectRatio > 0.9 && shape.AspectRatio < 1.1)
                        {
                            // It's a circle (aspect ratio close to 1)
                            circleCount++;
                        }
                        else if (shape.Width != shape.Height)
                        {
                            // It's a rectangle
                            rectangleCount++;
                        }
                        else
                        {
                            // Triangle (more advanced detection needed)
                            triangleCount++;
                        }
                    }
                }
            }

            return (circleCount, squareCount, rectangleCount, triangleCount);
        }


        private void FloodFillAndRecord(Bitmap image, int x, int y, bool[,] visited, List<Point> shapePixels)
        {
            int width = image.Width;
            int height = image.Height;

            Stack<Point> stack = new Stack<Point>();
            stack.Push(new Point(x, y));  // Start the flood fill from the initial point.

            // While there are points in the stack
            while (stack.Count > 0)
            {
                Point point = stack.Pop();
                int px = point.X;
                int py = point.Y;

                if (px < 0 || py < 0 || px >= width || py >= height || visited[px, py])
                {
                    continue;
                }

                if (image.GetPixel(px, py).ToArgb() == Color.Black.ToArgb())
                {
                    visited[px, py] = true;
                    shapePixels.Add(point);  

                    stack.Push(new Point(px + 1, py));  
                    stack.Push(new Point(px - 1, py));  
                    stack.Push(new Point(px, py + 1)); 
                    stack.Push(new Point(px, py - 1));
                }
            }
        }

        private ShapeProperties ExtractShapeFeatures(List<Point> shapePixels)
        {
            int minX = shapePixels.Min(p => p.X);
            int maxX = shapePixels.Max(p => p.X);
            int minY = shapePixels.Min(p => p.Y);
            int maxY = shapePixels.Max(p => p.Y);

            int area = shapePixels.Count;

            int perimeter = 0;
            foreach (var point in shapePixels)
            {
                int x = point.X;
                int y = point.Y;

                if (IsEdgePixel(x, y, shapePixels))
                {
                    perimeter++;
                }
            }

            int width = maxX - minX + 1;
            int height = maxY - minY + 1;
            double aspectRatio = (double)width / height;

            return new ShapeProperties
            {
                Area = area,
                Perimeter = perimeter,
                BoundingBox = new Rectangle(minX, minY, width, height),
                AspectRatio = aspectRatio
            };
        }

        private bool IsEdgePixel(int x, int y, List<Point> shapePixels)
        {
            var neighbors = new List<Point>
    {
        new Point(x + 1, y),  
        new Point(x - 1, y),  
        new Point(x, y + 1), 
        new Point(x, y - 1)  
    };

            foreach (var neighbor in neighbors)
            {
                if (!shapePixels.Contains(neighbor))
                {
                    return true; 
                }
            }

            return false;  
        }

        private bool AreColorsSimilar(Color c1, Color c2)
        {
            return Math.Abs(c1.R - c2.R) < 20 && Math.Abs(c1.G - c2.G) < 20 && Math.Abs(c1.B - c2.B) < 20;
        }

        //IGNORE THIS POINT FORWARD

        private void button5_Click(object sender, EventArgs e)
        {
            int count = imageBitCounter();
            double area = (double)count / 1000;
            label65.Text = count.ToString();
            label69.Text = area.ToString()+"km^2";
            int x = 0, y = 0;

            Bitmap centering = new Bitmap(imageBox.Image);
            int width = centering.Width;
            int height = centering.Height;
            int centerX = width / 2;
            int centerY = height / 2;

            int radius = 2;

            for (int i = centerY - radius; i <= centerY + radius; i++)
            {
                for (int j = centerX - radius; j <= centerX + radius; j++)
                {
                    double distance = Math.Sqrt(Math.Pow(i - centerY, 2) + Math.Pow(j - centerX, 2));

                    if (distance <= radius)
                    {
                        if (i >= 0 && i < centering.Height && j >= 0 && j < centering.Width)
                        {
                            centering.SetPixel(j, i, Color.Red);
                        }
                    }
                }
            }
            imageBox.Image = centering;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(imageBox.Image);
            int width = image.Width;
            int height = image.Height;
            int kernelSize = 3; 
            int offset = kernelSize / 2; 

            Bitmap newImage = new Bitmap(image);
            for (int y = offset; y < height - offset; y++)
            {
                for (int x = offset; x < width - offset; x++)
                {
                    Color centerColor = image.GetPixel(x, y);
                    bool allPixelsSimilar = true;

                    for (int ky = -offset; ky <= offset; ky++)
                    {
                        for (int kx = -offset; kx <= offset; kx++)
                        {
                            Color neighborColor = image.GetPixel(x + kx, y + ky);

                            if (!AreColorsSimilar(centerColor, neighborColor))
                            {
                                allPixelsSimilar = false;
                                break;
                            }
                        }
                        if (!allPixelsSimilar)
                        {
                            break;
                        }
                    }

                    if (!allPixelsSimilar)
                    {
                        for (int ky = -offset; ky <= offset; ky++)
                        {
                            for (int kx = -offset; kx <= offset; kx++)
                            {
                                newImage.SetPixel(x + kx, y + ky, Color.Black);
                            }
                        }
                    }
                }
            }
            int circleCount, squareCount, rectangleCount, triangleCount;
            (circleCount, squareCount, rectangleCount, triangleCount) = CountShapes(newImage);
            label67.Text = (squareCount + circleCount + rectangleCount + triangleCount).ToString();

        }

       
    }
}
    
