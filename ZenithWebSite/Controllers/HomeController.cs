using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZenithWebSite.Models;
using ZenithWebSite.Models.Entity;

namespace ZenithWebSite.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            // This will grab the Monday of the current week
            DateTime startOfWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek) + 1);

            // This stores all the dates of the current week
            List<DateTime> currentWeek = new List<DateTime>();
            currentWeek.Add(startOfWeek);
            // Add the rest of the days
            for (int i = 1; i < 7; i++)
            {
                currentWeek.Add(startOfWeek.AddDays(i));
            }

            DateTime monDate = currentWeek[0].Date;
            DateTime tuesDate = currentWeek[1].Date;
            DateTime wedsDate = currentWeek[2].Date;
            DateTime thursDate = currentWeek[3].Date;
            DateTime friDate = currentWeek[4].Date;
            DateTime satDate = currentWeek[5].Date;
            DateTime sunDate = currentWeek[6].Date;

            IEnumerable<Event> monday;
            IEnumerable<Event> tuesday;
            IEnumerable<Event> wednesday;
            IEnumerable<Event> thursday;
            IEnumerable<Event> friday;
            IEnumerable<Event> saturday;
            IEnumerable<Event> sunday;

            if (User.Identity.IsAuthenticated)
            {
                // This will grab all the events happening on that date
                 monday = db.Event
                                  .Include("Activity")
                                  .Where(e => DbFunctions.TruncateTime(e.eventFrom) == monDate)
                                  .OrderBy(e => e.eventFrom);

                 tuesday = db.Event
                                 .Include("Activity")
                                 .Where(e => DbFunctions.TruncateTime(e.eventFrom) == tuesDate)
                                 .OrderBy(e => e.eventFrom);

                 wednesday = db.Event
                                 .Include("Activity")
                                 .Where(e => DbFunctions.TruncateTime(e.eventFrom) == wedsDate)
                                 .OrderBy(e => e.eventFrom);

                 thursday = db.Event
                                 .Include("Activity")
                                 .Where(e => DbFunctions.TruncateTime(e.eventFrom) == thursDate)
                                 .OrderBy(e => e.eventFrom);

                 friday = db.Event
                                 .Include("Activity")
                                 .Where(e => DbFunctions.TruncateTime(e.eventFrom) == friDate)
                                 .OrderBy(e => e.eventFrom);

                 saturday = db.Event
                                 .Include("Activity")
                                 .Where(e => DbFunctions.TruncateTime(e.eventFrom) == satDate)
                                 .OrderBy(e => e.eventFrom);

                 sunday = db.Event
                                 .Include("Activity")
                                 .Where(e => DbFunctions.TruncateTime(e.eventFrom) == sunDate)
                                 .OrderBy(e => e.eventFrom);
            } else
            {   // For anonymous users
                // This will grab all the events happening on that date
                 monday = db.Event
                                  .Include("Activity")
                                  .Where(e => DbFunctions.TruncateTime(e.eventFrom) == monDate)
                                  .Where(e => e.isActive)
                                  .OrderBy(e => e.eventFrom);

                 tuesday = db.Event
                                 .Include("Activity")
                                 .Where(e => DbFunctions.TruncateTime(e.eventFrom) == tuesDate)
                                 .Where(e => e.isActive)
                                 .OrderBy(e => e.eventFrom);

                 wednesday = db.Event
                                 .Include("Activity")
                                 .Where(e => DbFunctions.TruncateTime(e.eventFrom) == wedsDate)
                                 .Where(e => e.isActive)
                                 .OrderBy(e => e.eventFrom);

                 thursday = db.Event
                                 .Include("Activity")
                                 .Where(e => DbFunctions.TruncateTime(e.eventFrom) == thursDate)
                                 .Where(e => e.isActive)
                                 .OrderBy(e => e.eventFrom);

                 friday = db.Event
                                 .Include("Activity")
                                 .Where(e => DbFunctions.TruncateTime(e.eventFrom) == friDate)
                                 .Where(e => e.isActive)
                                 .OrderBy(e => e.eventFrom);

                 saturday = db.Event
                                 .Include("Activity")
                                 .Where(e => DbFunctions.TruncateTime(e.eventFrom) == satDate)
                                 .Where(e => e.isActive)
                                 .OrderBy(e => e.eventFrom);

                 sunday = db.Event
                                 .Include("Activity")
                                 .Where(e => DbFunctions.TruncateTime(e.eventFrom) == sunDate)
                                 .Where(e => e.isActive)
                                 .OrderBy(e => e.eventFrom);
            }
           

            // This is the model we will be passing to the view, which includes the days of the current week and the events in each
            var vm = new ViewModel()
            {
                Dates = currentWeek,
                MonEvents = monday,
                TuesEvents = tuesday,
                WedsEvents = wednesday,
                ThursEvents = thursday,
                FriEvents = friday,
                SatEvents = saturday,
                SunEvents = sunday,
            };

            return View(vm);
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
    }
}