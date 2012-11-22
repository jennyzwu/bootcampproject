using System;
using System.IO;
using System.Web;

namespace app.specs.utility
{
  public class ObjectFactory
  {
    public class web
    {
      public static HttpContext create_request()
      {
        return new HttpContext(new HttpRequest("blah.aspx", "http://localhost/blah.aspx", String.Empty),
                               new HttpResponse(new StringWriter()));
      }
    }
  }
}