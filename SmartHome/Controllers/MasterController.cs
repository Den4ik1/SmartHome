using Domain.Interface;
using SmartHome.Mapper;
using SmartHome.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SmartHome.Controllers
{
    public class MasterController : Controller
    {
        private readonly IDomainDevice _deviceAPI;

        public MasterController(IDomainDevice deviceAPI)
        {
            _deviceAPI = deviceAPI;
        }

        public ActionResult GetDevices()
        {
            var res = _deviceAPI.GetAllDomain();
            ViewBag.list = res.Select(_ => _.ConvertToAPI()).ToList();
            return View();
        }

      
    }
}