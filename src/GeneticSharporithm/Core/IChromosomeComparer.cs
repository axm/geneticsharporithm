using GeneticSharporithm.Core;

namespace GeneticSharporithm
{
    public interface IChromosomeComparer<T> where T: class
    {
        /// <summary>
        /// Compares the two given chromosomes and returns a number that signifies
        /// their order.
        /// </summary>
        /// <returns>
        /// A negative number if <paramref name="chromosome1"/> is "smaller"
        /// that <paramref name="chromosome2"/>, 0 if they are equal and a positive
        /// number otherwise.
        /// </returns>
        int Compare(Chromosome<T> chromosome1, Chromosome<T> chromosome2);
    }
}
