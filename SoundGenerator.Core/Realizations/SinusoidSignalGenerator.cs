using SoundGenerator.Core.Abstractions;
using SoundGenerator.Core.Structures;

namespace SoundGenerator.Core.Realizations;

public class SinusoidSignalGenerator : ISignalGenerator
{
    public IEnumerable<double> GenerateSignal(GeneratorData generatorData)
    {
        List<double> signal = new();
        var amplitude = generatorData.Amplitude;
        var frequency = generatorData.Frequency;
        var sampleRate = generatorData.SampleRate;
        var initialPhase = generatorData.InitialPhase;
        var time = generatorData.Time;
        for (int i = 0; i < sampleRate * time; i++)
        {
            var signalValue = GenerateSignalValue(amplitude, frequency, i, sampleRate, initialPhase);
            signal.Add(signalValue);
        }
        return signal;
    }

    private double GenerateSignalValue(double amplitude, double frequency, double n, double sampleRate, double initialPhase) 
        => amplitude * Math.Sin(2 * Math.PI * frequency * n / sampleRate + initialPhase);
}