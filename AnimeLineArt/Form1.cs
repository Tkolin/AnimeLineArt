using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AnimeLineArt
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            
        }
        int width = 0;
        int height = 0;
        Bitmap bmp;
        Bitmap start;
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(dialog.FileName);
                width = image.Width;
                height = image.Height;
                pictureBox1.Width = width;
                pictureBox1.Height = height;
                //string txt ="W - " + width.ToString() + " |H - " + height.ToString();
                //MessageBox.Show(txt);
                start = new Bitmap(Image.FromFile(dialog.FileName), width, height);
                bmp = new Bitmap(Image.FromFile(dialog.FileName), width, height);

                pictureBox1.Image = bmp;
                label4.Text = dialog.FileName.ToString();
            }

            groupBox2.Visible = true;
                groupBox3.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Кистьи
            Graphics G = Graphics.FromImage(bmp);
            Pen P = new Pen(Color.Black, 1);

            //Картинка
            int score = (int)numericUpDown1.Value;//кол-во линий
            int period = (int)numericUpDown2.Value;//Пропуск растояния
            int t1 = score;
            int x = width;//ширина
            int y = height;//высота
            if (checkBox1.Checked)
            {
                for (int i = 0; i <= y; i++)//построчный проход ихображения
                {
                    if (t1 > 0)
                    {
                        t1--;
                        G.DrawLine(P, 0, i, x, i);
                    }
                    else if (t1 == 0)
                    {
                        t1 = score;
                        i += period;
                        i -= 1;
                    }

                }
            }
            else
            {
                for (int i = 0; i <= x; i++)//построчный проход ихображения
                {
                    if (t1 > 0)
                    {
                        t1--;
                        G.DrawLine(P, i, 0, i, x);
                    }
                    else if (t1 == 0)
                    {
                        t1 = score;
                        i += period;
                        i -= 1;
                    }

                }
            }
            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            dialog.FileName = "Пикча.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                bmp.Save(dialog.FileName);
               
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bmp = start;
            pictureBox1.Invalidate();
        }
    }
}
