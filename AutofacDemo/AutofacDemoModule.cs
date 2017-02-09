// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutofacDemoModule.cs" company="RungePincockMinarco">
//   2017
// </copyright>
// <summary>
//   Defines the AutofacDemoModule type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AutofacDemo
{
    using Autofac;

    /// <summary>
    /// The autofac demo module.
    /// </summary>
    public class AutofacDemoModule : Module
    {
        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<MyInstancePerDependency>().AsSelf().InstancePerDependency();
            builder.RegisterType<MyInstancePerLifetimeScope>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<MyInstancePerMatchingLifetimeScope>().AsSelf().InstancePerMatchingLifetimeScope("TestScope");
            builder.RegisterType<MySingleInstance>().AsSelf().SingleInstance();
        }
    }
}
