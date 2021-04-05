using GeneticSharporithm.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticSharporithm
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISolution<T> where T: class
    {
        /// <summary>
        /// Checks whether the specified chromosome is the solution to the problem.
        /// </summary>
        /// <param name="chromosome"></param>
        /// <returns>
        /// true if the specified chromosome is the solution to the problem,
        /// false otherwise.
        /// </returns>
        bool IsSolution(Chromosome<T> chromosome);
    }
}
