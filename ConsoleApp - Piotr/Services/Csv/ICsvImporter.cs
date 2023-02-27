namespace ConsoleAppPiotr
{
    internal interface ICsvImporter
    {
        IList<CsvModel> Import(string path);
    }
}
