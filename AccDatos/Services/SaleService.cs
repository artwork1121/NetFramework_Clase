using AccDatos.Repository;
using NET.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AccDatos.Services
{
	public class SaleService : ISaleService
	{
		private readonly SaleRepository _saleRepository;
		public SaleService()
		{
			_saleRepository = new SaleRepository();
		}
		public IEnumerable<Sale> ObtenerTodo(Expression<Func<Sale, bool>> expression = null)
		{
			return _saleRepository.ObtenerTodo(expression);
		}
	}
}
