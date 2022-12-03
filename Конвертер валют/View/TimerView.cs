using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_program
{
    internal class TimerView : BaseCalculatorView
    {
        public void AskFirstInput()
        {
            Console.WriteLine("Введiть кiлькiсть секунд, яку має вiдрахувати таймер");
        }

        public void CheckInput(int secondsAmount)
        {
            Console.WriteLine($"Ви ввели {secondsAmount} секунд");
        }

        public void ShowResult(int secondsInput)
        {
            Console.WriteLine($"Таймер працював {secondsInput} секунд");
        }

        public void SecondsAdding(string addSecondsInputString)
        {
            Console.WriteLine($"Ви додали секунд: {addSecondsInputString}");
        }

        public void TimerIsWorking()
        {
            Console.WriteLine("Таймер працює, ви можете в будь-який момент додати час в секунах");
        }

        public void ShowOverMessage()
        {
            Console.WriteLine("Час таймеру минув.");
        }
    }
}
