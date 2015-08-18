# geneticsharporithm
Simple genetic algorithm implementation in C# which aims to mimick natural selection for a number of generations in order to solve a problem.

Very briefly, a genetic algorithm runs like this:

You start off with a population (in our example implementation, a list of randomly generated string of length 10) of "chromosomes" and the goal is to run iterations on the population such that at the end the chromosomes (strings) will converge towards a goal. In the sample implementation, the strings are supposed to evolve become "abracadabra". On each iteration, each chromosome (string) is evaluated and the population is sorted (to make things easier).

On each iteration (denoted by the term "generation") we need to:

1. Kill some chromosomes (usually the weakest ones). The "Killer" class is responsible for killing chromosomes.
2. Select some chromosomes for breeding (usually the best ones, although some diversity is preferred). The "Selector" is responsible for selecting the chromosomes to be bred.
3. Mate/cross over the selected chromosomes. In the sample implementation, mating means "getting a substring from parent1 ( [0..n] ) and concatenate it with a subscring from parent2 ( [n+1..parent_length] ) to obtain a child". The resulting string will have the same length as the parent strings. This is performed using the "CrossOver" class.
4. Occasionally apply a mutation to the offspring. This is done via the Mutator class.
5. At the end of each generation, check whether we achieved the goal (in our example, a string equal to "abracadabra"). If so, stop the run.


The algorithm is set up via GeneticAlgorithmBuilder. Each of its components has an interface that can be used to implement a custom behaviour. Currently all of them are mandatory.

```csharp
var geneticAlgorithm = new GeneticAlgorithmBuilder<string>()
	.SetPopulation(population)
	.SetFitnessEvaluator(evaluator)
	.SetGenerations(150000)
	.SetMutationRate(0.05)
	.SetMutator(mutator)
	.SetCrossOver(crossOver)
	.SetSelection(selector)
	.SetKiller(killer)
	.SetSolution(solution)
	.Build();
	
geneticAlgorithm.Run();
```

You may want to register the `OnSolution` event and potentially `AfterRun`.
		
The repo is split in the following sections:
* GeneticSharporithm - holds the library files: all relevant interfaces, the core component(s) that run the algorithm etc.
* GeneticSharporithmTests - test files for the library project
* GeneticSharporithmProgram - sample implementation, which includes a main method etc.
