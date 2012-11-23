using System;

namespace app.utility.service_locator
{
    public interface IMapDependencies
    {
        Type get<T>();
    }
}