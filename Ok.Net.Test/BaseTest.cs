using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Ok.Framework.Db;

namespace Ok.Framework.Test;

[TestClass]
public class BaseTest
{
    private static IServiceProvider _serviceProvider;
    private static WebApplicationFactory<Ok.Net.Web.Program> _testFactory;
    protected IDbContextTransaction _transactionDb;

    [AssemblyInitialize]
    public static void AssemblyInitialize(TestContext context)
    {
        _testFactory = new WebApplicationFactory<Ok.Net.Web.Program>();
        _serviceProvider = _testFactory.Services.CreateScope().ServiceProvider;
    }

    protected static T Resolve<T>()
    {
        return _serviceProvider.GetRequiredService<T>();
    }

    [TestInitialize]
    public virtual void TransactionTestStart()
    {
        _transactionDb = Resolve<OkFrameworkContext>().Database.BeginTransaction();
    }

    [TestCleanup]
    public virtual void TransactionTestEnd()
    {
        _transactionDb.Rollback();
        _transactionDb.Dispose();
    }
}