using NUnit.Framework;
using GeneticSharporithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace GeneticSharporithm.Tests
{
    [TestFixture()]
    public class ChromosomeTests
    {
        [Test()]
        public void Constructor_NullGenes_ThrowsArgumentNullException()
        {
            Action action = () => new Chromosome<string>(null);
            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ConstructorWithFitness_NullGenes_ThrowsArgumentNullException()
        {
            Action action = () => new Chromosome<string>(null, 0);
            action.ShouldThrow<ArgumentNullException>();
        }
    }
}