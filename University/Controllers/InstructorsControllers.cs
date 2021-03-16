using Microsoft.AspNetCore.Mvc;
using University.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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
    
  
  
    public ActionResult AddCourse(int id)
    {
        var thisItem = _db.Instructors.FirstOrDefault(course => course.InstructorId == id);
        ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "CourseName");
        return View(thisItem);
    }

    [HttpPost]
    public ActionResult AddCourse(Instructor instructor, int CourseId)
    {
        if (CourseId != 0)
        {
        _db.CourseInstructor.Add(new CourseInstructor() { CourseId = CourseId, InstructorId = instructor.InstructorId });
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
  }
}