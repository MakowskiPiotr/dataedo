using ConsoleAppPiotr;


string pathCsv = Path.Combine(Environment.CurrentDirectory, @"Data\", "data.csv");

var csvImporter = new CsvImporter();
var databaseObjects = csvImporter.Import(pathCsv);

var logger = new DatabaseObjectLogger();
logger.PrintData(databaseObjects);