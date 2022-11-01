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
	public class ProductService : IProductService
	{
		private readonly ProductRepository _repository;

		public ProductService()
		{
			_repository = new ProductRepository();
		}
		public void AgregarProducto(Product product)
		{
			//logica que creamos!
			_repository.Agregar(product);
		}

		public void EditarProducto(Product product)
		{
			_repository.Editar(product);
		}

		public void EliminarProducto(Product product)
		{
			_repository.Eliminar(product);
		}

		public Product GetProductById(int id)
		{
			try
			{
				return _repository.ObtenerTodo(p => p.Id == id).First();
			}
			catch (Exception)
			{

				throw;
			}
            return _repository.ObtenerTodo(p => p.Id == id).FirstOrDefault();
		}

		public IEnumerable<Product> ObtenerTodo(Expression<Func<Product, bool>> expression = null)
		{
			return _repository.ObtenerTodo(expression);
		}
	}
}
