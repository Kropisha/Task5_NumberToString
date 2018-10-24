// <copyright file="ReverseComparer.cs" company="My Company Name">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace NumberToString
{
    using System.Collections.Generic;

    /// <summary>
    /// This class for dictionary reversing
    /// </summary>
    public sealed class ReverseComparer : IComparer<int>
    {
        /// <summary>
        /// base value for comparing
        /// </summary>
        private readonly IComparer<int> original;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReverseComparer"/> class
        /// </summary>
        /// <param name="original">standard value</param>
        public ReverseComparer(IComparer<int> original)
        {
            // TODO: Validation
            this.original = original;
        }

        /// <summary>
        /// Compare values
        /// </summary>
        /// <param name="left">left value</param>
        /// <param name="right">right value</param>
        /// <returns>changing values</returns>
        public int Compare(int left, int right)
        {
            return this.original.Compare(right, left);
        }
    }
}
