using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticSharporithm
{
    public class Population<T>
    {
        // TODO: This should be hidden or read only
        public IList<Chromosome<T>> Chromosomes { get; set; } = new List<Chromosome<T>>();
        public readonly int TargetSize;
        private IFitnessEvaluator<T> Evaluator { get; set; }

        public int ChromosomeCount
        {
            get
            {
                return Chromosomes.Count;
            }
        }

        public IReadOnlyList<Chromosome<T>> Chromosomes_RO
        {
            get
            {
                return new ReadOnlyCollection<Chromosome<T>>(Chromosomes);
            }
        }

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
            Contract.Requires<ArgumentOutOfRangeException>(count > 0);
            Contract.Requires<ArgumentNullException>(generator != null);
            Contract.Requires<ArgumentNullException>(evaluator != null);

            TargetSize = count;
            Evaluator = evaluator;

            for(var i = 0; i < count; i++)
            {
                var value = generator.Generate();
                var chromosome = new Chromosome<T>(value);
                chromosome.Fitness = evaluator.ComputeFitness(chromosome.Genes);

                Chromosomes.Add(chromosome);
            }
        }

        public void AddChromosome(Chromosome<T> chromosome)
        {
            Contract.Requires<ArgumentNullException>(chromosome != null, "Chromosome cannot be null.");

            Chromosomes.Add(chromosome);
        }

        public void RemoveChromosome(Chromosome<T> chromosome)
        {
            Contract.Requires<ArgumentNullException>(chromosome != null, "Chromosome cannot be null.");

            Chromosomes.Remove(chromosome);
        }
    }
}
