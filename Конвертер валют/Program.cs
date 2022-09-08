using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Конвертер_валют
{
    internal class Program
    {
        enum TypeOfUserInput{command, currency, money, year};
        private const string ExitIndex = "Exit";
        private const string CalcAgainIndex = "Calculate again";
        private const string dollarIndex = "USD";
        private const string euroIndex = "EUR";
        private const string hryvniaIndex = "UAH";

        static void Main(string[] args)
        {
              
            AgeControl();

            void AgeControl()
            {
                uint rightYear = 2004;
                uint tooOld = 1922;
                uint yearOfBirthInt;
                Console.WriteLine("Вiтеємо Вас в калькуляторi податкiв!");
                Console.WriteLine("Будь ласка введiть рiк вашого народження:");
                yearOfBirthInt = Convert.ToUInt32(GetUserInput(TypeOfUserInput.year));
                if (yearOfBirthInt < rightYear && yearOfBirthInt > tooOld)
                {
                    Console.WriteLine("Повнолiття пiдтверджено. Натиснiть будь-яку кнопку, щоб продовжити.");
                }
                else
                {
                    Console.WriteLine("Повнолiття не пiдтверджено. Натиснiть будь-яку кнопку, щоб закрити калькулятор.");
                    Environment.Exit(0);
                }

                Console.ReadKey();
                Console.Clear();

                TaxCalculator();
            }

            void TaxCalculator()
            {
                float yearProfit;
                string currency;
                float profit;
                float singleTaxRate = 0.05f;
                float socialContRate = 0.22f;
                const float MIN_SALARY = 6500;
                float singleTax;
                float socialCont;
                float dollarRate = 39.77f;
                float euroRate = 39.4f;
                float hryvniaRate = 1f;
                string dollarIndex = "USD";
                string euroIndex = "EUR";
                string hryvniaIndex = "UAH";
                float currencyVariant = 0;

                
                Console.WriteLine("Введiть валюту в якiй ви отримуєте дохiд UAH, USD або EUR");
                currency = GetUserInput(TypeOfUserInput.currency);
                Console.WriteLine($"Введена валюта - {currency}. ");
                Console.ReadKey();
                yearProfit = YearProfit();
                Console.WriteLine($"Ви ввели {yearProfit} {currency}. Для розрахунку податкiв натиснiть ENTER");
                Console.ReadKey();
                Console.Clear();

                //maths operations with taxes 
                if (currency == hryvniaIndex)
                {
                    currencyVariant = hryvniaRate;
                }
                else if (currency == dollarIndex)
                {
                    currencyVariant = dollarRate;
                }
                else if (currency == euroIndex)
                {
                    currencyVariant = euroRate;
                }


                yearProfit = yearProfit * currencyVariant;
                singleTax = yearProfit * singleTaxRate;
                socialCont = MIN_SALARY * socialContRate;
                profit = yearProfit - singleTax - socialCont;

                //output results in console

                Console.WriteLine($"Дохiд до вирахування податкiв - {yearProfit} UAH");
                Console.WriteLine($"Всього єдиного податку (5%) - {singleTax} UAH");
                Console.WriteLine($"Всього єдиного соцiального внеску (22%) - {socialCont} UAH");
                Console.WriteLine($"Прибуток пiсля вирахування податкiв - {profit} UAH");

                FinalAnswer();
            }

            int YearProfit()
            {
              string moneyInput;
              moneyInput = Console.ReadLine();
              if (int.TryParse(moneyInput, out int number))
               {
                returnInput = moneyInput;
               }
              else
               {
                Console.Clear();
                Console.WriteLine("Помилка! Будь ласка вводьте ваш дохiд числами!");
                Console.ReadKey();
                TaxCalculator();
               }
            }else if (type == TypeOfUserInput.currency)
            {
              string currencyInput;
              string dollarIndex = "USD";
              string euroIndex = "EUR";
              string hryvniaIndex = "UAH";
              currencyInput = Console.ReadLine();
              if (int.TryParse(currencyInput, out int number))
               {
                Console.Clear();
                Console.WriteLine("Неправильний ввiд! Використовуйте UAH, USD або EUR.");
                TaxCalculator();
               }
              else
               {
                if (currencyInput == hryvniaIndex)
	            {
                 returnInput = currencyInput;
	            }else if (currencyInput == dollarIndex)
                {
                 returnInput = currencyInput;
                }else if (currencyInput == euroIndex)
                {
                 returnInput = currencyInput;
                }
                else
                {
                 Console.WriteLine("Неправильний ввiд! Використовуйте UAH, USD або EUR.");
                 Console.ReadKey();
                 Console.Clear();
                 Main(args);
                }
                
               }
              
            }else if (type == TypeOfUserInput.command)
            {
              string commandInput;
              commandInput = Console.ReadLine();
              if (int.TryParse(commandInput, out int number))
               {
                Console.Clear();
                Console.WriteLine("Неправильний ввiд! Використовуйте Exit або Calculate again.");
                FinalAnswer();
               }
              else
               {
                switch (commandInput)
	            {
                  case  "Calculate again"  :
                  case  "calculate again"  :
                   Console.Clear();
                   AgeControl();       
                  break;
                  case  "Exit" :
                  case  "exit" :
                   Environment.Exit(0);
                  break;
		          default:
                   Console.WriteLine("Невiдома команда, перевiрте ввiд i спробуйте знову");
                   Console.ReadKey();
                   Console.Clear();
                   FinalAnswer();
                  break;
	            }
                returnInput = commandInput;
               }
            }
         return returnInput;
        }
        } 
    }
}

