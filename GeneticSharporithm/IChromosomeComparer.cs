using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticSharporithm
{
    public interface IChromosomeComparer<T>
    {
        int Compare(Chromosome<T> chromosome1, Chromosome<T> chromosome2);
    }
}
