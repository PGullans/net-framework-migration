using System.Net;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;

using Ok.Framework.Db.Model;
using Ok.Net.Web.Config;
using Ok.Net.Web.Services;


namespace Ok.Net.Web.Controllers;

public class OrdersController : Controller
{
    private readonly OrderService _orderService;
    private readonly AccountService _accountService;
    private readonly OptionDb _optionDb;


    public OrdersController(OrderService orderService, AccountService accountService,
        IOptions<OptionDb> optionDb)
    {
        _orderService = orderService;
        _accountService = accountService;
        _optionDb = optionDb.Value;
    }

    // GET: Orders
    public ActionResult Index()
    {
        if (_optionDb.ShowVersion)
            ViewBag.DbInfo = "Database Versioninfo: " + _optionDb.Version;
        
        var orders = _orderService.GetAll();
        return View(orders.ToList());
    }

    // GET: Orders/Details/5
    public ActionResult Details(Guid? id)
    {
        if (id == null)
        {
            return new BadRequestResult();
        }
        Order order = _orderService.GetById(id.Value);
        if (order == null)
        {
            return new NotFoundResult();
        }
        return View(order);
    }

    // GET: Orders/Create
    public ActionResult Create()
    {
        PrepareViewBags();
        return View();
    }

    // POST: Orders/Create
    // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
    // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([FromForm] Order order)
    {
        if (ModelState.IsValid)
        {
            _orderService.Upsert(order);
            return RedirectToAction("Index");
        }
        PrepareViewBags();
        return View(order);
    }

    // GET: Orders/Edit/5
    public ActionResult Edit(Guid? id)
    {
        if (id == null)
        {
            return new BadRequestResult();
        }
        Order order = _orderService.GetById(id.Value);
        if (order == null)
        {
            return new NotFoundResult();
        }
        PrepareViewBags();
        return View(order);
    }

    // POST: Orders/Edit/5
    // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
    // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([FromForm] Order order)
    {
        if (ModelState.IsValid)
        {
            _orderService.Upsert(order);
            return RedirectToAction("Index");
        }
        PrepareViewBags();
        return View(order);
    }

    // GET: Orders/Delete/5
    public ActionResult Delete(Guid? id)
    {
        if (id == null)
        {
            return new BadRequestResult();
        }
        Order order = _orderService.GetById(id.Value);
        if (order == null)
        {
            return new NotFoundResult();
        }
        return View(order);
    }

    // POST: Orders/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(Guid id)
    {
        _orderService.Delete(id);
        return RedirectToAction("Index");
    }

    private void PrepareViewBags()
    {
        var accounts = _accountService.GetAll().ToList();
        ViewBag.AccountId = new SelectList(accounts, "AccountId", "Name");
    }
}
