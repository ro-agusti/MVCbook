using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVCBook.Models;
using MVCBook.Data;
using System.Data.Entity;

namespace MVCBook.Controllers
{
    public class BookController : Controller
    {
        private DbBookMVCContext context = new DbBookMVCContext();
        // GET: Book
        public ActionResult Index()
        {
            var books = context.Books.ToList();
            return View("Index", books);
        }

        public ActionResult Create()
        {
            Book book = new Book();
            return View("Create", book);
        }

        [HttpPost]
        public ActionResult Create (Book book)
        {
            if (ModelState.IsValid)
            {
                context.Books.Add(book);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", book);
        }

        public ActionResult Detail (int id)
        {
            Book book = context.Books.Find(id);
            if (book != null)
            {
                return View("Detail", book);
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult Delete (int id)
        {
            Book book = context.Books.Find(id);
            if (book != null)
            {
                return View("Delete", book);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = context.Books.Find(id);
            if (book != null)
            {
                context.Books.Remove(book);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult Edit(int id)
        {
            Book book = context.Books.Find(id);
            if (book != null)
            {
                return View("Edit", book);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            context.Entry(book).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}