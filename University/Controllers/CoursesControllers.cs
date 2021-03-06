using Microsoft.AspNetCore.Mvc;
using University.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace University.Controllers
{
  public class CoursesController : Controller
  {
    private readonly UniversityContext _db;
    public CoursesController(UniversityContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Courses.ToList());
    }

    public ActionResult Details(int id)
    {
      var thisItem = _db.Courses
          //Grabbing JoinEntities Table information from database
          .Include(course => course.JoinEntities)
          //using JoinEntities information, grabbing applicable students
          .ThenInclude(join => join.Student)
          //then grabbing the actual course object
          .FirstOrDefault(course => course.CourseId == id);
          //passing into the view
      return View(thisItem);
    }


    public ActionResult Create()
    {
      ViewBag.StudentId = new SelectList(_db.Students, "StudentId", "StudentName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Course course, int StudentId)
    {
        _db.Courses.Add(course);
        _db.SaveChanges();
        if (StudentId != 0)
        {
            _db.CourseStudent.Add(new CourseStudent() { StudentId = StudentId, CourseId = course.CourseId });
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
  
    public ActionResult Edit(int id)
    {
        var thisCourse = _db.Courses.FirstOrDefault(course => course.CourseId == id);
        ViewBag.StudentId = new SelectList(_db.Students, "StudentId", "StudentName");
        return View(thisCourse);
    }

    [HttpPost]
    public ActionResult Edit(Course course, int StudentId)
    {
      if (StudentId != 0)
      {
        _db.CourseStudent.Add(new CourseStudent() { StudentId = StudentId, CourseId = course.CourseId });
      }
      _db.Entry(course).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddStudent(int id)
    {
        var thisItem = _db.Courses.FirstOrDefault(course => course.CourseId == id);
        ViewBag.StudentId = new SelectList(_db.Students, "StudentId", "StudentName");
        return View(thisItem);
    }

    [HttpPost]
    public ActionResult AddStudent(Course course, int StudentId)
    {
        if (StudentId != 0)
        {
        _db.CourseStudent.Add(new CourseStudent() { StudentId = StudentId, CourseId = course.CourseId });
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        var thisItem = _db.Courses.FirstOrDefault(course=> course.CourseId == id);
        return View(thisItem);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        var thisItem = _db.Courses.FirstOrDefault(course => course.CourseId == id);
        _db.Courses.Remove(thisItem);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteStudent(int joinId)
    {
        var joinEntry = _db.CourseStudent.FirstOrDefault(entry => entry.CourseStudentId == joinId);
        _db.CourseStudent.Remove(joinEntry);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
  }
}