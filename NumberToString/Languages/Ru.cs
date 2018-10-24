// <copyright file="Ru.cs" company="My Company Name">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace NumberToString
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Implementation for russian language
    /// </summary>
    public class Ru : ITranslater
    {
        /// <summary>
        /// Initialize tens
        /// </summary>
        /// <returns>dictionary with values</returns>
        public Dictionary<int, string> DefineTens()
        {
            return new Dictionary<int, string>
            {
                { 0, "ноль" },
                { 10, "десять" },
                { 20, "двадцать" },
                { 30, "тридцать" },
                { 40, "сорок" },
                { 50, "пятьдесят" },
                { 60, "шестьдесят" },
                { 70, "семьдесят" },
                { 80, "восемьдесят" },
                { 90, "девяносто" }
            };
        }

        /// <summary>
        /// Initialize units
        /// </summary>
        /// <returns>dictionary with values</returns>
        public Dictionary<int, string> DefineUnits()
        {
            Dictionary<int, string> units = new Dictionary<int, string>();

            units.Add(0, "ноль");
            units.Add(1, "один");
            units.Add(2, "два");
            units.Add(3, "три");
            units.Add(4, "четыре");
            units.Add(5, "пять");
            units.Add(6, "шесть");
            units.Add(7, "семь");
            units.Add(8, "восемь");
            units.Add(9, "девять");
            units.Add(10, "десять");
            units.Add(11, "одинадцать");
            units.Add(12, "двенадцать");
            units.Add(13, "тринадцать");
            units.Add(14, "четырнадцать");
            units.Add(15, "пятнадцать");
            units.Add(16, "шестнадцать");
            units.Add(17, "семнадцать");
            units.Add(18, "восемнадцать");
            units.Add(19, "девятнадцать");
            return units;
        }

        /// <summary>
        /// Initialize hundreds
        /// </summary>
        /// <returns>dictionary with values</returns>
        public Dictionary<int, string> DefineHundreds()
        {
            return new Dictionary<int, string>
            {
                { 100, "сто" },
                { 200, "двести" },
                { 300, "триста" },
                { 400, "четыреста" },
                { 500, "пятьсот" },
                { 600, "шестьсот" },
                { 700, "семьсот" },
                { 800, "восемьсот" },
                { 900, "девятьсот" }
            };
        }

        /// <summary>
        /// Initialize power of 10
        /// </summary>
        /// <returns>list with values</returns>
        public List<string> ListInitialazier()
        {
            List<string> list = new List<string>();
            list.Add("сто");
            list.Add("тысяча");
            list.Add("миллион");
            return list;
        }

        /// <summary>
        /// For writing number by words
        /// </summary>
        /// <param name="number">current integer value</param>
        /// <returns>integer value by words</returns>
        public string TransformToWords(int number)
        {
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
           
            foreach (var k in dict)
            {
                if ((number / k.Key) > 0)
                {
                    if (k.Key == 1000000)
                    {
                        if ((number / k.Key) % 10 > 1 && (number / k.Key) % 10 < 5 
                            && !(((number / k.Key) % 100 > 5) && ((number / k.Key) % 100 < 20)))
                        {
                            words.Append(this.TransformToWords(number / k.Key) + " " + "миллиона ");
                            number %= k.Key;
                            continue;
                        }

                        if ((number / k.Key) % 10 == 1 && (number / k.Key) % 100 != 11)
                        {
                            words.Append(this.TransformToWords(number / k.Key) + " " + k.Value + " ");
                            number %= k.Key;
                            continue;
                        }
                        else 
                        {
                            words.Append(this.TransformToWords(number / k.Key) + " " + "миллионов ");
                            number %= k.Key;
                        }
                        
                        continue;
                    }

                    if (k.Key == 1000)
                    {
                        if ((number / k.Key) % 10 == 1 && (number / k.Key) % 100 != 11)
                        {
                            words.Append(this.TransformToWords((number / k.Key) - 1) + " одна" + " " + k.Value + " ");
                            number %= k.Key;
                            continue;
                        }

                        if ((number / k.Key) % 10 == 2 && (number / k.Key) % 100 != 12)
                        {
                            words.Append(this.TransformToWords((number / k.Key) - 2) + " две" + " " + "тысячи ");
                            number %= k.Key;
                            continue;
                        }

                        if (((number / k.Key) % 10 > 1 && (number / k.Key) % 10 < 5) &&
                            !((number / k.Key) % 100 > 10 && (number / k.Key) % 100 < 20))
                        {
                            words.Append(this.TransformToWords(number / k.Key) + " " + "тысячи ");
                            number %= k.Key;
                            continue;
                        }
                        else 
                        {
                            words.Append(this.TransformToWords(number / k.Key) + " " + "тысяч ");
                            number %= k.Key;
                        }

                        continue;
                    }

                    if (k.Key == 100)
                    {
                        var helper = this.DefineHundreds();
                        foreach (var h in helper)
                        {
                            if ((number / k.Key) * 100 == h.Key)
                            {
                                words.Append(h.Value + " ");
                                number %= k.Key;
                                break;
                            }
                        }

                        break;
                    }
                   
                    words.Append(this.TransformToWords(number / k.Key) + " " + k.Value + " ");
                    number %= k.Key;
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
                            break;
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
                            break;
                        }
                    }

                    foreach (var w in unitsMap)
                    {
                        if ((number % 10) > 0)
                        {
                            if (w.Key == (number % 10))
                            {
                                words.Append(" " + w.Value); // -
                                break;
                            }
                        }
                    }
                }
            }

            return words.ToString();
        }
    }
}
