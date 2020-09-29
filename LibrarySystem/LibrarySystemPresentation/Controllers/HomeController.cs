using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace LibrarySystemPresentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserService UserService;
        private readonly BookService BookService;
        private readonly UserBookService UserBookService;

        public HomeController(UserService _UserService, BookService _BookService, UserBookService _UserBookService)
        {
            UserService = _UserService;
            BookService = _BookService;
            UserBookService = _UserBookService;
        }
        public ActionResult Index()
        {
            var Book = BookService.GetAll();
            Session["log"] = 1;
            return View(Book);
        }

        public ActionResult Add()
        {
            if (Session["log"] == null)
                return RedirectToAction("Index", "Home", null);
            return View();
        }
        [HttpPost]
        public ActionResult Add(BookEditViewModel Book)
        {
            if (!ModelState.IsValid)
            {

                return View();
            }
            BookService.Add(Book);
            return RedirectToAction("Index");
        }
        public ActionResult Borrow(int id)
        {
            if (Session["log"] == null)
                return RedirectToAction("Index", "Home", null);
            var NumberOfBorrowings = 0;
            var Book = BookService.GetByID(id);
            var UserBook = UserBookService.GetAll().Where(i => i.BookID == Book.ID);
            foreach (var oneUserBook in UserBook)
            {
                NumberOfBorrowings = oneUserBook.NumberOfBorrowings + NumberOfBorrowings;
            }
            Session["BookID"] = Book.ID;
            ViewBag.BookTitle = Book.Title;
            ViewBag.NumberOfCopies = Book.NumberOfCopies;
            ViewBag.NumberOfBorrowings = NumberOfBorrowings;
            Session["BookTitle"] = Book.Title;
            Session["NumberOfCopies"] = Book.NumberOfCopies;
            Session["NumberOfBorrowings"] = NumberOfBorrowings;
            ViewBag.Users = UserService.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Borrow(UserBookEditViewModel UserBook)
        {
            UserBook.ID = 0;
            UserBook.BookID = int.Parse(Session["BookID"].ToString());
            UserBook.NumberOfCopies = int.Parse(Session["NumberOfCopies"].ToString());
            if (!ModelState.IsValid)
            {

                return View();
            }
            if (int.Parse(Session["NumberOfBorrowings"].ToString()) + UserBook.NumberOfBorrowings> UserBook.NumberOfCopies
                || UserBook.NumberOfBorrowings.ToString() == null || UserBook.NumberOfBorrowings.ToString() == ""
                || UserBook.NumberOfBorrowings == 0)
            {
                ViewBag.Error = "NumberOfBorrowings must be less than NumberOfCopies and not empty or Zero";
                ViewBag.Users = UserService.GetAll();
                ViewBag.BookTitle = Session["BookTitle"].ToString();
                ViewBag.NumberOfCopies = Session["NumberOfCopies"].ToString();
                return View();
            }
            UserBookService.Add(UserBook);
            return RedirectToAction("Index");
        }
        public ActionResult UnBorrow(int id)
        {
            if (Session["log"] == null)
                return RedirectToAction("Index", "Home", null);
            var NumberOfBorrowings = 0;
            var Book = BookService.GetByID(id);
            var UserBook = UserBookService.GetAll().Where(i => i.BookID == Book.ID);
            foreach (var oneUserBook in UserBook)
            {
                NumberOfBorrowings = oneUserBook.NumberOfBorrowings + NumberOfBorrowings;
                Session["UserBookID"] = oneUserBook.ID;
            }
            
            Session["BookID"] = Book.ID;
            ViewBag.BookTitle = Book.Title;
            ViewBag.NumberOfCopies = Book.NumberOfCopies;
            ViewBag.NumberOfBorrowings = NumberOfBorrowings;
            Session["BookTitle"] = Book.Title;
            Session["NumberOfCopies"] = Book.NumberOfCopies;
            Session["NumberOfBorrowings"] = NumberOfBorrowings;
            ViewBag.Users = UserService.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult UnBorrow(UserBookEditViewModel UserBook)
        {
            UserBook.ID = int.Parse(Session["UserBookID"].ToString());
            UserBook.BookID = int.Parse(Session["BookID"].ToString());
            UserBook.NumberOfCopies = int.Parse(Session["NumberOfCopies"].ToString());
            if (!ModelState.IsValid)
            {

                return View();
            }
            if (int.Parse(Session["NumberOfBorrowings"].ToString()) - UserBook.NumberOfBorrowings > UserBook.NumberOfCopies
                || UserBook.NumberOfBorrowings.ToString() == null || UserBook.NumberOfBorrowings.ToString() == ""
                || UserBook.NumberOfBorrowings == 0 || UserBook.NumberOfBorrowings >= UserBook.NumberOfCopies)
            {
                ViewBag.Error = "NumberOfBorrowings must be less than NumberOfCopies and not empty or Zero";
                ViewBag.Users = UserService.GetAll();
                ViewBag.BookTitle = Session["BookTitle"].ToString();
                ViewBag.NumberOfCopies = Session["NumberOfCopies"].ToString();
                return View();
            }
            UserBook.NumberOfBorrowings = int.Parse(Session["NumberOfBorrowings"].ToString()) - UserBook.NumberOfBorrowings;
            UserBookService.Update(UserBook);
            return RedirectToAction("Index");
        }
        [HttpGet]
 
        public ActionResult Delete(int id)
        {
            if (Session["log"] == null)
                return RedirectToAction("Index", "Home", null);
            return View();
        }
        [HttpPost]
        public ActionResult Delete(BookEditViewModel Book)
        {
            BookService.Remove(Book.ID);
            return RedirectToAction("Index");
        }
    }
}