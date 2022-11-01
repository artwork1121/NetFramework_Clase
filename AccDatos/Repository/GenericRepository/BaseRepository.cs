using NET.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AccDatos.Repository.GenericRepository
{
	public abstract class BaseRepository<T> where T : EntityBase
	{
		private readonly MyContext _context;

		public BaseRepository()
		{
			_context = new MyContext();
		}

		public void Agregar(T element)
		{
			_context.Set<T>().Add(element);
			_context.SaveChanges();
		}

		public void Editar(T element)
		{
			_context.Set<T>().AddOrUpdate(element);
			_context.SaveChanges();
		}

		public void Eliminar(T element)
		{
			_context.Set<T>().Remove(element);
			_context.SaveChanges();
		}

		public IEnumerable<T> ObtenerTodo(Expression<Func<T, bool>> expression = null)
		{
			if (expression != null)
			{
				return _context.Set<T>().AsQueryable().Where(expression).ToList();
			}
			else
				return _context.Set<T>().ToList();
		}
	}
}
