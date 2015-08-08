using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticSharporithm
{
    /// <summary>
    /// Used to generate random strings of a given length.
    /// 
    /// This class cannot be inherited.
    /// </summary>
    public sealed class StringGenerator : IPopulationGenerator<string>
    {
        public readonly int Length;

        /// <summary>
        /// Initializes a new instance of the <see cref="StringGenerator"/> class
        /// using the specified length for the generated strings.
        /// </summary>
        /// <param name="length">
        /// The length of the strings to be generated with
        /// this generator.
        /// </param>
        /// <remarks>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if length is zero or negative.
        /// </remarks>
        public StringGenerator(int length)
        {
            Contract.Requires<ArgumentOutOfRangeException>(length > 0);

            Length = length;
        }
        
        public string Generate()
        {
            throw new NotImplementedException();
        }
    }
}
