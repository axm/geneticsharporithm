using GeneticSharporithm.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticSharporithm
{
    /// <summary>
    /// Interface for crossing over chromosomes.
    /// </summary>
    public interface ICrossOver<T>
    {
        /// <summary>
        /// Performs a crossover on the given chromosomes.
        /// </summary>
        /// <returns>The result of the crossover of the two given chromosomes.</returns>
        Chromosome<T> CrossOver(Chromosome<T> parent1, Chromosome<T> parent2);
    }
}
