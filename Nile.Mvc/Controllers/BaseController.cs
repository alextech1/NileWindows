using ClassProject2.Data.Infrastructure;
using System.Web.Mvc;

namespace Nile.Mvc.Controllers
{
    public class BaseController : Controller
    {
        protected IUnitOfWork UnitOfWork;
        public BaseController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}