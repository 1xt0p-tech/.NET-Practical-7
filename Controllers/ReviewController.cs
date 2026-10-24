using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Practical7.Models;

namespace Practical7.Controllers
{
    public class ReviewController : Controller
    {
        private static readonly List<StudentReview> reviewStore = new List<StudentReview>();
        private static readonly object padlock = new object();

        // GET: Review
        public ActionResult Index()
        {
            List<StudentReview> all;

            lock (padlock)
            {
                all = reviewStore.OrderByDescending(r => r.SubmittedOn).ToList();
            }

            ViewBag.Total = all.Count;
            ViewBag.Average = all.Any() ? Math.Round(all.Average(r => r.Rating), 1) : 0;

            return View(all);
        }

        // GET: Review/Add
        [HttpGet]
        public ActionResult Add()
        {
            LoadCourses();
            return View(new StudentReview());
        }

        // POST: Review/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(StudentReview review)
        {
            if (!ModelState.IsValid)
            {
                LoadCourses();
                return View(review);
            }

            review.SubmittedOn = DateTime.Now;

            lock (padlock)
            {
                reviewStore.Add(review);
            }

            TempData["Message"] = "Thank you, " + review.StudentName + "! Your feedback was saved.";
            return RedirectToAction("Index");
        }

        private void LoadCourses()
        {
            ViewBag.Courses = new SelectList(new[]
            {
                "Dot NET Technologies",
                "Database Management Systems",
                "Operating System",
                "Computer Networks"
            });
        }
    }
}
