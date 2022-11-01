using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NET.Dominio
{
	public class Client : EntityBase
	{
		[Required(ErrorMessage = "El cliente debe tener un nomber.")]
		public string Name { get; set; }
		[Required(ErrorMessage = "El DNI no puede estar vacio.")]
        public string DNI { get; set; }
		public ICollection<Adress> Adress { get; set; }
	}
}