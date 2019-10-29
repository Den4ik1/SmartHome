using DI;
using DI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using RebitMQ;
using SmartHome.Models;
using System;
using System.Web;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace SmartHome
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion
     
      
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ApplicationDbContext>();
            container.RegisterType<ApplicationSignInManager>();
            container.RegisterType<ApplicationUserManager>();
            container.RegisterType<EmailService>();
            container.RegisterType<SmsService>();

            //container.RegisterType<Broker>();

            container.RegisterType<IAuthenticationManager>(
  new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));

            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(
            new InjectionConstructor(typeof(ApplicationDbContext)));

            container.RegisterType<IRoleStore<IdentityRole, string>, RoleStore<IdentityRole>>(
         new HierarchicalLifetimeManager(), new InjectionConstructor(typeof(ApplicationDbContext)));

            Registre<DemainDevice>(container);
            Registre<InfrastructureDevice>(container);
            

          
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

        }

        private static void Registre<T>(IUnityContainer container) where T : IModels, new()
        {
            new T().Register(container);
        }
    }
}