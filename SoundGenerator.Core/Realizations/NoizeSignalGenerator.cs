using SoundGenerator.Core.Abstractions;
using SoundGenerator.Core.Structures;

namespace SoundGenerator.Core.Realizations;

public class NoizeSignalGenerator : ISignalGenerator
{
    private static Random _random = new();

    public IEnumerable<double> GenerateAmplitudeModulatedSignal(IEnumerable<double> messageSignal, GeneratorData carrierData)
    {
        var sampleRate = carrierData.SampleRate;
        var time = carrierData.Time;
        var carrierAmplitude = carrierData.Amplitude;
        var carrierFrequency = carrierData.Frequency;
        var carrierInitialPhase = carrierData.InitialPhase;
        var messageSignalList = messageSignal.ToList();
        List<double> modulatedSignal = new();
        for(int i = 0; i < sampleRate * time; i++)
        {
            var modulatedSignalValue = GenerateSignalValue(carrierAmplitude * (1 + messageSignalList[i]));
            modulatedSignal.Add(modulatedSignalValue);
        }
        return modulatedSignal;
    }

    public IEnumerable<double> GenerateFrequencyModulatedSignal(IEnumerable<double> messageSignal, GeneratorData carrierData)
    {
        var sampleRate = carrierData.SampleRate;
        var time = carrierData.Time;
        var carrierAmplitude = carrierData.Amplitude;
        var carrierFrequency = carrierData.Frequency;
        var carrierInitialPhase = carrierData.InitialPhase;
        var messageSignalList = messageSignal.ToList();
        List<double> modulatedSignal = new();
        double sum = 0;
        for (int i = 0; i < sampleRate * time; i++)
        {
            sum += 1 + messageSignalList[i];    
            var modulatedSignalValue = GenerateSignalValue(carrierAmplitude);
            modulatedSignal.Add(modulatedSignalValue);
        }
        return modulatedSignal;
    }

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