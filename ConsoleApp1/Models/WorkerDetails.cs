using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class WorkerDetails
    {
        public decimal getHowOld(Worker w)
        {
            string timeformat = "dd.MM.yyyy";
            DateTime today = DateTime.Now;
            DateTime birthday = DateTime.ParseExact(w.Birthday, timeformat, null);
            decimal days = (decimal)(today - birthday).TotalDays;
            decimal years = Math.Round(days / 365.242199m, 1);
            return years;
        }
        public Worker getWorker(List<Worker> workers, int id)
        {
            return (Worker)workers.Single(w => w.Id == id);
        }
    }
}
