// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using ConsoleApp1.Models;

var app = new App();
var message = new Message();

//message.OptionsList();

while (true)
{
    var userchoice = message.OptionsList();

    if (userchoice == 1)
    {
        Console.Clear();
        app.DisplayWorkers();
    }
    if (userchoice == 2)
    {
        Console.Clear();
        app.SelectWorker();
        break;
    }
    if (userchoice == 3)
    {
        break;
    }
}