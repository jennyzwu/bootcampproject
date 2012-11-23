using System;
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

        public class when_fetching_contract_implementation : concern
        {
            Establish c = () =>
                {
                    var mapDependencies = fake.an<IMapDependencies>();
                    mapDependencies.setup(x => x.get<IAmAContract>()).Return(implementationType);
                    depends.on(mapDependencies);


                    findContractDependencies = depends.on<IFindContractDependencies>();
                };

            Because b = () =>
                result = sut.an<IAmAContract>();

            It should_return_instance_of_the_correct_type =
                () => result.ShouldBe(implementationType);

            private It should_search_for_contract_dependencies =
                () => findContractDependencies.received(x => x.get_required_dependencies(implementationType));

            private static IAmAContract result;
            private static IAmAContract contractImplementor;
            private static IFindContractDependencies findContractDependencies;
            private static Type implementationType = typeof(ContractImpl);
        }
    }

    internal interface IAmAContract
    {
    }

    internal class ContractImpl : IAmAContract
    {
    }
}
