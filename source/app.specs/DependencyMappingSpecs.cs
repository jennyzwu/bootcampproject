using System;
using Machine.Specifications;
using app.utility.service_locator;
using app.web.core;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    public class DependencyMappingSpecs
    {
        public abstract class concern : Observes<DependencyMapping>
        { }

        public class when_the_getting_a_contract_type_from_mappings : concern
        {
            private Because b = () => result = sut.get(typeof (IProcessRequests));

            private It should_return_the_implementation_type = () => result.ShouldEqual(typeof(FrontController));

            private static Type result;
            private static IFindDependencies resolution_service;
        }
    }
}