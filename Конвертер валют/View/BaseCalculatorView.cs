using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Calculator_program
{
    public class BaseCalculatorView : IVisible
    {       
        public void Show(string writeLineInput)
        {
            Console.WriteLine(writeLineInput);
        }

        public void ShowOnThirdLine(string writeLineInput)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(writeLineInput);
        }

        public void Clear()
        {
            Console.Clear();
        }
        public void ShowSeparatorLine()
        {
            Console.WriteLine("______________________________________________________________");      
        }

        public void ShowGreeting(string name)
        {
            Console.WriteLine($"Ви обрали {name}!");
        }

        public void AskOfContinue()
        {
            Console.WriteLine("Натиснiть ENTER, щоб продовжити.");
        }

        public void AskFinalAnswer()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Щоб закрити програму напишiть Exit, щоб повернутись в головне меню напишiть Return.");
            Console.WriteLine("Щоб рахувати знову напишiть Calculate again.");
        }
    }
}
