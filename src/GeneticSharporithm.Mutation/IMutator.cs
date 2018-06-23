using GeneticSharporithm.Core;

namespace GeneticSharporithm.Mutation
{
    /// <summary>
    /// Interface for mutating a chromosome.
    /// </summary>
    public interface IMutator<T>
    {
        /// <summary>
        /// "Mutates" the given <paramref name="chromosome"/> to produce another chromosome.
        /// </summary>
        /// <param name="chromosome">A chromosome that should be mutated.</param>
        /// <returns>The result of mutation applied to the given <paramref name="chromosome"/>.</returns>
        Chromosome<T> Mutate(Chromosome<T> chromosome);
    }
}
