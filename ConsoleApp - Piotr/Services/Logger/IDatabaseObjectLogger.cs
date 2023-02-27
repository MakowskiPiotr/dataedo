namespace ConsoleAppPiotr
{
    internal interface IDatabaseObjectLogger
    {
        void PrintData(IList<CsvModel> databaseObjects);
    }
}
