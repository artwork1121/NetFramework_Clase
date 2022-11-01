using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NET.Dominio
{
	public class User : EntityBase
	{
		[Required]
		[StringLength(20, MinimumLength = 5, ErrorMessage = "Longitud invalida")]
		public string Name { get; set; }
		[DataType(DataType.Password)]
		public string Password { get; set; }
		public DateTime CreationDate { get; set; } = DateTime.Now;
		public bool IsActive { get; set; } = true;
		public Client Client { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}