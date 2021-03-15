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


    // public ActionResult Create()
    // {
    //   ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
    //   return View();
    // }

    // [HttpPost]
    // public ActionResult Create(Item item, int CategoryId)
    // {
    //     _db.Items.Add(item);
    //     _db.SaveChanges();
    //     if (CategoryId != 0)
    //     {
    //         _db.CategoryItem.Add(new CategoryItem() { CategoryId = CategoryId, ItemId = item.ItemId });
    //     }
    //     _db.SaveChanges();
    //     return RedirectToAction("Index");
    // }
  
    // public ActionResult Edit(int id)
    // {
    //     var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
    //     ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
    //     return View(thisItem);
    // }

    // [HttpPost]
    // public ActionResult Edit(Item item, int CategoryId)
    // {
    //   if (CategoryId != 0)
    //   {
    //     _db.CategoryItem.Add(new CategoryItem() { CategoryId = CategoryId, ItemId = item.ItemId });
    //   }
    //   _db.Entry(item).State = EntityState.Modified;
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // public ActionResult AddCategory(int id)
    // {
    //     var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
    //     ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
    //     return View(thisItem);
    // }

    // [HttpPost]
    // public ActionResult AddCategory(Item item, int CategoryId)
    // {
    //     if (CategoryId != 0)
    //     {
    //     _db.CategoryItem.Add(new CategoryItem() { CategoryId = CategoryId, ItemId = item.ItemId });
    //     }
    //     _db.SaveChanges();
    //     return RedirectToAction("Index");
    // }

    // public ActionResult Delete(int id)
    // {
    //     var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
    //     return View(thisItem);
    // }

    // [HttpPost, ActionName("Delete")]
    // public ActionResult DeleteConfirmed(int id)
    // {
    //     var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
    //     _db.Items.Remove(thisItem);
    //     _db.SaveChanges();
    //     return RedirectToAction("Index");
    // }

    // [HttpPost]
    // public ActionResult DeleteCategory(int joinId)
    // {
    //     var joinEntry = _db.CategoryItem.FirstOrDefault(entry => entry.CategoryItemId == joinId);
    //     _db.CategoryItem.Remove(joinEntry);
    //     _db.SaveChanges();
    //     return RedirectToAction("Index");
    // }
  }
}