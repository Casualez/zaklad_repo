using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp1.Models
{
    public class App
    {
        public void DisplayWorkers()
        {
            GetWorkers();
            Message message = new Message();
            message.Display(Workers);
        }

        // właściwości
        public List<Worker> Workers { get; set; }

        // metoda wybierająca pracownika z listy
        public void SelectWorker()
        {
            Message message = new Message();
            var choice = message.WorkersList();
            var number = choice;

            GetWorkers();
            var worker = Workers.FirstOrDefault(x => x.Id == number);
            List<Worker> workers = new List<Worker>();
            workers.Add(worker);
            message.Display(workers);

            int hoursWorked = message.GetHourWorked();
            decimal bonus = message.GetBonus();
            Calc calc = new Calc();
            decimal vat = 0.18m;
            decimal salarybrutto = calc.init(worker, hoursWorked, bonus);
            decimal salaryvat = Math.Round(salarybrutto * vat, 1);
            decimal finalsalary = Math.Round(salarybrutto - salaryvat, 1);

            Console.Clear();
            message.Display(workers);
            Console.WriteLine();
            Console.Write("Wynagrodzenie brutto w tym miesiącu wynosi: ");
            Console.WriteLine(salarybrutto + " zł");
            Console.WriteLine();
            Console.Write("Potrącony podatek (18%): ");
            Console.WriteLine(salaryvat + " zł");
            Console.WriteLine();
            Console.Write("Do wypłaty: ");
            Console.WriteLine(finalsalary + " zł");
        }

        // pobieranie bazy pracowników
        void GetWorkers()
        {
            var path = $"{Directory.GetCurrentDirectory()}\\WorkersList.json";
            var json = File.ReadAllText(path);
            Workers = JsonConvert.DeserializeObject<List<Worker>>(json);
        }

    }
}
