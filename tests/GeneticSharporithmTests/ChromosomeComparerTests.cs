using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticSharporithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using FluentAssertions;

namespace GeneticSharporithm.Tests
{
    public class ChromosomeComparerTests
    {
        public void Compare_NullFirstParameter()
        {
            var chromosome = new Mock<Chromosome<string>>(string.Empty);

            var comparer = new ChromosomeComparer<string>();

            Action action = () => comparer.Compare(null, chromosome.Object);

            action.ShouldThrow<ArgumentNullException>("First parameter is null.");
        }

        public void Compare_NullSecondParameter()
        {
            var chromosome = new Mock<Chromosome<string>>(string.Empty);

            var comparer = new ChromosomeComparer<string>();

            Action action = () => comparer.Compare(chromosome.Object, null);

            action.ShouldThrow<ArgumentNullException>("Second parameter is null.");
        }
        
        public void CompareTest()
        {

        }
    }
}