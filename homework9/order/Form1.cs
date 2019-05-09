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
using order;

namespace order
{
    
    public partial class Form1 : Form
    {


       // BindingSource fieldsBS = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            init();
            //orderBindingSource.DataSource = orderService.QueryAll();
        }



      public OrderService orderService = new OrderService();
     
     public String ky { get; set; }//下拉框的数据绑定字段

        public void get_order(Order order)
        {
            this.orderService.AddOrder(order);
        }
        public void get_orderDetail(OrderDetail orderDetail,int id)
        {
            Order order = orderService.GetById(id);
            order.Details.Add(orderDetail);
            orderService.Update(order);
            orderBS.ResetBindings(false);
            orderDetailBindingSource.ResetBindings(false);
        }

        public void init()//初始化
        {
           
            orderBS.DataSource = orderService.QueryAll();
         
            
           // textBox1.DataBindings.Add("Text", this, "ky");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            using (Form2 form = new Form2(this))
            {
                form.ShowDialog(this);
            }
            orderBS.DataSource = orderService.QueryAll();
            orderBS.ResetBindings(false);
            orderDetailBindingSource.ResetBindings(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Order order = (Order)orderBS.Current;//得到选中资源
            if(order !=null)
            {
                orderService.RemoveOrder(order.Id);
                QueryAll();
            }
            else
            {
                MessageBox.Show("未选择订单");
            }
            orderBS.ResetBindings(false);
           // orderDetailBindingSource.ResetBindings(false);


        }

        private void QueryAll()
        {
            orderBS.DataSource = orderService.QueryAll();
            orderBS.ResetBindings(false);
        }

        private void button3_Click(object sender, EventArgs e)////查找部分
        {
            switch (cb1.SelectedIndex)
            {
                case 0:
                    orderBS.DataSource =
                        orderService.QueryAll();
                    break;
                case 1:
                    int.TryParse(ky, out int id);
                    orderBS.DataSource = orderService.GetById(id);
                    break;
                case 2:
                    orderBS.DataSource =
                            orderService.QueryByCustomerName(ky);
                    break;
                
               
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //textBox1.DataBindings.Add("Text", this, "ky");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.DataBindings.Add("Text", this, "ky");
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void deleteGoods_Click(object sender, EventArgs e)
        {
            OrderDetail orderDetail = (OrderDetail)orderDetailBindingSource.Current;
            Order order = (Order)orderBS.Current;
            if (orderDetail != null)
            {
                orderService.RemoveGoods(order.Id, (int)orderDetail.Id);
                QueryAll();
            }
            orderDetailBindingSource.ResetBindings(false);
        }

        private void changeo_Click(object sender, EventArgs e)
        {
            using (Form3 form = new Form3(this, (Order)orderBS.Current))
            {
                form.ShowDialog(this);
            }
            orderBS.DataSource = orderService.QueryAll();
           // orderDetailBindingSource.ResetBindings(false);
        }
    }
}
