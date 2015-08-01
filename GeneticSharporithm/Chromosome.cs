using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticSharporithm
{
    public class Chromosome<T> : IEquatable<T>
    {
        public T Genes { get; private set; }
        public double Fitness { get; set; }

        public Chromosome(T genes)
        {
            Contract.Requires<ArgumentNullException>(genes != null, "Genes cannot be null");

            Genes = genes;
        }

        public override string ToString()
        {
            return $"{Genes.ToString()}, {Fitness}";
        }

        public bool Equals(T other)
        {
            Contract.Requires<ArgumentNullException>(other != null);

            return Genes.Equals(other);
        }
    }
}
