using DomainLayer.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class CustomerAdressDTO
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string FullAddress { get; set; }

        CustomerAdressDTO( Customer customer, Address address)
        {
            /// 
        }
    }
}
