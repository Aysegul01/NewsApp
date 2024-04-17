using Microsoft.AspNetCore.Mvc;
using NewsApp.Models;
using NewsApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static NewsApp.Service.Sevice;

namespace NewsApp.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public ActionResult UpdateInformation()
        {
            return View();
        }


        public ActionResult Index(int page = 1, string searchTerm = "")
        {
            const int pageSize = 10;
            List<NewsModel> allNews = _newsService.GetAllNews();

            // Arama yapılacaksa
            if (!string.IsNullOrEmpty(searchTerm))
            {
                allNews = allNews.Where(n => n.Title.Contains(searchTerm)).ToList();
            }

            int totalItems = allNews.Count;
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            allNews = allNews.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.SearchTerm = searchTerm;

            return View(allNews);
        }
    }

}


