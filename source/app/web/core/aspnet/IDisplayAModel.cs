using System.Web;

namespace app.web.core.aspnet
{
  public interface IDisplayA<Model> : IHttpHandler
  {
    Model model { get; set; }
  }
}