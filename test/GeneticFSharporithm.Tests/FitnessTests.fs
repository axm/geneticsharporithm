module FitnessTests

open Xunit
open GeneticFSharporithm.Fitness

[<Fact>]
let ``calculateFitnessAgainstTargetString when given same strings it returns 0`` () =
    let result = calculateFitnessAgainstTargetString "abra" "abra"

    Assert.Equal(0., result) |> ignore
