// <copyright file="UI.cs" company="My Company Name">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace NumberToString
{
    using System;
    using System.Threading;
    using ShowMenuLib;

    /// <summary>
    /// Present visualization for user
    /// </summary>
    internal class UI : GetMenu
    {
        /// <summary>
        /// Instance of business logic
        /// </summary>
        private BusinessLogic logic = new BusinessLogic();
        
        /// <summary>
        /// User`s number
        /// </summary>
        private double number;
        
        /// <summary>
        /// Show menu for translator
        /// </summary>
        /// <param name="type">The header-line of menu </param>
        /// <returns>user choice</returns>
        public override char ShowMenu(string type)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(type);
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("           1.Помощь               ");
            Console.WriteLine("           2.Погнали              ");
            Console.WriteLine("           3.Назад в меню         ");
            Console.WriteLine("           4.Выход                ");
            Console.WriteLine();
            Console.WriteLine(" Каков ваш выбор? [напишите число]");

            return Console.ReadKey().KeyChar;
        }

        /// <summary>
        /// Show logic depending on the choice
        /// </summary>
        /// <param name="i">position of user choice(from top)</param>
        public override void UserChoice(int i)
        {
            if (i == 4)
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-EN");
                this.PrintMenu(" Welcome to the translate program!", @"..\..\Files\ENRef.txt");
            }

            if (i == 5)
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru-RU");
                this.PrintRussianMenu();
            }

            if (i == 6)
            {
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Sub-menu inside english language
        /// </summary>
        private void ToEnglish()
        {
            BusinessLogic.Language = ChooseLanguage.English;
            bool isCorrect = false;
            Console.WriteLine("Write down your number.");
            string helper = Console.ReadLine();
            if (helper.Contains("."))
            {
                helper = helper.Replace(".", ",");
            }

            try
            {
                this.number = double.Parse(helper);
                isCorrect = true;
            }
            catch
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Beep();
                Console.WriteLine("Please,write a number.");
                isCorrect = false;
            }

            if (isCorrect)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                BusinessLogic.Zero = "zero ";
                try
                {
                    Console.WriteLine(this.logic.GetWords(number.ToString(), "point", "minus"));
                }
                catch (FormatException)
                {
                    Console.WriteLine("Quantity of zeros after coma should not be more than 3.");
                }
            }

            Console.ResetColor();
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        /// <summary>
        /// Sub-menu inside russian language
        /// </summary>
        private void ToRussian()
        {
            BusinessLogic.Language = ChooseLanguage.Russian;
            bool isCorrect = false;
            Console.WriteLine("Введите ваше число:");
            string helper = Console.ReadLine();
            if (helper.Contains("."))
            {
                helper = helper.Replace(".", ",");
            }

            try
            {
                this.number = double.Parse(helper);
                isCorrect = true;
            }
            catch
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Beep();
                Console.WriteLine("Будьте добры, введите число.");
                isCorrect = false;
            }

            if (isCorrect)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                BusinessLogic.Zero = "ноль ";
                try
                {
                    Console.WriteLine(this.logic.GetWords(number.ToString(), "точка", "минус"));
                }
                catch (FormatException)
                {
                    Console.WriteLine("К-ство нолей после запятой не должно быть больше трех.");
                }
            }

            Console.ResetColor();
            Console.WriteLine("Нажми любую клавишу...");
            Console.ReadKey();
        }

        /// <summary>
        /// English menu
        /// </summary>
        /// <param name="menuHeader">string with caption</param>
        /// <param name="referencesFile"> txt file</param>
        private void PrintMenu(string menuHeader, string referencesFile)
        {
            UsersAction action;
            do
            {
                Console.SetCursorPosition(0, 0);
                Enum.TryParse(base.ShowMenu(menuHeader).ToString(), out action);
                Console.WriteLine();
                Console.ResetColor();

                switch (action)
                {
                    case UsersAction.Help:
                        Help helper = new Help();
                        Console.WriteLine(helper.References(referencesFile));
                        Console.ReadKey();
                        break;
                    case UsersAction.Program:
                        this.ToEnglish();
                        break;
                    case UsersAction.Back:
                        UI user = new UI();
                        Console.Clear();
                        user.ConsoleMenuPaint(user.X, "English words     ", "Russian words   ");
                        user.ColourMenu(user.X);
                        break;
                    case UsersAction.Quit:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }

                Console.Clear();
            }
            while (action != UsersAction.Quit);
        }

        /// <summary>
        /// Russian menu
        /// </summary>
        private void PrintRussianMenu()
        {
            UsersAction action;
            do
            {
                Console.SetCursorPosition(0, 0);
                Enum.TryParse(this.ShowMenu(" Добро пожаловать в программу перевода!").ToString(), out action);
                Console.WriteLine();
                Console.ResetColor();

                switch (action)
                {
                    case UsersAction.Help:
                        Help helper = new Help();
                        Console.WriteLine(helper.References(@"..\..\Files\RURef.txt"));
                        Console.ReadKey();
                        break;
                    case UsersAction.Program:
                        this.ToRussian();
                        break;
                    case UsersAction.Back:
                        UI user = new UI();
                        Console.Clear();
                        user.ConsoleMenuPaint(user.X, "English words     ", "Russian words   ");
                        user.ColourMenu(user.X);
                        break;
                    case UsersAction.Quit:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }

                Console.Clear();
            }
            while (action != UsersAction.Quit);
        }
    }
}
