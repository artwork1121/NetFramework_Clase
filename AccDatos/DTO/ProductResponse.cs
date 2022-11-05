using NET.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccDatos.DTO
{
    public class ProductResponse
    {
        public bool status { get; set; }
        public string Message { get; set; }
        public IEnumerable<Product> ProductResponses { get; set; }
    }
}
