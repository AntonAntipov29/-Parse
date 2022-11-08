using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Calculator_program
{
    public class AgeCalculatorView : BaseCalculatorView
    {
       

        public void AskFirstInput()
        {
            Console.WriteLine("Введiть дату народження в форматi дд.мм.рррр :");
        }

        public void CheckInput(string dayOfBirthString)
        {
            Console.WriteLine($"Ви ввели дату: {dayOfBirthString}");
        }

        public void ShowResult(double fullYears)
        {
            Console.WriteLine("Вам " + fullYears + " рокiв");
        }
    }
}
