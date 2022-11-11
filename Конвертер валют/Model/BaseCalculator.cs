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
        protected InputController userInput = new InputController();
        protected BaseCalculatorView baseCalculatorView = new BaseCalculatorView();

        public BaseCalculator(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public string Name { get { return name; } }

        public int ID { get { return id; } }

        public void Start()
        {
            ShowGreeting();
            GettingInput();
            Calculation();
            AskFinalAnswer();
        }

        public void ShowGreeting()
        {
            baseCalculatorView.ShowGreeting(name);
        }

        public abstract void GettingInput();

        public abstract void Calculation();

        public void AskFinalAnswer()
        {
            baseCalculatorView.AskFinalAnswer();
            finalAnswer = userInput.GetUserInput(TypeOfUserInput.command);
            if (finalAnswer == Commands.exitIndex)
            {
                Environment.Exit(0);
            }
            else if (finalAnswer == Commands.calcAgainIndex)
            {
                Console.Clear();
                Start();
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
                userInput.ShowWarning();              
                AskFinalAnswer();
                userInput.GetUserInput(TypeOfUserInput.command);
            }
        }
    }
}
