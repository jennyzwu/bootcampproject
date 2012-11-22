namespace app.web.core
{
  public interface IProcessOneRequest : ISupportAUserFeature
  {
    bool can_process(IContainRequestDetails request);
  }
}