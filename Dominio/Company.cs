using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NET.Dominio
{
	public class Company : EntityBase
	{
		[Required(ErrorMessage = "Se debe ingresar un nombre de empresa.")]
		[MaxLength(50, ErrorMessage = "No puede tener mas de 50 caracteres.")]
		[MinLength(5, ErrorMessage = "El nombre es demasiado corto.")]
		public string BussinesName { get; set; }
		[Required(ErrorMessage = "CUIT no puede estar vacio.")]
		[StringLength(11, MinimumLength = 11, ErrorMessage = "CUIT debe ser de 11 caracteres")]
		public string CUIT { get; set; }
        [Required(ErrorMessage = "Debe ingresar un nombre de fantasia.")]
		[MinLength(2)]
        public string FantasyName { get; set; }
        [Required(ErrorMessage = "Se debe ingresar un nombre de empresa.")]
		[StringLength(50, ErrorMessage = "Email demasiado largo.")]
		[DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Se debe proporcionar una dirección.")]
        [MaxLength(50, ErrorMessage = "No puede tener mas de 50 caracteres.")]
        [MinLength(5, ErrorMessage = "El nombre es demasiado corto.")]
        public string Adress { get; set; }

		public ICollection<User> Users { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}