namespace Lab1.dataProcessing;

public interface IDataProcessorPlugin
{
    byte[] ProcessBeforeSave(byte[] data);    // шифрование
    byte[] ProcessAfterLoad(byte[] data);     // дешифрование
}