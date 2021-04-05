using GeneticSharporithm.Core;
using System;

namespace GeneticSharporithm.Mutation
{
    /// <summary>
    /// Interface for mutating a chromosome.
    /// </summary>
    public interface IMutator<T> where T: class
    {
        State<T> Mutate(State<T> state);
    }
}
