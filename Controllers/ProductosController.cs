using AccDatos.Services;
using NET.Dominio;
using NET_Framework.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace NET_Framework.Controllers
{
	public class ProductosController : Controller
	{
		private readonly ProductService _productoService = new ProductService();
		// GET: Productos
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Buscar(string buscar)
		{
			IEnumerable<ProductoViewModel> productos = _productoService
				.ObtenerTodo(p => p.Description.Contains(buscar))
				.Select(p => new ProductoViewModel()
				{
					Id = p.Id,
					Name = p.Name,
					Description = p.Description,
					Price = p.Price,
					Tax = p.Tax,
				});
			return View(productos);
		}
		[HttpGet]
		public ActionResult Producto()
		{
			var producto = _productoService.ObtenerTodo(x=>x.Id == 1).FirstOrDefault();

			var response = new ProductoViewModel()
			{
				Name = producto.Name,
				Description = producto.Description,
				Price = producto.Price,
				Tax = producto.Tax,
				Image = $"data:image/png;base64,{Convert.ToBase64String(producto.Image)}"
			};
			return View(response);
		}
		[HttpPost]
		public ActionResult Producto(FormCollection collection)
		{
			//recepcion
			var file = Request.Files;
			WebImage image = new WebImage(file[0].InputStream);

			var arrayBit = image.GetBytes();
			_productoService.AgregarProducto(new Product()
			{
				Name = collection["name"],
				Description = collection["description"],
				Price = decimal.Parse(collection["price"]),
				Tax = decimal.Parse(collection["tax"]),
				CompanyId = 2,
				Image = arrayBit
            });

			//var producto = _productoService.GetProduct(1).ProductResponses.First();

			////
			//string imagenTobase64 = String.Empty;

			//if (producto.Image != null)
			//{
			//	imagenTobase64 = Convert.ToBase64String(producto.Image);
			//}


			var imagenTobase64 = Convert.ToBase64String(arrayBit);

			return View(new ProductoViewModel()
			{
				Name = collection["name"],
				Description = collection["description"],
				Price = decimal.Parse(collection["price"]),
				Tax = decimal.Parse(collection["tax"]),
				Image = $"data:image/png;base64,{imagenTobase64}"
			});
		}

		//[HttpPost]
		//public ActionResult Producto(ProductoViewModel producto)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		return RedirectToAction("Index", "Home");
		//	}
		//	return View(producto);
		//}
	}
}