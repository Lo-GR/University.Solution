using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using University.Models;
using System.Collections.Generic;
using System.Linq;

namespace University.Models
{
  public class InstructorsController : Controller
  {
    private readonly UniversityContext _db;
    public InstructorsController (UniversityContext db)
    {
      _db = db;
    }
        public ActionResult Index()
    {
      return View(_db.Instructors.ToList());
    }
    
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Instructor instructor)
    {
      _db.Instructors.Add(instructor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      var thisInstructor = _db.Instructors
        .Include(instructor => instructor.JoinEntities2)
        .ThenInclude(join => join.Course)
        .FirstOrDefault(instructor => instructor.InstructorId == id);
      return View(thisInstructor);
    }
  }
}