using GeneticSharporithm.Core;
using GeneticSharporithm.Mutation;
using System;

namespace GeneticSharporithmProgram
{
    public class Mutator : IMutator<string>
    {
        public Chromosome<string> Mutate(Chromosome<string> chromosome)
        {
            var genes = chromosome.Genes;

            var random = new Random();

            var index = random.Next(0, genes.Length - 1);

            var min = 97;
            var max = 122;

            var newCharacter = (char)random.Next(min, max);

            var chars = genes.ToCharArray();
            chars[index] = newCharacter;

            return new Chromosome<string>(new string(chars));
        }
    }
}
