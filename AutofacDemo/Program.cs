namespace AutofacDemo
{
    using System;
    using System.Windows.Forms;

    using Autofac;
    using Autofac.Core;
    using Autofac.Core.Lifetime;
    using Autofac.Core.Registration;

    /// <summary>
    /// Program class
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            RunTests();
        }

        private static void RunTests()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AutofacDemoModule>();
            var container = builder.Build();

            System.Console.WriteLine("Lifetime Scope: Unscoped");
            System.Console.WriteLine(container.Resolve<MyInstancePerDependency>().ToString());
            System.Console.WriteLine(container.Resolve<MyInstancePerDependency>().ToString());
            System.Console.WriteLine(container.Resolve<MyInstancePerLifetimeScope>().ToString());
            System.Console.WriteLine(container.Resolve<MyInstancePerLifetimeScope>().ToString());
            System.Console.WriteLine(container.Resolve<MySingleInstance>().ToString());
            System.Console.WriteLine(container.Resolve<MySingleInstance>().ToString());

            try
            {
                System.Console.WriteLine(container.Resolve<MyInstancePerMatchingLifetimeScope>().ToString());
                System.Console.WriteLine(container.Resolve<MyInstancePerMatchingLifetimeScope>().ToString());
            }
            catch (Exception)
            {
                System.Console.WriteLine("InstancePerMatchingLifetimeScope is unable to be resolved in this scope.");
            }
            
            using (var scope = new LifetimeScope(container.ComponentRegistry))
            {
                System.Console.WriteLine("Lifetime Scope: Unnamed");
                System.Console.WriteLine(scope.Resolve<MyInstancePerDependency>().ToString());
                System.Console.WriteLine(scope.Resolve<MyInstancePerDependency>().ToString());
                System.Console.WriteLine(scope.Resolve<MyInstancePerLifetimeScope>().ToString());
                System.Console.WriteLine(scope.Resolve<MyInstancePerLifetimeScope>().ToString());
                System.Console.WriteLine(scope.Resolve<MySingleInstance>().ToString());
                System.Console.WriteLine(scope.Resolve<MySingleInstance>().ToString());

                try
                {
                    System.Console.WriteLine(scope.Resolve<MyInstancePerMatchingLifetimeScope>().ToString());
                    System.Console.WriteLine(scope.Resolve<MyInstancePerMatchingLifetimeScope>().ToString());
                }
                catch (Exception)
                {
                    System.Console.WriteLine("InstancePerMatchingLifetimeScope is unable to be resolved in this scope.");
                }

                System.Console.WriteLine("End of scope: Unnamed");
            }

            using (var scope = new LifetimeScope(container.ComponentRegistry))
            {
                System.Console.WriteLine("Lifetime Scope: Unnamed 2");
                System.Console.WriteLine(scope.Resolve<MyInstancePerDependency>().ToString());
                System.Console.WriteLine(scope.Resolve<MyInstancePerDependency>().ToString());
                System.Console.WriteLine(scope.Resolve<MyInstancePerLifetimeScope>().ToString());
                System.Console.WriteLine(scope.Resolve<MyInstancePerLifetimeScope>().ToString());
                System.Console.WriteLine(scope.Resolve<MySingleInstance>().ToString());
                System.Console.WriteLine(scope.Resolve<MySingleInstance>().ToString());

                try
                {
                    System.Console.WriteLine(scope.Resolve<MyInstancePerMatchingLifetimeScope>().ToString());
                    System.Console.WriteLine(scope.Resolve<MyInstancePerMatchingLifetimeScope>().ToString());
                }
                catch (Exception)
                {
                    System.Console.WriteLine("InstancePerMatchingLifetimeScope is unable to be resolved in this scope.");
                }

                System.Console.WriteLine("End of scope: Unnamed");
            }

            using (var scope = new LifetimeScope(container.ComponentRegistry, "TestScope"))
            {
                System.Console.WriteLine("Lifetime Scope: TestScope");
                System.Console.WriteLine(scope.Resolve<MyInstancePerDependency>().ToString());
                System.Console.WriteLine(scope.Resolve<MyInstancePerDependency>().ToString());
                System.Console.WriteLine(scope.Resolve<MyInstancePerLifetimeScope>().ToString());
                System.Console.WriteLine(scope.Resolve<MyInstancePerLifetimeScope>().ToString());
                System.Console.WriteLine(scope.Resolve<MySingleInstance>().ToString());
                System.Console.WriteLine(scope.Resolve<MySingleInstance>().ToString());

                try
                {
                    System.Console.WriteLine(scope.Resolve<MyInstancePerMatchingLifetimeScope>().ToString());
                    System.Console.WriteLine(scope.Resolve<MyInstancePerMatchingLifetimeScope>().ToString());
                }
                catch (Exception)
                {
                    System.Console.WriteLine("InstancePerMatchingLifetimeScope is unable to be resolved in this scope.");
                }

                using (var childScope = new LifetimeScope(container.ComponentRegistry, "TestScope"))
                {
                    System.Console.WriteLine("Lifetime Scope: ChildScope");
                    System.Console.WriteLine(childScope.Resolve<MyInstancePerDependency>().ToString());
                    System.Console.WriteLine(childScope.Resolve<MyInstancePerDependency>().ToString());
                    System.Console.WriteLine(childScope.Resolve<MyInstancePerLifetimeScope>().ToString());
                    System.Console.WriteLine(childScope.Resolve<MyInstancePerLifetimeScope>().ToString());
                    System.Console.WriteLine(childScope.Resolve<MySingleInstance>().ToString());
                    System.Console.WriteLine(childScope.Resolve<MySingleInstance>().ToString());

                    try
                    {
                        System.Console.WriteLine(childScope.Resolve<MyInstancePerMatchingLifetimeScope>().ToString());
                        System.Console.WriteLine(childScope.Resolve<MyInstancePerMatchingLifetimeScope>().ToString());
                    }
                    catch (Exception)
                    {
                        System.Console.WriteLine("InstancePerMatchingLifetimeScope is unable to be resolved in this scope.");
                    }

                    System.Console.WriteLine("End of scope: ChildScope");
                }

                System.Console.WriteLine("End of scope: TestScope");

                container.Dispose();
            }
        }
    }
}
