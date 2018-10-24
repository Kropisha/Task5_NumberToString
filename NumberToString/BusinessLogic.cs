// <copyright file="BusinessLogic.cs" company="My Company Name">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace NumberToString
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This class for logic of my program
    /// </summary>
    public class BusinessLogic
    { 
        /// <summary>
        /// Gets or sets language
        /// </summary>
        public static ChooseLanguage Language { get; set; }

        public static string Zero { get; set; }

        /// <summary>
        /// For initialization and sorting dictionary
        /// </summary>
        /// <returns>Sorted dictionary</returns>
        public SortedDictionary<int, string> InitializeDictionary()
        {
            List<string> list = null;
            ITranslater language = this.GetTranslator(Language);
            list = language.ListInitialazier();
            SortedDictionary<int, string> dict = new SortedDictionary<int, string>();
            
            dict = new SortedDictionary<int, string>(
            new ReverseComparer(Comparer<int>.Default));
            int i = 1;
            for (int k = 0; k < list.Count; k++)
            {   
                i = i * 1000;
                if (k == 0)
                {
                    i = 100;
                }

                if (k == 1)
                {
                    i = 1000;
                }

                dict.Add(i, list[k]);               
            }
          
            return dict;
        }      

        /// <summary>
        /// For getting words value of number
        /// </summary>
        /// <param name="numb">get number</param>
        /// <param name="point">point value</param>
        /// <param name="minus">minus value</param>
        /// <returns>words values</returns>
        public string GetWords(string numb, string point, string minus)
        {
            string result = " ", sign = " ", wholeNo = numb, points = " ", andStr = " ";
     
            int decimalPlace = numb.IndexOf(",");

            if (decimalPlace > 0)
            {
                wholeNo = numb.Substring(0, decimalPlace);
                points = numb.Substring(decimalPlace + 1);
                if (Convert.ToDouble(points) > 0)
                {
                    andStr = point; // to separate whole numbers from points
                }
            }

            string zeros = " ";
            while (points.StartsWith("0") && int.Parse(points) != 0)
            {
                    zeros += Zero;
                    points = points.Remove(0, 1);
            }
            
            if (double.Parse(numb) == 0.0)
            {
                result = Zero;
                return result;
            }

            if (double.Parse(numb) < 0)
            {
                sign = minus;
            }

            ITranslater language = this.GetTranslator(Language);
            try
            {
                if (double.Parse(numb) > 999999999)
                {
                    throw new ArgumentException("Only to a billion!");
                }

                if (points != " ")
                {
                    result = string.Format("{0} {1} {2}{3}",
                             sign,
                             language.TransformToWords(int.Parse(wholeNo)).Trim(),
                             andStr, 
                             zeros + language.TransformToWords(int.Parse(points)));
                }
                else
                {
                    result = string.Format("{0} {1}", sign, language.TransformToWords(int.Parse(wholeNo)).Trim());
                }            
            }
            catch (ArgumentException ex) 
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Set current language
        /// </summary>
        /// <param name="lang">get enum parameter for language</param>
        /// <returns>class instance</returns>
        private ITranslater GetTranslator(ChooseLanguage lang)
        {
            ITranslater translator = null;
            
            switch (lang)
            {
                case ChooseLanguage.English:
                    translator = new EN();
                    break;
                case ChooseLanguage.Russian:
                    translator = new Ru();
                    break;
                default:
                    break;
            }

            return translator;
        }
    }
}
