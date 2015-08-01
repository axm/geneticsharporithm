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
        // TODO: This should be hidde or read only
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

        public Population(IList<Chromosome<T>> chromosomes)
        {
            Contract.Requires<ArgumentNullException>(chromosomes != null);

            Chromosomes = chromosomes;

            TargetSize = chromosomes.Count;
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

        public void Sort(IComparer<Chromosome<string>> comparer)
        {
            Contract.Requires<ArgumentNullException>(comparer != null);

            var list = (List<Chromosome<string>>)Chromosomes;

            list.Sort(comparer);
        }
    }
}
