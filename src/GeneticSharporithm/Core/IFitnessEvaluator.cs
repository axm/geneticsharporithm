namespace GeneticSharporithm
{
    public interface IFitnessEvaluator<T>
    {
        double ComputeFitness(T genes);
    }
}
