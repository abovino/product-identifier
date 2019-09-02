using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace product_identifer
{
    class Product
    {
        public string materialNo { get; private set; }

        public Product(string materialNo)
        {
            this.materialNo = materialNo;
        }
    }
}
