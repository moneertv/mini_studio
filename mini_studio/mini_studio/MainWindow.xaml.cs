using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mini_studio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        OpenFileDialog op;
        Boolean isopen = false;
        Bitmap bitmap;

        BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        void openImg()
        {
            op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                img.Source = new BitmapImage(new Uri(op.FileName));
                string filename = Convert.ToString(op.FileName);
                bitmap = new Bitmap(filename);
                isopen = true;
            }
        }

        void reload()
        {
            if (isopen)
            {
                img.Source = new BitmapImage(new Uri(op.FileName));
                string filename = Convert.ToString(op.FileName);
                bitmap = new Bitmap(filename);
            }
            else
            {
                MessageBox.Show("Open an image first !");
            }
        }

        void saveImg()
        {
            if (isopen == true)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Title = "Save image";
                save.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                  "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                  "Portable Network Graphic (*.png)|*.png";
                ImageFormat format = ImageFormat.Jpeg;
                if (save.ShowDialog() == true)
                {
                    string ext = System.IO.Path.GetExtension(save.FileName);
                    switch (ext)
                    {
                        case ".png":
                            format = ImageFormat.Png;
                            break;
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                        default:
                            format = ImageFormat.Jpeg;
                            break;
                    }
                    bitmap.Save(save.FileName, format);
                }
                MessageBox.Show("The image was saved sucssefully !");
            }
            else
            {
                MessageBox.Show("Open an image first !");
            }
        }

        void grayFilter()
        {
            if(isopen == true)
            {
                ImageAttributes ia = new ImageAttributes();
                ColorMatrix nc = new ColorMatrix(new float[][]
                {
                    new float[]{0.3f, 0.3f, 0.3f, 0, 0},
                    new float[]{0.6f, 0.6f, 0.6f, 0, 0},
                    new float[]{0.1f, 0.1f, 0.1f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 0}
                });
                ia.SetColorMatrix(nc);
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawImage(bitmap, new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                img.Source = BitmapToImageSource(bitmap); 
            }
            else
            {
                MessageBox.Show("Open an image first !");
            }
        }

        void springFilter()
        {
            if (isopen == true)
            {
                ImageAttributes ia = new ImageAttributes();
                ColorMatrix nc = new ColorMatrix(new float[][]
                {
                    new float[]{0.8f, 0, 0, 0, 0},
                    new float[]{0, 1, 0, 0, 0},
                    new float[]{0, 0, 0.8f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0.1f, 0, 0, 0}
                });
                ia.SetColorMatrix(nc);
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawImage(bitmap, new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                img.Source = BitmapToImageSource(bitmap);
            }
            else
            {
                MessageBox.Show("Open an image first !");
            }
        }

        void winterFilter()
        {
            if (isopen == true)
            {
                ImageAttributes ia = new ImageAttributes();
                ColorMatrix nc = new ColorMatrix(new float[][]
                {
                    new float[]{0.8f, 0, 0, 0, 0},
                    new float[]{0, 0.8f, 0, 0, 0},
                    new float[]{0, 0, 1, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(nc);
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawImage(bitmap, new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                img.Source = BitmapToImageSource(bitmap);
            }
            else
            {
                MessageBox.Show("Open an image first !");
            }
        }

        void automFilter()
        {
            if (isopen == true)
            {
                ImageAttributes ia = new ImageAttributes();
                ColorMatrix nc = new ColorMatrix(new float[][]
                {
                    new float[]{1f, 0, 0, 0, 0},
                    new float[]{0, 0.6f, 0, 0, 0},
                    new float[]{0, 0, 0.4f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0.1f, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(nc);
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawImage(bitmap, new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                img.Source = BitmapToImageSource(bitmap);
            }
            else
            {
                MessageBox.Show("Open an image first !");
            }

        }

        void summerFilter()
        {
            if (isopen == true)
            {
                ImageAttributes ia = new ImageAttributes();
                ColorMatrix nc = new ColorMatrix(new float[][]
                {
                    new float[]{1, 0, 0, 0, 0},
                    new float[]{0, 0.8f, 0, 0, 0},
                    new float[]{0, 0, 0.4f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(nc);
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawImage(bitmap, new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                img.Source = BitmapToImageSource(bitmap);
            }
            else
            {
                MessageBox.Show("Open an image first !");
            }
        }

        void fogFilter()
        {
            if (isopen == true)
            {
                ImageAttributes ia = new ImageAttributes();
                ColorMatrix nc = new ColorMatrix(new float[][]
                {
                    new float[]{1+0.3f, 0, 0, 0, 0},
                    new float[]{0, 1+0.7f, 0, 0, 0},
                    new float[]{0, 0, 1+1.3f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(nc);
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawImage(bitmap, new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                img.Source = BitmapToImageSource(bitmap);
            }
            else
            {
                MessageBox.Show("Open an image first !");
            }
        }

        void negativeFilter()
        {
            if (isopen == true)
            {
                ImageAttributes ia = new ImageAttributes();
                ColorMatrix nc = new ColorMatrix(new float[][]
                {
                   new float[] {-1,  0,  0,  0, 0},        // red scaling factor of 2
                   new float[] {0,  -1,  0,  0, 0},        // green scaling factor of 1
                   new float[] {0,  0,  -1,  0, 0},        // blue scaling factor of 1
                   new float[] {0,  0,  0,  1, 0},        // alpha scaling factor of 1
                   new float[] {1, 1, 1, 0, 1 }    // three translations of 0.2
            });
                ia.SetColorMatrix(nc);
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawImage(bitmap, new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                img.Source = BitmapToImageSource(bitmap);
            }
            else
            {
                MessageBox.Show("Open an image first !");
            }
        }

        void tanFilter(System.Windows.Media.Color c)
        {
            float red =(float)c.R / 255;
            float green = (float)c.G / 255;
            float blue = (float)c.B / 255;
            textBox.Text = Convert.ToString(red);


            if (isopen == true)
            {
                ImageAttributes ia = new ImageAttributes();
                ColorMatrix nc = new ColorMatrix(new float[][]
                {
                   new float[] {red+0f,  0,  0,  0, 0},        // red scaling factor of 2
                   new float[] {0,  green+0f,  0,  0, 0},        // green scaling factor of 1
                   new float[] {0,  0,  blue+0f,  0, 0},        // blue scaling factor of 1
                   new float[] {0,  0,  0,  1, 0},        // alpha scaling factor of 1
                   new float[] {0, 0, 0, 0, 1 }    // three translations of 0.2
            });
                ia.SetColorMatrix(nc);
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawImage(bitmap, new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                img.Source = BitmapToImageSource(bitmap);
            }
            else
            {
                MessageBox.Show("Open an image first !");
            }

        }

        void brightFilter(float b)
        {           
            if (isopen == true)
            {
                ImageAttributes ia = new ImageAttributes();
                ColorMatrix nc = new ColorMatrix(new float[][]
                {
                   new float[] {1,  0,  0,  0, 0},        // red scaling factor of 2
                   new float[] {0,  1,  0,  0, 0},        // green scaling factor of 1
                   new float[] {0,  0,  1,  0, 0},        // blue scaling factor of 1
                   new float[] {0,  0,  0,  1, 0},        // alpha scaling factor of 1
                   new float[] { b + 0f, b + 0f, b + 0f, 0, 1 }    // three translations of 0.2
            });
                ia.SetColorMatrix(nc);
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawImage(bitmap, new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                img.Source = BitmapToImageSource(bitmap);
            }
            else
            {
                MessageBox.Show("Open an image first !");
            }
        }

        void constractFilter(float c)
        {
            if (isopen == true)
            {
                ImageAttributes ia = new ImageAttributes();
                ColorMatrix nc = new ColorMatrix(new float[][]
                {
                   new float[] {c,  0,  0,  0, 0},        // red scaling factor of 2
                   new float[] {0, c,  0,  0, 0},        // green scaling factor of 1
                   new float[] {0,  0, c,  0, 0},        // blue scaling factor of 1
                   new float[] {0,  0,  0,  1, 0},        // alpha scaling factor of 1
                   new float[] {0.5f*(1f-c), 0.5f * (1f - c), 0.5f * (1f - c), 0, 1 }    // three translations of 0.2
            });
                ia.SetColorMatrix(nc);
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawImage(bitmap, new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                img.Source = BitmapToImageSource(bitmap);
            }
            else
            {
                MessageBox.Show("Open an image first !");
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            openImg();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            saveImg();
        }

        private void Gray_Click(object sender, RoutedEventArgs e)
        {
            reload();
            grayFilter();
        }

         private void Spring_Click(object sender, RoutedEventArgs e)
        {
            reload();
            springFilter();
        }

        private void Winter_Click(object sender, RoutedEventArgs e)
        {
            reload();
            winterFilter();
        }

         private void Autom_Click(object sender, RoutedEventArgs e)
        {
            reload();
            automFilter();
        }

        private void Summer_Click(object sender, RoutedEventArgs e)
        {
            reload();
            summerFilter();
        }

        private void Fog_Click(object sender, RoutedEventArgs e)
        {
            reload();
            fogFilter();
        }

        private void Negative_Click(object sender, RoutedEventArgs e)
        {
            reload();
            negativeFilter();
        }

        private void addTan(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color?> e)
        {
            reload();
            if (isopen)
            {
                if (clrPicker.SelectedColor.HasValue)
                {
                    System.Windows.Media.Color c = clrPicker.SelectedColor.Value;
                    tanFilter(c);
                }
            }
            else
            {
                MessageBox.Show("Open an image first !");
            }

        }

        private void addbright(object sender, RoutedPropertyChangedEventArgs<double> e)
        {            
            if (isopen)
            {
                reload();
                float brightVal = (float)bright.Value;
                brightVal -= 50;
                brightVal /= 50;
                brightFilter(brightVal);
            }           
        }

        private void addcontrast(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (isopen)
            {
                reload();
                float contrastVal = (float)contrast.Value;
                contrastVal /= 50;
                constractFilter(contrastVal);
            }                     
        }
    }
}
