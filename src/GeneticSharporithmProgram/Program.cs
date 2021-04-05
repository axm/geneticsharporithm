using GeneticSharporithm;
using System;
using System.Collections.Immutable;

namespace GeneticSharporithmProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // trying to make the word "abracadabra"
            const string target = "dog";
            var evaluator = new FitnessEvaluator(target);
            var random = new Random();
            var generator = new Generator(random);

            const int Total = 100;

            var population = new Population<string>(Total, generator, evaluator);

            var mutator = new Mutator(state =>
            {
                var count = state.Chromosomes.Length / 20;
                return count > 0 ? count : 1;
            }, evaluator);

            var crossOver = new SinglePointCrossOver(random, evaluator,
                state =>
                {
                    return state.Chromosomes.Length / 10;
                });

            var selector = new UniqueChromosomeSelector(evaluator, 10, Total);

            var killer = new ChromosomeKiller(state =>
            {
                if (state.Chromosomes.Length < 5)
                {
                    return 0;
                }

                return state.Chromosomes.Length / 5;
            });

            var solution = new Solution();

            var geneticAlgorithm = new GeneticAlgorithmBuilder<string>()
                .SetPopulation(population.Chromosomes)
                .SetMutationRate(0.05)
                .SetMutator(mutator)
                .SetCrossOver(crossOver)
                .SetKiller(killer)
                .Build();

            for (var i = 0; i < 9999; i++)
            {
                var state = geneticAlgorithm.Step();
                if (state.Best.Genes == target)
                {
                    Console.WriteLine("success!");
                }
            }
        }
    }
}
