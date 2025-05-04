using patern.Models;

namespace patern.OutputStrategies;

public class OutputContext
{
    private readonly IOutputStrategy _strategy;

    public OutputContext(IOutputStrategy strategy)
    {
        _strategy = strategy;
    }

    public void Write(CrimeRecord record)
    {
        _strategy.Write(record);
    }
}
