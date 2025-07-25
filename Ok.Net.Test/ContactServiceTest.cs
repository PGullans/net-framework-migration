using Microsoft.VisualStudio.TestTools.UnitTesting;

using Ok.Net.Web.Services;

using Shouldly;

namespace Ok.Framework.Test;

[TestClass]
public class ContactServiceTest : BaseTest
{
    private ContactService _contactService;

    [TestInitialize]
    public void Setup()
    {
        _contactService = Resolve<ContactService>();
    }

    [TestMethod]
    public void GetAll_Succeeds()
    {
        // arrange

        // act
        var result = _contactService.GetAll().ToList();

        // assert
        result.ShouldNotBeNull();
        result.ShouldNotBeEmpty();
        result.ShouldAllBe(_ => !string.IsNullOrWhiteSpace(_.FirstName));
        result.ShouldAllBe(_ => !string.IsNullOrWhiteSpace(_.LastName));
    }

    [TestMethod]
    public void GetById_Succeeds()
    {
        // arrange
        var contactId = _contactService.GetAll().Select(_ => _.ContactId).First();

        // act
        var result = _contactService.GetById(contactId);

        result.ShouldNotBeNull();
        result.FirstName.ShouldNotBeNullOrWhiteSpace();
        result.LastName.ShouldNotBeNullOrWhiteSpace();
    }
}
