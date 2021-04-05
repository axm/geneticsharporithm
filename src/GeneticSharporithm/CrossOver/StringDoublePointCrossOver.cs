using GeneticSharporithm.Core;
using System;
using System.Diagnostics.Contracts;

namespace GeneticSharporithm.CrossOvers
{
    /// <summary>
    /// .
    /// </summary>
    public sealed class StringDoublePointCrossOver : ICrossOver<string>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent1"></param>
        /// <param name="parent2"></param>
        /// <returns></returns>
        public Chromosome<string> CrossOver(Chromosome<string> parent1, Chromosome<string> parent2)
        {
            Contract.Requires<InvalidOperationException>(parent1.Genes != null);
            Contract.Requires<InvalidOperationException>(parent2.Genes != null);
            Contract.Requires<InvalidOperationException>(parent1.Genes.Length != parent2.Genes.Length, "Gene length of parents does not match.");

            throw new NotImplementedException();
        }

        public State<string> CrossOver(State<string> state)
        {
            throw new NotImplementedException();
        }

        public State<string> CrossOver(in State<string> state)
        {
            throw new NotImplementedException();
        }
    }
}
