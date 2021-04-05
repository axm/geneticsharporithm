using GeneticSharporithm.Core;
using GeneticSharporithm.Mutation;

namespace GeneticSharporithm
{
    public class GeneticAlgorithm<V> where V: class
    {
        public IMutator<V> Mutator { get; }
        public ICrossOver<V> CrossOver { get; }
        public IKiller<V> Killer { get; }
        public double MutationRate { get; }
        private State<V> State;

        internal GeneticAlgorithm(GeneticAlgorithmBuilder<V> builder)
        {
            MutationRate = builder.MutationRate;
            Mutator = builder.Mutator;
            CrossOver = builder.CrossOver;
            Killer = builder.Killer;
            State = builder.Population;
        }

        public State<V> Step()
        {
            State = Killer.Kill(State);
            State = CrossOver.CrossOver(State);
            State = Mutator.Mutate(State);

            return State;
        }
    }
}
