using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.TableModule
{
    public class CustomerTableModule
    {
        DataTable TableData;
        public CustomerTableModule( DataTable table )
        {
            TableData = table;
        }

        /* Domain Logic Functions*/
        public double AverageSalary()
        {
            double SalarySum = 0;
            
            foreach ( DataRow row in this.TableData.Rows)
            {
                SalarySum += Double.Parse(row[4].ToString());
            }

            return SalarySum / TableData.Rows.Count;
        }
    }
}
