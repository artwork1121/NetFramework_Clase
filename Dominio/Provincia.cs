using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace NET.Dominio
{
	public class Provincia: EntityBase
	{
		public string Name { get; set; }
		public virtual ICollection<Localidad> Localidades { get; set; }
	}
}