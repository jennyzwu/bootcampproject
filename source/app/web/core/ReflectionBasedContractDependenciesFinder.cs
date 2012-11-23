using System;
using System.Collections.Generic;
using System.Reflection;
using app.utility.service_locator;

namespace app.web.core
{
    public class ReflectionBasedContractDependenciesFinder : IFindContractDependencies
    {
        public IEnumerable<Type> get_required_dependencies(Type type)
        {
            ConstructorInfo[] constructors = type.GetConstructors();
            ParameterInfo[] parameters = constructors[0].GetParameters();
            foreach (var parameterInfo in parameters)
            {
                yield return parameterInfo.ParameterType;
            }
        }
    }
}