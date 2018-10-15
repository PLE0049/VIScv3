using ClassLibrary2;
using System.Data.SqlClient;
using System.Text;

namespace VIScv3.Data
{
    public class CustomerTableGateway
    {
        public void  FindById(int id)
        {

        }

        public CustomerRecord FindName( string name)
        {
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
