using GeneticSharporithm;
using GeneticSharporithm.Core;
using System;
using System.Linq;

namespace GeneticSharporithmProgram
{
    public class ChromosomeKiller : IKiller<string>
    {
        private Func<State<string>, int> KillCountFormula { get; }

        public ChromosomeKiller(Func<State<string>, int> killCountFormula)
        {
            if (killCountFormula == null)
            {
                throw new ArgumentNullException(nameof(killCountFormula));
            }

            KillCountFormula = killCountFormula;
        }

        public State<string> Kill(State<string> state)
        {
            var count = KillCountFormula.Invoke(state);
            if (count == 0)
            {
                return state;
            }

            var survivors = state.Chromosomes.Take(state.Chromosomes.Length - count);

            return State<string>.FromChromosomes(survivors);
        }
    }
}
