using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace assignment.App_Start
{
    public class AutofacConfig
    {


        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<Data.repo.data.assignment.assignmentContext>()
                   .As<Model.repo.data.assignment.Idbcontext>()
                   .InstancePerRequest();

            builder.RegisterType<Application.employeeRepo>()
                   .As<Application.IemployeeRepo>()
                   .InstancePerRequest();

            //builder.RegisterGeneric(typeof(GenericRepository<>))
            //       .As(typeof(IGenericRepository<>))
            //       .InstancePerRequest();

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }
        //public static void Register()
        //{
        //    string text = "A class is the most powerful data type in C#. Like a structure, " +
        //               "a class defines the data and behavior of the data type. ";
        //    // WriteAllText creates a file, writes the specified string to the file,
        //    // and then closes the file.    You do NOT need to call Flush() or Close().
        //    System.IO.File.WriteAllText(@"WriteText.txt", text);

        //    var builder = new ContainerBuilder();

        //    // Register dependencies in controllers
        //    builder.RegisterControllers(typeof(WebApiApplication).Assembly);

        //    // Register dependencies in filter attributes
        //    builder.RegisterFilterProvider();

        //    // Register dependencies in custom views
        //    builder.RegisterSource(new ViewRegistrationSource());

        //    builder.RegisterType<Application.employeeRepo>().As<Application.IemployeeRepo>();

        //    // Register our Data dependencies
        //    builder.RegisterModule(new assignment.Data.moduleReg());

        //    var container = builder.Build();

        //    // Set MVC DI resolver to use our Autofac container
        //    DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        //}
    }
    public class bootstrapper
    {
        public static void Run()
        {
            AutofacConfig.Initialize(GlobalConfiguration.Configuration);
        }
    }

}