using System.Web;
using app.web.application.catalogbrowsing.app.web.core.stubs;
using app.web.core;

namespace app.web.application.catalogbrowsing
{
  public class ViewAReport<PresentationData> : ISupportAUserFeature
  {
    IDisplayInformation display_engine;
    IGetPresentationDataFromARequest<PresentationData> query;

    public ViewAReport(IDisplayInformation display_engine, IGetPresentationDataFromARequest<PresentationData> query)
    {
      this.display_engine = display_engine;
      this.query = query;
    }
	public ViewAReport(IGetPresentationDataFromARequest<PresentationData> query)
		: this(new StubDisplayEngine(), query)
	{
	}

	public ViewAReport(IFetchAReport<PresentationData> query)
		: this(query.fetch_using)
	{
	}
    public void run(IContainRequestDetails request)
    {
      display_engine.display(query(request));
    }
  }
  namespace app.web.core.stubs
  {
	  public class StubDisplayEngine : IDisplayInformation
	  {
		  public void display<PresentationModel>(PresentationModel model)
		  {
			  HttpContext.Current.Items.Add("blah", model);
			  HttpContext.Current.Server.Transfer("~/views/DepartmentBrowser.aspx");
		  }
	  }
  }
}