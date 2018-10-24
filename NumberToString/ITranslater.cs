// <copyright file="ITranslater.cs" company="My Company Name">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace NumberToString
{
    using System.Collections.Generic;

    /// <summary>
    /// Set the  obvious interface for every language
    /// </summary>
   internal interface ITranslater
    {
        /// <summary>
        /// For writing number by words
        /// </summary>
        /// <param name="number">current integer value</param>
        /// <returns>integer value by words</returns>
        string TransformToWords(int number);

        /// <summary>
        /// Initialize tens
        /// </summary>
        /// <returns>dictionary with values</returns>
        Dictionary<int, string> DefineTens();

        /// <summary>
        /// Initialize units
        /// </summary>
        /// <returns>dictionary with values</returns>
        Dictionary<int, string> DefineUnits();

        /// <summary>
        /// Initialize power of 10
        /// </summary>
        /// <returns>list with values</returns>
        List<string> ListInitialazier();
    }
}
