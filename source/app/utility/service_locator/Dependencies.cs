﻿using System;
using System.Collections.Generic;

namespace app.utility.service_locator
{
    public static class Dependencies
    {
        public static IResolveTheContainerConfiguredAtStartup resolution = (d) =>
            {
                throw new NotImplementedException("This needs to be configured by a startup process");
            };

        
        public static IFindDependencies fetch
        {
            get
            {
                return resolution(_dictionary);
            }
        }







        public static void map<TContract>(Type concreteType)
        {
            _dictionary.Add(typeof (TContract), concreteType);
        }
    }
}