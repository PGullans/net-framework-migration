using Autofac;
using Autofac.Integration.Mvc;

using Ok.Framework.Db.Config;

using System;
using System.Reflection;

namespace Ok.Framework.Web
{
    public class WebIocModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly());
            builder.RegisterModule<DbIocModule>();
        }
    }
}