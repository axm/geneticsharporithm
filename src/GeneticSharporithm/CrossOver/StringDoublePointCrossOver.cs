using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Contract.Requires<ArgumentNullException>(parent1 != null);
            Contract.Requires<ArgumentNullException>(parent2 != null);
            Contract.Requires<InvalidOperationException>(parent1.Genes != null);
            Contract.Requires<InvalidOperationException>(parent2.Genes != null);
            Contract.Requires<InvalidOperationException>(parent1.Genes.Length != parent2.Genes.Length, "Gene length of parents does not match.");

            throw new NotImplementedException();
        }
    }
}
