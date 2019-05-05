using System;
using ordertest;
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
    public partial class Form2 : Form
    {

        private int cusid;
        private int orderid;

        Form1 form1;
        Order order;
       

        public Form2(Form1 form)
        {
            InitializeComponent();
            this.form1 = form;
        }//创建构造方法

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Customer customer = new Customer((uint)cusid,textBox2.Text);
            order = new Order(orderid,customer);
            form1.get_order(order);//向父窗口传值
            this.Close();//关闭子窗口
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out cusid);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(textBox3.Text, out orderid);
        }
    }
}
