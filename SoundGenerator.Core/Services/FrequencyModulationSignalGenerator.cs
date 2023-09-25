using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoundGenerator.Core.Structures;

namespace SoundGenerator.Core.Services;

public class FrequencyModulationSignalGenerator
{
    public IEnumerable<double> GenerateSignal(GeneratorData generatorData, IEnumerable<double> messageSignal, double carrierAmplitude, double carrirerFrequency, double carrierInitialPhase)
    {
        List<double> modulatedSignal = new();
        var messageSignalList = messageSignal.ToList();
        var sampleRate = generatorData.SampleRate;
        var time = generatorData.Time;
        double sum = 0;
        for (int i = 0; i < sampleRate * time; i++)
        {   
            sum += 2 * Math.PI * carrirerFrequency * (1 + messageSignalList[i]) * 1.0 / sampleRate;
            modulatedSignal.Add(carrierAmplitude * Math.Sin(sum + carrierInitialPhase));
        }
        return modulatedSignal;
    }   
}