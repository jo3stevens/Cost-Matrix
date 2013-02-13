using AutoMapper;
using CostMatrix.Core.Service;
using CostMatrix.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CostMatrix.Web.Controllers
{
    public class ClientController : Controller
    {
        private readonly ClientService _clientService;
        private readonly MatrixService _matrixService;
        
        public ClientController()
        {
            _clientService = new ClientService();
            _matrixService = new MatrixService();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var clients = _clientService.GetAll();
            var viewModel = Mapper.Map<IEnumerable<ClientViewModel>>(clients);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new ClientEditModel());
        }

        [HttpPost]
        public ActionResult Add(ClientEditModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _clientService.Add(viewModel.Name, User.Identity.Name, DateTime.UtcNow);
                TempData.Add("SuccessMessage", "The new client was created successfully");
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var client = _clientService.GetById(id);
            var viewModel = Mapper.Map<ClientEditModel>(client);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(ClientEditModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _clientService.Edit(viewModel.Id, viewModel.Name);
                TempData.Add("SuccessMessage", "The client " + viewModel.Name + " was updated successfully");
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            var client = _clientService.GetById(id);
            var viewModel = Mapper.Map<ClientEditModel>(client);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(ClientEditModel viewModel)
        {
            var client = Mapper.Map<ClientViewModel>(_clientService.GetById(viewModel.Id));
            client.Projects.Each(p => _matrixService.DeleteByProjectId(p.Id));

            _clientService.Delete(viewModel.Id);
            TempData.Add("SuccessMessage", "The client " + viewModel.Name + " was deleted successfully");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Detail(string id)
        {
            var client = _clientService.GetById(id);
            var viewModel = Mapper.Map<ClientViewModel>(client);

            foreach (var project in viewModel.Projects)
            {
                project.Matrixes = Mapper.Map<IList<MatrixViewModel>>(_matrixService.GetByProjectId(project.Id));
            }

            return View(viewModel);
        }

        //Project Methods

        [HttpGet]
        public ActionResult AddProject(string id)
        {
            var client = Mapper.Map<ClientEditModel>(_clientService.GetById(id));
            var viewModel = new ProjectEditModel { ClientId = client.Id, ClientName = client.Name };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddProject(ProjectEditModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _clientService.AddProject(viewModel.ClientId, viewModel.Name, User.Identity.Name, DateTime.UtcNow);
                TempData.Add("SuccessMessage", "The project was created successfully");
                return RedirectToAction("Detail", "Client", new { @id = viewModel.ClientId });
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult EditProject(string id)
        {
            var client = _clientService.GetByProjectId(id);
            var viewModel = Mapper.Map<ProjectEditModel>(client);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditProject(ProjectEditModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _clientService.EditProject(viewModel.Id, viewModel.Name);
                TempData.Add("SuccessMessage", "The project was updated successfully");
                return RedirectToAction("Detail", "Client", new { @id = viewModel.ClientId });
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult DeleteProject(string id)
        {
            var client = _clientService.GetByProjectId(id);
            var viewModel = Mapper.Map<ProjectEditModel>(client);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DeleteProject(ProjectEditModel viewModel)
        {
            _matrixService.DeleteByProjectId(viewModel.Id);
            _clientService.DeleteProject(viewModel.Id);
            TempData.Add("SuccessMessage", "The project " + viewModel.Name + " was deleted successfully");
            return RedirectToAction("Detail", "Client", new { @id = viewModel.ClientId });
        }
    }
}
