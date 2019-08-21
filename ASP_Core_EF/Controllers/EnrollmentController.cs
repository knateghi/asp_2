using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Core_EF.Models;
using ASP_Core_EF.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Core_EF.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollment _Enrollment;
        private readonly ICourse _Course;
        private readonly IStudent _Student;
        public EnrollmentController(IEnrollment _IEnrollment, ICourse _ICourse, IStudent _IStudent)
        {
            _Enrollment = _IEnrollment;
            _Course = _ICourse;
            _Student = _IStudent;
        }
        public IActionResult Index()
        {
            return View(_Enrollment.GetEnrollments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Courses = _Course.GetCourses;
            ViewBag.Students = _Student.GetStudents;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Enrollment model)
        {
            if (ModelState.IsValid)
            {
                _Enrollment.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            Enrollment model = _Enrollment.GetEnrollment(Id);
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            _Enrollment.Remove(Id);
            return RedirectToAction("Index");
        }
    }
}
