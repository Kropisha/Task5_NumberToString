// <copyright file="Program.cs" company="My Company Name">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace NumberToString
{
    using System;

    /// <summary>
    /// This class is for User Interface
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point to the program
        /// </summary>
        /// <param name="args">Args of command line</param>
        internal static void Main(string[] args)
        {
            Console.Title = "Number to words [Kropyvna Yuliia]";
            UI user = new UI();
            user.ConsoleMenuPaint(user.X, "English words     ", "Russian words   ");
            user.ColourMenu(user.X);
        }
    }
}
