
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Ok.Net.Web.Services;

using Shouldly;

namespace Ok.Framework.Test;

[TestClass]
public class AccountServiceTest : BaseTest
{
    private AccountService _accountService;

    [TestInitialize]
    public void Setup()
    {
        _accountService = Resolve<AccountService>();
    }

    [TestMethod]
    public void GetAll_Succeeds()
    {
        // arrange

        // act
        var result = _accountService.GetAll().ToList();

        // assert
        result.ShouldNotBeNull();
        result.ShouldNotBeEmpty();
        result.ShouldAllBe(_ => !string.IsNullOrWhiteSpace(_.Name));
        result.ShouldAllBe(_ => _.Contacts.Any());
    }

    [TestMethod]
    public void GetById_Succeeds()
    {
        // arrange
        var accountId = _accountService.GetAll().Select(_ => _.AccountId).First();

        // act
        var result = _accountService.GetById(accountId);

        result.ShouldNotBeNull();
        result.Name.ShouldNotBeNullOrWhiteSpace();
        result.Contacts.ShouldNotBeNull();
        result.Contacts.ShouldNotBeEmpty();
    }
}
