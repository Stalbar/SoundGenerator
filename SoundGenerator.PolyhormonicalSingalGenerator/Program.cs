using SoundGenerator.Core.Realizations;
using SoundGenerator.Core.Services;
using SoundGenerator.Core.Structures;

internal class Program
{
    static List<IEnumerable<double>> signals = new();
    private static void Main(string[] args)
    {

        static void GenerateNewSignal()
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
            signals.Add(signal!);
        }

        static void GenerateFile()
        {
            Console.Write("File Name: ");
            string fileName = Console.ReadLine()!;
            PolyharmonicalSignalGenerator polyharmonicalSignalGenerator = new();
            var signal = polyharmonicalSignalGenerator.GeneratePolyharmonicalSignal(signals);
            WavFileGenerator wavFileGenerator = new();
            wavFileGenerator.GenerateWavFile(signal, 44100, 5, fileName);
        }

        while (true)
        {
            Console.WriteLine("1 - Generate New Signal\n2 - Generate File");
            int command = int.Parse(Console.ReadLine()!);
            if (command == 1)
            {
                GenerateNewSignal();
            }
            else
            {
                GenerateFile();
            }
        }
    }
}