using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoundGenerator.Core.Abstractions;
using SoundGenerator.Core.Structures;

namespace SoundGenerator.Core.Services;

public class AmplitudeModulationSignalGenerator
{
    public IEnumerable<double> GenerateSignal(GeneratorData generatorData, IEnumerable<double> messageSignal, double carrierAmplitude, double carrirerFrequency, double carrierInitialPhase)
    {
        List<double> modulatedSignal = new List<double>();
        var messageSignalList = messageSignal.ToList();
        var sampleRate = generatorData.SampleRate;
        var time = generatorData.Time;
        for (int i = 0; i < sampleRate * time; i++)
        {
            modulatedSignal.Add(carrierAmplitude * (1 + messageSignalList[i]) * Math.Sin(2 * Math.PI * carrirerFrequency * i / sampleRate + carrierInitialPhase));
        }
        return modulatedSignal;
    }
}