using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Core_EF.Models;
using ASP_Core_EF.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Core_EF.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourse _Course;
        public CourseController(ICourse _ICourse)
        {
            _Course = _ICourse;
        }

        public IActionResult Index()
        {
            return View(_Course.GetCourses);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Course model)
        {
            if (ModelState.IsValid)
            {
                _Course.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                //Written by Reza: Error Handling
                return NotFound();
            }
            else
            {
                Course model = _Course.GetCourse(Id);
                return View(model);
            }
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            _Course.Remove(Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int? Id)
        {
            return View(_Course.GetCourse(Id));
        }
        public IActionResult Edit(int? Id)
        {
            var model = _Course.GetCourse(Id);
            return View("Create", model);
        }
    }
}
