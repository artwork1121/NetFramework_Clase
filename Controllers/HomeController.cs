using AccDatos;
using AccDatos.Services;
using Microsoft.Ajax.Utilities;
using NET.Dominio;
using NET_Framework.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace NET_Framework.Controllers
{
	public class HomeController : Controller
	{
		private readonly ProductService _productService;
        private readonly SaleService _saleService;

        public HomeController()
		{
			_productService = new ProductService();
			_saleService = new SaleService();
		}
		public ActionResult Index(bool optional = false)
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Products()
		{
			ViewBag.Message = "Productos";

			var productos = _productService.ObtenerTodo();

			var respuesta = productos.Any(p => p.Name.Equals("remera"));

			var ventas = _saleService.ObtenerTodo();

			var producto2 = _productService.GetProduct(123);

			//ventas.Where(x => x.SaleLine.Any(sl => sl.Total > 100));

			//var respuesta2 = productos.Select(x => new DTO
			//{
			//	Nombre = x.Name,
			//	Descripcion = x.Description
			//});

			//productos.Sum(x => x.TotalPrice);
			//productos.Take(10);
			//productos.ToArray();
			//productos.Max(x => x.TotalPrice);
			//productos.Min(x => x.TotalPrice);

			try
			{
				if (producto2.status)
				{
					throw new ArithmeticException("");
				}
			}
			catch (Exception)
			{

				throw;
			}

			var model = new ProductsViewModel();
			
			return View(model);
		}

		[HttpPost]
		public ActionResult AlgoPost()
		{
			return RedirectToAction("Index", new { optional = true });
		}

		//public ActionResult JsonObtener(string comment)
		//{
		//	var producto = _service
		//		.ObtenerTodos()
		//		.Where(x => x.Description.Contains(comment))
		//		.Select(x => new dto
		//		{
		//			Id = x.Id,
		//			Name = x.Name,
		//			Descripcion = x.Description,
		//			Price = x.Price + (x.Price * x.Tax) / 100,
		//		}).ToArray();

		//	return Json(producto, JsonRequestBehavior.AllowGet);
		//}

		//public class dto
		//{
		//	public int Id { get; set; }
		//	public string Name { get; set; }
		//	public string Descripcion { get; set; }
		//	public decimal Price { get; set; }
		//}

		class DTO
		{
			public string Nombre { get; set; }
			public string Descripcion { get; set; }
		}
	}
}