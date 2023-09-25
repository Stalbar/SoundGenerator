using SoundGenerator.Core.Services;
using SoundGenerator.Core.Structures;

while (true)
{
    Console.WriteLine("Choose Generator: ");
    Console.WriteLine("1 - Noize\n2 - Pulse\n3 - Sawtooth\n4 - Sinusoid\n5 - Triangle");
    int n = int.Parse(Console.ReadLine()!);
    var generator = SignalGeneratorFactory.Create(n);
    Console.Write("Amplitude: ");
    double amplitude = double.Parse(Console.ReadLine()!);
    Console.Write("Frequency: ");
    double frequency = double.Parse(Console.ReadLine()!);
    Console.Write("Initial Phase: ");
    double initialPhase = double.Parse(Console.ReadLine()!);
    Console.Write("Sample Rate: ");
    double sampleRate = double.Parse(Console.ReadLine()!);
    Console.Write("Duty Cycle: ");
    double dutyCycle = double.Parse(Console.ReadLine()!);
    Console.Write("Time: ");
    double time = double.Parse(Console.ReadLine()!);
    var generatorData = new GeneratorData(amplitude, frequency, initialPhase, dutyCycle, sampleRate, time);
    var signal = generator?.GenerateSignal(generatorData);
    FrequencyModulationSignalGenerator frequencyModulation = new();
    Console.Write("Carrier Amplitude: ");
    double carrierAmplitude = Double.Parse(Console.ReadLine()!);
    Console.Write("Carrier Frequency: ");
    double carrierFrequency = Double.Parse(Console.ReadLine()!);
    Console.Write("Carrier Initial Phase: ");
    double carrierInitialPhase = Double.Parse(Console.ReadLine()!);
    var modulated = frequencyModulation.GenerateSignal(generatorData, signal!, carrierAmplitude, carrierFrequency, carrierInitialPhase);
    WavFileGenerator wavFileGenerator = new();
    Console.Write("File Name: ");
    string fileName = Console.ReadLine()!;
    wavFileGenerator.GenerateWavFile(modulated, sampleRate, time, fileName);
}