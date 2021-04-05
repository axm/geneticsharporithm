using GeneticSharporithm;
using System;

namespace GeneticSharporithmProgram
{
    public class FitnessEvaluator : IFitnessEvaluator<string>
    {
        public string Target { get; }

        public FitnessEvaluator(string target)
        {
            if (string.IsNullOrWhiteSpace(target))
            {
                throw new System.ArgumentException($"{nameof(target)} cannot be null or whitespace.");
            }

            Target = target;
        }

        /// <summary>
        /// 1 is perfect match, 0 is perfect mismatch.
        /// 
        /// 
        /// </summary>
        public double ComputeFitness(string genes)
        {
            if (string.IsNullOrWhiteSpace(genes))
            {
                throw new ArgumentException($"{nameof(genes)} cannot be null or whitespace.");
            }

            var evaluation = 0d;
            
            // assuming both genes and target have same length
            for(int i = 0; i < Target.Length; i++)
            {
                var targetValue = (int)Target[i];
                var geneValue = (int)genes[i];

                if(targetValue == geneValue)
                {
                    evaluation += 1;
                } else
                {
                    evaluation = 1d / (1.5 * Math.Abs(targetValue - geneValue));
                }
            }

            return evaluation / Target.Length;
        }
    }
}
