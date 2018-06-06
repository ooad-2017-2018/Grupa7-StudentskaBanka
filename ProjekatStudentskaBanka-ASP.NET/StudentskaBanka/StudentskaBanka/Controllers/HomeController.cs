using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace StudentskaBanka.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MapaSpecificFunctionality()
        {
            ViewBag.Message = "Vaza lokacija";

            return View();
        }

        public ActionResult GetLocations()
        {
            var task = Task.Run(async () => await AsyncUzmiLokacije());
            task.Wait();
            var asyncFunctionResult = task.Result;
            return asyncFunctionResult;
        }

        public async Task<ActionResult> AsyncUzmiLokacije()
        {

            var client = new HttpClient();
            var address = new Uri("https://api.foursquare.com/v2/venues/search?ll=43.85,18.23&categoryId=4bf58dd8d48988d175941735&client_id=KHAWRYD4PJ0LKVSZQF4CEXTX5GK3BDPTWS3XLCTVAYQPK515&client_secret=BSTBTSNVENYHWGGNYGGQ00X33NJNNFTPZVIPOB3LGC1UVXBI&v=20160202");
            HttpResponseMessage response = await client.GetAsync(address);
            String stream = await response.Content.ReadAsStringAsync();
            dynamic dyn = JsonConvert.DeserializeObject(stream);
            var sp = stream.Split('"');
            double lat = 0;
            var locations = new List<Lokacija>();
            string loc = "n";
            for (int i = 0; i < sp.Length; i++)
            {
                if (sp[i] == "lat")
                    lat = Convert.ToDouble(sp[i + 1].Substring(1, sp[i + 1].Length - 2));
                if (sp[i] == "lng")
                {
                    for (int j = i; j >= 0; j--)
                        if (sp[j] == "name")
                        {
                            loc = sp[j + 2];
                            break;
                        }
                    locations.Add(new Lokacija(lat, Convert.ToDouble(sp[i + 1].Substring(1, sp[i + 1].Length - 4)), loc));
                }
            }

            return Json(locations, JsonRequestBehavior.AllowGet);
        }
    
    }

}