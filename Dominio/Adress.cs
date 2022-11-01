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
		public int ProvinciaId { get; set; }
        public virtual Provincia Provincia { get; set; }
        public int LocalidadId { get; set; }
        public virtual Localidad Localidad { get; set; }
    }
}