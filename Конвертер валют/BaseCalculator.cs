using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_program
{
    public class BaseCalculator
    {
        int id;
        string name;

        public const string exitIndex = "Exit";
        public const string calcAgainIndex = "Calculate again";
        public const string returnIndex = "Return";
        public string finalAnswer;

        UserInput userInput = new UserInput();

        void GettingInput()
        {

        }

        void Calculation()
        {

        }

        public void AskFinalAnswer()
        {
            Console.WriteLine("Щоб закрити програму напишiть Exit, щоб повернутись в головне меню напишiть Return.");
            Console.WriteLine("Щоб рахувати знову напишiть Calculate again.");
            finalAnswer = userInput.GetUserInput(TypeOfUserInput.command);
            if (finalAnswer == exitIndex)
            {
                Environment.Exit(0);
            }
            else if (finalAnswer == calcAgainIndex)
            {
                Console.Clear();
                GettingInput();
            }
            else if (finalAnswer == returnIndex)
            {
                Console.Clear();
                MainMenu mainMenu = new MainMenu();
                mainMenu.ShowMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Неправильний ввiд! Використовуйте Exit, Return або Calculate again.");
                AskFinalAnswer();
                userInput.GetUserInput(TypeOfUserInput.command);
            }
        }
    }
}
