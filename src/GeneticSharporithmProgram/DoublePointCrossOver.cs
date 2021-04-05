using GeneticSharporithm;
using GeneticSharporithm.Core;
using System;

namespace GeneticSharporithmProgram
{
    public class DoublePointCrossOver<T> : ICrossOver<T> where T: class
    {
        public Chromosome<T> CrossOver(Chromosome<T> parent1, Chromosome<T> parent2)
        {
            throw new NotImplementedException();
        }

        public State<T> CrossOver(in State<T> state)
        {
            throw new NotImplementedException();
        }
    }
}
