 using Machine.Specifications;
 using app.utility.service_locator;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(Container))]  
  public class ContainerSpecs
  {
    public abstract class concern : Observes<IFindDependencies,
                                      Container>
    {
        
    }

   
    //public class when_fetching_contract_implementation : concern
    //{
    //    private Establish c = () =>
    //        {
    //            depends.on<IFindContractI>()
    //        };

    //    Because b = () =>
    //                        result = sut.an<IAmAContract>();

    //    It should_first_observation = () =>
    //        {
    //            result.ShouldBeTheSameAs(contractImplementor);
    //        };

    //    private static IAmAContract result;
    //    private static IAmAContract contractImplementor;
    //}
  }

    internal interface IAmAContract
    {
    }
}
