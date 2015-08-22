using GeneticSharporithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticSharporithmProgram
{
    public class FitnessEvaluator : IFitnessEvaluator<string>
    {
        public string Target { get; private set; }

        public FitnessEvaluator(string target)
        {
            Target = target;
        }

        /// <summary>
        /// 1 is perfect match, 0 is perfect mismatch.
        /// 
        /// 
        /// </summary>
        public double ComputeFitness(string genes)
        {
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
