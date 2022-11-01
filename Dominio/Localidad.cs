using System.ComponentModel.DataAnnotations.Schema;

namespace NET.Dominio
{
	public class Localidad : EntityBase
	{
		public string Name { get; set; }
		public int CP { get; set; }
		public string NewCP { get; set; }
		public int ProvinciaId { get; set; }
		public virtual Provincia Provincia { get; set; }
	}
}