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
        // TODO: Make this readonly
        public T Genes { get; private set; }

        // TODO: Make this readonly
        public double Fitness { get; set; }

        public Chromosome(T genes) : this(genes, 0)
        {
        }

        public Chromosome(T genes, double Fitness)
        {
            Contract.Requires<ArgumentNullException>(genes != null, "Genes cannot be null");

            Genes = genes;
        }

        public override string ToString()
        {
            return $"{Genes.ToString()}, {Fitness}";
        }

        public virtual bool Equals(T other)
        {
            Contract.Requires<ArgumentNullException>(other != null);

            return Genes.Equals(other);
        }
    }
}
