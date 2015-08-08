using NUnit.Framework;
using FluentAssertions;
using GeneticSharporithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace GeneticSharporithm.Tests
{
    [TestFixture]
    public class PopulationTests
    {
        private Mock<IPopulationGenerator<string>> PopulationGenerator;
        private Mock<IFitnessEvaluator<string>> FitnessEvaluator;
        private Mock<Population<string>> PopulationMock;
        private Population<string> Population;
        private int Count;

        [SetUp]
        public void SetUp()
        {
            PopulationGenerator = new Mock<IPopulationGenerator<string>>();
            FitnessEvaluator = new Mock<IFitnessEvaluator<string>>();
            Count = 1;

            PopulationMock = new Mock<Population<string>>(Count, PopulationGenerator.Object, FitnessEvaluator.Object);
            Population = new Population<string>(Count, PopulationGenerator.Object, FitnessEvaluator.Object);
        }

        [Test]
        public void Constructor_WhenZeroCount_ThrowArgumentOutOfRangeException()
        {
            Action action = () => new Population<string>(-1, PopulationGenerator.Object, FitnessEvaluator.Object);

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void Constructor_WhenPopulationGeneratorIsNull_ThrowArgumentNullException()
        {
            Action action = () => new Population<string>(Count, null, FitnessEvaluator.Object);

            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void Constructor_WhenFitnessEvaluatorIsNull_ThrowArgumentNullException()
        {
            Action action = () => new Population<string>(Count, PopulationGenerator.Object, null);
            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddChromosome_WhenChromosomeIsNull_ThrowArgumentNullException()
        {
            Action action = () => Population.AddChromosome(null);

            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void RemoveChromosome_WhenChromosomeIsNull_ThrowNullArgumentException()
        {
            Action action = () => Population.RemoveChromosome(null);

            action.ShouldThrow<ArgumentNullException>();
        }
    }
}