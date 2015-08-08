using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticSharporithm
{
    /// <summary>
    /// Represents the selection step of a genetic algorithm.
    /// </summary>
    public interface ISelection<V>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="chromosomes"></param>
        /// <returns></returns>
        /// <remarks>
        /// <paramref name="chromosomes"/> must have at least one element.
        /// </remarks>
        IEnumerable<Tuple<Chromosome<V>, Chromosome<V>>> Select(IList<Chromosome<V>> chromosomes);
    }
}
