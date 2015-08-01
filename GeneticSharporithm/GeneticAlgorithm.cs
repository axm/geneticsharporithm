using System;
using System.Collections.Generic;

namespace GeneticSharporithm
{
    public delegate void GeneticEvent<V>(GeneticAlgorithm<V> sender, EventArgs e);

    public class GeneticAlgorithm<V>
    {
        public int Generations { get; private set; }
        public Population<V> Population { get; private set; }
        public IFitnessEvaluator<V> Evaluator { get; private set; }
        public IMutate<V> Mutator { get; private set; }
        public ICrossOver<V> CrossOver { get; private set; }
        public double MutationRate { get; private set; }
        private Random Random = new Random();

        /// <summary>
        /// Executed before each generation run.
        /// </summary>
        public event GeneticEvent<V> BeforeRun;

        /// <summary>
        /// Executed after each generation run.
        /// </summary>
        public event GeneticEvent<V> AfterRun;

        public event GeneticEvent<V> BeforeKill;
        public event GeneticEvent<V> AfterKill;
        public event GeneticEvent<V> BeforeMutate;
        public event GeneticEvent<V> AfterMutate;
        public event GeneticEvent<V> BeforeCrossOver;
        public event GeneticEvent<V> AfterCrossOver;

        internal GeneticAlgorithm(GeneticAlgorithmBuilder<V> builder)
        {
            Generations = builder.Generations;
            Population = builder.Population;
            Evaluator = builder.FitnessEvaluator;
            MutationRate = builder.MutationRate;
            Mutator = builder.Mutator;
            CrossOver = builder.CrossOver;
        }

        public void Execute()
        {
            for (int i = 0; i < Generations; i++)
            {
                if(BeforeRun != null)
                {
                    BeforeRun(this, EventArgs.Empty);
                }

                var chromosomes = (List<Chromosome<V>>)Population.Chromosomes;
                chromosomes.Sort(new ChromosomeComparer<V>());

                if(BeforeKill != null)
                {
                    BeforeKill(this, EventArgs.Empty);
                }

                Kill(chromosomes, 10);

                if(AfterKill != null)
                {
                    AfterKill(this, EventArgs.Empty);
                }

                if(BeforeCrossOver != null)
                {
                    BeforeCrossOver(this, EventArgs.Empty);
                }

                while(chromosomes.Count < Population.TargetSize)
                {
                    var index = Random.Next(0, 10);

                    var c1 = chromosomes[index];

                    index = Random.Next(0, chromosomes.Count);

                    var c2 = chromosomes[index];

                    chromosomes.Add(CrossOver.CrossOver(c1, c2));
                }

                if(AfterCrossOver != null)
                {
                    AfterCrossOver(this, EventArgs.Empty);
                }

                if(BeforeMutate != null)
                {
                    BeforeMutate(this, EventArgs.Empty);
                }

                MutateStep(chromosomes);

                if(AfterMutate != null)
                {
                    AfterMutate(this, EventArgs.Empty);
                }

                if(AfterRun != null)
                {
                    AfterRun(this, EventArgs.Empty);
                }
            }
        }

        private IList<Tuple<Chromosome<V>, Chromosome<V>>> Select(List<Chromosome<V>> chromosomes, int count)
        {
            var tempSelected = new List<Chromosome<V>>();

            var selected = new List<Tuple<Chromosome<V>, Chromosome<V>>>();

            var mateIndex = Random.Next(5, chromosomes.Count / 2);
            
            selected.Add(Tuple.Create(chromosomes[0], chromosomes[mateIndex]));

            mateIndex = Random.Next(5, chromosomes.Count / 2);
            selected.Add(Tuple.Create(chromosomes[1], chromosomes[mateIndex]));


            mateIndex = Random.Next(5, chromosomes.Count / 2);
            selected.Add(Tuple.Create(chromosomes[2], chromosomes[mateIndex]));


            mateIndex = Random.Next(5, chromosomes.Count / 2);
            selected.Add(Tuple.Create(chromosomes[3], chromosomes[mateIndex]));


            mateIndex = Random.Next(5, chromosomes.Count / 2);
            selected.Add(Tuple.Create(chromosomes[4], chromosomes[mateIndex]));

            while (tempSelected.Count < count - 10)
            {
                var index = Random.Next(0, chromosomes.Count);

                var c1 = chromosomes[index];

                if(!tempSelected.Contains(c1))
                {
                    tempSelected.Add(c1);
                }
            }

            for(var i = 0; i < tempSelected.Count;)
            {
                selected.Add(Tuple.Create(tempSelected[i++], tempSelected[i++]));
            }

            return selected;
        }

        private void Cross(IList<Tuple<Chromosome<V>, Chromosome<V>>> matingChromosomes, IList<Chromosome<V>> chromosomes, int count)
        {
            foreach(var tuple in matingChromosomes)
            {
                var child = CrossOver.CrossOver(tuple.Item1, tuple.Item2);
                child.Fitness = Evaluator.ComputeFitness(child.Genes);

                chromosomes.Add(child);
            }
        }

        protected void Kill(List<Chromosome<V>> chromosomes, int count)
        {
            chromosomes.RemoveRange(chromosomes.Count - count - 1, count);
        }

        protected void MutateStep(IList<Chromosome<V>> chromosomes)
        {
            for(int i = 0; i < chromosomes.Count; i++)
            {
                var c = chromosomes[i];

                if(Random.NextDouble() > (1 - MutationRate))
                {
                    c = Mutator.Mutate(c);
                    c.Fitness = Evaluator.ComputeFitness(c.Genes);
                }
            }
        }
    }
}