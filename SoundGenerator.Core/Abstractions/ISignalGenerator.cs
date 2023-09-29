using SoundGenerator.Core.Structures;

namespace SoundGenerator.Core.Abstractions;

public interface ISignalGenerator
{
    public IEnumerable<double> GenerateSignal(GeneratorData generatorData);

    public IEnumerable<double> GenerateAmplitudeModulatedSignal(IEnumerable<double> messageSignal, GeneratorData carrierData);

    public IEnumerable<double> GenerateFrequencyModulatedSignal(IEnumerable<double> messageSignal, GeneratorData carrierData);
}