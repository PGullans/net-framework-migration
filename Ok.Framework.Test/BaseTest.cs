using Autofac;

using Ok.Framework.Db;
using Ok.Framework.Web;

using System.Data.Entity;

namespace Ok.Framework.Test
{
    [TestClass]
    public class BaseTest
    {
        private readonly IContainer container;
        protected DbContextTransaction _transactionDb;


        public BaseTest()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new WebIocModule());
            container = builder.Build();
        }

        protected TEntity Resolve<TEntity>()
        {
            return container.Resolve<TEntity>();
        }

        [ClassInitialize]
        public virtual void DbContextInitialize()
        {
            container.Resolve<OkFrameworkContext>();
        }

        [TestInitialize]
        public virtual void TransactionTestStart()
        {
            _transactionDb = container.Resolve<OkFrameworkContext>().Database.BeginTransaction();
        }

        [TestCleanup]
        public virtual void TransactionTestEnd()
        {
            _transactionDb.Rollback();
            _transactionDb.Dispose();
        }

        [ClassCleanup]
        public virtual void DbContextCleanup()
        {
            container.Dispose();
        }
    }
}