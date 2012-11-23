using System;
using System.Collections.Generic;
using app.utility.service_locator;
using app.web.core.stubs;

namespace app.web.core
{
    public class DependencyMapping : IMapDependencies
    {
        private readonly Dictionary<Type, Type> _dictionary;

        public DependencyMapping()
        {
            _dictionary = new Dictionary<Type, Type>
                {
                    {typeof (IProcessRequests), typeof (FrontController)},

                    {typeof (IFindCommands), typeof (CommandRegistry)},
                    {typeof (IEnumerable<IProcessOneRequest>), typeof (StubSetOfCommands)},
                    {typeof(ICreateTheCommandWhenOneCantBeFound), null},

                    {typeof (ICreateControllerRequests), typeof (StubRequestFactory)},
                };
        }

        public Type get(Type contractType)
        {
            return _dictionary[contractType];
        }
    }
}