using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundGenerator.Core.Services;

public class PolyharmonicalSignalGenerator
{
    public IEnumerable<double> GeneratePolyharmonicalSignal(IEnumerable<IEnumerable<double>> signals)
    {
        var signalsList = signals.ToList();
        var polyharmonicalSignal = new List<double>();
        foreach (var value in signalsList[0])
        {
            polyharmonicalSignal.Add(value);
        }

        for (int i = 1; i < signalsList.Count(); i++)
        {
            var signalsValues = signalsList[i].ToList();
            for (int j = 0; j < signalsValues.Count(); j++)
            {
                polyharmonicalSignal[j] += signalsValues[j];
            }
        }
        return polyharmonicalSignal;
    }    
}