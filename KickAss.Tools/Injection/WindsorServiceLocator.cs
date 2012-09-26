namespace KickAss.Tools.Injection
{
    using System;
    using System.Collections.Generic;
    using Castle.Windsor;
    using Microsoft.Practices.ServiceLocation;

    public class WindsorServiceLocator : ServiceLocatorImplBase
    {
        private readonly IWindsorContainer container;

        public WindsorServiceLocator(IWindsorContainer container)
        {
            this.container = container;
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            return key != null
                       ? container.Resolve(key, serviceType)
                       : container.Resolve(serviceType);
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            // ReSharper disable SuspiciousTypeConversion.Global
            return (IEnumerable<object>)container.ResolveAll(serviceType);
            // ReSharper restore SuspiciousTypeConversion.Global
        }
    }
}