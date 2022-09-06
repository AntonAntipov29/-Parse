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
        
        static void Main(string[] args)
        {
            //age control 
            AgeControl(); 

            //ask for gain values from user, maths operations with taxes, output results in console
            TaxCalculator();

            //final answer
            FinalAnswer();
        }

        

        static void AgeControl()
        {         
            Console.WriteLine("Вiтеємо Вас в калькуляторi податкiв!");
            Console.WriteLine("Будь ласка введiть рiк вашого народження:");
            GetUserInput(TypeOfUserInput.year);
            Console.ReadKey();
            Console.Clear();
        }

        void TaxCalculator()
        {
            float userInput;
            string currency;
            float userInputUsd;
            float userInputEur;
            float profit;
            float profitUsd;
            float profitEur;
            float singleTaxRate = 0.05f; 
            float socialContRate = 0.22f;
            const float MIN_SALARY = 6500;
            float singleTax;
            float singleTaxUsd;
            float singleTaxEur;
            float socialCont;
            float dollarRate = 0.027f;
            float euroRate = 0.026f;
            

            Console.WriteLine("Введiть валюту в якiй ви отримуєте дохiд UAH, USD або EUR");
            currency = GetUserInput(TypeOfUserInput.currency);
            Console.WriteLine($"Введена валюта - {currency}. ");
            Console.ReadKey();
            userInput = YearProfit();
            Console.WriteLine($"Ви ввели {userInput} {currency}. Для розрахунку податкiв натиснiть ENTER");
            Console.ReadKey();
            Console.Clear();

            //maths operations with taxes 

            singleTax = userInput * singleTaxRate;
            socialCont = MIN_SALARY * socialContRate;
            profit = userInput - singleTax - socialCont;
                      
            //output results in console

            switch (currency)
            {
             case  "UAH":
             case  "uah":
             break;
             case  "USD":
             case  "usd":
                singleTaxUsd = singleTax/dollarRate;
                userInputUsd = userInput/dollarRate;
                profitUsd = (userInput - singleTax - socialCont * dollarRate)/dollarRate;
                userInput = userInputUsd;
                singleTax = singleTaxUsd;
                profit = profitUsd;
             break;
             case  "EUR":
             case  "eur":
                profitEur = (userInput - singleTax - socialCont * euroRate)/euroRate;
                userInputEur = userInput/euroRate;
                singleTaxEur = singleTax/euroRate;
                userInput = userInputEur;
                singleTax = singleTaxEur;
                profit = profitEur;
             break;
             default:
               Console.WriteLine("Введена валюта невiрна");
               Console.Clear();
               AgeControl();
             break;
            }
         
             Console.WriteLine($"Дохiд до вирахування податкiв - {userInput} UAH" );
             Console.WriteLine($"Всього єдиного податку (5%) - {singleTax} UAH");
             Console.WriteLine($"Всього єдиного соцiального внеску (22%) - {socialCont} UAH");
             Console.WriteLine($"Прибуток пiсля вирахування податкiв - {profit} UAH");
        }

        static int YearProfit()
        {
            string [] months = {"Сiчень","Лютий","Березень","Квiтень","Травень","Червень","Липень","Серпень","Вересень","Жовтень","Листопад","Грудень"};
            int [] monthsProfit = new int[12];
            int count = 0;
            int result = 0;
            int returnInt;
            
            while(count < months.Length)
            {
            Console.Clear();
            Console.WriteLine("Введiть дохiд за " + months[count]);
            returnInt = Convert.ToInt32(GetUserInput(TypeOfUserInput.money));
            monthsProfit[count] = returnInt;
            result += monthsProfit[count];
            count++;
            }
            return result;
        } 

        static void FinalAnswer()
        {
            string finalAnswer;
            Console.WriteLine("Щоб закрити програму напишiть Exit, щоб рахувати знову напишiть Calculate again.");
            finalAnswer = GetUserInput(TypeOfUserInput.command);
            
            switch (finalAnswer)
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
            Console.ReadKey();
        }
        static string GetUserInput(TypeOfUserInput type)
        {
            string returnInput = "";

            if (type == TypeOfUserInput.year)
            {
              string yearOfBirth;  
              uint yearOfBirthInt;
              uint rightYear = 2004;
              uint tooOld = 1922;
              yearOfBirth = Console.ReadLine();
              if (int.TryParse(yearOfBirth, out int number))
	          {
                yearOfBirthInt = Convert.ToUInt32(yearOfBirth);
                if (yearOfBirthInt < rightYear && yearOfBirthInt > tooOld)
	            {            
                Console.WriteLine("Повнолiття пiдтверджено. Натиснiть будь-яку кнопку, щоб продовжити.");
                }
                else
                { 
                Console.WriteLine("Повнолiття не пiдтверджено. Натиснiть будь-яку кнопку, щоб закрити калькулятор.");
                Environment.Exit(0);
                }
	          }
              else
              {
                Console.Clear();
                Console.WriteLine("Будь ласка введiть рiк вашого народження числом!");
                GetUserInput(TypeOfUserInput.year);
              } 
            }else if (type == TypeOfUserInput.money)
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
                BasisBlock();
               }
            }else if (type == TypeOfUserInput.currency)
            {
              string currencyInput;
              currencyInput = Console.ReadLine();
              if (int.TryParse(currencyInput, out int number))
               {
                Console.Clear();
                Console.WriteLine("Неправильний ввiд! Використовуйте UAH, USD або EUR.");
                BasisBlock();
               }
              else
               {
                returnInput = currencyInput;
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
                returnInput = commandInput;
               }
            }
         return returnInput;
        }
        }
    }

