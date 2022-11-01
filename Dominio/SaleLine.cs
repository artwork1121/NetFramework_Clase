using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NET.Dominio
{
	public class SaleLine : EntityBase
	{
		public int SaleId { get; set; }
		public virtual Sale Sale { get; set; }
		public int Quantity { get; set; }
		[NotMapped]
		public decimal Total { get => Product.TotalPrice * Quantity; }
		public virtual Product Product { get; set; }
		public int ProductId { get; set; }
	}
}