using SoundGenerator.Core.Abstractions;
using SoundGenerator.Core.Structures;

namespace SoundGenerator.Core.Realizations;

public class SawtoothSignalGenerator : ISignalGenerator
{
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
            var modulatedSignalValue = GenerateSignalValue(carrierAmplitude * (1 + messageSignalList[i]), carrierFrequency, i, sampleRate, carrierInitialPhase);
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
            var modulatedSignalValue = GenerateSignalValue(carrierAmplitude, carrierFrequency * sum, 1, sampleRate, carrierInitialPhase);
            modulatedSignal.Add(modulatedSignalValue);
        }
        return modulatedSignal;
    }

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
        => amplitude / Math.PI * ((2 * Math.PI * frequency * n / sampleRate + initialPhase - Math.PI) % (2 * Math.PI)) - amplitude;
}