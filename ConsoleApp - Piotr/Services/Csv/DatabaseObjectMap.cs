using CsvHelper.Configuration;

namespace ConsoleAppPiotr

{
    internal class DatabaseObjectMap : ClassMap<CsvModel>
    {
        public DatabaseObjectMap()
        {
            Map(p => p.Type);
            Map(p => p.Name);
            Map(p => p.Schema);
            Map(p => p.ParentName);
            Map(p => p.ParentType);
            Map(p => p.DataType);
            Map(p => p.IsNullable);
        }
    }
}
