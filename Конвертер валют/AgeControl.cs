using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator_program;

namespace Calculator_program
{
    public class AgeControl
    {

        public void Realization()
        {
            ControlAsk();
        }
            
        void ControlAsk()
        {
            uint rightYear = 2004;
            uint tooOld = 1922;
            uint yearOfBirthInt;
            string yearOfBirth;
            Console.WriteLine("Будь ласка введiть рiк вашого народження:");
            UserInput userInput = new UserInput();
            yearOfBirth = userInput.GetUserInput(TypeOfUserInput.year);

            yearOfBirthInt = Convert.ToUInt32(yearOfBirth);

            if (yearOfBirthInt < rightYear && yearOfBirthInt > tooOld)
            {
                Console.WriteLine("Повнолiття пiдтверджено. Натиснiть будь-яку кнопку, щоб продовжити.");
            }
            else
            {
                Console.WriteLine("Повнолiття не пiдтверджено. Натиснiть будь-яку кнопку, щоб закрити калькулятор.");
                Console.ReadKey();
                Environment.Exit(0);
            }

            Console.ReadKey();
            Console.Clear();
            ShowMainMenu mainMenu = new ShowMainMenu();
            mainMenu.ShowMenu();

        }
    }
}
