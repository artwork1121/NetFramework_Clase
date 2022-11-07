using NET_Framework.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NET_Framework.Utils
{
	public static class HtmlUtils
	{
		public static IHtmlString CardProduct(this HtmlHelper helper, ProductoViewModel producto)
		{
			var card =
				$@"<div class=""card"" style=""width: 18rem;"">
					<img src=""{producto.Image}"" class=""card-img-top"" alt=""..."">
					<div class=""card-body"">
					<h5 class=""card-title"">{producto.Name}</h5>
					<p class=""card-text"">{producto.Description}</p>
					<p class=""card-text""><strong>$ {producto.TotalPrice}</strong></p>
					<a href=""#"" class=""btn btn-primary"">Go somewhere</a>
					</div>
				</div>";
			return helper.Raw(card);
		}
	}
}