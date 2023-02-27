using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace ConsoleAppPiotr
{
    public class CsvImporter : ICsvImporter
    {
        public IList<CsvModel> Import(string path)
        {
            var databaseObjectList = new List<CsvModel>();

            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                MissingFieldFound = null,
                Delimiter = ";"
            };

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, configuration))
            {
                csv.Context.RegisterClassMap<DatabaseObjectMap>();
                var databaseObjects = csv.GetRecords<CsvModel>();
                foreach (var row in databaseObjects)
                {
                    databaseObjectList.Add(row);
                }
            }

            // count the number of children
            var parents = databaseObjectList
                .Where(x => x.Type.ToLower() == "database" || x.Type.ToLower() == "table");

            foreach (var parent in parents)
            {
                parent.NumberOfChildren = databaseObjectList
                    .Where(x => x.ParentName == parent.Name)
                    .Count();
            }

            return databaseObjectList;
        }
    }
}
