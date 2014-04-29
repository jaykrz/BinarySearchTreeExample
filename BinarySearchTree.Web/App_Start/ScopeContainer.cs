﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;

namespace BinarySearchTree.Web.App_Start
{
    public class ScopeContainer : IDependencyScope
    {
        protected IUnityContainer container;

        public ScopeContainer(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            //if (container.IsRegistered(serviceType))
            //{

            object result = null;
            try
            {
                result = container.Resolve(serviceType);
            }
            catch (Exception)
            {

            }
            return result;
            //}
            //else
            //{
            //    return null;
            //}
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (container.IsRegistered(serviceType))
            {
                return container.ResolveAll(serviceType);
            }
            else
            {
                return new List<object>();
            }
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }

    class IoCContainer : ScopeContainer, IDependencyResolver
    {
        public IoCContainer(IUnityContainer container)
            : base(container)
        {
        }

        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new ScopeContainer(child);
        }
    }
}