using GeneticSharporithm;
using GeneticSharporithm.Core;
using GeneticSharporithm.Mutation;
using System;
using System.Collections.Generic;

namespace GeneticSharporithmProgram
{
    public class Mutator : IMutator<string>
    {
        private Random Random = new Random();
        private readonly Func<State<string>, int> MutatorCount;
        private readonly IFitnessEvaluator<string> Evaluator;

        public Mutator(Func<State<string>, int> mutatorCount, IFitnessEvaluator<string> evaluator)
        {
            if (mutatorCount == null)
            {
                throw new ArgumentNullException(nameof(mutatorCount));
            }

            if (evaluator == null)
            {
                throw new System.ArgumentNullException(nameof(evaluator));
            }

            MutatorCount = mutatorCount;
            Evaluator = evaluator;
        }

        private  Chromosome<string> Mutate(Chromosome<string> chromosome)
        {
            var genes = chromosome.Genes;

            var random = new Random();

            var index = random.Next(0, genes.Length - 1);

            var min = 97;
            var max = 122;

            var newCharacter = (char)random.Next(min, max);

            var chars = genes.ToCharArray();
            chars[index] = newCharacter;

            var newGenes = new string(chars);
            return new Chromosome<string>(new string(chars), Evaluator.ComputeFitness(newGenes));
        }

        public State<string> Mutate(State<string> state) // TODO in?
        {
            var cutoff = Random.NextDouble();

            var maxCount = MutatorCount.Invoke(state);
            if (maxCount == 0)
            {
                return state;
            }

            var selected = new bool[state.Chromosomes.Length];
            var count = 0;
            var chromosomes = new List<Chromosome<string>>();

            while (count < maxCount)
            {
                var index = Random.Next(0, state.Chromosomes.Length - 1);
                if (selected[index])
                {
                    continue;
                }

                selected[index] = true;
                count++;

                var chromosome = state.Chromosomes[index];
                chromosomes.Remove(chromosome);
                state = state.AddChromosome(Mutate(chromosome));
            }

            return state;
        }

        Chromosome<string> IMutator<string>.Mutate(Chromosome<string> chromosome)
        {
            throw new NotImplementedException();
        }
    }
}
