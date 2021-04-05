using System;

namespace GeneticSharporithm.Core
{
    public struct Chromosome<T> : IComparable<Chromosome<T>>, IEquatable<T> where T: class
    {
        public T Genes { get; }
        public double Fitness { get; }

        public Chromosome(T genes, double fitness)
        {
            if(genes == null)
            {
                throw new ArgumentNullException($"{nameof(genes)} cannot be null.");
            }

            if (fitness < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(fitness)} must be zero or positive.");
            }    

            Genes = genes;
            Fitness = fitness;
        }

        public override string ToString()
        {
            return $"({Genes} = {Fitness})";
        }

        public bool Equals(T other)
        {
            return Genes.Equals(other);
        }

        public int CompareTo(Chromosome<T> other) => Fitness.CompareTo(other.Fitness);
    }
}
