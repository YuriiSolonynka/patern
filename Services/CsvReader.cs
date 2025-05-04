using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using patern.Models;

public class CsvReaderService
{
    public IEnumerable<CrimeRecord> Read(string path)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HeaderValidated = null,
            MissingFieldFound = null,
            AllowComments = true,
        };
        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        return csv.GetRecords<CrimeRecord>().ToList();
    }
}
