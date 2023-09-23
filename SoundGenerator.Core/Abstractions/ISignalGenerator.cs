using SoundGenerator.Core.Structures;

namespace SoundGenerator.Core.Abstractions;

public interface ISignalGenerator
{
    public IEnumerable<double> GenerateSignal(GeneratorData generatorData);
}