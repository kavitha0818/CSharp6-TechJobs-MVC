using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVCAutograded6.Data;
using TechJobsMVCAutograded6.Models;

namespace TechJobsMVCAutograded6.Controllers;

public class SearchController : Controller
{
    // GET: /<controller>/
    //sets viewBag.columns to ColumnChoices//
    public IActionResult Index()
    {
        ViewBag.columns = ListController.ColumnChoices;
        return View();
    }

    // TODO #3 - Create an action method to process a search request and render the updated search views.
     public IActionResult Results(string searchType, string searchTerm)
    {
        // Create a local variable to store search results
        List<Job> jobs = new List<Job>();

        if (searchTerm == "all" || string.IsNullOrEmpty(searchTerm))
        {
            // If so, retrieves all jobs
            jobs = JobData.FindAll();
        }
        else
        {
            jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
        }

        // Pass the search results and column choices to the view
        ViewBag.Jobs = jobs;
        ViewBag.columns = ListController.ColumnChoices;

        // Return the view
        return View("Index");
    }
    
}

