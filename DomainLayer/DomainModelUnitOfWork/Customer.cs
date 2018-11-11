using DomainLayer.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DomainModelUnitOfWork
{
    public class Customer : IUnitOfWorkCompatible
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Salary { get; set; }

        public int Age { get; set; }

        public string Adrress { get; set; }

        public Customer()
        {
            
        }

        public void IncreaseSallaryByPercentige( int percentige)
        {
            Salary = Salary * (1 + ((double)percentige/100));
        }

        public string Print()
        {
            return "Name:" + this.Name + " Age:" + this.Age;
        }

        public void MarkNew()
        {
            throw new NotImplementedException();
        }

        public void MarkDirty()
        {
            throw new NotImplementedException();
        }

        public void MarkRemoved()
        {
            throw new NotImplementedException();
        }
    }
}
