using GeneticSharporithm.Core;
using System;
using System.Collections.Generic;

namespace GeneticSharporithm.Selection
{
    /// <summary>
    /// Represents the selection step of a genetic algorithm.
    /// </summary>
    public interface ISelection<T> where T: class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="chromosomes"></param>
        /// <returns>An enumeration of chromosome pairs.</returns>
        /// <remarks>
        /// <paramref name="chromosomes"/> must have at least one element.
        /// </remarks>
        IEnumerable<Tuple<Chromosome<T>, Chromosome<T>>> Select(IList<Chromosome<T>> chromosomes);
    }
}
