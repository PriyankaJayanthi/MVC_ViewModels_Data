using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_ViewModels_Data.Models;
using MVC_ViewModels_Data.Models.ViewModel;

namespace MVC_ViewModels_Data.Controllers
{
    public class PeopleController : Controller
    {

 
        [HttpGet]
        public IActionResult Index()
        {
     
            PeopleService checkListView = new PeopleService();
            PeopleViewModel peopleList = new PeopleViewModel();
            InMemoryPeopleRepo makeBaseList = new InMemoryPeopleRepo();

            peopleList.PeopleListView = checkListView.All().PeopleListView;

            if (peopleList.PeopleListView.Count == 0 || peopleList.PeopleListView == null)
            {
                makeBaseList.CreateBasePersons();
            }

            return View(peopleList);
        }



        [HttpPost]
        public IActionResult Index(PeopleViewModel peopleviewModel)
        {
            PeopleService filterString = new PeopleService();

            peopleviewModel = filterString.FindBy(peopleviewModel);
            return View(peopleviewModel);
        }

        [HttpGet]
        public IActionResult CreatePerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel personViewModel) 
        {
            var newPersonModel = new PeopleViewModel();
            PeopleService peopleService = new PeopleService();

            if (ModelState.IsValid)
            {
                 

                newPersonModel.Name = personViewModel.Name;
                newPersonModel.ContactNumber = personViewModel.ContactNumber;
                newPersonModel.City = personViewModel.City;

                newPersonModel.PeopleListView = peopleService.All().PeopleListView;


                peopleService.Add(personViewModel);

                ViewBag.Mess = "Person Added!";

                return View("Index", newPersonModel);
            }         

            return View("Index", newPersonModel);
        }


        public IActionResult DeletePerson(int id)
        {
            PeopleService deleteById = new PeopleService();
            deleteById.Remove(id);

            return RedirectToAction("Index");
        }
    

    }
}
