using AutoMapper;
using CostMatrix.Core.Domain;
using CostMatrix.Core.Service;
using CostMatrix.Web.Models;
using System.Web.Mvc;

namespace CostMatrix.Web.Controllers
{
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService =settingService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var settings = _settingService.Get();
            var viewModel = Mapper.Map<SettingEditModel>(settings);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(SettingEditModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var domain = Mapper.Map<Setting>(viewModel);
                _settingService.Save(domain);
                TempData.Add("SuccessMessage", "Settings saved successfully");
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

    }
}
