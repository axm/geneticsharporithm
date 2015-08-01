using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
