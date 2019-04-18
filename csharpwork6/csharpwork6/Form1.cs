using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharpwork6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        int n1=30;
        int n2 = 35;
        double k = 1;
        string color1="Blue";
        float width=0.5f;
        private Graphics graphics;
        
        double per1 = 0.6;
        double per2 = 0.7;

      

        private void drawCayleyTree(int n, double x0, double y0,double leng , double th)
        {
            if (n == 0) return;

            double th1 = n1%180 * Math.PI / 180;
            double th2 = n2%180 * Math.PI / 180;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            double x2 = x0 + k*leng * Math.Cos(th);
            double y2 = y0 +k* leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x2, y2, per2 * leng, th -th2);

        }

        private void drawLine(double x0, double y0, double x1, double y1)
        {
            Color color = new Color();
            ColorConverter ColorConverter = new ColorConverter();
           color = (Color)ColorConverter.ConvertFromString(color1);
            Pen pen = new Pen(color,width);
            

            graphics.DrawLine(
                pen, (int)x0, (int)y0, (int)x1, (int)y1);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            else
            {
                this.Refresh();
                drawCayleyTree(10, 200, 310, 100, -Math.PI / 2);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out n1);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(textBox2.Text, out n2);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(textBox3.Text, out per1);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(textBox4.Text, out per2);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(textBox5.Text, out k);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            color1 = comboBox1.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(textBox6.Text, out width);
        }
    }
    
}
