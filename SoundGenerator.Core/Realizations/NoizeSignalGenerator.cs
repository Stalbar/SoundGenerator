using SoundGenerator.Core.Abstractions;
using SoundGenerator.Core.Structures;

namespace SoundGenerator.Core.Realizations;

public class NoizeSignalGenerator : ISignalGenerator
{
    private static Random _random = new();
    public IEnumerable<double> GenerateSignal(GeneratorData generatorData)
    {
        List<double> signal = new();
        var amplitude = generatorData.Amplitude;
        var sampleRate = generatorData.SampleRate;
        var time = generatorData.Time;
        for (int i = 0; i < sampleRate * time; i++)
        {
            var signalValue = GenerateSignalValue(amplitude);
            signal.Add(signalValue);
        }
        return signal;
    }

    public double GenerateSignalValue(double amplitude)
        => amplitude * (2 * _random.NextDouble() - 1);
}