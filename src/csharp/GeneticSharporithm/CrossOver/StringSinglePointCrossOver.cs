using GeneticSharporithm.Core;
using System;

namespace GeneticSharporithm.CrossOvers
{
    public sealed class StringSinglePointCrossOver : ICrossOver<string>
    {
        private readonly Random Random;
        private readonly IFitnessEvaluator<string> Evaluator;

        public StringSinglePointCrossOver(Random random, IFitnessEvaluator<string> evaluator)
        {
            if(random == null)
            {
                throw new ArgumentNullException($"{nameof(random)}");
            }

            if (evaluator == null)
            {
                throw new ArgumentNullException($"{nameof(evaluator)}");
            }

            Random = random;
            Evaluator = evaluator;
        }

        private Chromosome<string> CrossOver(in Chromosome<string> parent1, in Chromosome<string> parent2)
        {

            if(parent1.Genes.Length != parent2.Genes.Length)
            {
                throw new ArgumentException("The parents have different gene lengths.");
            }

            var parent1Genes = parent1.Genes;
            var parent2Genes = parent2.Genes;

            var index = Random.Next(0, parent1.Genes.Length);

            var newChars = new char[parent1Genes.Length];

            for (int i = 0; i < newChars.Length; i++)
            {
                newChars[i] = i >= index ? parent2Genes[i] : parent1Genes[i];
            }

            var genes = new string(newChars);
            return new Chromosome<string>(genes, Evaluator.ComputeFitness(genes));
        }

        public State<string> CrossOver(in State<string> state)
        {
            throw new NotImplementedException();
        }
    }
}
