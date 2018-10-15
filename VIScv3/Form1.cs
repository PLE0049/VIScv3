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

            // https://sqlchoice.azurewebsites.net/en-us/sql-server/developer-get-started/csharp/win/step/2.html 
            try
            {
                // Build connection string
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = @"dbsys.cs.vsb.cz\STUDENT";   // update me
                builder.UserID = "ple0049";              // update me
                builder.Password = "BMAMiq5uVf";      // update me
                builder.InitialCatalog = "ple0049";

                // Connect to SQL
                Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("Reading data from table, press any key to continue...");
                    string sql = "SELECT * FROM CUSTOMERS;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomersList.Add(new Customer(reader.GetInt32(0), reader.GetString(1), (double)reader.GetDecimal(4), reader.GetInt32(2), reader.GetString(3)));
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

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
    }
}
