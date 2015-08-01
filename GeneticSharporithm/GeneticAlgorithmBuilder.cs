using System;
using System.Diagnostics.Contracts;

namespace GeneticSharporithm
{
    public class GeneticAlgorithmBuilder<U>
    {
        public int Generations { get; private set; }
        public double MutationRate { get; private set; }

        public Population<U> Population { get; private set; }
        public IMutate<U> Mutator { get; private set; }
        public ICrossOver<U> CrossOver { get; private set; }
        public IFitnessEvaluator<U> FitnessEvaluator { get; private set; }
        public IKiller<U> Killer { get; private set; }
        public ISelection<U> Selector { get; private set; }
        public ISolution<U> Solution { get; private set; }

        public GeneticAlgorithmBuilder<U> SetPopulation(Population<U> population)
        {
            Contract.Requires<ArgumentNullException>(population != null, "Argument cannot be null.");

            Population = population;

            return this;
        }

        public GeneticAlgorithmBuilder<U> SetGenerations(int generations)
        {
            Contract.Requires<ArgumentOutOfRangeException>(generations > 0, "Number of generations cannot be zero or negative.");

            Generations = generations;

            return this;
        }

        public GeneticAlgorithmBuilder<U> SetMutationRate(double mutationRate)
        {
            Contract.Requires<ArgumentOutOfRangeException>(mutationRate >= 0 && mutationRate <= 1, "Mutation rate must be in [0, 1]");

            MutationRate = mutationRate;

            return this;
        }

        public GeneticAlgorithmBuilder<U> SetMutator(IMutate<U> mutator)
        {
            Contract.Requires<ArgumentNullException>(mutator != null, "Argument cannot be null.");

            Mutator = mutator;

            return this;
        }

        public GeneticAlgorithmBuilder<U> SetCrossOver(ICrossOver<U> crossOver)
        {
            Contract.Requires<ArgumentNullException>(crossOver != null, "Argument cannot be null.");

            CrossOver = crossOver;

            return this;
        }

        public GeneticAlgorithmBuilder<U> SetFitnessEvaluator(IFitnessEvaluator<U> fitnessEvaluator)
        {
            Contract.Requires<ArgumentNullException>(fitnessEvaluator != null, "Argument cannot be null.");

            FitnessEvaluator = fitnessEvaluator;

            return this;
        }
        
        public GeneticAlgorithmBuilder<U> SetSelection(ISelection<U> selection)
        {
            Selector = selection;

            return this;
        }

        public GeneticAlgorithmBuilder<U> SetKiller(IKiller<U> killer)
        {
            Contract.Requires<ArgumentNullException>(killer != null, "Killer cannot be null.");

            Killer = killer;

            return this;
        }

        public GeneticAlgorithmBuilder<U> SetSolution(ISolution<U> solution)
        {
            Solution = solution;

            return this;
        }

        public GeneticAlgorithm<U> Build()
        {
            string message;

            if (!IsValid(out message))
            {
                throw new InvalidOperationException(message);
            }

            return new GeneticAlgorithm<U>(this);
        }

        private bool IsValid(out string message)
        {
            message = null;

            if(Population == null)
            {
                message = "Population not set.";

                return false;
            }

            if (Generations <= 0)
            {
                message = "Generations count must be positive";

                return false;
            }
            
            if(FitnessEvaluator == null)
            {
                message = "Fitness evaluator not set.";

                return false;
            }

            if (Killer == null)
            {
                message = "Killer not set.";

                return false;
            }

            if(CrossOver == null)
            {
                message = "CrossOver not set.";

                return false;
            }

            if(Selector == null)
            {
                message = "Selection not set.";

                return false;
            }

            if(Solution == null)
            {
                message = "Solution not set.";

                return false;
            }

            return true;
        }
    }
}