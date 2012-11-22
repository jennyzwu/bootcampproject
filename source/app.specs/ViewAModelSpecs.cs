using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewAReport<>))]
  public class ViewAModelSpecs
  {
    public abstract class concern : Observes<ISupportAUserFeature,
                                      ViewAReport<string>>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IContainRequestDetails>();
        model = "Test";
        depends.on<IGetPresentationDataFromARequest<string>>(x =>
        {
          x.ShouldEqual(request);
          return model;
        });

        display_engine = depends.on<IDisplayInformation>();
      };

      Because b = () =>
        sut.run(request);

      It should_display_the_model_retrieved_by_a_query =
        () => display_engine.received(x => x.display(model));

      static IContainRequestDetails request;
      static IDisplayInformation display_engine;
      static string model;
    }
  }
}