using Autofac;

using Ok.Framework.Db.Repository;

using System;

namespace Ok.Framework.Db.Config
{
    public class DbIocModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(OkFrameworkContext)).InstancePerLifetimeScope();
        }
    }
}
