using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DomainModel
{
    public class Address
    {
        public string Street { get; set; }

        public string Country { get; set; }

        private IAddressTableGateway Gateway;

        public Address(IAddressTableGateway gw)
        {
            Gateway = gw;
            Gateway.GetById(1);
        }
        // < IAddressTableGateway, TypA >
    }
}
