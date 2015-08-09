using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace GeneticSharporithm
{
    public delegate void GeneticEventWithGeneticEventArgs<V>(GeneticAlgorithm<V> sender, GeneticEventArgs e);
    public delegate void GeneticEvent<V>(GeneticAlgorithm<V> sender, EventArgs e);

    public class GeneticAlgorithm<V>
    {
        public int Generations { get; private set; }
        public Population<V> Population { get; private set; }
        public IFitnessEvaluator<V> Evaluator { get; private set; }
        public IMutate<V> Mutator { get; private set; }
        public ICrossOver<V> CrossOver { get; private set; }
        public ISelection<V> Selector { get; private set; }
        public IKiller<V> Killer { get; private set; }
        public ISolution<V> Solution { get; private set; }
        public double MutationRate { get; private set; }
        private Random Random = new Random();

        /// <summary>
        /// Executed before each generation run.
        /// </summary>
        public event GeneticEventWithGeneticEventArgs<V> BeforeRun;

        /// <summary>
        /// Executed after each generation run.
        /// </summary>
        public event GeneticEventWithGeneticEventArgs<V> AfterRun;
        public event GeneticEvent<V> BeforeKill;
        public event GeneticEvent<V> AfterKill;
        public event GeneticEvent<V> BeforeMutate;
        public event GeneticEvent<V> AfterMutate;
        public event GeneticEvent<V> BeforeCrossOver;
        public event GeneticEvent<V> AfterCrossOver;
        public event GeneticEvent<V> BeforeSelection;
        public event GeneticEvent<V> AfterSelection;
        public event GeneticEvent<V> OnSolution;

        internal GeneticAlgorithm(GeneticAlgorithmBuilder<V> builder)
        {
            Generations = builder.Generations;
            Population = builder.Population;
            Evaluator = builder.FitnessEvaluator;
            MutationRate = builder.MutationRate;
            Mutator = builder.Mutator;
            CrossOver = builder.CrossOver;
            Selector = builder.Selector;
            Killer = builder.Killer;
            Solution = builder.Solution;
        }

        public void Execute()
        {
            for (int i = 0; i < Generations; i++)
            {
                if(BeforeRun != null)
                {
                    BeforeRun(this, new GeneticEventArgs(i));
                }

                foreach(var chromosome in Population.Chromosomes)
                {
                    chromosome.Fitness = Evaluator.ComputeFitness(chromosome.Genes);
                }

                Population.Chromosomes = Population.Chromosomes.OrderByDescending(x => x.Fitness).ToList();

                if (BeforeKill != null)
                {
                    BeforeKill(this, EventArgs.Empty);
                }
                
                Killer.Kill(Population);
                
                if(AfterKill != null)
                {
                    AfterKill(this, EventArgs.Empty);
                }

                var selected = Selector.Select(Population.Chromosomes);

                if (BeforeCrossOver != null)
                {
                    BeforeCrossOver(this, EventArgs.Empty);
                }

                foreach(var pair in selected)
                {
                    var offspring = CrossOver.CrossOver(pair.Item1, pair.Item2);

                    Population.AddChromosome(offspring);
                }

                if(AfterCrossOver != null)
                {
                    AfterCrossOver(this, EventArgs.Empty);
                }

                if(BeforeMutate != null)
                {
                    BeforeMutate(this, EventArgs.Empty);
                }

                MutateStep(Population);

                if(AfterMutate != null)
                {
                    AfterMutate(this, EventArgs.Empty);
                }

                if(AfterRun != null)
                {
                    AfterRun(this, new GeneticEventArgs(i));
                }
                
                if (Solution.IsSolution(Population.Best))
                {
                    if (OnSolution != null)
                    {
                        OnSolution(this, EventArgs.Empty);
                    }

                    return;
                }
            }
        }

        private void MutateStep(Population<V> population)
        {
            var chromosomes = population.Chromosomes;

            for (int i = 0; i < chromosomes.Count; i++)
            {
                var c = chromosomes[i];

                if (Random.NextDouble() > (1 - MutationRate))
                {
                    c = Mutator.Mutate(c);
                    c.Fitness = Evaluator.ComputeFitness(c.Genes);

                    chromosomes[i] = c;
                }
            }
        }
    }
}