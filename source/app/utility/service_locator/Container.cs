using System;
using System.Collections.Generic;

namespace app.utility.service_locator
{
  public class Container :IFindDependencies,
  {
      private  readonly Dictionary<Type, Type> _dictionary = new Dictionary<Type, Type>();

    public TDependency an<TDependency>()
    {
        return _dictionary[typeof (TDependency)];
    }
  }
}