using GeneticSharporithm;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticSharporithmProgram
{
    public class ChromosomeKiller : IKiller<string>
    {
        public readonly int Count;

        public ChromosomeKiller(int count)
        {
            Contract.Requires<ArgumentOutOfRangeException>(count > 0);

            Count = count;
        }

        public void Kill(Population<string> population)
        {
            Contract.Requires<ArgumentNullException>(population != null);

            var chromosomes = population.Chromosomes_RO;

            var i = 0;

            while (i++ < Count)
            {
                population.RemoveChromosome(population.Chromosomes_RO.Last());
            }
        }
    }
}
