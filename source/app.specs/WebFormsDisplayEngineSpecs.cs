﻿using System.Web;
using Machine.Specifications;
using app.specs.utility;
using app.web.core;
using app.web.core.aspnet;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(WebFormsDisplayEngine))]
  public class WebFormsDisplayEngineSpecs
  {
    public abstract class concern : Observes<IDisplayInformation,
                                      WebFormsDisplayEngine>
    {
    }

    public class when_displaying_a_presentation_model : concern
    {
      Establish c = () =>
      {
        view = fake.an<IHttpHandler>();
        data = new AnItemToDisplay();
        the_current_request = ObjectFactory.web.create_request();

        view_factory = depends.on<ICreateViews>();
        depends.on<IGetTheCurrentlyExecutingRequest>(() => the_current_request);

        view_factory.setup(x => x.create_view_that_can_render(data)).Return(view);
      };
      Because b = () =>
        sut.display(data);

      It should_tell_the_view_that_can_display_the_model_to_render = () =>
        view.received(x => x.ProcessRequest(the_current_request));


      static AnItemToDisplay data;
      static IHttpHandler view;
      static HttpContext the_current_request;
      static ICreateViews view_factory;
    }

    public class AnItemToDisplay
    {
    }
  }
}