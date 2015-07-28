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
        public IList<Chromosome<T>> Chromosomes { get; set; } = new List<Chromosome<T>>();
        public readonly int TargetSize;
        private IFitnessEvaluator<T> Evaluator { get; set; }

        public Population(int count, IPopulationGenerator<T> generator, IFitnessEvaluator<T> evaluator)
        {
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
            var list = (List<Chromosome<string>>)Chromosomes;

            list.Sort(comparer);
        }
    }
}
