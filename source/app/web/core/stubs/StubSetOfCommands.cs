using System.Collections;
using System.Collections.Generic;
using System.Web;
using app.web.application;
using app.web.application.catalogbrowsing;
using app.web.application.stubs;
using app.web.core.aspnet;

namespace app.web.core.stubs
{
	public class StubSetOfCommands : IEnumerable<IProcessOneRequest>
	{
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerator<IProcessOneRequest> GetEnumerator()
		{


			yield return new RequestCommand(x => Routes.IsMainDepartmentsRoute(x),
										  new ViewAReport<IEnumerable<Department>>(new GetTheMainDepartments()));

			yield return new RequestCommand(x => true,
				new ViewAReport<IEnumerable<Department>>(x => new StubCatalog().get_the_departments_using(x.map<ViewSubDepartmentsRequest>())));

			yield return new RequestCommand(x => true,
			                                new ViewAReport<IEnumerable<Product>>(
			                                	x =>
			                                	new StubCatalog().get_the_products_using(x.map<ViewProductsInDepartmentRequest>())));


		}

		private static class Routes
		{
			public static bool IsMainDepartmentsRoute(IContainRequestDetails request)
			{
				return request.is_good_for("main-deparments");
			}
		}

	  public class GetTheMainDepartments : IFetchAReport<IEnumerable<Department>>
	  {
	    public IEnumerable<Department> fetch_using(IContainRequestDetails request)
	    {
	      return new StubCatalog().get_the_main_departments();
	    }
	  }

		//public class SomeShit
		//{
		//    public bool MatchARequest(IContainRequestDetails request)
		//    {
		//        return request.Url.endsWith()
		//    }
		//}

	}
}