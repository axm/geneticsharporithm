using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticSharporithm
{
    /// <summary>
    /// Interface for mutating a chromosome.
    /// </summary>
    public interface IMutate<T>
    {
        /// <summary>
        /// "Mutates" the given <paramref name="chromosome"/> to produce another chromosome.
        /// </summary>
        /// <param name="chromosome">A chromosome that should be mutated.</param>
        /// <returns>The result of mutation applied to the given <paramref name="chromosome"/>.</returns>
        Chromosome<T> Mutate(Chromosome<T> chromosome);
    }
}
