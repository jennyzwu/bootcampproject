using System;
using System.Collections.Generic;
using app.web.core;

namespace app.utility.service_locator
{
  public class Container :IFindDependencies
  {
      private readonly IMapDependencies _dependencyMapping;

      public Container(IMapDependencies dependencyMapping)
      {
          _dependencyMapping = dependencyMapping;
      }

    public TDependency an<TDependency>()
    {
        var type = _dependencyMapping.get<TDependency>();



        return (TDependency)Activator.CreateInstance(type);
    }
  }
}