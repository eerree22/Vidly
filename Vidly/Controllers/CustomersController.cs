using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        //使用DbContext的第一步
        private ApplicationDbContext _context;

        //使用DbContext的第二步
        public CustomersController()//建構子初始化DbContext 
        {
            _context=new ApplicationDbContext();
        }

        //使用DbContext的第三步
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            //這邊一定要Include MembershipType進來，View裡面才能使用MembershipType的東西
            var myCustimers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(myCustimers);
        }

        public ActionResult Details(int id)
        {
            var myCustomer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(x => x.Id == id);
            if (myCustomer==null)
            {
                return HttpNotFound();
            }
            return View(myCustomer);
        }
    }
}