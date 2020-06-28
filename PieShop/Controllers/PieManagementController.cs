using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using PieShop.Models;
using PieShop.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PieShop.Controllers
{
    [Authorize(Roles = "Administrators")]
    [Authorize(Policy ="DeletePie")]
    
    public class PieManagementController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;
        public PieManagementController(IPieRepository pieRepository,ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var pies = _pieRepository.AllPies.OrderBy(p => p.PieId);
            return View(pies);
        }

        public IActionResult AddPie()
        {
            var categories = _categoryRepository.AllCategories;
            var pieEditViewModel = new PieEditViewModel()
            {
                Categories = categories.Select(c => new SelectListItem()
                {
                    Text = c.CategoryName,
                    Value = c.CategoryId.ToString()
                }).ToList(),

                CategoryId = categories.FirstOrDefault().CategoryId
            };

            return View(pieEditViewModel);
        }

        [HttpPost]
        public IActionResult AddPie(PieEditViewModel pieEditViewModel)
        {
            //Basic validation
            //if (ModelState.IsValid)
            //{
            //    _pieRepository.CreatePie(pieEditViewModel.Pie);
            //    return RedirectToAction("Index");
            //}

            //custom validation rules
            if (ModelState.GetValidationState("Pie.Price") == ModelValidationState.Valid
                || pieEditViewModel.Pie.Price < 0)
                ModelState.AddModelError(nameof(pieEditViewModel.Pie.Price), "The price of the pie should be higher than 0");

            if (pieEditViewModel.Pie.IsPieOfTheWeek && !pieEditViewModel.Pie.InStock)
                ModelState.AddModelError(nameof(pieEditViewModel.Pie.IsPieOfTheWeek), "Only pies that are in stock should be Pie of the Week");

            if (ModelState.IsValid)
            {
                _pieRepository.CreatePie(pieEditViewModel.Pie);
                return RedirectToAction("Index");
            }

            return View(pieEditViewModel);
        }

        public IActionResult EditPie(int pieId)
        {
            var categories = _categoryRepository.AllCategories;

            var pie = _pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);

            var pieEditViewModel = new PieEditViewModel
            {
                Categories = categories.Select(c => new SelectListItem() { Text = c.CategoryName, Value = c.CategoryId.ToString() }).ToList(),
                Pie = pie,
                CategoryId = pie.CategoryId
            };

            var item = pieEditViewModel.Categories.FirstOrDefault(c => c.Value == pie.CategoryId.ToString());
            item.Selected = true;

            return View(pieEditViewModel);
        }

        [HttpPost]
        public IActionResult EditPie(PieEditViewModel pieEditViewModel)
        {
            pieEditViewModel.Pie.CategoryId = pieEditViewModel.CategoryId;

            if (ModelState.IsValid)
            {
                _pieRepository.UpdatePie(pieEditViewModel.Pie);
                return RedirectToAction("Index");
            }
            return View(pieEditViewModel);
        }

        [HttpPost]
        public IActionResult DeletePie(string pieId)
        {
            return View();
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckIfPieNameAlreadyExists([Bind(Prefix = "Pie.Name")]string name)
        {
            var pie = _pieRepository.AllPies.FirstOrDefault(p => p.Name == name);
            return pie == null ? Json(true) : Json("That pie name is already taken");
        }

    }
}
