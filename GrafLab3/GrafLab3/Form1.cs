using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrafLab3
{
    public partial class Form1 : Form
    {
        private System.Drawing.Graphics g;
        private System.Drawing.Pen pen1 = new Pen(Color.Blue, 1);
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }

        double kat(PointF P1, PointF P2, PointF P3, PointF P4)
        {
            double x1 = P2.X - P1.X;
            double y1 = P2.Y - P1.Y;
            double d1 = Math.Sqrt(x1*x1+y1*y1);
            double x2 = P4.X - P3.X;
            double y2 = P4.Y - P3.Y;
            double d2 = Math.Sqrt(x2 * x2 + y2 * y2);
            double a = x1 / d1;
            double b = y1 / d1;
            double c = x2 / d2;
            double d = y2 / d2;
            return Math.Acos(Math.Abs(a * c + b * d));
        }

        private double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            PointF P1 = new PointF();
            PointF P2 = new PointF();
            PointF P3 = new PointF();
            PointF P4 = new PointF();
            P1.X = (float)Double.Parse(textBox1.Text);
            P1.Y = (float)Double.Parse(textBox2.Text);
            P2.X = (float)Double.Parse(textBox3.Text);
            P2.Y = (float)Double.Parse(textBox4.Text);
            P3.X = (float)Double.Parse(textBox5.Text);
            P3.Y = (float)Double.Parse(textBox6.Text);
            P4.X = (float)Double.Parse(textBox7.Text);
            P4.Y = (float)Double.Parse(textBox8.Text);
            g.DrawLine(pen1, P1, P2);
            g.DrawLine(pen1, P3, P4);
            float a = (P2.X - P1.X) * (P3.Y - P4.Y) - (P3.X - P4.X) * (P2.Y - P1.Y);
            if (a == 0)
            {
                label10.Text = "Tak";
            }
            else
            {
                label10.Text = "Nie";
                float wyz = (P3.X - P1.X) * (P3.Y - P4.Y) - (P3.X - P4.X) * (P3.Y - P1.Y);
                float wspol = wyz / a;
                PointF result = new PointF();
                result.X = (1 - wspol) * P1.X + wspol * P2.X;
                result.Y = (1 - wspol) * P1.Y + wspol * P2.Y;
                label12.Text = result.ToString();
            }
            label14.Text = RadianToDegree(kat(P1, P2, P3, P4)).ToString(); ;

        }

        class PointF3D
        {
            public float x;
            public float y;
            public float z;
            public PointF3D(float x,float y, float z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        };

        private void button2_Click(object sender, EventArgs e)
        {
            PointF3D P1 = new PointF3D((float)Double.Parse(textBox1.Text), (float)Double.Parse(textBox2.Text), (float)Double.Parse(textBox3.Text));
            PointF3D P2 = new PointF3D((float)Double.Parse(textBox4.Text), (float)Double.Parse(textBox5.Text), (float)Double.Parse(textBox6.Text));
            PointF3D P3 = new PointF3D((float)Double.Parse(textBox7.Text), (float)Double.Parse(textBox8.Text), (float)Double.Parse(textBox9.Text));

            String wynik="";
            float p1, p2, p3;
            p1 = (P1.x - P2.x) * (P3.x - P1.x);
            p2 = (P1.y - P2.y) * (P3.y - P1.y);
            p3 = (P1.z - P2.z) * (P3.z - P1.z);
            wynik += p1 + "(x-" + P1.x + ") + ";
            wynik += p2 + "(y-" + P1.y + ") + ";
            wynik += p3 + "(z-" + P1.z + ") = 0";
            label25.Text = wynik;
        }
    }
}
