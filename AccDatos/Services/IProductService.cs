using NET.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AccDatos.Services
{
	public interface IProductService
	{
		void AgregarProducto(Product product);
        void EditarProducto(Product product);
        void EliminarProducto(Product product);
        IEnumerable<Product> ObtenerTodo(Expression<Func<Product, bool>> expression = null);
        Product GetProductById(int id);
    }
}
