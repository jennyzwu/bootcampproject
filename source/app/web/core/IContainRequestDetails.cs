using System;

namespace app.web.core
{
  public interface IContainRequestDetails
  {
  	InputModel map<InputModel>();
  	bool is_good_for(string route);
  }

	class ContainRequestDetails : IContainRequestDetails
	{
		private readonly Uri _url;

		public ContainRequestDetails(Uri url)
		{
			_url = url;
		}

		public InputModel map<InputModel>()
		{
			throw new System.NotImplementedException();
		}

		public bool is_good_for(string route)
		{
			return _url.Query.EndsWith(route);
		}
	}
}