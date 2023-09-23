namespace SoundGenerator.Core.Structures;

public struct GeneratorData
{
    public double Amplitude { get; }
    public double Frequency { get; }
    public double InitialPhase { get; }
    public double DutyCycle { get; }
    public double SampleRate { get; }
    public double Time { get; }

    public GeneratorData(double amplitude, double frequency, double initialPhase, double dutyCycle, double sampleRate, double time)
    {
        Amplitude = amplitude;
        Frequency = frequency;
        InitialPhase = initialPhase;
        DutyCycle = dutyCycle;
        SampleRate = sampleRate;
        Time = time;
    }
}