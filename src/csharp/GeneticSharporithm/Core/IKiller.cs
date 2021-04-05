using GeneticSharporithm.Core;
using System;

namespace GeneticSharporithm
{
    /// <summary>
    /// Interface for killing the weakest offspring.
    /// </summary>
    public interface IKiller<T> where T: class
    {
        State<T> Kill(State<T> state);
    }
}