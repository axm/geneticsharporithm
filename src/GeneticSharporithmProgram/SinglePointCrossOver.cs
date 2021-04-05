using GeneticSharporithm;
using GeneticSharporithm.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticSharporithmProgram
{
    public sealed class SinglePointCrossOver : ICrossOver<string>
    {
        private readonly Random Random;
        private readonly IFitnessEvaluator<string> Evaluator;
        private readonly Func<State<string>, int> CrossOverCount;

        public SinglePointCrossOver(Random random, IFitnessEvaluator<string> evaluator, Func<State<string>, int> crossOverCount)
        {
            Random = random;
            Evaluator = evaluator;
            CrossOverCount = crossOverCount;
        }

        public State<string> CrossOver(in State<string> state)
        {
            var maxCount = CrossOverCount.Invoke(state);
            if (maxCount == 0)
            {
                return state;
            }
            maxCount = maxCount % 2 == 0 ? maxCount : maxCount + 1;

            var selected = new bool[state.Chromosomes.Length];
            var count = 0;

            var parents = new Stack<Chromosome<string>>();
            var updatedState = state;

            while (count < maxCount)
            {
                var index = Random.Next(0, state.Chromosomes.Length - 1);
                if (selected[index])
                {
                    continue;
                }

                selected[index] = true;
                count++;

                if (!parents.Any())
                {
                    parents.Push(state.Chromosomes[index]);
                    continue;
                }

                var child = CrossOver(state.Chromosomes[index], parents.Pop());
                updatedState = updatedState.AddChromosome(child);
            }

            return updatedState;
        }

        private Chromosome<string> CrossOver(in Chromosome<string> parent1, in Chromosome<string> parent2)
        {
            var parent1Genes = parent1.Genes;
            var parent2Genes = parent2.Genes;

            var index = Random.Next(0, parent1.Genes.Length);

            var newChars = new char[parent1Genes.Length];

            for (int i = 0; i < newChars.Length; i++)
            {
                newChars[i] = i >= index ? parent2Genes[i] : parent1Genes[i];
            }

            var genes = new string(newChars);
            return new Chromosome<string>(new string(newChars), Evaluator.ComputeFitness(genes));
        }
    }
}
