using System;
using System.Collections.Generic;

namespace app.utility.service_locator
{
  public delegate IFindDependencies IResolveTheContainerConfiguredAtStartup();

  public delegate void IStoreDependencyMapping(Type contractType,Type implementorType);
}