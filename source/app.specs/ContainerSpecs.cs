using System;
using System.Collections.Generic;
using Machine.Specifications;
using app.utility.service_locator;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
    [Subject(typeof(Container))]
    public class ContainerSpecs
    {
        public abstract class concern : Observes<IFindDependencies, Container>
        {}

        public class when_fetching_contract_implementation_for_a_simple_type : concern
        {
            Establish c = () =>
                {
                    var mapDependencies = fake.an<IMapDependencies>();
                    mapDependencies.setup(x => x.get(typeof(IMapDependencies))).Return(implementationType);
                    depends.on(mapDependencies);


                    findContractDependencies = depends.on<IFindContractDependencies>();
                };

            Because b = () => result = sut.an<IAmAContract>();
 
            It should_return_instance_of_the_correct_type = () => result.ShouldBe(implementationType);

            private It should_search_for_contract_dependencies =
                () => findContractDependencies.received(x => x.get_required_dependencies(implementationType));

            private static IAmAContract result;
            private static IAmAContract contractImplementor;
            private static IFindContractDependencies findContractDependencies;
            private static Type implementationType = typeof(ContractImpl);
        }

        public class when_fetching_contract_implementation_for_a_complex_type : concern
        {
            Establish c = () =>
            {
                var mapDependencies = fake.an<IMapDependencies>();
                mapDependencies.setup(x => x.get(typeof(IAmAComplexContract))).Return(typeof(ComplexContractImpl));
                mapDependencies.setup(x => x.get(typeof(IAmAContract))).Return(typeof(ContractImpl));
                depends.on(mapDependencies);

                findContractDependencies = depends.on<IFindContractDependencies>();
                findContractDependencies.setup(x => x.get_required_dependencies(typeof (ComplexContractImpl)))
                                        .Return(() => new List<Type> { typeof(IAmAContract) });
                findContractDependencies.setup(x => x.get_required_dependencies(typeof(ContractImpl)))
                                        .Return(() => new List<Type>());
            };

            Because b = () => result = sut.an<IAmAComplexContract>();

            It should_return_instance_of_the_correct_type = () => result.ShouldBe(implementationType);

            private It should_search_for_contract_dependencies =
                () => findContractDependencies.received(x => x.get_required_dependencies(implementationType));

            private static IAmAComplexContract result;
            private static IAmAContract contractImplementor;
            private static IFindContractDependencies findContractDependencies;
            private static Type implementationType = typeof(ComplexContractImpl);
        }
    }

    internal interface IAmAContract
    {
    }

    internal class ContractImpl : IAmAContract
    {
    }

    internal interface IAmAComplexContract
    {
    }

    internal class ComplexContractImpl : IAmAComplexContract
    {
        public ComplexContractImpl(IAmAContract contract)
        {
            
        }
    }

}
