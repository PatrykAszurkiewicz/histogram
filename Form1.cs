using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        int wys;
        int szer;

        Bitmap bitmap;

        int[] histogram1 = new int[256];
        int[] histogram2 = new int[256];
        int[] histogram3 = new int[256];

        bool odczyt = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                bitmap = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = bitmap;
                pictureBox2.Image = bitmap;
                wys = pictureBox1.Image.Height;
                szer = pictureBox1.Image.Width;
                Array.Clear(histogram1, 0, histogram1.Length);
                Array.Clear(histogram2, 0, histogram2.Length);
                Array.Clear(histogram3, 0, histogram3.Length);
                histogram();
                odczyt = true;
                panel1.Invalidate();
                panel2.Invalidate();
                panel3.Invalidate();
            }
        }
        private void histogram()
        {
            int i = 0, j = 0, k = 0;
            for (int y = 0; y < wys; y++)
            {
                for (int x = 0; x < szer; x++)
                {
                    Color p = bitmap.GetPixel(x, y);

                    int red = p.R;
                    int green = p.G;
                    int blue = p.B;
                    histogram1[red]++;
                    histogram2[green]++;
                    histogram3[blue]++;
                }
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Bitmap bitmap2;
            try
            {
                bitmap2 = (Bitmap)bitmap.Clone();
                for (int y = 0; y < wys; y++)
                {
                    for (int x = 0; x < szer; x++)
                    {

                        Color p = bitmap2.GetPixel(x, y);

                        int red = p.R;
                        int green = p.G;
                        int blue = p.B;

                        red = (127 / (127 - trackBar1.Value)) * (red - trackBar1.Value);
                        green = (127 / (127 - trackBar1.Value)) * (green - trackBar1.Value);
                        blue = (127 / (127 - trackBar1.Value)) * (blue - trackBar1.Value);

                        if (red < 0)
                        {
                            red = 0;
                        }
                        if (green < 0)
                        {
                            green = 0;
                        }
                        if (blue < 0)
                        {
                            blue = 0;
                        }
                        if (red > 255)
                        {
                            red = 255;
                        }
                        if (green > 255)
                        {
                            green = 255;
                        }
                        if (blue > 255)
                        {
                            blue = 255;
                        }

                        bitmap2.SetPixel(x, y, Color.FromArgb(red, green, blue));
                    }
                }

                pictureBox2.Image = bitmap2;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Nie załadowano obrazka");
            }
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Bitmap bitmap3;
            try
            {
                bitmap3 = (Bitmap)bitmap.Clone();
                for (int y = 0; y < wys; y++)
                {
                    for (int x = 0; x < szer; x++)
                    {

                        Color p = bitmap3.GetPixel(x, y);

                        double red = (double)p.R;
                        double green = (double)p.G;
                        double blue = (double)p.B;

                        double red1, green1, blue1;
                        red1 = (127 + trackBar2.Value) * red;
                        red1 = red1 / 127;

                        red1 = red1 - trackBar2.Value;

                        green1 = (127 + trackBar2.Value) * green;
                        green1 = green1 / 127;

                        green1 = green1 - trackBar2.Value;

                        blue1 = (127 + trackBar2.Value) * blue;
                        blue1 = blue1 / 127;

                        blue1 = blue1 - trackBar2.Value;



                        bitmap3.SetPixel(x, y, Color.FromArgb((int)red1, (int)green1, (int)blue1));
                    }
                }

                pictureBox2.Image = bitmap3;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Nie załadowano obrazka");
            }
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            Bitmap bitmap3;
            try
            {
                bitmap3 = (Bitmap)bitmap.Clone();
                for (int y = 0; y < wys; y++)
                {
                    for (int x = 0; x < szer; x++)
                    {

                        Color p = bitmap3.GetPixel(x, y);

                        double red = (double)p.R;
                        double green = (double)p.G;
                        double blue = (double)p.B;

                        double red1 = 0, green1 = 0, blue1 = 0;
                        if (red < 127)
                        {
                            red1 = (127 - trackBar3.Value) * red;
                            red1 = red1 / 127;
                        }
                        else if (red >= 127)
                        {
                            red1 = (127 - trackBar3.Value) * red;
                            red1 = red1 / 127;
                            red1 = red1 + (2 * trackBar3.Value);
                        }

                        if (green < 127)
                        {
                            green1 = (127 - trackBar3.Value) * green;
                            green1 = green1 / 127;
                        }
                        else if (green >= 127)
                        {
                            green1 = (127 - trackBar3.Value) * green;
                            green1 = green1 / 127;
                            green1 = green1 + (2 * trackBar3.Value);
                        }

                        if (blue < 127)
                        {
                            blue1 = (127 - trackBar3.Value) * blue;
                            blue1 = blue1 / 127;
                        }
                        else if (blue >= 127)
                        {
                            blue1 = (127 - trackBar3.Value) * blue;
                            blue1 = blue1 / 127;
                            blue1 = blue1 + (2 * trackBar3.Value);
                        }



                        bitmap3.SetPixel(x, y, Color.FromArgb((int)red1, (int)green1, (int)blue1));
                    }
                }

                pictureBox2.Image = bitmap3;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Nie załadowano obrazka");
            }
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            Bitmap bitmap3;

            bitmap3 = (Bitmap)bitmap.Clone();
            for (int y = 0; y < wys; y++)
            {
                for (int x = 0; x < szer; x++)
                {

                    Color p = bitmap3.GetPixel(x, y);

                    double red = (double)p.R;
                    double green = (double)p.G;
                    double blue = (double)p.B;

                    double red1, green1, blue1;
                    if (red < 127 + trackBar4.Value)
                    {
                        red1 = (127 / (127 + trackBar4.Value)) * red;
                    }
                    else if (red > 127 - trackBar4.Value)
                    {
                        red1 = ((127 * red) + (255 * trackBar4.Value)) / (127 + trackBar4.Value);
                    }
                    else
                    {
                        red1 = 127;
                    }

                    if (green < 127 + trackBar4.Value)
                    {
                        green1 = (127 / (127 + trackBar4.Value)) * green;
                    }
                    else if (green > 127 - trackBar4.Value)
                    {
                        green1 = ((127 * green) + (255 * trackBar4.Value)) / (127 + trackBar4.Value);
                    }
                    else
                    {
                        green1 = 127;
                    }

                    if (blue < 127 + trackBar4.Value)
                    {
                        blue1 = (127 / (127 + trackBar4.Value)) * blue;
                    }
                    else if (blue > 127 - trackBar4.Value)
                    {
                        blue1 = ((127 * blue) + (255 * trackBar4.Value)) / (127 + trackBar4.Value);
                    }
                    else
                    {
                        blue1 = 127;
                    }

                    bitmap3.SetPixel(x, y, Color.FromArgb((int)red1, (int)green1, (int)blue1));
                }
            }

            pictureBox2.Image = bitmap3;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (odczyt == true)
            {
                int x = 0;
                Graphics g = e.Graphics;
                for (int i = 0; i < 256; i++)
                {
                    double red = histogram1[i];
                    red = red / (bitmap.Width * bitmap.Height);
                    red = red * 5000;
                    g.DrawLine(new Pen(Color.Red), x, panel1.Height, x, panel1.Height - (int)red);
                    x++;
                }

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (odczyt == true)
            {
                int x = 0;
                Graphics g = e.Graphics;
                for (int i = 0; i < 256; i++)
                {
                    double green = histogram2[i];
                    green = green / (bitmap.Width * bitmap.Height);
                    green = green * 5000;
                    g.DrawLine(new Pen(Color.Green), x, panel2.Height, x, panel2.Height - (int)green);
                    x++;
                }

            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            if (odczyt == true)
            {
                int x = 0;
                Graphics g = e.Graphics;
                for (int i = 0; i < 256; i++)
                {
                    double blue = histogram3[i];
                    blue = blue / (bitmap.Width * bitmap.Height);
                    blue = blue * 5000;
                    g.DrawLine(new Pen(Color.Blue), x, panel3.Height, x, panel3.Height - (int)blue);
                    x++;
                }

            }
        }
    }
}

