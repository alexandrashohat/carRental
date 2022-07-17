using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;


namespace carRental.model
{
    public class carDetails
    {
        public int id { get; set; }
        public string description { get; set; }
        public string available_extras { get; set; }
        public int price { get; set; }
        public string discount { get; set; }
        public int minimum_driver_age { get; set; }
        public DateTime available_dates { get; set; }
        public string available_locations { get; set; }
    }
    public class cars
    {
        public cars()
        {}
        public int setACar(carDetails carDetails)
        {
            List<carDetails> source = new List<carDetails>();
            try
            {
                using (StreamReader r = new StreamReader("mock/mockData.json"))
                {
                    string json = r.ReadToEnd();
                    source = JsonConvert.DeserializeObject<List<carDetails>>(json);
                }

                List<carDetails> destination = source.Select(d => new carDetails
                {
                    id = d.id,
                    description = d.description,
                    price = d.price,
                    discount = d.discount,
                    available_extras = d.available_extras,
                    minimum_driver_age = d.minimum_driver_age,
                    available_dates = d.available_dates,
                    available_locations = d.available_locations
                }).ToList();
                var maxid = destination.Max(a => a.id);
                carDetails.id = maxid + 1;
                destination.Add(carDetails);
                string jsonString = JsonConvert.SerializeObject(destination);
                using (StreamWriter outputFile = new StreamWriter("mock/mockData.json"))
                {
                    outputFile.WriteLine(jsonString);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return 0;
            }
          
            return 1;
        }
        public int deleteCar(int id)
        {
            List<carDetails> source = new List<carDetails>();
            try
            {
                using (StreamReader r = new StreamReader("mock/mockData.json"))
                {
                    string json = r.ReadToEnd();
                    source = JsonConvert.DeserializeObject<List<carDetails>>(json);
                }

                List<carDetails> destination = source.Select(d => new carDetails
                {
                    id = d.id,
                    description = d.description,
                    price = d.price,
                    discount = d.discount,
                    available_extras = d.available_extras,
                    minimum_driver_age = d.minimum_driver_age,
                    available_dates = d.available_dates,
                    available_locations = d.available_locations
                }).ToList();

                var ret = destination.Where(a => a.id ==id).FirstOrDefault();
                destination.Remove(ret);

                string jsonString = JsonConvert.SerializeObject(destination);
                using (StreamWriter outputFile = new StreamWriter("mock/mockData.json"))
                {
                    outputFile.WriteLine(jsonString);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return 0;
            }

            return 1;
        }
        public int editCar(carDetails carDetails)
        {
            List<carDetails> source = new List<carDetails>();
            try
            {
                using (StreamReader r = new StreamReader("mock/mockData.json"))
                {
                    string json = r.ReadToEnd();
                    source = JsonConvert.DeserializeObject<List<carDetails>>(json);
                }

                List<carDetails> destination = source.Select(d => new carDetails
                {
                    id = d.id,
                    description = d.description,
                    price = d.price,
                    discount = d.discount,
                    available_extras = d.available_extras,
                    minimum_driver_age = d.minimum_driver_age,
                    available_dates = d.available_dates,
                    available_locations = d.available_locations
                }).ToList();

                destination.Find(a => a.id == carDetails.id).description = carDetails.description;
                destination.Find(a => a.id == carDetails.id).available_dates = carDetails.available_dates;
                destination.Find(a => a.id == carDetails.id).available_extras = carDetails.available_extras;
                destination.Find(a => a.id == carDetails.id).available_locations = carDetails.available_locations;
                destination.Find(a => a.id == carDetails.id).discount = carDetails.discount;
                destination.Find(a => a.id == carDetails.id).minimum_driver_age = carDetails.minimum_driver_age;
                destination.Find(a => a.id == carDetails.id).price = carDetails.price;

                string jsonString = JsonConvert.SerializeObject(destination);
                using (StreamWriter outputFile = new StreamWriter("mock/mockData.json"))
                {
                    outputFile.WriteLine(jsonString);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return 0;
            }

            return 1;
        }
        public List<carDetails> getTenants()
        {
            var ret = new List<carDetails>();
            try
            {

                //List<string> available_locations = new List<string>();
                //available_locations.Add("hadera");
                //available_locations.Add("tlv");
                //List<string> available_dates = new List<string>();
                //available_dates.Add("1.1.22");
                //available_dates.Add("2.2.22");
                //ret.Add(new carDetails() { id=1,description = "cool car",
                //    available_extras = "GPS",
                //    price = 123,
                //    discount = "10%",
                //    minimum_driver_age = 30,
                //    available_dates = DateTime.Now.ToShortDateString(),
                //    available_locations = "hadera"
                //});
                //ret.Add(new carDetails()
                //{
                //    id = 2,
                //    description = "another cool car",
                //    available_extras = "GPS fun seats",
                //    price = 111,
                //    discount = "2%",
                //    minimum_driver_age = 30,
                //    available_dates = DateTime.Now.ToShortDateString(),
                //    available_locations = "hadera"
                //});

                List<carDetails> source = new List<carDetails>();

                using (StreamReader r = new StreamReader("mock/mockData.json"))
                {
                    string json = r.ReadToEnd();
                    source = JsonConvert.DeserializeObject<List<carDetails>>(json);
                }

                List<carDetails> destination = source.Select(d => new carDetails
                {
                    id = d.id,
                    description = d.description,
                    price = d.price,
                    discount = d.discount,
                    available_extras = d.available_extras,
                    minimum_driver_age = d.minimum_driver_age,
                    available_dates = d.available_dates,
                    available_locations = d.available_locations
                }).ToList();


                //string jsonString = JsonConvert.SerializeObject(ret);
                //using (StreamWriter outputFile = new StreamWriter("mock/mockData.json"))
                //{
                //    outputFile.WriteLine(jsonString);
                //}
                return destination;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ret;
        }

    }
    
   

}
