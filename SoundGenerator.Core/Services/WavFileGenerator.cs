namespace SoundGenerator.Core.Services;

public class WavFileGenerator
{
    public void GenerateWavFile(IEnumerable<double> signal, double sampleRate, double time, string fileName)
    {
        using (var file = new FileStream(fileName, FileMode.Create))
        {
            uint chunkId = 0x52494646;
            uint format = 0x57415645;
            uint subChunk1Id = 0x666d7420;
            uint subChunk1Size = 16;
            ushort audioFormat = 1;
            ushort numChannels = 1;
            ushort bitsPerSample = 16;
            uint subChunk2Id = 0x64617461;
            ushort blockAlign = (ushort)(numChannels * bitsPerSample / 8);
            uint subChunk2Size = (uint)(sampleRate * time) * blockAlign;
            uint chunkSize = 36 + subChunk2Size;
            uint byteRate = (uint)sampleRate * blockAlign;

            WriteBigEndian(file, chunkId);
            WriteLittleEndian(file, chunkSize);
            WriteBigEndian(file, format);
            WriteBigEndian(file, subChunk1Id);
            WriteLittleEndian(file, subChunk1Size);
            WriteUnsignedShort(file, audioFormat);
            WriteUnsignedShort(file, numChannels);
            WriteLittleEndian(file, (uint)sampleRate);
            WriteLittleEndian(file, byteRate);
            WriteUnsignedShort(file, blockAlign);
            WriteUnsignedShort(file, bitsPerSample);
            WriteBigEndian(file, subChunk2Id);
            WriteLittleEndian(file, subChunk2Size);

            foreach (var value in signal)
            {
                WriteShort(file, (short)(short.MaxValue * value));
            }
        }
    }

    private void WriteLittleEndian(FileStream stream, uint value)
    {
        foreach (var b in BitConverter.GetBytes(value))
        {
            stream.WriteByte(b);
        }
    }

    private void WriteBigEndian(FileStream stream, uint value)
    {
        foreach (var b in BitConverter.GetBytes(value).Reverse())
        {
            stream.WriteByte(b);
        }
    }

    private void WriteUnsignedShort(FileStream stream, ushort value)
    {
        foreach (var b in BitConverter.GetBytes(value))
        {
            stream.WriteByte(b);
        }
    }

    private void WriteShort(FileStream stream, short value)
    {
        foreach (var b in BitConverter.GetBytes(value))
        {
            stream.WriteByte(b);
        }
    }
}