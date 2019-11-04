using DataLayer.TableDataGateway;
using DomainLayer.DomainModel;
using DomainLayer.DomanModelActiveRecord;
using DomainLayer.TableModule;
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

namespace VIScv3
{
    public partial class Form1 : Form
    {

        List<CustomerActireRecord> CustomersList = new List<CustomerActireRecord>();
        public Form1()
        {
            /* Use Customer Data Gateway to return all records*/
            InitializeComponent();
            CustomersList = CustomerActireRecord.Find();
            BindingSource bSource = new BindingSource();
            bSource.DataSource = CustomersList;
            dataGridView1.DataSource = bSource;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  TODO: Implement - Save new Customer
            CustomerActireRecord NewCustomer = new CustomerActireRecord(textBoxName.Text, Double.Parse(textBox1.Text), Int32.Parse(textBox2.Text), textBox3.Text);
            NewCustomer.Insert();
            CustomersList.Add(NewCustomer);
            dataGridView1.DataSource = CustomersList;
            dataGridView1.Update();
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            Customer Pepa = new Customer();
            int CustomerId;
            Int32.TryParse(textBoxCustomerId.Text, out CustomerId);
            Pepa.Get(CustomerId);

            lblCustomerToString.Text = Pepa.Print();    
             */
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CustomerTableModule CustomerModule = new CustomerTableModule( CustomerTableGateway.Find() );           
            lblAvgSalary.Text = CustomerModule.AverageSalary().ToString();
        }
    }
}
