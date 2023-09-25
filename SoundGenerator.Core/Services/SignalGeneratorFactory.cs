using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoundGenerator.Core.Abstractions;
using SoundGenerator.Core.Realizations;

namespace SoundGenerator.Core.Services;

public class SignalGeneratorFactory
{
    public static ISignalGenerator Create<T>() where T: ISignalGenerator, new() 
    {
        return new T();
    }

    public static ISignalGenerator? Create(int n)
    {
        switch (n)
        {
            case 1:
                return Create<NoizeSignalGenerator>();
            case 2:
                return Create<PulseSignalGenerator>();
            case 3:
                return Create<SawtoothSignalGenerator>();
            case 4:
                return Create<SinusoidSignalGenerator>();
            case 5:
                return Create<TriangleSignalGenerator>();
            default:
                return null;
        }
    }
}