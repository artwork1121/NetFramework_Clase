using System.ComponentModel.DataAnnotations;

namespace NET.Dominio
{
	public class Adress : EntityBase
	{
		[Required(ErrorMessage = "Debe ingresar una direccion")]
		public string AdressName { get; set; }
		[Required(ErrorMessage = "Debe ingresar la numeración")]
		public int Number { get; set; }
		public bool IsActive { get; set; } = true;

		public int ClientId { get; set; }
		public virtual Client Client { get; set; }
    }
}