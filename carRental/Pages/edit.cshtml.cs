using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using carRental.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace carRental.Pages
{
    public class editModel : PageModel
    {
        public carDetails carDetails = new carDetails();
        public string dates = "";
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
            int id = Int32.Parse(Request.Query["id"]);
            var cars = new cars();
            var listOfCars = cars.getTenants();
            var chosenCar = listOfCars.Where(a => a.id == id).FirstOrDefault();
            carDetails.description = chosenCar.description;
            carDetails.price = chosenCar.price;
            carDetails.discount = chosenCar.discount;
            carDetails.available_extras = chosenCar.available_extras;
            carDetails.minimum_driver_age = chosenCar.minimum_driver_age;
            carDetails.available_dates = chosenCar.available_dates.Date;
            carDetails.available_locations = chosenCar.available_locations;
            carDetails.id = chosenCar.id;

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
            carDetails.id = Int32.Parse(Request.Query["id"]);
            if (carDetails.description.Length == 0 || carDetails.price == 0 ||
                carDetails.discount.Length == 0 || carDetails.available_extras.Length == 0 ||
                carDetails.minimum_driver_age == 0 || carDetails.available_dates.ToString() =="" ||
                carDetails.available_locations.Length == 0
                )
            {
                errorMessage = "Please fill the fields";
                return;
            }
            var cars = new cars();
            var ret = cars.editCar(carDetails);
            if (ret == 0)
            {
                errorMessage = "failed to add the car";
                return;
            }
            successMessage = "edited the car";
            Response.Redirect("Index");
        }
    }
}