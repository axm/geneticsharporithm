namespace GeneticFSharporithm

module Core =
    type Chromosome = {
        Value: string;
        Fitness: double;
    }

    type Population = {
        Chromosomes: Chromosome list;
    }

    type PopulationAction = Population -> Population

    let getPopulationSortedByFitness population =
        let chromosomes = population.Chromosomes |> List.sortBy (fun c -> c.Fitness)

        {
            Chromosomes = chromosomes
        }
