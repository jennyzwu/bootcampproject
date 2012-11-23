using System;
using System.Collections.Generic;
using System.Linq;
using app.web.core;

namespace app.utility.service_locator
{
    public class Container : IFindDependencies
    {
        private readonly IMapDependencies _dependencyMapping;
        private readonly IFindContractDependencies _dependencies;

        public Container(IMapDependencies dependencyMapping, IFindContractDependencies dependencies)
        {
            _dependencyMapping = dependencyMapping;
            _dependencies = dependencies;
        }

        private object create(Type contractType)
        {
            var implementationType = _dependencyMapping.get(contractType);
            if (implementationType == null)
                return null;
            var requiredDependencies = _dependencies.get_required_dependencies(implementationType);
            var dependants = requiredDependencies.Select(create).ToArray();

            return Activator.CreateInstance(implementationType, dependants);
        }

        public TDependency an<TDependency>()
        {
            return (TDependency) create(typeof (TDependency));
        }
    }
}