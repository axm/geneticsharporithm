using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticSharporithm
{
    public class GeneticEventArgs : EventArgs
    {
        public readonly int Generation;

        public GeneticEventArgs(int generation)
        {
            Generation = generation;
        }
    }
}
