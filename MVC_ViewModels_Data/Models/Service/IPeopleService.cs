using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_ViewModels_Data.Controllers;
using MVC_ViewModels_Data.Models.ViewModel;

namespace MVC_ViewModels_Data.Models
{
    public interface IPeopleService
    {
         Person Add(CreatePersonViewModel person);

         PeopleViewModel All();

         PeopleViewModel FindBy(PeopleViewModel search);

        Person FindBy(int id);

        bool Remove(int id);
       
    }
}
