using System.Collections.Generic;

namespace app.web.application.catalogbrowsing
{
	public class ViewProductsInDepartmentRequest
	{
		public IEnumerable<Product> products { get; set; }
	}
}