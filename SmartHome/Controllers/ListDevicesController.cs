using Domain.Interface;
using SmartHome.Mapper;
using System.Collections;
using System.Linq;
using System.Web.Mvc;

namespace SmartHome.Controllers
{
    public class ListDevicesController : Controller
    {
        // GET: ListDevices
        private readonly IDomainDevice _deviceAPI;

        public ListDevicesController(IDomainDevice deviceAPI)
        {
            _deviceAPI = deviceAPI;
        }

        public ActionResult GetAllDevices()
        {
            var res = _deviceAPI.GetAllDomain();
            //ViewBag.list = res.Select(_ => _.ConvertToAPI()).ToList();
            IEnumerable AllDevices = res.Select(_ => _.ConvertToAPI()).ToList();
            return View(AllDevices);
            //return View();
        }
    }
}