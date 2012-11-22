using System.Collections.Generic;

namespace app.web.application.catalogbrowsing
{
	public class ViewSubDepartmentsRequest
	{
		public IEnumerable<Department> departments { get; set; }
	}
}