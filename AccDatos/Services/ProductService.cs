using AccDatos.DTO;
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

		public ProductResponse GetProduct(int id)
		{
			try
			{
				throw new Exception("No pasas de aca");
				return new ProductResponse()
				{
					status = true,
					Message = "todo OK",
					ProductResponses = new List<Product>()
				};
			}
			catch (Exception e)
			{
				return new ProductResponse()
				{
					status = false,
					Message = e.Message,
					ProductResponses = new List<Product>()
				};
			}
		}

		public Product GetProductById(int id)
		{
			try
			{
				return _repository.ObtenerTodo(p => p.Id == id).First();
			}
			catch (Exception)
			{
				return _repository.ObtenerTodo(p => p.Id == id).FirstOrDefault();
			}
		}

		public IEnumerable<Product> ObtenerTodo(Expression<Func<Product, bool>> expression = null)
		{
			return _repository.ObtenerTodo(expression);
		}
	}
}
