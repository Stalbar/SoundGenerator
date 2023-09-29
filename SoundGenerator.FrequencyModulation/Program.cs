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
    Console.WriteLine("Choose Generator for Carrier Signal: ");
    Console.WriteLine("1 - Noize\n2 - Pulse\n3 - Sawtooth\n4 - Sinusoid\n5 - Triangle");
    n = int.Parse(Console.ReadLine()!);
    generator = SignalGeneratorFactory.Create(n);
    Console.Write("Amplitude: ");
    amplitude = double.Parse(Console.ReadLine()!);
    Console.Write("Frequency: ");
    frequency = double.Parse(Console.ReadLine()!);
    Console.Write("Initial Phase: ");
    initialPhase = double.Parse(Console.ReadLine()!);
    Console.Write("Sample Rate: ");
    sampleRate = double.Parse(Console.ReadLine()!);
    Console.Write("Duty Cycle: ");
    dutyCycle = double.Parse(Console.ReadLine()!);
    Console.Write("Time: ");
    time = double.Parse(Console.ReadLine()!);
    generatorData = new GeneratorData(amplitude, frequency, initialPhase, dutyCycle, sampleRate, time);
    var modulated = generator!.GenerateFrequencyModulatedSignal(signal!, generatorData);
    WavFileGenerator wavFileGenerator = new();
    Console.Write("File Name: ");
    string fileName = Console.ReadLine()!;
    wavFileGenerator.GenerateWavFile(modulated, sampleRate, time, fileName);
}