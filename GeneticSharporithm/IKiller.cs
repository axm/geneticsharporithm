using System.Collections.Generic;

namespace GeneticSharporithm
{
    /// <summary>
    /// Interface for killing the weakest offspring.
    /// </summary>
    public interface IKiller<T>
    {
        void Kill(ICollection<Chromosome<T>> chromosomes);
    }
}