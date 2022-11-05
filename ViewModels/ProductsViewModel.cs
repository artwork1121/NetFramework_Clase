using NET.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET_Framework.ViewModels
{
    public class ProductsViewModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<Product> Product { get; set; }
        public Company Company { get; set; }
    }
}