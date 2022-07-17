using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using carRental.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace carRental.controllers
{
    public class AddModel : PageModel
    {
        public carDetails carDetails = new carDetails();
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            carDetails.description = Request.Form["description"];
            carDetails.price = Int32.Parse(Request.Form["price"]);
            carDetails.discount = Request.Form["discount"];
            carDetails.available_extras = Request.Form["available_extras"];
            carDetails.minimum_driver_age = Int32.Parse(Request.Form["minimum_driver_age"]);
            carDetails.available_dates = DateTime.Parse(Request.Form["available_dates"]);
            carDetails.available_locations = Request.Form["available_locations"];
            if (carDetails.description.Length == 0 || carDetails.price == 0 ||
                carDetails.discount.Length == 0 || carDetails.available_extras.Length == 0 ||
                carDetails.minimum_driver_age == 0 || carDetails.available_dates.ToString() == "" ||
                carDetails.available_locations.Length == 0
                )
            {
                errorMessage = "Please fill the fields";
                return;
            }
            var cars = new cars();
            var ret = cars.setACar(carDetails);
            if (ret == 0)
            {
                errorMessage = "failed to add the car";
                return;
            }
            carDetails.description = ""; carDetails.price = 0; carDetails.discount = ""; carDetails.available_extras = "";
            carDetails.minimum_driver_age = 0; carDetails.available_dates = DateTime.Today;carDetails.available_locations = "";
            successMessage = "added new car";
            Response.Redirect("Index");
        }
    }
}