 using Machine.Specifications;
 using app.utility.service_locator;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  public class DependenciesSpecs
  {
    public abstract class concern : Observes
    {
        
    }

   
    public class when_providing_access_to_the_service_that_does_dependency_resolution : concern
    {
      Establish c = () =>
      {
        resolution_service = fake.an<IFindDependencies>();
        IResolveTheContainerConfiguredAtStartup resolution = () => resolution_service;

        spec.change(() => Dependencies.resolution).to(resolution);
      };

      Because b = () =>
        result = Dependencies.fetch;

      It should_return_the_resolution_facade_configured_during_the_startup_process = () =>
        result.ShouldEqual(resolution_service);

      static IFindDependencies result;
      static IFindDependencies resolution_service;
    }
  }
}
