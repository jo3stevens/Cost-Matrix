using System.Collections.Generic;
using CostMatrix.Core.Domain;
using CostMatrix.Web.Models;
using System.Web.Mvc;
using CostMatrix.Core.Service;
using AutoMapper;
using WebGrease.Css.Extensions;
using System;

namespace CostMatrix.Web.Controllers
{
    public class MatrixController : Controller
    {
        private readonly SettingService _settingService;
        private readonly ClientService _clientService;
        private readonly MatrixService _matrixService;

        public MatrixController()
        {
            _settingService = new SettingService();
            _clientService = new ClientService();
            _matrixService = new MatrixService();
        }

        [HttpGet]
        public ActionResult Add(string id)
        {
            var viewModel = new MatrixEditModel();

            var settings = _settingService.Get();
            viewModel.Settings = Mapper.Map<SettingEditModel>(settings);

            var client = Mapper.Map<ClientViewModel>(_clientService.GetByProjectId(id));
            viewModel.ClientName = client.Name;

            viewModel.ProjectId = id;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(MatrixEditModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.Sections != null)
                {
                    foreach (var section in viewModel.Sections)
                    {
                        foreach (var item in section.Items)
                        {
                            item.Testing = ((item.FrontEnd + item.BackEnd) / 100) * viewModel.Settings.Testing;

                            item.ProjectManagement = ((item.FrontEnd + item.BackEnd + item.Design + item.ArtDirector + item.Producer +
                                             item.AccountDirector + item.ServerManagement + item.Seo + item.Copyrighter +
                                             item.Other + item.Testing) / 100) * viewModel.Settings.ProjectManagement;
                        }
                    }
                }

                var domain = Mapper.Map<Matrix>(viewModel);
                var id = _matrixService.Add(domain);
                TempData.Add("SuccessMessage", "The new matrix was created successfully");
                return RedirectToAction("Edit", "Matrix", new {id = id});
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var matrix = _matrixService.GetById(id);
            var viewModel = Mapper.Map<MatrixEditModel>(matrix);

            var client = _clientService.GetByProjectId(viewModel.ProjectId);
            var clientViewModel = Mapper.Map<ClientViewModel>(client);
            viewModel.ClientName = clientViewModel.Name;

            foreach (var section in viewModel.Sections)
            {
                foreach (var item in section.Items)
                {
                    item.Total = (item.FrontEnd * viewModel.Settings.FrontEnd) 
                                 + (item.BackEnd * viewModel.Settings.BackEnd)
                                 + (item.Design * viewModel.Settings.Design)
                                 + (item.ArtDirector * viewModel.Settings.ArtDirector)
                                 + (item.Producer * viewModel.Settings.Producer)
                                 + (item.AccountDirector * viewModel.Settings.AccountDirector)
                                 + (item.ServerManagement * viewModel.Settings.ServerManagement)
                                 + (item.Seo * viewModel.Settings.Seo)
                                 + (item.Copyrighter * viewModel.Settings.Copyrighter)
                                 + (item.Other * viewModel.Settings.Other)
                                 + (item.Testing * 175M) //TODO: Create a seperate value for testing and pm
                                 + (item.ProjectManagement * 175M);

                    item.HasMore = item.ArtDirector > 0 || item.Producer > 0 || item.AccountDirector > 0 ||
                                   item.ServerManagement > 0 || item.Seo > 0 || item.Copyrighter > 0;
                }

                var currentSection = section;
                section.Items.ForEach(i => currentSection.FrontEndTotal += i.FrontEnd);
                section.Items.ForEach(i => currentSection.BackEndTotal += i.BackEnd);
                section.Items.ForEach(i => currentSection.DesignTotal += i.Design);
                section.Items.ForEach(i => currentSection.ArtDirectorTotal += i.ArtDirector);
                section.Items.ForEach(i => currentSection.ProducerTotal += i.Producer);
                section.Items.ForEach(i => currentSection.AccountDirectorTotal += i.AccountDirector);
                section.Items.ForEach(i => currentSection.ServerManagementTotal += i.ServerManagement);
                section.Items.ForEach(i => currentSection.SeoTotal += i.Seo);
                section.Items.ForEach(i => currentSection.CopyrighterTotal += i.Copyrighter);
                section.Items.ForEach(i => currentSection.OtherTotal += i.Other);
                section.Items.ForEach(i => currentSection.TestingTotal += i.Testing);
                section.Items.ForEach(i => currentSection.ProjectManagementTotal += i.ProjectManagement);

                section.Items.ForEach(i => currentSection.Total += i.Total);
            }

            viewModel.Sections.ForEach(s => viewModel.FrontEndTotal += s.FrontEndTotal);
            viewModel.Sections.ForEach(s => viewModel.BackEndTotal += s.BackEndTotal);
            viewModel.Sections.ForEach(s => viewModel.DesignTotal += s.DesignTotal);
            viewModel.Sections.ForEach(s => viewModel.ArtDirectorTotal += s.ArtDirectorTotal);
            viewModel.Sections.ForEach(s => viewModel.ProducerTotal += s.ProducerTotal);
            viewModel.Sections.ForEach(s => viewModel.AccountDirectorTotal += s.AccountDirectorTotal);
            viewModel.Sections.ForEach(s => viewModel.ServerManagementTotal += s.ServerManagementTotal);
            viewModel.Sections.ForEach(s => viewModel.SeoTotal += s.SeoTotal);
            viewModel.Sections.ForEach(s => viewModel.CopyrighterTotal += s.CopyrighterTotal);
            viewModel.Sections.ForEach(s => viewModel.OtherTotal += s.OtherTotal);
            viewModel.Sections.ForEach(s => viewModel.TestingTotal += s.TestingTotal);
            viewModel.Sections.ForEach(s => viewModel.ProjectManagementTotal += s.ProjectManagementTotal);

            viewModel.Sections.ForEach(s => viewModel.Total += s.Total);

            return View(viewModel);
        }

        public ActionResult Edit(MatrixEditModel viewModel)
        {
            if (ModelState.IsValid)
            {
                foreach (var section in viewModel.Sections)
                {
                    foreach (var item in section.Items)
                    {
                        item.Testing = ((item.FrontEnd + item.BackEnd) / 100) * viewModel.Settings.Testing;

                        item.ProjectManagement = ((item.FrontEnd + item.BackEnd + item.Design + item.ArtDirector + item.Producer +
                                         item.AccountDirector + item.ServerManagement + item.Seo + item.Copyrighter +
                                         item.Other + item.Testing) / 100) * viewModel.Settings.ProjectManagement;
                    }
                }

                var domain = Mapper.Map(viewModel, _matrixService.GetById(viewModel.MatrixId));
                _matrixService.Edit(domain);
                TempData.Add("SuccessMessage", "The new matrix was updated successfully");
                return RedirectToAction("Edit", "Matrix", new { id = viewModel.MatrixId });
            }

            return View(viewModel);
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult GetNewSection(string sectionName)
        {
            return PartialView("EditorTemplates/MatrixSection", new MatrixSection { Name = sectionName, UniqueId  = Guid.NewGuid(), Items = new List<MatrixSectionItem> { new MatrixSectionItem() } });
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult GetNewItem(string containerPrefix)
        {
            ViewData["ContainerPrefix"] = containerPrefix;
            return PartialView("EditorTemplates/MatrixSectionItem", new MatrixSectionItem() { UniqueId = Guid.NewGuid() });
        }
    }
}
