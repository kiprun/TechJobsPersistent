using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsPersistent.Data;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {
        private JobDbContext context;// private DbContext variable to perform CRUD operations on the database.

        public EmployerController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index() //pass all of the Employer objects in the the database to the view.
        {
            List<Employer> employers = context.Employers.ToList();
            
            return View(employers);
        }

        public IActionResult Add()//create instance of AddEmployerViewModel and pass the instance into the View return method
        {
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel();

            return View(addEmployerViewModel);
        }

        [HttpPost]//Process form submissions and make sure that only valid Employer objects are saved to database
        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEmployerViewModel)
        {
            if (ModelState.IsValid)
            {
                Employer newEmployer = new Employer
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location
                };

                context.Employers.Add(newEmployer);
                context.SaveChanges();

                return View("/Employer/");
            }
            return View(addEmployerViewModel);
        }

        public IActionResult About(int id)//pass an Employer object to the view for display

        {
            Employer employer = context.Employers.Find(id);
            return View(employer);
        }
    }
}
