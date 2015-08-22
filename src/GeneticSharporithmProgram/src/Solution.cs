using GeneticSharporithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticSharporithmProgram
{
    public class Solution : ISolution<string>
    {
        public bool IsSolution(Chromosome<string> chromosome)
        {
            return chromosome.Genes == "abracadabra";
        }
    }
}
