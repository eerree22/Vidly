using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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

        public ActionResult New()
        {
            var myMembershiptype = _context.MembershipTypes.ToList();

            //當需要給View多個Model時則先建立ViewModel
            var myNewCustomerViewModel = new CustomerFormViewModel
            {
                MembershipTypes = myMembershiptype,
                ActName="新增會員"
            };

            return View(myNewCustomerViewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList(),
                ActName="修改會員"
            };

            return View("New",viewModel);
        }

        /// <summary>
        /// 雖然前端是一個ViewModel，但這個ViewModel中包含Customer,所以這邊用Customer當參數接收HttpPost
        /// </summary>
        /// <param name="Customer">重點!!! 這個客戶參數的名稱要與ViewModel的客戶完全相同</param>
        /// <returns></returns>
        [HttpPost]//限制這個function只能用HttpPost呼叫
        public ActionResult Save(Customer Customer)
        {
            //看放在前端的HiddenFor(Id)來決定要做新增還是修改動作
            if (Customer.Id==0)
            {
                _context.Customers.Add(Customer);//新增                
            }
            else
            {
                var myCustomer = _context.Customers.Single(c => c.Id == Customer.Id);
                myCustomer.Name = Customer.Name;
                myCustomer.Birthdate = Customer.Birthdate;
                myCustomer.MembershipTypeId = Customer.MembershipTypeId;
                myCustomer.IsSubscribedToNewsletter = Customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();//要commit才會執行

            return RedirectToAction("Index","Customers"); //(AnctionName,ControllerName)
        }
    }
}