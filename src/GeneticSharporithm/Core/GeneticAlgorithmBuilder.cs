using GeneticSharporithm.Core;
using GeneticSharporithm.Mutation;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace GeneticSharporithm
{
    public class GeneticAlgorithmBuilder<T> where T: class
    {
        public double MutationRate { get; private set; }

        public IMutator<T> Mutator { get; private set; }
        public ICrossOver<T> CrossOver { get; private set; }
        public IKiller<T> Killer { get; private set; }
        public State<T> Population { get; private set; }

        public GeneticAlgorithmBuilder<T> SetPopulation(IEnumerable<Chromosome<T>> population)
        {
            Population = State<T>.FromChromosomes(population);

            return this;
        }

        public GeneticAlgorithmBuilder<T> SetMutationRate(double mutationRate)
        {
            Contract.Requires<ArgumentOutOfRangeException>(mutationRate >= 0 && mutationRate <= 1, "Mutation rate must be in [0, 1]");

            MutationRate = mutationRate;

            return this;
        }

        public GeneticAlgorithmBuilder<T> SetMutator(IMutator<T> mutator)
        {
            if (mutator == null)
            {
                throw new System.ArgumentNullException(nameof(mutator));
            }

            Mutator = mutator;

            return this;
        }

        public GeneticAlgorithmBuilder<T> SetCrossOver(ICrossOver<T> crossOver)
        {
            if (crossOver == null)
            {
                throw new System.ArgumentNullException(nameof(crossOver));
            }

            CrossOver = crossOver;

            return this;
        }

        public GeneticAlgorithmBuilder<T> SetKiller(IKiller<T> killer)
        {
            if (killer == null)
            {
                throw new System.ArgumentNullException(nameof(killer));
            }

            Killer = killer;

            return this;
        }

        /// <summary>
        /// Creates an instance of <see cref="GeneticAlgorithm{V}"/>.
        /// </summary>
        /// <remarks>
        /// The following fields are mandatory: <see cref="GeneticAlgorithmBuilder{U}.Population"/>,
        /// <see cref="GeneticAlgorithmBuilder{U}.FitnessEvaluator"/>, <see cref="GeneticAlgorithmBuilder{U}.Killer"/>,
        /// <see cref="GeneticAlgorithmBuilder{U}.CrossOver"/>, <see cref="GeneticAlgorithmBuilder{U}.Selector"/>,
        /// <see cref="GeneticAlgorithmBuilder{U}.Solution"/>.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown when a mandatory component is missing.
        /// </exception>
        /// <returns>
        /// An instance of <see cref="GeneticAlgorithm{V}"/> that uses the given
        /// components. 
        /// </returns>
        public GeneticAlgorithm<T> Build()
        {
            if (!IsValid(out string message))
            {
                throw new InvalidOperationException(message);
            }

            return new GeneticAlgorithm<T>(this);
        }

        private bool IsValid(out string message)
        {
            message = null;

            if (Killer == null)
            {
                message = "Killer not set.";

                return false;
            }

            if (CrossOver == null)
            {
                message = "CrossOver not set.";

                return false;
            }

            return true;
        }
    }
}