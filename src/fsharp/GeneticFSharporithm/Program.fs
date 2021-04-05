open System
open GeneticFSharporithm.Fitness


type Result = {
    State: string;
    TargetState: string;
    Fitness: double;
}

type Mutator = PopulationAction
type Crossover = PopulationAction
type Killer = PopulationAction

type MutationConfig = {
    Mutator: Mutator;
    Rate: double;
}

type KillerConfig = {
    Killer: Killer;
    Rate: double;
}

type CrossoverConfig = {
    Crossover: Crossover;
    Rate: double;
}

type Parameters = {
    InitialState: string;
    TargetState: string;
    Generations: int;
    MutationConfig: MutationConfig;
    KillerConfig: KillerConfig;
    CrossoverConfig: CrossoverConfig;
    FitnessCalculator: FitnessCalculator<string>;
}

let run (parameters : Parameters) : Result =
    raise (NotImplementedException "Not implemented")

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    let message = from "F#" // Call the function
    printfn "Hello world %s" message
    0 // return an integer exit code