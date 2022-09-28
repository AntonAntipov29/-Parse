using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_program
{
    internal class AgeCalculator
    {
        public void LaunchAgeCalculator()
        {
            Console.WriteLine("Данна функцiя буде додана згодом, очiкуйте на оновлення.");
            Console.WriteLine("Щоб повернутись в попередньє меню введiть Return.");
            Console.WriteLine("Щоб закрити додаток введiть Exit.");
            string answer = Console.ReadLine();
            if (answer == TaxCalculator.exitIndex)
            {
                Environment.Exit(0);
            }
            else if (answer == TaxCalculator.returnIndex)
            {
                Console.Clear();
                MainMenu mainMenu = new MainMenu();
                mainMenu.ShowMenu();
            }
            else
            {
                Console.Clear();
                UserInput userInputTwo = new UserInput();
                userInputTwo.ShowWarning();
                LaunchAgeCalculator();
            }
        }
    }
}
