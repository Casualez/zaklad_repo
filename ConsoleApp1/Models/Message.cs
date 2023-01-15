using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Message
    {
        public void Display(List<Worker> workers)
        {
            WorkerDetails details = new WorkerDetails();
            String s = " | ";
            Console.WriteLine("Lp.      Imię       |      Nazwisko       |           Wiek           |      Rodzaj pracy      |   zł/h  |   zł/mies.   ");
            foreach (Worker w in workers)
            {
                Console.WriteLine("________________________________________________________________________________________________________________________");
                Console.Write(w.Id + ". ");
                Console.Write(Text(w.FirstName, 17) + " ");
                Console.Write(Text(w.LastName, 20) + s);
                Console.Write(Text(w.Birthday + "(" + details.getHowOld(details.getWorker(workers, w.Id)) + " lat)", 24) + s);
                Console.Write(Text(w.WorkType, 22) + s);
                Console.Write(Text(w.PerHour + "", 7) + s);
                Console.WriteLine(Text(w.Salary + "", 7));

            }
        }
        public void DisplayOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine();
            Console.WriteLine("1 => Lista pracowników");
            Console.WriteLine();
            Console.WriteLine("2 => Wylicz pensję pracownika");
            Console.WriteLine();
            Console.WriteLine("3 => Zakończ program");
            Console.WriteLine();
        }

        public int OptionsList()
        {
            while (true)
            {
                DisplayOptions();
                Console.WriteLine("Wybierz 1, 2 lub 3: ");
                var choice = Console.ReadLine();
                
                // sprawdza czy liczba jest intem i poprawna
                if (int.TryParse(choice, out int x) && x > 0 && x < 4)
                {
                    return int.Parse(choice);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wybrałeś nieprawidłową opcję...");
                }
            }
        }

        public int WorkersList()
        {
            while (true)
            {
                Console.WriteLine("Proszę podać ID pracownika dla którego zostanie wyliczone wynagrodzenie: ");
                var choice = Console.ReadLine();

                // sprawdza czy liczba jest intem i poprawna
                if (int.TryParse(choice, out int x) && x > 0 && x < 6)
                {
                    Console.Clear();
                    return int.Parse(choice);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Brak pracownika o podanym ID");
                }
            }
        }

        public int GetHourWorked()
        {
            Console.WriteLine();
            Console.WriteLine("WYLICZANIE WYNAGRODZENIA PRACOWNIKA: ");
            Console.WriteLine("________________________________________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("Proszę podać ilość przepracowanych godzin (Max. 20): ");
            string i = Console.ReadLine();
            if (int.TryParse(i, out int x) && x <= 20 && x >= 0)
                return x;
            GetHourWorked();
            return 20;

        }

        public decimal GetBonus()
        {
            Console.WriteLine();
            Console.WriteLine("Proszę podać kwotę premii pracownika: ");
            string i = Console.ReadLine();
            if (int.TryParse(i, out int x) && x >= 0)
                return x;
            GetBonus();
            return 0;

        }

        public String Text(String text, int lenght)
        {
            int howLong =  text.Length;
            int howManySpaces = lenght-howLong-2;
            String spaces = "";
            for (int i = 0; i < howManySpaces; i++)
            {
                spaces += " ";
            }
            if (howLong < lenght-2)
                return "  " + text + spaces;
            return text;
        }
    }
}
