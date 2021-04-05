using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace GeneticSharporithm.Core
{
    public struct State<T> where T: class
    {
        private ImmutableArray<Chromosome<T>>? _chromosomes { get; set; }
        public ImmutableArray<Chromosome<T>> Chromosomes
        { 
            get
            {
                if (_chromosomes == null)
                {
                    _chromosomes = ImmutableArray.Create<Chromosome<T>>();
                }

                return _chromosomes.Value;
            }
        }

        public bool HasChromosomes => Chromosomes.Any();

        public Chromosome<T> Best
        {
            get
            {
                if (!Chromosomes.Any())
                {
                    throw new InvalidOperationException("No chromosomes exist for this state.");
                }

                return Chromosomes.First();
            }
        }

        private State(IEnumerable<Chromosome<T>> chromosomes)
        {
            if (chromosomes == null)
            {
                throw new ArgumentNullException(nameof(chromosomes));
            }

            chromosomes = chromosomes.OrderByDescending(c => c.Fitness);
            _chromosomes = ImmutableArray.ToImmutableArray(chromosomes);
        }

        public State<T> AddChromosome(Chromosome<T> chromosome)
        {
            var newChromosomes = Chromosomes.Add(chromosome).OrderByDescending(c => c.Fitness);

            return new State<T>(newChromosomes);
        }

        public static State<T> FromChromosomes<T>(IEnumerable<Chromosome<T>> chromosomes) where T: class => new State<T>(chromosomes);
    }
}
