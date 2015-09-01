using NUnit.Framework;
using GeneticSharporithm.CrossOvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using FluentAssertions;

namespace GeneticSharporithm.CrossOvers.Tests
{
    [TestFixture()]
    public class StringSinglePointCrossOverTests
    {
        [Test()]
        public void StringSinglePointCrossOverTest()
        {

        }

        [Test()]
        public void CrossOver_NullParent1_ThrowsArgumentNullException()
        {
            var random = new Random();
            var fitnessEvaluatorMock = new Mock<IFitnessEvaluator<string>>();
            var parent2 = new Mock<Chromosome<string>>("", 0);

            var stringSinglePointCrossOver = new StringSinglePointCrossOver(random, fitnessEvaluatorMock.Object);

            Action action = () => stringSinglePointCrossOver.CrossOver(null, parent2.Object);
            action.ShouldThrow<ArgumentNullException>();
        }


        [Test()]
        public void CrossOver_NullParent2_ThrowsArgumentNullException()
        {
            var random = new Random();
            var fitnessEvaluatorMock = new Mock<IFitnessEvaluator<string>>();
            var parent1 = new Mock<Chromosome<string>>("", 0);

            var stringSinglePointCrossOver = new StringSinglePointCrossOver(random, fitnessEvaluatorMock.Object);

            Action action = () => stringSinglePointCrossOver.CrossOver(parent1.Object, null);
            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void CrossOver_ResultingChromosomeHasSameLengthAsParents()
        {
            var random = new Random();
            var parent1 = new Chromosome<string>("Parent1");
            var parent2 = new Chromosome<string>("Parent2");

            var fitnessEvaluatorMock = new Mock<IFitnessEvaluator<string>>();
            fitnessEvaluatorMock.Setup<double>(x => x.ComputeFitness("Parent1")).Returns(0);
            fitnessEvaluatorMock.Setup<double>(x => x.ComputeFitness("Parent2")).Returns(0);

            var stringSinglePointCrossOver = new StringSinglePointCrossOver(random, fitnessEvaluatorMock.Object);

            var child = stringSinglePointCrossOver.CrossOver(parent1, parent2);

            child.Genes.Length.Should().Be(parent1.Genes.Length);
        }

        [Test]
        public void CrossOver_DifferentGeneLengthsInChromosomes_ThrowArgumentException()
        {
            var random = new Random();
            var parent = new Chromosome<string>("Parent");
            var parent2 = new Chromosome<string>("Parent2");

            var fitnessEvaluatorMock = new Mock<IFitnessEvaluator<string>>();

            var stringSinglePointCrossOver = new StringSinglePointCrossOver(random, fitnessEvaluatorMock.Object);

            Action action = () => stringSinglePointCrossOver.CrossOver(parent, parent2);

            action.ShouldThrow<ArgumentException>();
        }
        
        public void CrossOver_CallsEvaluatorComputeFitness()
        {
            var random = new Random();
            var parent1 = new Chromosome<string>("Parent1");
            var parent2 = new Chromosome<string>("Parent2");

            var fitnessEvaluatorMock = new Mock<IFitnessEvaluator<string>>();
            fitnessEvaluatorMock.Verify();

            var stringSinglePointCrossOver = new StringSinglePointCrossOver(random, fitnessEvaluatorMock.Object);


            Action action = () => stringSinglePointCrossOver.CrossOver(parent1, parent2);

        }
    }
}