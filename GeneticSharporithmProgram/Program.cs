using GeneticSharporithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticSharporithmProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // trying to make the word "abracadabra"

            var evaluator = new FitnessEvaluator("abracadabra");
            var random = new Random();
            var generator = new Generator(random);

            var population = new Population<string>(100, generator, evaluator);

            var fitnessDict = new Dictionary<Chromosome<string>, double>();

            var mutator = new Mutator();

            var crossOver = new SinglePointCrossOver(random);

            var geneticAlgorithm = new GeneticAlgorithmBuilder<string>()
                .SetPopulation(population)
                .SetFitnessEvaluator(evaluator)
                .SetGenerations(10000)
                .SetMutationRate(0.05)
                .SetMutator(mutator)
                .SetCrossOver(crossOver)
                .Build();

            geneticAlgorithm.Execute();

        }

        
    }
}
