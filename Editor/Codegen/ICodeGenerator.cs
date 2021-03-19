namespace MWG
{
    public interface ICodeGenerator
    {
        string FileName();
        string Namespace();
        string FileContent();
    }
}