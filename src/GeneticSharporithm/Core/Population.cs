using GeneticSharporithm.Core;
using System;
using System.Collections.Generic;

namespace GeneticSharporithm
{
    [Obsolete("Use state instead")]
    public class Population<T> where T: class
    {
        // TODO: This should be hidden or read only
        public IList<Chromosome<T>> Chromosomes { get; set; } = new List<Chromosome<T>>();
        
        /// <summary>
        /// Represents how big this population should be.
        /// </summary>
        public readonly int TargetSize;

        /// <summary>
        /// Searches and returns the best chromosome of this population. The fitness
        /// of the chromosome is used to determine which one is the best. The bigger
        /// the fitness, the better the chromosome.
        /// </summary>
        /// <returns>The best chromosome of the population, by fitness.</returns>
        /// <remarks>
        /// This performs a linear search on the chromosome population, thus the
        /// complexity of this method is O(n) on the size of the population.
        /// </remarks>
        public Chromosome<T> Best
        {
            get
            {
                var max = Chromosomes[0];

                foreach (var c in Chromosomes)
                {
                    if (c.Fitness > max.Fitness)
                    {
                        max = c;
                    }
                }

                return max;
            }
        }

        public Population(int count, IPopulationGenerator<T> generator, IFitnessEvaluator<T> evaluator)
        {
            if (count <= 0)
            {
                throw new ArgumentException($"{nameof(count)} must be greater than 0. Actual: {count}.");
            }

            if (generator == null)
            {
                throw new System.ArgumentNullException(nameof(generator));
            }

            if (evaluator == null)
            {
                throw new System.ArgumentNullException(nameof(evaluator));
            }

            TargetSize = count;

            // TODO: This really shouldn't be here. We should instead pass the 
            // population
            for(var i = 0; i < count; i++)
            {
                var value = generator.Generate();
                var fitness = evaluator.ComputeFitness(value);
                var chromosome = new Chromosome<T>(value, fitness);

                Chromosomes.Add(chromosome);
            }
        }
    }
}
