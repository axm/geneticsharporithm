using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticSharporithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;

namespace GeneticSharporithm.Tests
{
    [TestFixture]
    public class GeneticAlgorithmTests
    {
        private GeneticAlgorithm<string> GeneticAlgorithm;

        [SetUp]
        public void SetUp()
        {
            const int Count = 100;

            var mutator = new Mock<IMutate<string>>();
            var crossOver = new Mock<ICrossOver<string>>();
            var fitnessEvaluator = new Mock<IFitnessEvaluator<string>>();
            var populationGenerator = new Mock<IPopulationGenerator<string>>();
            var population = new Mock<Population<string>>(Count, populationGenerator.Object, fitnessEvaluator.Object);

            GeneticAlgorithm = new GeneticAlgorithmBuilder<string>()

                .Build();

        }
    }
}