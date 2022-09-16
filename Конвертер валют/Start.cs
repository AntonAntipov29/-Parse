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

            void Greeting()
            {

            
            Console.WriteLine("Вiтеємо Вас в унiверсальному калькуляторi!");
            Console.WriteLine("Натиснiть будь-яку кнопку, щоб продовжити.");
            Console.ReadKey();
            Console.Clear();
            AgeControl ageControl = new AgeControl();
            ageControl.Realization();
            }

        }
    }
}
