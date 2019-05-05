using ordertest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace order
{
    public partial class Form3 : Form

    {
        Form1 Form1;
        public  OrderDetail orderDetail = new OrderDetail();
        Order order;
        int id;
        int num;
        double price;
        double total;
        string name;


        public Form3()
        {
            InitializeComponent();
        }

        public Form3(Form1 form1,Order order)
        {
            InitializeComponent();
            this.Form1 = form1;
         
            this.order = order;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            name = textBox1.Text;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            orderDetail.Goods.Id =(uint) id;
            orderDetail.Goods.Name = name;
            orderDetail.Goods.Price = (float)price;

            orderDetail.Quantity = (uint)num;
            Form1.get_orderDetail(orderDetail, order.Id);
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(textBox2.Text, out int num);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(textBox3.Text, out int id);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(textBox4.Text, out double price);
        }
    }
}
