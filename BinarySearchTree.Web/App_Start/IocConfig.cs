using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using BinarySearchTree.Domain;
using BinarySearchTree.Domain.Factory;
using BinarySearchTree.Web.DbContext;
using BinarySearchTree.Web.Service;
using Microsoft.Practices.Unity;
using NextDimension.GenericRepository;
using NextDimension.GenericRepository.EntityFrameworkRepository;

namespace BinarySearchTree.Web.App_Start
{
    public class IocConfig
    {
        private static IUnityContainer _ioc;
        public static void RegisterIoc(HttpConfiguration config)
        {
            ConfigureIoC();
            config.DependencyResolver = new IoCContainer(_ioc);

            IControllerFactory factory = new UnityControllerFactory(_ioc);
            ControllerBuilder.Current.SetControllerFactory(factory);
        }

        private static void ConfigureIoC()
        {
            _ioc = _ioc ?? new UnityContainer();

            _ioc.RegisterType<System.Data.Entity.DbContext, BinarySearchTreeDomainContext>();
            _ioc.RegisterType<IBinarySearchTreeReadService, BinarySearchTreeReadService>();
            //_ioc.RegisterType<IBinarySearchTreeReadService, BinarySearchTreeReadServiceFake>();
            _ioc.RegisterType<IBinarySearchTreeReadContext, BinarySearchTreeReadContext>();
            _ioc.RegisterType<ITreeFactory, TreeFactory>();
             
            _ioc.RegisterType<IUnitOfWork, UnitOfWork>();
            _ioc.RegisterType<IGenericRepository<Tree, Guid>, GenericRepository<Tree, Guid>>(new InjectionConstructor(typeof(IUnitOfWork), true));

        }
    }

    internal class UnityControllerFactory : DefaultControllerFactory
    {
        public readonly IUnityContainer Container;

        public UnityControllerFactory(IUnityContainer container)
        {
            Container = container;
        }

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            return (IController)Container.Resolve(GetControllerType(requestContext, controllerName));
        }

        public override void ReleaseController(IController controller)
        {
            Container.Teardown(controller);

            base.ReleaseController(controller);
        }
    }
}