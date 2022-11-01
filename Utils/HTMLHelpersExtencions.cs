using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NET_Framework.Utils
{
	public static class HTMLHelpersExtencions
	{
		public static IHtmlString ButtonColorChange(this HtmlHelper helper, string color)
		{
			var button = $"<button type=\"button\" class=\"btn\" onclick=\"alert('{color}');\" style=\"background-color:{color}; cursor:pointer\">{color}</button>";

			return helper.Raw(button);
		}
	}
}