using patern.Models;

public class ConsoleOutputStrategy : IOutputStrategy
{
    public void Write(CrimeRecord record)
    {
        Console.WriteLine($"{record.ID}, {record.CaseNumber}, {record.Date}, {record.Block}, {record.IUCR}, " +
        $"{record.PrimaryType}, {record.Description}, {record.LocationDescription}, {record.Arrest}, {record.Domestic}, " +
        $"{record.Beat}, {record.District}, {record.Ward}, {record.CommunityArea}, {record.FBICode}, {record.XCoordinate}, " +
        $"{record.YCoordinate}, {record.Year}, {record.UpdatedOn}, {record.Latitude}, {record.Longitude}, {record.Location}, " +
        $"{record.HistoricalWards}, {record.ZipCodes}, {record.CommunityAreas}, {record.CensusTracts}, {record.Wards}, " +
        $"{record.BoundariesZIPCodes}, {record.PoliceDistricts}, {record.PoliceBeats}");

    }
}
