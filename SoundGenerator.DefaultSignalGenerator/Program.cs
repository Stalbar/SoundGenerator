using SoundGenerator.Core.Services;
using SoundGenerator.Core.Structures;

while (true)
{
    Console.WriteLine("Choose Generator: ");
    Console.WriteLine("1 - Noize\n2 - Pulse\n3 - Sawtooth\n4 - Sinusoid\n5 - Triangle");
    int n = Int32.Parse(Console.ReadLine()!);
    var generator = SignalGeneratorFactory.Create(n);
    Console.Write("Amplitude: ");
    double amplitude = Double.Parse(Console.ReadLine()!);
    Console.Write("Frequency: ");
    double frequency = Double.Parse(Console.ReadLine()!);
    Console.Write("Initial Phase: ");
    double initialPhase = Double.Parse(Console.ReadLine()!);
    Console.Write("Sample Rate: ");
    double sampleRate = Double.Parse(Console.ReadLine()!);
    Console.Write("Duty Cycle: ");
    double dutyCycle = Double.Parse(Console.ReadLine()!);
    Console.Write("Time: ");
    double time = Double.Parse(Console.ReadLine()!);
    var generatorData = new GeneratorData(amplitude, frequency, initialPhase, dutyCycle, sampleRate, time);
    var signal = generator?.GenerateSignal(generatorData);
    Console.Write("File Name: ");
    string fileName = Console.ReadLine()!;
    WavFileGenerator wavFileGenerator = new();
    wavFileGenerator.GenerateWavFile(signal!, sampleRate, time, fileName);
}