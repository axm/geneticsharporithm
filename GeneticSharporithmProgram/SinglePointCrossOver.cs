using GeneticSharporithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticSharporithmProgram
{
    public class SinglePointCrossOver : ICrossOver<string>
    {
        private readonly Random Random;
        private readonly IFitnessEvaluator<string> Evaluator;

        public SinglePointCrossOver(Random random, IFitnessEvaluator<string> evaluator)
        {
            Random = random;
            Evaluator = evaluator;
        }

        Chromosome<string> ICrossOver<string>.CrossOver(Chromosome<string> parent1, Chromosome<string> parent2)
        {
            var parent1Genes = parent1.Genes;
            var parent2Genes = parent2.Genes;

            var index = Random.Next(1, parent1.Genes.Length);

            var newChars = new char[parent1Genes.Length];

            for (int i = 0; i < newChars.Length; i++)
            {
                newChars[i] = i >= index ? parent2Genes[i] : parent1Genes[i];
            }

            var chromosome = new Chromosome<string>(new string(newChars));
            chromosome.Fitness = Evaluator.ComputeFitness(chromosome.Genes);

            return chromosome;
        }
    }
}
