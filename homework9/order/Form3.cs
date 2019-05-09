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
        Order order=new Order();
        private uint id;
        private uint num;
        private float price;
        private string name;


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
            //Goods goods = new Goods((uint)id, name, (float)price);
            orderDetail = new OrderDetail();
            orderDetail.Id = id;
            orderDetail.Name = name;
            orderDetail.Price = price;
            
            Form1.get_orderDetail(orderDetail, order.Id);
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            uint.TryParse(textBox2.Text, out  this.num);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            uint.TryParse(textBox3.Text, out this.id);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(textBox4.Text, out this.price);
        }
    }
}
