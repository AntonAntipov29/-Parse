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
                double yearProfit;
                string currency;
                double profit;
                float singleTaxRate = 0.05f;
                float socialContRate = 0.22f;
                const float MIN_SALARY = 6500;
                double singleTax;
                double socialCont;
                float dollarRate = 39.77f;
                float euroRate = 39.4f;
                float hryvniaRate = 1f;
                float currencyVariant = 0;
                string formatMoney = "{0:N}";


                Console.WriteLine("Введiть валюту в якiй ви отримуєте дохiд UAH, USD або EUR");
                currency = GetUserInput(TypeOfUserInput.currency);
                Console.WriteLine($"Введена валюта - {currency}. ");
                Console.WriteLine("Натиснiть ENTER, щоб продовжити.");
                Console.ReadKey();
                yearProfit = YearProfit();
                Console.Write("Ви ввели " + formatMoney,yearProfit);
                Console.Write(" "+currency);
                Console.WriteLine(". Для розрахунку податкiв натиснiть ENTER");
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


                Console.Write("Дохiд до вирахування податкiв - " + formatMoney, yearProfit);
                Console.WriteLine(" гривень");
                Console.Write("Всього єдиного податку (5%) - " + formatMoney, singleTax);
                Console.WriteLine(" гривень");
                Console.Write("Всього єдиного соцiального внеску (22%) - " + formatMoney, socialCont);
                Console.WriteLine(" гривень");
                Console.Write("Прибуток пiсля вирахування податкiв - " + formatMoney, profit);
                Console.WriteLine(" гривень");

                FinalAnswer();
            }

            double YearProfit()
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
                    monthsProfit[count] = GetUserInput(TypeOfUserInput.money);

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
                return result;
            }

            void FinalAnswer()
            {
                string finalAnswer = "";

                Console.WriteLine("Щоб закрити програму напишiть Exit, щоб рахувати знову напишiть Calculate again.");
                finalAnswer = GetUserInput(TypeOfUserInput.command);

                if (finalAnswer == ExitIndex)
                {
                    Environment.Exit(0);
                }
                else if (finalAnswer == CalcAgainIndex)
                {

                    TaxCalculator();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Неправильний ввiд! Використовуйте Exit або Calculate again.");
                    FinalAnswer();
                }

                Console.ReadKey();
            }
            string GetUserInput(TypeOfUserInput type)
            {
                string returnInput = "";

                if (type == TypeOfUserInput.year)
                {
                    string yearOfBirth;
                    yearOfBirth = Console.ReadLine();
                    if (int.TryParse(yearOfBirth, out int number))
                    {
                        returnInput = yearOfBirth;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Ввiд неправильний! Будь ласка введiть рiк числом!");
                        Console.ReadKey();
                        Console.Clear();
                        AgeControl();
                    }
                }
                else if (type == TypeOfUserInput.money)
                {




                    string moneyInput;
                    float number;
                    moneyInput = Console.ReadLine();
                    bool isLetter = moneyInput.All(Char.IsLetter);
                    if (Single.TryParse(moneyInput, out number))
                    {
                        returnInput = moneyInput;
                    }
                    else if (isLetter == false && moneyInput.Contains("."))
                    {
                        returnInput = moneyInput;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Помилка! Будь ласка вводьте числами!");
                        Console.ReadKey();
                        TaxCalculator();
                    }
                }
                else if (type == TypeOfUserInput.currency)
                {
                    string currencyInput;
                    currencyInput = Console.ReadLine();
                    if (int.TryParse(currencyInput, out int number))
                    {
                        Console.Clear();
                        Console.WriteLine("Неправильний ввiд! Використовуйте UAH, USD або EUR. Натиснiть будь-яку кнопку, щоб продовжити.");
                        TaxCalculator();
                    }
                    else
                    {
                        if (currencyInput == hryvniaIndex)
                        {
                            returnInput = currencyInput;
                        }
                        else if (currencyInput == dollarIndex)
                        {
                            returnInput = currencyInput;
                        }
                        else if (currencyInput == euroIndex)
                        {
                            returnInput = currencyInput;
                        }
                        else
                        {
                            Console.WriteLine("Неправильний ввiд! Використовуйте UAH, USD або EUR. Натиснiть будь-яку кнопку, щоб продовжити.");
                            Console.ReadKey();
                            Console.Clear();
                            TaxCalculator();
                        }

                    }

                }
                else if (type == TypeOfUserInput.command)
                {
                    string commandInput;
                    commandInput = Console.ReadLine();

                    if (commandInput == CalcAgainIndex)
                    {

                        returnInput = commandInput;
                    }
                    else if (commandInput == ExitIndex)
                    {
                        returnInput = commandInput;
                    }

                }
                return returnInput;
            }
        } 
    }
}

