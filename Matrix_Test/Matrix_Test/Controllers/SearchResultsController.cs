using Matrix_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Matrix_Test.Controllers
{
    public class SearchResultsController : Controller
    {
        public RepoSerarch search = new RepoSerarch();

        // GET: SearchResults
        public async Task<ActionResult> Index(string searchValue)
        {
            if (searchValue != null)
            {
                RepoResults repoResults = new RepoResults();
                // Start the search function 
                repoResults = await search.Start("repositories?q=" + searchValue); 

                return View(repoResults.items);
            }
            return RedirectToAction("Index", "Home");
        }

        // post: Item
        // Save item to Session at 'bookMarkList' 
        [HttpPost]
        public ActionResult saveRepoToSession(Item repo)
        {
            if (Request.IsAjaxRequest())
            {
                if (Session["bookMarkList"] == null)
                {
                    Session["bookMarkList"] = new List<Item>();
                }
                List<Item> itemList = Session["bookMarkList"] as List<Item>;
                itemList.Add(repo);
                Session["bookMarkList"] = itemList;

                return RedirectToAction("Index", "BookMark");
            }
            return new EmptyResult();
        }


    }
}