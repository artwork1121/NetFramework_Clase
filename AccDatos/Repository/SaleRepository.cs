using AccDatos.Repository.GenericRepository;
using NET.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccDatos.Repository
{
	public class SaleRepository : BaseRepository<Sale>
	{
		public Sale GetSaleById(int id)
		{
			using(var _context = new MyContext())
			{
				return _context.Sales.Where(x=>x.Id == id)
					.Include(x=>x.SaleLine)
					.FirstOrDefault();
			}
		}
	}
}
