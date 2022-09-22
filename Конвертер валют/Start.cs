using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_program
{
    public class Start
    {


        static void Main()
        {
            Greeting();
            AgeControler();
            ShowMainMenu();

            void Greeting()
            {
                Console.WriteLine("Вiтеємо Вас в унiверсальному калькуляторi!");
                Console.WriteLine("Натиснiть будь-яку кнопку, щоб продовжити.");
                Console.ReadKey();
                Console.Clear();
            }
            void AgeControler()
            {
                bool ageControlchecked;
                AgeControl ageControl = new AgeControl();
                ageControlchecked = AgeControl.ControlAsk();

                if (ageControlchecked == false)
                {
                    Environment.Exit(0);
                }
                else
                {
                }
            }
            void ShowMainMenu()
            {
                ShowMainMenu showMainMenu = new ShowMainMenu();
                showMainMenu.ShowMenu();
            }
        }
    }
}
