using System;
using System.Collections.Generic;
using app.utility.service_locator;

namespace app.web.core
{
    public class ReflectionBasedContractDependenciesFinder : IFindContractDependencies
    {
        public IEnumerable<Type> get_required_dependencies(Type type)
        {
            throw new NotImplementedException();
        }
    }

    public class DependencyMapping : IMapDependencies
    {
        private readonly Dictionary<Type, Type> _dictionary;

        public DependencyMapping()
        {
            _dictionary = new Dictionary<Type, Type>
                {
                    {typeof (IProcessRequests), typeof (FrontController)}
                };
        }

        public Type get(Type contractType)
        {
            return _dictionary[contractType];
        }
    }
}