using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mm6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        public int[,] matrix;
        public int[,] matrix2;
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics gr = pictureBox1.CreateGraphics();
            gr.Clear(Color.White);
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;

            int widthLines = Convert.ToInt32(textBox1.Text);
            int heightLines = widthLines;
            matrix = new int[500 / heightLines, 750 / widthLines];
            matrix2 = new int[500 / heightLines, 750 / widthLines];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 0;
                    matrix2[i, j] = 0;
                }
            for (int i = 0; i < w; i += widthLines)
            {
                gr.DrawLine(new Pen(Brushes.Black), new Point(i + widthLines, 0), new Point(i + widthLines, h));
                gr.DrawLine(new Pen(Brushes.Black), new Point(0, i + heightLines), new Point(w, i + heightLines));
            }
           // textBox1.Text = matrix.GetLength(0).ToString();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics gr = pictureBox1.CreateGraphics();
            matrix[Convert.ToInt32(e.Y / Convert.ToInt32(textBox1.Text)), Convert.ToInt32(e.X / Convert.ToInt32(textBox1.Text))] = 1;
            gr.FillRectangle(Brushes.Blue, Convert.ToInt32(e.X / (pictureBox1.Width / matrix.GetLength(1))) * Convert.ToInt32(textBox1.Text), Convert.ToInt32(e.Y / (pictureBox1.Height / matrix.GetLength(0))) * Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox1.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix2[i, j] = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int individual = 0;
                    if (i - 1 < 0)
                    {
                        if (j - 1 < 0)
                        {
                            if (matrix[i + 1, j] == 1)
                                individual++;
                            if (matrix[i + 1, j + 1] == 1)
                                individual++;
                            if (matrix[i, j + 1] == 1)
                                individual++;
                            if (matrix[matrix.GetLength(0) - 1, j] == 1)
                                individual++;
                            if (matrix[matrix.GetLength(0) - 1, j + 1] == 1)
                                individual++;
                            if (matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1] == 1)
                                individual++;
                            if (matrix[i, matrix.GetLength(1) - 1] == 1)
                                individual++;
                            if (matrix[i + 1, matrix.GetLength(1) - 1] == 1)
                                individual++;
                        }
                        else
                        if (j + 1 > matrix.GetLength(1) - 1)
                        {
                            if (matrix[i, j - 1] == 1)
                                individual++;
                            if (matrix[i + 1, j - 1] == 1)
                                individual++;
                            if (matrix[i + 1, j] == 1)
                                individual++;
                            if (matrix[i, 0] == 1)
                                individual++;
                            if (matrix[i + 1, 0] == 1)
                                individual++;
                            if (matrix[matrix.GetLength(0) - 1, 0] == 1)
                                individual++;
                            if (matrix[matrix.GetLength(0) - 1, j] == 1)
                                individual++;
                            if (matrix[matrix.GetLength(0) - 1, j - 1] == 1)
                                individual++;
                        }
                        else
                        {
                            if (matrix[i, j - 1] == 1)
                                individual++;
                            if (matrix[i, j + 1] == 1)
                                individual++;
                            if (matrix[i + 1, j - 1] == 1)
                                individual++;
                            if (matrix[i + 1, j] == 1)
                                individual++;
                            if (matrix[i + 1, j + 1] == 1)
                                individual++;
                            if (matrix[matrix.GetLength(0) - 1, j] == 1)
                                individual++;
                            if (matrix[matrix.GetLength(0) - 1, j - 1] == 1)
                                individual++;
                            if (matrix[matrix.GetLength(0) - 1, j + 1] == 1)
                                individual++;
                        }
                    }
                    else if (i + 1 > matrix.GetLength(0) - 1)
                    {
                        if (j - 1 < 0)
                        {
                            if (matrix[i - 1, j] == 1)
                                individual++;
                            if (matrix[i - 1, j + 1] == 1)
                                individual++;
                            if (matrix[i, j + 1] == 1)
                                individual++;
                            if (matrix[0, j] == 1)
                                individual++;
                            if (matrix[0, j + 1] == 1)
                                individual++;
                            if (matrix[0, matrix.GetLength(1) - 1] == 1)
                                individual++;
                            if (matrix[i, matrix.GetLength(1) - 1] == 1)
                                individual++;
                            if (matrix[i - 1, matrix.GetLength(1) - 1] == 1)
                                individual++;
                        }
                        else
                        if (j + 1 > matrix.GetLength(1) - 1)
                        {
                            if (matrix[i, j - 1] == 1)
                                individual++;
                            if (matrix[i - 1, j - 1] == 1)
                                individual++;
                            if (matrix[i - 1, j] == 1)
                                individual++;
                            if (matrix[i, 0] == 1)
                                individual++;
                            if (matrix[i - 1, 0] == 1)
                                individual++;
                            if (matrix[0, 0] == 1)
                                individual++;
                            if (matrix[0, j] == 1)
                                individual++;
                            if (matrix[0, j - 1] == 1)
                                individual++;
                        }
                        else
                        {
                            if (matrix[i, j - 1] == 1)
                                individual++;
                            if (matrix[i, j + 1] == 1)
                                individual++;
                            if (matrix[i - 1, j - 1] == 1)
                                individual++;
                            if (matrix[i - 1, j] == 1)
                                individual++;
                            if (matrix[i - 1, j + 1] == 1)
                                individual++;
                            if (matrix[0, j] == 1)
                                individual++;
                            if (matrix[0, j - 1] == 1)
                                individual++;
                            if (matrix[0, j + 1] == 1)
                                individual++;
                        }
                    }
                    else
                    {
                        if (j - 1 < 0)
                        {
                            if (matrix[i - 1, j] == 1)
                                individual++;
                            if (matrix[i - 1, j + 1] == 1)
                                individual++;
                            if (matrix[i, j + 1] == 1)
                                individual++;
                            if (matrix[i + 1, j + 1] == 1)
                                individual++;
                            if (matrix[i + 1, j] == 1)
                                individual++;
                            if (matrix[i, matrix.GetLength(1) - 1] == 1)
                                individual++;
                            if (matrix[i + 1, matrix.GetLength(1) - 1] == 1)
                                individual++;
                            if (matrix[i - 1, matrix.GetLength(1) - 1] == 1)
                                individual++;
                        }
                        else
                        if (j + 1 > matrix.GetLength(1) - 1)
                        {
                            if (matrix[i - 1, j] == 1)
                                individual++;
                            if (matrix[i - 1, j - 1] == 1)
                                individual++;
                            if (matrix[i, j - 1] == 1)
                                individual++;
                            if (matrix[i + 1, j - 1] == 1)
                                individual++;
                            if (matrix[i + 1, j] == 1)
                                individual++;
                            if (matrix[i, 0] == 1)
                                individual++;
                            if (matrix[i + 1, 0] == 1)
                                individual++;
                            if (matrix[i - 1, 0] == 1)
                                individual++;
                        }
                        else
                        {
                            if (matrix[i, j - 1] == 1)
                                individual++;
                            if (matrix[i - 1, j - 1] == 1)
                                individual++;
                            if (matrix[i - 1, j] == 1)
                                individual++;
                            if (matrix[i - 1, j + 1] == 1)
                                individual++;
                            if (matrix[i, j + 1] == 1)
                                individual++;
                            if (matrix[i + 1, j + 1] == 1)
                                individual++;
                            if (matrix[i + 1, j] == 1)
                                individual++;
                            if (matrix[i + 1, j - 1] == 1)
                                individual++;
                        }

                    }
                    if (matrix[i, j] == 0)
                    {
                        if (individual == 3)
                        {
                            matrix2[i, j] = 1;
                        }
                    }
                    else
                    {
                        if (individual == 2 || individual == 3)
                            matrix2[i, j] = 1;
                    }
                }
            Graphics gr = pictureBox1.CreateGraphics();
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gr.Clear(Color.White);
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;
            int widthLines = Convert.ToInt32(textBox1.Text);
            int heightLines = widthLines;
            for (int i = 0; i < w; i += widthLines)
            {
                gr.DrawLine(new Pen(Brushes.Black), new Point(i + widthLines, 0), new Point(i + widthLines, h));
                gr.DrawLine(new Pen(Brushes.Black), new Point(0, i + heightLines), new Point(w, i + heightLines));
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = matrix2[i, j];
                    if (matrix2[i, j] == 1)
                    {
                        gr.FillRectangle(Brushes.Blue, j * Convert.ToInt32(textBox1.Text), i * Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox1.Text));
                    }
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
