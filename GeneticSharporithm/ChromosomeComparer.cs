using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace GeneticSharporithm
{
    public class ChromosomeComparer<V> : IComparer<Chromosome<V>>
    {
        public int Compare(Chromosome<V> x, Chromosome<V> y)
        {
            Contract.Requires<ArgumentNullException>(x != null, $"First parameter cannot be null.");
            Contract.Requires<ArgumentNullException>(y != null, $"Second parameter cannot be null.");

            if(x.Fitness == y.Fitness)
            {
                return 0;
            }

            return x.Fitness > y.Fitness ? -1 : 1;
        }
    }
}