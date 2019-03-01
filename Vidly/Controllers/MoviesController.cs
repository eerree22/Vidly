using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //public List<Movie> movies = new List<Movie>
        //{
        //    new Movie() {Id = 1, Name = "黑暗騎士"},
        //    new Movie() {Id = 2, Name = "全面啟動"},
        //    new Movie() {Id = 3, Name = "記憶拼圖"},
        //    new Movie() {Id = 4, Name = "星際效應"},
        //    new Movie() {Id = 5, Name = "頂尖對決"}

        //};

        // GET: Movies/Random
        //ActionResult = output of our action
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "史瑞克" };

            var customers = new List<Customer>
            {
                new Customer() {Name = "客人A"},
                new Customer() {Name = "客人B"}
            };

            //ViewModel是為了View所需要的資料客製化的Model
            var viewModel = new RandomMovieViewModel()
            {
                Customers = customers,
                Movie = movie
            };

            #region 將資料送往View的兩種方式 *屬於遺產寫法，不要再用

            //1.ViewData
            //ViewData["Movie"] = movie;

            //2.ViewBag
            //ViewBag.Movie = movie;

            #endregion

            return View(viewModel);
            //return new ViewResult();
            //return Content("Fuck this shit!");  //return文字
            //return HttpNotFound(); //return 404
            //return new EmptyResult(); //return nothing
            //return Redirect("https://www.google.com/");//return to 指定的URL
            //return RedirectToAction("Index", "Home",new{page=1,sort=2}); //return to 指定的action
        }

        /*以下是呼叫此Action的幾種不同方法:
          1.    ~/Movies/Edit/1
          2.    ~/Movies/Edit?id=1
          3.    In the form data: id=1


            這裡這個"id"是在App_Start/RouteConfig下事先定義好的，必須完全符合RouteConfig裡的定義
        */
        //public ActionResult Edit(int id)
        //{
        //    return Content("id=" + id);
        //}

        // 呈現所有movies的列表
        // 這裡使用選擇性的input參數，int後面須加問號，如果是string本來就可以為空所以不用
        public ActionResult Index(int? id)
        {
            if (id.HasValue)
            {
                var myMovie = _context.Movies.Include(x => x.Genre).SingleOrDefault(x => x.Id == id);

                List<Movie> myMovieList=new List<Movie>();
                myMovieList.Add(myMovie);
                return View(myMovieList);
            }
            else
            {
                var myMovie = _context.Movies.Include(x => x.Genre).ToList();

                return View(myMovie);
            }
        }

        public ActionResult Details(int id)
        {
            var myMovie = _context.Movies.Include(x => x.Genre).SingleOrDefault(x => x.Id == id);

            if (myMovie == null)
            {
                return HttpNotFound();
            }
            return View(myMovie);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")] //這邊使用AttributeRoutes處理Rout的工作，讓關注點不會分離
        public ActionResult ByReleaseDate(int? year,int? month)
        {
            if (year.HasValue == false)
            {
                year = DateTime.Now.Year;
            }
            if (month.HasValue == false)
            {
                month = DateTime.Now.Month;
            }

            return Content(year + "/" + month);
        }

        public ActionResult New()
        {
            var myGenres = _context.Genres.ToList();

            var myMovieFormViewModel = new MovieFormViewModel()
            {
                ActName = "新增影片",
                genres = myGenres
            };

            return View("MovieForm", myMovieFormViewModel);
        }

        public ActionResult Edit(int id)
        {
            var myMovie = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (myMovie==null)
            {
                return HttpNotFound();
            }

            var myMovieFormViewModel = new MovieFormViewModel()
            {
                ActName = "修改影片",
                movie=myMovie,
                genres = _context.Genres.ToList()
            };

            return View("MovieForm", myMovieFormViewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            var myMovie = _context.Movies.SingleOrDefault(x => x.Id == movie.Id);

            if (myMovie == null)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                myMovie.Name = movie.Name;
                myMovie.ReleaseDate = movie.ReleaseDate;
                myMovie.NumberInStock = movie.NumberInStock;
                myMovie.GenreId = movie.GenreId;
                myMovie.DateAdded = DateTime.Now;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}