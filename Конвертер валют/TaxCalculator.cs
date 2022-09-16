using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_program
{
    
    class TaxCalculator
    {
         
        public const string ExitIndex = "Exit";
        public const string CalcAgainIndex = "Calculate again";
        public const string ReturnIndex = "Return";
        public const string dollarIndex = "USD";
        public const string euroIndex = "EUR";
        public const string hryvniaIndex = "UAH";
        double yearProfit;
        public string currency;
        public double profit;
        public double singleTaxRate = 0.05;
        public double socialContRate = 0.22;
        public const double MIN_SALARY = 6500;
        public double singleTax;
        public double socialCont;
        public double dollarRate = 39.77;
        public double euroRate = 39.4;
        public double hryvniaRate = 1;
        public double currencyVariant = 0;
        public string formatMoney = "{0:N}";
        public string finalAnswer;

        public void Main()
        {
            
           GettingInput();
           Calculation();
           ShowResult();
           
        }
     
        private void GettingInput()
        {

            Console.WriteLine("Введiть валюту в якiй ви отримуєте дохiд UAH, USD або EUR");
            UserInput userInput = new UserInput();
            currency = userInput.GetUserInput(TypeOfUserInput.currency);
            Console.WriteLine($"Введена валюта - {currency}.");
            Console.WriteLine("Натиснiть ENTER, щоб продовжити.");
    
        }

        void Calculation()
        { 

            string[] months = { "Сiчень", "Лютий", "Березень", "Квiтень", "Травень", "Червень", "Липень", "Серпень", "Вересень", "Жовтень", "Листопад", "Грудень" };
            string[] monthsProfit = new string[12];
            double[] monthsProfitDouble = new double[12];
            int count = 0;
            double result = 0;

            NumberFormatInfo formatComa = new NumberFormatInfo()
            {
                NumberDecimalSeparator = ",",
            };
            NumberFormatInfo formatDot = new NumberFormatInfo()
            {
                NumberDecimalSeparator = ".",
            };

            while (count < months.Length)
            {
                Console.Clear();
                Console.WriteLine("Введiть дохiд за " + months[count]);
                UserInput userInputMoney = new UserInput();
                monthsProfit[count] = userInputMoney.GetUserInput(TypeOfUserInput.money);

                if (monthsProfit[count].Contains(","))
                {
                    monthsProfitDouble[count] = Double.Parse(monthsProfit[count], formatComa);
                }
                else if (monthsProfit[count].Contains("."))
                {
                    monthsProfitDouble[count] = Double.Parse(monthsProfit[count], formatDot);
                }
                else
                {
                    monthsProfitDouble[count] = Double.Parse(monthsProfit[count]);
                }
                result += monthsProfitDouble[count];
                count++;
            }
            
            if (currency == hryvniaIndex)
            {
                currencyVariant = hryvniaRate;
            }
            else if (currency == euroIndex)
            {
                currencyVariant = euroRate;
            }
            else if (currency == dollarIndex)
            {
                currencyVariant = dollarRate;
            }
           
            yearProfit = result;
            yearProfit = yearProfit * currencyVariant;
            singleTax = yearProfit * singleTaxRate;
            socialCont = MIN_SALARY * socialContRate;
            profit = yearProfit - singleTax - socialCont;       
          
            Console.Clear();
            Console.Write("Ви ввели " + formatMoney, result);
            Console.Write(" " + currency);
            Console.WriteLine(". Для розрахунку податкiв натиснiть ENTER");
            Console.ReadKey();
                    
        }

        void ShowResult()
        {
            
            Console.Clear();
            Console.Write("Дохiд до вирахування податкiв - " + formatMoney, yearProfit);
            Console.WriteLine(" гривень");
            Console.Write("Всього єдиного податку (5%) - " + formatMoney, singleTax);
            Console.WriteLine(" гривень");
            Console.Write("Всього єдиного соцiального внеску (22%) - " + formatMoney, socialCont);
            Console.WriteLine(" гривень");
            Console.Write("Прибуток пiсля вирахування податкiв - " + formatMoney, profit);
            Console.WriteLine(" гривень");
            Console.WriteLine(" ");
            Console.WriteLine("Щоб закрити програму напишiть Exit, щоб повернутись в головне меню напишiть Return.");
            Console.WriteLine("Щоб рахувати знову напишiть Calculate again.");
            UserInput userInputCommand = new UserInput();
            finalAnswer = userInputCommand.GetUserInput(TypeOfUserInput.command);
            if (finalAnswer == ExitIndex)
            {
                Environment.Exit(0);
            }
            else if (finalAnswer == CalcAgainIndex)
            {
                Console.Clear();
                var reload = new TaxCalculator();
                reload.GettingInput();
            }
            else if (finalAnswer == ReturnIndex)
            {
                Console.Clear();
                MainMenu mainMenu = new MainMenu();
                mainMenu.ShowMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Неправильний ввiд! Використовуйте Exit, Return або Calculate again.");
                ShowResult();
                userInputCommand.GetUserInput(TypeOfUserInput.command);
            }
        }  
    }
} 


