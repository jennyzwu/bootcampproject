using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using app.utility.service_locator;
using app.web.core;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    public class ReflectionBasedContractDependenciesFinderSpecs
    {
        public abstract class concern : Observes<ReflectionBasedContractDependenciesFinder>
        { }

        public class when_the_getting_a_constructor_parameters_for_a_simple_typoe : concern
        {
            private Because b = () => result = sut.get_required_dependencies(typeof(SimpleType));

            private It should_return_no_constructor_parameters = () => result.Count().ShouldEqual(0);

            private static IEnumerable<Type> result;
        }

        public class when_the_getting_a_constructor_parameters_for_a_complex_typoe : concern
        {
            private Because b = () => result = sut.get_required_dependencies(typeof(ComplexType));

            private It should_return_one_constructor_parameters = () => result.Count().ShouldEqual(1);

            private It should_return_correct_constructor_parameters =
                () => result.First().ShouldEqual(typeof (SimpleType));
            
            private static IEnumerable<Type> result;
        }
    }

    public class SimpleType
    {
    }

    public class ComplexType
    {
        public ComplexType(SimpleType type)
        {
            
        }
    }
}