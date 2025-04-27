using Lab1.dataProcessing;

namespace EncryptionPlugin;

using Lab1;

public class SimpleEncryptionPlugin: IDataProcessorPlugin
{
    private readonly byte key = 0x5A;
    public byte[] ProcessBeforeSave(byte[] data)
    {
        return data.Select(b => (byte)(b ^ key)).ToArray();
    }

    public byte[] ProcessAfterLoad(byte[] data)
    {
        return data.Select(b => (byte)(b ^ key)).ToArray();
    }
}