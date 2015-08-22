using GeneticSharporithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticSharporithmProgram
{
    public class Generator : IPopulationGenerator<string>
    {
        private readonly Random Random;

        public Generator(Random random)
        {
            Random = random;
        }

        public string Generate()
        {
            var chars = new char[11];

            var min = 97;
            var max = 122;

            for (var i = 0; i < chars.Length; i++)
            {

                chars[i] = (char)Random.Next(min, max + 1);
            }

            return new string(chars);
        }
    }
}
