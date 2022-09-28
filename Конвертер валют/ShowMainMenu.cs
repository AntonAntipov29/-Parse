﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_program
{
    public class MainMenu
    {
        public void ShowMenu()
        {
            string choiseInput;
            Console.WriteLine("Введiть номер калькулятора, який хочете використовувати:");
            Console.WriteLine("1. Простий калькулятор");
            Console.WriteLine("2. Калькулятор вiку");
            Console.WriteLine("3. Калькулятор податкiв");

            UserInput userInput = new UserInput();
            choiseInput = userInput.GetUserInput(TypeOfUserInput.number, TypeOfUserInput.command);
            
            if (choiseInput == "1")
            {
                Console.Clear();
                SimpleCalculator simpleCalculator = new SimpleCalculator();
                simpleCalculator.LaunchSimpleCalculator();
            }
            else if (choiseInput == "2")
            {
                Console.Clear();
                AgeCalculator ageCalculator = new AgeCalculator();
                ageCalculator.LaunchAgeCalculator();
            }
            else if (choiseInput == "3")
            {
                Console.Clear();
                TaxCalculator taxCalculator = new TaxCalculator();
                taxCalculator.Show();
            }
            else if (choiseInput == TaxCalculator.exitIndex)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                UserInput userInputTwo = new UserInput();
                userInputTwo.ShowWarning();
                ShowMenu();
            }
        }
    }
}
