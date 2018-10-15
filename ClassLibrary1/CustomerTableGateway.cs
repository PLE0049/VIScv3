using System.Text;

namespace VIScv3.Data
{
    public class CustomerTableGateway
    {
        public void  FindById(int id)
        {

        }

        public void FindName( string name)
        {

        }
        public void SaveCustomer()
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
                    command.Parameters.AddWithValue("@name", customer.Name);
                    command.Parameters.AddWithValue("@age", customer.Age);
                    command.Parameters.AddWithValue("@adress", customer.Adrress);
                    command.Parameters.AddWithValue("@salary", customer.Salary);
                    int modified = (int)command.ExecuteScalar();
                    customer.Id = modified;
                }
            }
        }
    }
}
