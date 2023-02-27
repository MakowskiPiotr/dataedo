namespace ConsoleAppPiotr
{
    public class DatabaseObjectLogger : IDatabaseObjectLogger
    {
        public void PrintData(IList<CsvModel> databaseObjects)
        {
            var databases = databaseObjects
                .Where(x => x.Type.ToLower() == "database")
                .ToList();

            databases.ForEach(database =>
            {
                Print(database);
                var tables = databaseObjects
                    .Where(x => x.Type.ToLower() == "table" && x.ParentName == database.Name)
                    .ToList();
                tables.ForEach(table =>
                {
                    Print(table);
                    var columns = databaseObjects
                        .Where(x => x.Type.ToLower() == "column" && x.ParentName == table.Name)
                        .ToList();
                    columns.ForEach(column => Print(column));
                });
            });
        }

        private void Print(CsvModel databaseObject)
        {
            string message = databaseObject.Type.ToLower() switch
            {
                "database" => $"Database '{databaseObject.Name}' ({databaseObject.NumberOfChildren} tables)",
                "table" => $"\tTable '{databaseObject.Schema}.{databaseObject.Name}' ({databaseObject.NumberOfChildren} columns)",
                "column" => $"\t\tColumn '{databaseObject.Name}' with {databaseObject.DataType} data type {(databaseObject.IsNullable == "1" ? "accepts nulls" : "with no nulls")}",
                _ => ""
            };

            Console.WriteLine(message);
        }
    }
}
