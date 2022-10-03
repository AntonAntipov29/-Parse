using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Calculator_program
{
    internal class AgeCalculator
    {
        DateTime dayOfBirth;
        DateTime timeNow = DateTime.Now;
        private string finalAnswer;
        private double fullYears;
        private double daysInYear = 365.24;

        UserInput userInput = new UserInput();

        public void Show()
        {
            GettingInput();
            Calculation();
            ShowResult();
        }

        private void GettingInput()
        {            
            Console.WriteLine("Ви обрали калькулятор вiку.");
            Console.WriteLine("Введiть дату народження в форматi дд.мм.рррр :");
            string userInputString = userInput.GetUserInput(TypeOfUserInput.date);
            dayOfBirth = DateTime.Parse(userInputString);
            Console.Clear();
            Console.WriteLine($"Ви ввели дату: {dayOfBirth.ToShortDateString()}");
            Console.WriteLine("Натиснiть ENTER, щоб продовжити.");
            Console.ReadKey();
            Console.Clear();
        }

        private void Calculation()
        {
            TimeSpan age = timeNow - dayOfBirth;
            fullYears =  age.TotalDays / daysInYear;
        }       
        
        private void ShowResult()
        {    
            Console.WriteLine("Вам " + Math.Floor(fullYears) + " рокiв");          
            Console.WriteLine(" ");          
            Console.WriteLine("Щоб закрити програму напишiть Exit, щоб повернутись в головне меню напишiть Return.");
            Console.WriteLine("Щоб рахувати знову напишiть Calculate again.");
            finalAnswer = userInput.GetUserInput(TypeOfUserInput.command);

            if (finalAnswer == TaxCalculator.exitIndex)
            {
                Environment.Exit(0);
            }
            else if (finalAnswer == TaxCalculator.calcAgainIndex)
            {
                Console.Clear();
                Show();
            }
            else if (finalAnswer == TaxCalculator.returnIndex)
            {
                Console.Clear();
                MainMenu mainMenu = new MainMenu();
                mainMenu.ShowMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Неправильний ввiд! Використовуйте Exit, Return або Calculate again.");
                ShowResult();
                userInput.GetUserInput(TypeOfUserInput.command);
            }
        }   
    }
}
