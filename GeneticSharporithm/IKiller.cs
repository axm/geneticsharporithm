using System.Collections.Generic;

namespace GeneticSharporithm
{
    /// <summary>
    /// Interface for killing the weakest offspring.
    /// </summary>
    public interface IKiller<T>
    {
        void Kill(Population<T> chromosomes);
    }
}