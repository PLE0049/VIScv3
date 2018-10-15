using ClassLibrary2;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace VIScv3.Data
{
    public class CustomerDataGateway
    {

        public List<Dictionary<string,object>> GetAll()
        {
            List<Dictionary<string, object>> Customers = new List<Dictionary<string, object>>(); 
            string sql = "SELECT * FROM CUSTOMERS;";
            SqlConnectionStringBuilder builder = DBConnector.GetBuilder();
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var CustomerOne = new Dictionary<string, object>();

                            CustomerOne["Id"] = reader.GetInt32(0);
                            CustomerOne["Name"] = reader.GetString(1);
                            CustomerOne["Salary"] = (double)reader.GetDecimal(4);
                            CustomerOne["Age"] = reader.GetInt32(2);
                            CustomerOne["Adrress"] = reader.GetString(3);

                            Customers.Add(CustomerOne);
                        }
                    }
                }
            }

            return Customers;
        }

        public Dictionary<string, object> FindById(int id)
        {
            Dictionary<string, object> Customer = null;
            string sql = "SELECT * FROM CUSTOMERS WHERE ID = @id;";

            using (SqlConnection connection = new SqlConnection(DBConnector.GetBuilder().ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer = new Dictionary<string, object>();
                            Customer["Id"] = reader.GetInt32(0);
                            Customer["Name"] = reader.GetString(1);
                            Customer["Salary"] = (double)reader.GetDecimal(4);
                            Customer["Age"] = reader.GetInt32(2);
                            Customer["Adrress"] = reader.GetString(3);
                        }
                    }
                }
            }

            return Customer;
        }

        public CustomerRecord FindName( string name)
        {
            SqlConnectionStringBuilder builder = DBConnector.GetBuilder();
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Clear();
                sb.Append("INSERT INTO CUSTOMERS (NAME,AGE,ADDRESS,SALARY)");
            }
            return null;
        }

        public int SaveCustomer( string name, string age, double salary, string adrress)
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
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@age", age);
                    command.Parameters.AddWithValue("@adress", adrress);
                    command.Parameters.AddWithValue("@salary", salary);
                    int modified = (int)command.ExecuteScalar();
                    return modified;
                }
            }
        }
    }
}
