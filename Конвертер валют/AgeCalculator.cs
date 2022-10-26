using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Calculator_program
{
    public class AgeCalculator : BaseCalculator
    {
        private DateTime dayOfBirth;
        private DateTime timeNow = DateTime.Now;
        private double fullYears;
        private double daysInYear = 365.24;

        public AgeCalculator(string name, int id) : base(name, id)
        {
            base.name = name;
        }

        public string nameOfCalculator { set { name = value; } }

        public new void Show()
        {
            ShowGreeting();
            GettingInput();
            Calculation();
            AskFinalAnswer();
        }

        public override void GettingInput()
        {
            Console.WriteLine("Введiть дату народження в форматi дд.мм.рррр :");
            string userInputString = userInput.GetUserInput(TypeOfUserInput.date);
            dayOfBirth = DateTime.Parse(userInputString);
            Console.Clear();
            Console.WriteLine($"Ви ввели дату: {dayOfBirth.ToShortDateString()}");
            Console.WriteLine("Натиснiть ENTER, щоб продовжити.");
            Console.ReadKey();
            Console.Clear();
        }

        public override void Calculation()
        {
            TimeSpan age = timeNow - dayOfBirth;
            fullYears = age.TotalDays / daysInYear;
            Console.WriteLine("Вам " + Math.Floor(fullYears) + " рокiв");
            Console.WriteLine(" ");
        }
    }
}
