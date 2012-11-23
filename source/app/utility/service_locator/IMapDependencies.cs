using System;
using System.Collections.Generic;

namespace app.utility.service_locator
{
    public interface IMapDependencies
    {
        Type get(Type contractType);
    }

    public interface IFindContractDependencies
    {
        IEnumerable<Type> get_required_dependencies(Type type);
    }
}