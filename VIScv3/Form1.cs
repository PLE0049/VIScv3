using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VIScv3.Model;
using VIScv3.Models;

namespace VIScv3
{
    public partial class Form1 : Form
    {

        List<Customer> CustomersList = new List<Customer>();
        public Form1()
        {
            /* Use Customer Data Gateway to return all records*/

            InitializeComponent();
            BindingSource bSource = new BindingSource();
            bSource.DataSource = CustomersList;
            dataGridView1.DataSource = bSource;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  TODO: Implement - Save new Customer
            Customer NewCustomer = new Customer(textBoxName.Text, Double.Parse(textBox1.Text), Int32.Parse(textBox2.Text), textBox3.Text);
            NewCustomer.Insert();
            CustomersList.Add(NewCustomer);
            dataGridView1.DataSource = CustomersList;
            dataGridView1.Update();
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer Pepa = new Customer();
            int CustomerId;
            Int32.TryParse(textBoxCustomerId.Text, out CustomerId);
            Pepa.Get(CustomerId);

            lblCustomerToString.Text = Pepa.Print();


        }
    }
}
