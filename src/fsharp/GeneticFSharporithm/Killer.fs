namespace GeneticFSharporithm

open Core

module Killer =
    let killPopulation (population: Population) : Population =
        let newPopulation = getPopulationSortedByFitness population
        newPopulation
