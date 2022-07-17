using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using carRental.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace carRental.Pages
{
    public class IndexModel : PageModel
    {
        public List<carDetails> listOfCars = new List<carDetails>();
        public cars cars = new cars();
        public string SearchString = "";

        public void OnGet()
        {
            // var cars = new cars();
            listOfCars = cars.getTenants();

        }
        public void OnPost()
        {
            listOfCars = cars.getTenants();
            SearchString = Request.Form["SearchString"];
            if (!string.IsNullOrEmpty(SearchString))
            {
                listOfCars = listOfCars.Where(s => s.description.Contains(SearchString) || s.available_locations.Contains(SearchString)
                || s.available_extras.Contains(SearchString)).ToList();
            }
            
        }
        //public async Task OnGetAsync()
        //{
        //    listOfCars = cars.getTenants();


        //    if (!string.IsNullOrEmpty(SearchString))
        //    {
        //        listOfCars = listOfCars.Where(s => s.description.Contains(SearchString) || s.available_locations.Contains(SearchString) 
        //        || s.available_extras.Contains(SearchString)).ToList();
        //    }
        //    await Task.FromResult(listOfCars);
        //}
    }
}
