using GeneticSharporithm;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticSharporithmProgram
{
    /// <summary>
    /// In this particular implementation chromosomes have at most one chance
    /// of breeding per generation.
    /// </summary>
    public class UniqueChromosomeSelector : ISelection<string>
    {
        private readonly IFitnessEvaluator<string> FitnessEvaluator;
        private readonly int Count;
        private readonly Random Random = new Random();
        private readonly int Total;

        public UniqueChromosomeSelector(IFitnessEvaluator<string> fitnessEvaluator, int count, int total)
        {
            Contract.Requires<ArgumentNullException>(fitnessEvaluator != null);
            Contract.Requires<ArgumentOutOfRangeException>(count > 0);
            Contract.Requires<ArgumentOutOfRangeException>(total > 0);

            FitnessEvaluator = fitnessEvaluator;
            Count = count;
            Total = total;
        }

        public IEnumerable<Tuple<Chromosome<string>, Chromosome<string>>> Select(IList<Chromosome<string>> chromosomes)
        {
            Contract.Requires<ArgumentNullException>(chromosomes != null);
            Contract.Requires<InvalidOperationException>(chromosomes.Count != 0);

            var list = new List<Chromosome<string>>();
            
            while(list.Count < Count)
            {
                var number = Random.NextDouble();
                var sum = 0.0;

                for(var i = 0; i < chromosomes.Count; i++)
                {
                    sum += chromosomes[i].Fitness / Total;

                    if(sum > number)
                    {
                        if(!list.Contains(chromosomes[i]))
                        {
                            list.Add(chromosomes[i]);
                        }

                        break;
                    }
                }
            }

            var tupleList = new List<Tuple<Chromosome<string>, Chromosome<string>>>();

            for(var i = 0; i < list.Count; i += 2)
            {
                tupleList.Add(Tuple.Create<Chromosome<string>, Chromosome<string>>(list[i], list[i+1]));
            }

            return tupleList.AsEnumerable();
        }
    }
}
