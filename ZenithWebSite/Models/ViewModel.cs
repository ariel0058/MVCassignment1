using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenithWebSite.Models.Entity;

namespace ZenithWebSite.Models
{
    public class ViewModel
    {
        public IEnumerable<DateTime> Dates { get; set; }
        public IEnumerable<Event> MonEvents { get; set; }
        public IEnumerable<Event> TuesEvents { get; set; }
        public IEnumerable<Event> WedsEvents { get; set; }
        public IEnumerable<Event> ThursEvents { get; set; }
        public IEnumerable<Event> FriEvents { get; set; }
        public IEnumerable<Event> SatEvents { get; set; }
        public IEnumerable<Event> SunEvents { get; set; }
    }
}
