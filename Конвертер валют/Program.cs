using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Конвертер_валют
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float userInput;
            string currency;
            string finalAnswer;
            uint yearOfBirth;
            bool isEighteen;
            uint rightYear = 2004;
            uint tooOld = 1922;
            float profit;
            float profitUsd;
            float profitEur;
            float singleTaxRate = 0.05f;
            float singleTaxRate = 0.05f; 
            float socialContRate = 0.22f;
            float minSalary = 6500;
            const float MIN_SALARY = 6500;
            float singleTax;
            float socialCont;
            float dollarRate = 0.027f;
            float euroRate = 0.026f;

            //age control 
            Console.WriteLine("Вiтеємо Вас в калькуляторi податкiв!");
            Console.WriteLine("Будь ласка введiть рiк вашого народження:");
            yearOfBirth = uint.Parse(Console.ReadLine());
            
            if (yearOfBirth < rightYear && yearOfBirth > tooOld)
	        {
            isEighteen = true;
            }
            else
            { 
            isEighteen = false;
            }
            if (isEighteen)
	        {
            Console.WriteLine("Повнолiття пiдтверджено");
	        }
            else
            { 
            Console.WriteLine("Повнолiття не пiдтверджено. Натиснiть будь-яку кнопку, щоб закрити калькулятор.");
            Environment.Exit(0);
            }

            Console.WriteLine("Введiть валюту в якiй ви отримуєте дохiд (UAH, USD чи EUR)");

            currency = (Console.ReadLine());

            Console.WriteLine($"Введена валюта - {currency}. Введiть сумму");

            userInput = float.Parse(Console.ReadLine());

            Console.WriteLine("Ви ввели " + userInput + " " + currency + ". Для розрахунку податкiв нажмiть ENTER");
            Console.WriteLine($"Ви ввели {userInput} {currency}. Для розрахунку податкiв нажмiть ENTER");

            Console.ReadKey();

            //maths operations with taxes 

            singleTax = userInput * singleTaxRate;
            socialCont = minSalary * socialContRate;
            socialCont = MIN_SALARY * socialContRate;
            profit = userInput - singleTax - socialCont;
            profitUsd = userInput - singleTax - socialCont * dollarRate;
            profitEur = userInput - singleTax - socialCont * euroRate;


            //output results in console

            
            
            if(currency == "UAH") 
            {
                Console.WriteLine("Дохiд до вирахування податкiв - " + userInput + " UAH" );
                Console.WriteLine("Всього єдиного податку (5%) - " + singleTax + " UAH");
                Console.WriteLine("Всього єдиного соцiального внеску (22%) - " + socialCont + " UAH");
                Console.WriteLine("Прибуток пiсля вирахування податкiв - " + profit + " UAH");
            }
            else if(currency == "USD")
            {
                Console.WriteLine("Дохiд до вирахування податкiв - " + userInput/dollarRate + " UAH");
                Console.WriteLine("Всього єдиного податку (5%) - " + singleTax/dollarRate + " UAH");
                Console.WriteLine("Всього єдиного соцiального внеску (22%) - " + socialCont + " UAH");
                Console.WriteLine("Прибуток пiсля вирахування податкiв - " + profitUsd/dollarRate + " UAH");
            }
            else if (currency == "EUR")
            {
                Console.WriteLine("Дохiд до вирахування податкiв - " + userInput/euroRate + " UAH");
                Console.WriteLine("Всього єдиного податку (5%) - " + singleTax/euroRate + " UAH");
                Console.WriteLine("Всього єдиного соцiального внеску (22%) - " + socialCont + " UAH");
                Console.WriteLine("Прибуток пiсля вирахування податкiв - " + profitEur/euroRate + " UAH");
            }
            else
            switch (currency)
            {
                case  "UAH":
                case  "uah":
                    Console.WriteLine($"Дохiд до вирахування податкiв - {userInput} UAH" );
                    Console.WriteLine($"Всього єдиного податку (5%) - {singleTax} UAH");
                    Console.WriteLine($"Всього єдиного соцiального внеску (22%) - {socialCont} UAH");
                    Console.WriteLine($"Прибуток пiсля вирахування податкiв - {profit} UAH");
                    break;
                case  "USD":
                case  "usd":
                    Console.WriteLine($"Дохiд до вирахування податкiв - {userInput/dollarRate} UAH");
                    Console.WriteLine($"Всього єдиного податку (5%) - {singleTax/dollarRate} UAH");
                    Console.WriteLine($"Всього єдиного соцiального внеску (22%) - {socialCont} UAH");
                    Console.WriteLine($"Прибуток пiсля вирахування податкiв - {profitUsd/dollarRate} UAH");
                    break;
                case  "EUR":
                case  "eur":
                    Console.WriteLine($"Дохiд до вирахування податкiв - {userInput/euroRate} UAH");
                    Console.WriteLine($"Всього єдиного податку (5%) - {singleTax/euroRate} UAH");
                    Console.WriteLine($"Всього єдиного соцiального внеску (22%) - {socialCont} UAH");
                    Console.WriteLine($"Прибуток пiсля вирахування податкiв - {profitEur/euroRate} UAH");
                    break;
                default:
                    Console.WriteLine("Введена валюта невiрна");
                    Main(args);
                    break;
 
            }



            Console.ReadKey();


        }
    }
}
