using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        }
        private bool AreColorsSimilar(Color color1, Color color2)
        {
            int rDiff = Math.Abs(color1.R - color2.R);
            int gDiff = Math.Abs(color1.G - color2.G);
            int bDiff = Math.Abs(color1.B - color2.B);

            int threshold = 30;

            return rDiff < threshold && gDiff < threshold && bDiff < threshold;
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

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(imageBox.Image);
            int width = image.Width;
            int height = image.Height;
            int kernelSize = 3; // Use a 3x3 kernel (can be adjusted)
            int offset = kernelSize / 2; // Offset for center pixel in the kernel

            Bitmap newImage = new Bitmap(image); // Create a new image for the result

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

            // Now, count the shapes in the segmented image
            int shapeCount = CountShapes(newImage);
            label55.Text = shapeCount.ToString();
            imageBox.Image = newImage; // Display the segmented image
        }
        private int CountShapes(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;
            bool[,] visited = new bool[width, height];
            int shapeCount = 0;

            // Loop over every pixel in the image
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // If the pixel is black and hasn't been visited yet, it's part of a new shape
                    if (image.GetPixel(x, y).ToArgb() == Color.Black.ToArgb() && !visited[x, y])
                    {
                        // Perform a flood fill to mark all connected black pixels as visited
                        FloodFill(image, x, y, visited);
                        shapeCount++; // Increment shape count
                    }
                }
            }

            return shapeCount;
        }
        private void FloodFill(Bitmap image, int x, int y, bool[,] visited)
        {
            int width = image.Width;
            int height = image.Height;

            // Stack to hold the pixels to be processed (iterative flood fill)
            Stack<Point> stack = new Stack<Point>();
            stack.Push(new Point(x, y));

            while (stack.Count > 0)
            {
                Point point = stack.Pop();
                int px = point.X;
                int py = point.Y;

                // If the current pixel is out of bounds or already visited, skip it
                if (px < 0 || py < 0 || px >= width || py >= height || visited[px, py])
                {
                    continue;
                }

                // If the current pixel is black, mark it as visited
                if (image.GetPixel(px, py).ToArgb() == Color.Black.ToArgb())
                {
                    visited[px, py] = true;

                    // Push the neighboring pixels onto the stack
                    stack.Push(new Point(px + 1, py)); // Right
                    stack.Push(new Point(px - 1, py)); // Left
                    stack.Push(new Point(px, py + 1)); // Down
                    stack.Push(new Point(px, py - 1)); // Up
                }
            }
        }
    }
}
    
