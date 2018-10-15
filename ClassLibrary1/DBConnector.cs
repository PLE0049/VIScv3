using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIScv3.Data
{
    public static class DBConnector
    {

        // handle db connection

        public static SqlConnectionStringBuilder GetBuilder()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"dbsys.cs.vsb.cz\STUDENT";   // update me
            builder.UserID = "ple0049";              // update me
            builder.Password = "BMAMiq5uVf";      // update me
            builder.InitialCatalog = "ple0049";

            return builder;
        }
    }
}
