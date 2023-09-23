using SoundGenerator.Core.Abstractions;
using SoundGenerator.Core.Structures;

namespace SoundGenerator.Core.Realizations;

public class TriangleSignalGenerator : ISignalGenerator
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

    public double GenerateSignalValue(double amplitude, double frequency, double n, double sampleRate, double initialPhase)
        => 2 * amplitude / Math.PI * Math.Abs(((2 * Math.PI * frequency * n / sampleRate + initialPhase - Math.PI / 2) % (2 * Math.PI)) - Math.PI) - amplitude;
}