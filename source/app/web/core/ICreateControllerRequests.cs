using System.Web;

namespace app.web.core
{
  public interface ICreateControllerRequests
  {
    IContainRequestDetails create_a_controller_request_from(HttpContext a_raw_aspnet_request);
  }

	class ControllerFactory : ICreateControllerRequests
	{
		public IContainRequestDetails create_a_controller_request_from(HttpContext a_raw_aspnet_request)
		{
			return new ContainRequestDetails(a_raw_aspnet_request.Request.Url);
		}
	}
}