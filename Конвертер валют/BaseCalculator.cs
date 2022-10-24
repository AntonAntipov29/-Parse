using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_program
{
    public abstract class BaseCalculator : ICalculator
    {
        protected string name;
        protected int id;
        protected string finalAnswer;
        protected UserInput userInput = new UserInput();

        public BaseCalculator(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public string Name
        {
            get { return name; }
        }

        public int ID
        {
            get { return id; }
        }

        public void Show()
        {
            ShowGreeting();
            GettingInput();
            Calculation();
            AskFinalAnswer();
        }

        public abstract void GettingInput();

        public abstract void Calculation();

        public void ShowGreeting()
        {
            Console.WriteLine($"Ви обрали {name}!");
        }

        public void AskFinalAnswer()
        {
            Console.WriteLine("Щоб закрити програму напишiть Exit, щоб повернутись в головне меню напишiть Return.");
            Console.WriteLine("Щоб рахувати знову напишiть Calculate again.");
            finalAnswer = userInput.GetUserInput(TypeOfUserInput.command);
            if (finalAnswer == Commands.exitIndex)
            {
                Environment.Exit(0);
            }
            else if (finalAnswer == Commands.calcAgainIndex)
            {
                Console.Clear();
                Show(); 
            }
            else if (finalAnswer == Commands.returnIndex)
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
