using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Calculator_program
{
    

    public class TimerApp : BaseCalculator
    {
        private string secondsInputString;
        private string addSecondsInputString;
        private int secondsInput;
        private int time;
        TimerView timerView = new TimerView();

        InputController inputController = new InputController();

        public TimerApp(string name, int id) : base(name, id)
        {
            base.name = name;
        }

        public string nameOfCalculator { set { name = value; } }

        public new void Start()
        {
            ShowGreeting();
            GettingInput();
            AddTime();
            Calculation();
            AskFinalAnswer();
        }

        public override void GettingInput()
        {
            timerView.AskFirstInput();          
            secondsInputString = userInput.GetUserInput(TypeOfUserInput.number, TypeOfUserInput.command);
            secondsInput = Int32.Parse(secondsInputString);
            timerView.Clear();          
            timerView.CheckInput(secondsInput);
            timerView.AskOfContinue();
            Console.ReadKey();
            timerView.Clear();
        }

        public async void AddTime()
        {
            await Task.Run(() =>
            {
                if (time < secondsInput)
                {
                    addSecondsInputString = userInput.GetUserInput(TypeOfUserInput.number, TypeOfUserInput.command);
                    secondsInput += Int32.Parse(addSecondsInputString);
                    timerView.SecondsAdding(addSecondsInputString);
                }         
            });
        }

        public override void Calculation()
        {
            timerView.TimerIsWorking();

            for (time = 0; time < secondsInput; time++)
            {
                Thread.Sleep(1000);
            }

            Console.Beep();            
            timerView.Clear();
            timerView.ShowResult(secondsInput);

            inputController.Message += timerView.ShowOverMessage;
            timerView.ShowOverMessage();
        }   
    }
}
