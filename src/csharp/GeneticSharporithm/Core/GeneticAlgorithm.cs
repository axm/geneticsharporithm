using GeneticSharporithm.Core;
using GeneticSharporithm.Mutation;

namespace GeneticSharporithm
{
    public class GeneticAlgorithm<T> where T: class
    {
        public IMutator<T> Mutator { get; }
        public ICrossOver<T> CrossOver { get; }
        public IKiller<T> Killer { get; }
        public double MutationRate { get; }
        private State<T> State;

        internal GeneticAlgorithm(GeneticAlgorithmBuilder<T> builder)
        {
            MutationRate = builder.MutationRate;
            Mutator = builder.Mutator;
            CrossOver = builder.CrossOver;
            Killer = builder.Killer;
            State = builder.Population;
        }

        public State<T> Step()
        {
            State = Killer.Kill(State);
            State = CrossOver.CrossOver(State);
            //State = Mutator.Mutate(State);

            return State;
        }
    }
}
