using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Конвертер_валют
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            float userInput;
            float userInputUsd;
            float userInputEur;
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
            float singleTaxUsd;
            float singleTaxEur;
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
            Console.WriteLine("Повнолiття пiдтверджено. Натиснiть будь-яку кнопку, щоб продовжити.");
	        }
            else
            { 
            Console.WriteLine("Повнолiття не пiдтверджено. Натиснiть будь-яку кнопку, щоб закрити калькулятор.");
            Environment.Exit(0);
            }

            Console.ReadKey();
            Console.Clear();

            //ask for gain values from user, and take it from console
            Console.WriteLine("Введiть валюту в якiй ви отримуєте дохiд (UAH, USD чи EUR)");
            Console.WriteLine("Введiть валюту в якiй ви отримуєте дохiд UAH, USD чи EUR");

            currency = (Console.ReadLine());

            Console.WriteLine($"Введена валюта - {currency}. Введiть сумму");

            userInput = float.Parse(Console.ReadLine());

            Console.WriteLine("Ви ввели " + userInput + " " + currency + ". Для розрахунку податкiв нажмiть ENTER");
            Console.WriteLine($"Ви ввели {userInput} {currency}. Для розрахунку податкiв нажмiть ENTER");

            Console.ReadKey();

            Console.Clear();

            //maths operations with taxes 

            singleTax = userInput * singleTaxRate;
            socialCont = minSalary * socialContRate;
            socialCont = MIN_SALARY * socialContRate;
            profit = userInput - singleTax - socialCont;
            profitUsd = userInput - singleTax - socialCont * dollarRate;
            profitEur = userInput - singleTax - socialCont * euroRate;

            profitUsd = (userInput - singleTax - socialCont * dollarRate)/dollarRate;
            profitEur = (userInput - singleTax - socialCont * euroRate)/euroRate;
            userInputEur = userInput/euroRate;
            userInputUsd = userInput/dollarRate;
            singleTaxUsd = singleTax/dollarRate;
            singleTaxEur = singleTax/euroRate;
            

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
                    userInput = userInputUsd;
                    singleTax = singleTaxUsd;
                    profit = profitUsd;
                    break;
                case  "EUR":
                case  "eur":
                    Console.WriteLine($"Дохiд до вирахування податкiв - {userInput/euroRate} UAH");
                    Console.WriteLine($"Всього єдиного податку (5%) - {singleTax/euroRate} UAH");
                    Console.WriteLine($"Всього єдиного соцiального внеску (22%) - {socialCont} UAH");
                    Console.WriteLine($"Прибуток пiсля вирахування податкiв - {profitEur/euroRate} UAH");
                    userInput = userInputEur;
                    singleTax = singleTaxEur;
                    profit = profitEur;
                    break;
                default:
                    Console.WriteLine("Введена валюта невiрна");
                    Main(args);
                    break;
 
            }
            
                    Console.WriteLine($"Дохiд до вирахування податкiв - {userInput} UAH" );
                    Console.WriteLine($"Всього єдиного податку (5%) - {singleTax} UAH");
                    Console.WriteLine($"Всього єдиного соцiального внеску (22%) - {socialCont} UAH");
                    Console.WriteLine($"Прибуток пiсля вирахування податкiв - {profit} UAH");

            //final answer

            Console.WriteLine("Щоб закрити програму напишiть Exit, щоб рахувати знову напишiть Calculate again.");
            finalAnswer = Console.ReadLine();
            
            switch (finalAnswer)

	        {
                case  "Calculate again"  :
                case  "calculate again"  :
                    Console.Clear();
                        Main(args);
                    break;
                case  "Exit" :
                case  "exit" :
                        Environment.Exit(0);
                    break;
		        default:
                    Console.WriteLine("Невiдома команда, перевірте ввiд i спробуйте знову");
                    Console.WriteLine("Невiдома команда, перевiрте ввiд i спробуйте знову");
                    Console.ReadKey();
                    Console.Clear();
                    Main(args);
                    break;
	           }   
            
            Console.ReadKey();
           
          }

                
        }
    }

