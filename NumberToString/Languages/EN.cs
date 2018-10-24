// <copyright file="EN.cs" company="My Company Name">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace NumberToString
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Implementation for english language
    /// </summary>
    public class EN : ITranslater
    {
        /// <summary>
        /// Initialize tens
        /// </summary>
        /// <returns>dictionary with values</returns>
        public Dictionary<int, string> DefineTens()
        {
            return new Dictionary<int, string>
            {
                { 0, "zero" },
                { 10, "ten" },
                { 20, "twenty" },
                { 30, "thirty" },
                { 40, "forty" },
                { 50, "fifty" },
                { 60, "sixty" },
                { 70, "seventy" },
                { 80, "eighty" },
                { 90, "ninety" }
            };
        }

        /// <summary>
        /// Initialize units
        /// </summary>
        /// <returns>dictionary with values</returns>
        public Dictionary<int, string> DefineUnits()
        {
            Dictionary<int, string> units = new Dictionary<int, string>();

            units.Add(0, "zero");
            units.Add(1, "one");
            units.Add(2, "two");
            units.Add(3, "three");
            units.Add(4, "four");
            units.Add(5, "five");
            units.Add(6, "six");
            units.Add(7, "seven");
            units.Add(8, "eight");
            units.Add(9, "nine");
            units.Add(10, "ten");
            units.Add(11, "eleven");
            units.Add(12, "twelve");
            units.Add(13, "thirteen");
            units.Add(14, "fourteen");
            units.Add(15, "fifteen");
            units.Add(16, "sixteen");
            units.Add(17, "seventeen");
            units.Add(18, "eighteen");
            units.Add(19, "nineteen");
            return units;
        }

        /// <summary>
        /// Initialize power of 10
        /// </summary>
        /// <returns>list with values</returns>
        public List<string> ListInitialazier()
        {
            List<string> list = new List<string>();
            list.Add("hundred");
            list.Add("thousand");
            list.Add("million");
            return list;
        }

        /// <summary>
        /// For writing number by words
        /// </summary>
        /// <param name="number">current integer value</param>
        /// <returns>integer value by words</returns>
        public string TransformToWords(int number)
        {
            string and = "and ";
            StringBuilder words = new StringBuilder();
            Dictionary<int, string> unitsMap = this.DefineUnits();
            Dictionary<int, string> tensMap = this.DefineTens();
            BusinessLogic bl = new BusinessLogic();
            SortedDictionary<int, string> dict = bl.InitializeDictionary();

            if (number < 0)
            {
                number = Math.Abs(number);
            }

            if (number == 0)
            {
                words.Append(BusinessLogic.Zero);
            }

            if (number.ToString().StartsWith("0") && number != 0)
            {
                words.Append(BusinessLogic.Zero);
                number *= 10;
            }

            foreach (var k in dict)
            {
                if ((number / k.Key) > 0)
                {
                    words.Append(this.TransformToWords(number / k.Key) + " " + k.Value + " ");
                    number %= k.Key;
                    if ((number / 10) > 0 && (number / 10) < 10)
                    {
                        if (!words.Equals(" "))
                        {
                            words.Append(and);
                        }
                    }
                }
            }

            if (number > 0)
            {
                if (number < 20)
                {
                    foreach (var w in unitsMap)
                    {
                        if (w.Key == number)
                        {
                            words.Append(w.Value);
                        }
                    }
                }
                else
                {
                    foreach (var t in tensMap)
                    {
                        if (t.Key == number - (number % 10))
                        {
                            words.Append(t.Value);
                        }
                    }

                    foreach (var w in unitsMap)
                    {
                        if ((number % 10) > 0)
                        {
                            if (w.Key == (number % 10))
                            {
                                words.Append("-" + w.Value); // hyphen
                            }
                        }
                    }
                }
            }

            return words.ToString();
        }
    }
}
