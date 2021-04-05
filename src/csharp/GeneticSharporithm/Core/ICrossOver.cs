using GeneticSharporithm.Core;
using System;

namespace GeneticSharporithm
{
    /// <summary>
    /// Interface for crossing over chromosomes.
    /// </summary>
    public interface ICrossOver<T> where T: class
    {
        State<T> CrossOver(in State<T> state);
    }
}
