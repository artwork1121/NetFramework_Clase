using NET.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace NET_Framework.ViewModels
{
	public class ProductoViewModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Debe ingresar un nombre.")]
		[StringLength(50, MinimumLength = 4, ErrorMessage = "Longitud no valida.")]
		[Display(Name = "Producto")]
		public string Name { get; set; }
		[Display(Name = "Descripción")]
		public string Description { get; set; }
		public decimal Price { get; set; }
		public decimal Tax { get; set; }
		public decimal TotalPrice { get => Price + (Price * Tax) / 100; }
		public string Image { get; set; }
	}
}