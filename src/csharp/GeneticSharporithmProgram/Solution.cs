using GeneticSharporithm;
using GeneticSharporithm.Core;

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
