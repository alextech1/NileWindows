using ClassProject2.Data.Entities;
using ClassProject2.Data.Infrastructure;
using ClassProject2.Data.Repositories;
using Nile.Mvc.Extensions;
using Nile.Mvc.Models;
using System.Web.Mvc;

namespace Nile.Mvc.Controllers
{
    public class CustomersController : BaseController
    {
        private IEntityBaseRepository<Customer> _customerRepository;
        
        public CustomersController (IEntityBaseRepository<Customer> customerRepository, IUnitOfWork unitOfWork): base(unitOfWork)
        {            
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var items = _customerRepository.GetAll();            
            return View(items.ToModel());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CustomerModel());
        }

        [HttpPost]
        public ActionResult Create(CustomerModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var item = new Customer { FirstName = model.FirstName, LastName = model.LastName };
            _customerRepository.Add(item);
            UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit (int id) //Fetch data
        {
            var item = _customerRepository.GetSingle(id);
            var model = new CustomerModel()
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CustomerModel model)
        {
            if (!ModelState.IsValid)
                return View(model);            
            var item = _customerRepository.GetSingle(model.Id);
            item.LastName = model.LastName;
            item.FirstName = model.FirstName;
            _customerRepository.Edit(item);
            UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var item = _customerRepository.GetSingle(id);
            var model = new CustomerModel()
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var item = _customerRepository.GetSingle(id);
            var model = new CustomerModel()
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName
            };
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var item = _customerRepository.GetSingle(id);
            _customerRepository.Delete(item);
            UnitOfWork.Commit();
            return RedirectToAction("Index");
        }
    }
}