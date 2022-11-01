using System.ComponentModel.DataAnnotations;

namespace NET.Dominio
{
	public class Role : EntityBase
	{
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
	}
}