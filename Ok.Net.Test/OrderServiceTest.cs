using Microsoft.VisualStudio.TestTools.UnitTesting;

using Ok.Net.Web.Services;

using Shouldly;

namespace Ok.Framework.Test;

[TestClass]
public class OrderServiceTest : BaseTest
{
    private OrderService _orderService;

    [TestInitialize]
    public void Setup()
    {
        _orderService = Resolve<OrderService>();
    }

    [TestMethod]
    public void GetAll_Succeeds()
    {
        // arrange

        // act
        var result = _orderService.GetAll().ToList();

        // assert
        result.ShouldNotBeNull();
        result.ShouldNotBeEmpty();
        result.ShouldAllBe(_ => !string.IsNullOrWhiteSpace(_.Name));
        result.ShouldAllBe(_ => _.Account != null);
        result.ShouldAllBe(_ => _.Account.Contacts.Any());
    }

    [TestMethod]
    public void GetById_Succeeds()
    {
        // arrange
        var orderId = _orderService.GetAll().Select(_ => _.OrderId).First();

        // act
        var result = _orderService.GetById(orderId);

        result.ShouldNotBeNull();
        result.Name.ShouldNotBeNull();
        result.Price.ShouldBeGreaterThan(0);
        result.Account.ShouldNotBeNull();
        result.Account.Contacts.ShouldNotBeEmpty();
    }
}
