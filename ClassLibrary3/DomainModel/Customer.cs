
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIScv3.Data;
using VIScv3.Models;

namespace DomainLayer.Model
{
    public class Customer
    {

        private CustomerDataGateway Gateway;

        public int Id { get; set; }

        public string Name { get; set; }

        public double Salary { get; set; }

        public int Age { get; set; }

        public string Adrress { get; set; }


        public Customer()
        {
            Gateway = new CustomerDataGateway();
        }

        public Customer( int id, string name, double salary, int age, string adress)
        {
            this.Id = id;
            this.Name = name;
            this.Salary = salary;
            this.Age = age;
            this.Adrress = adress;
        }

        public Customer(string name, double salary, int age, string adress)
        {
            this.Name = name;
            this.Salary = salary;
            this.Age = age;
            this.Adrress = adress;
        }
        public void IncreaseSallaryByPercentige()
        {
            // TODO:  Some Business Logic
        }

        // ACTIVE RECORDS */ 

        public Customer Get(int id)
        {
            Dictionary<string,object> result = Gateway.FindById(id);

            this.Id = (int)result["Id"];
            this.Name = (string)result["Name"];
            this.Salary = (double)result["Salary"];
            this.Adrress = (string)result["Adrress"];
            this.Age = (int)result["Age"];

            return this;
        }

        public bool Delete()
        {
            return true;
        }

        public Customer Update()
        {
            return null;
        }

        public Customer Insert()
        {
            SqlConnectionStringBuilder builder = DBConnector.GetBuilder();
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Clear();
                sb.Append("INSERT INTO CUSTOMERS (NAME,AGE,ADDRESS,SALARY)");
                sb.Append("VALUES (@name, @age, @adress, @salary);");
                sb.Append("SELECT CAST(scope_identity() AS int)");
                string sql = sb.ToString();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@name", Name);
                    command.Parameters.AddWithValue("@age", Age);
                    command.Parameters.AddWithValue("@adress", Adrress);
                    command.Parameters.AddWithValue("@salary", Salary);
                    int modified = (int)command.ExecuteScalar();
                    this.Id = modified;
                }
            }
            return this;
        }

        public void IncreaseSallaryByPercentige( int percentige)
        {
            Salary = Salary * (1 + ((double)percentige/100));
        }

        public string Print()
        {
            return "Name:" + this.Name + " Age:" + this.Age;
        }

        public Payment CalculatePayment(int month)
        {
            /// get worksheet for given month
            Worksheet worksheet = new Worksheet();

            Payment p = new Payment();
            p.Amount = worksheet.Hours < 150 ? (worksheet.Hours * Salary) * 0.75 : (worksheet.Hours * Salary) * 0.85;
            p.Date = DateTime.UtcNow;
            // SAVE IT
            return p;
        }
    }
}
