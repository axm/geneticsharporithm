using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticSharporithm
{
    public interface ICrossOver<T>
    {
        Chromosome<T> CrossOver(Chromosome<T> parent1, Chromosome<T> parent2);
    }
}
