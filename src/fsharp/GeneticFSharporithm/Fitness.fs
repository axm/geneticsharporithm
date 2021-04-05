namespace GeneticFSharporithm

open System

module Fitness =
    type FitnessCalculator<'a> = 'a -> 'a -> double

    let calculateFitnessAgainstTargetString (value:string) (target:string) =
        assert (value.Length = target.Length)

        let inline charToInt (c: char) = int c - int '0'
        let inline getCharDiff c1 c2 = Math.Abs((c1 |> charToInt) - (c2 |> charToInt))

        let mutable diff = Math.Abs(value.Length - target.Length)
        let minLength = Math.Min(value.Length, target.Length)

        for index = 0 to minLength - 1 do
            diff <- diff + getCharDiff value.[index] target.[index]

        match diff with
        | 0 -> 1.0
        | _ -> 1.0 / double diff
