namespace patern.Models;
public class CrimeRecord
{
    public int ID { get; set; }
    public string CaseNumber { get; set; }
    public DateTime Date { get; set; }
    public string Block { get; set; }
    public string IUCR { get; set; }
    public string PrimaryType { get; set; }
    public string Description { get; set; }
    public string LocationDescription { get; set; }
    public bool Arrest { get; set; }
    public bool Domestic { get; set; }
    public int Beat { get; set; }
    public int District { get; set; }
    public int Ward { get; set; }
    public int CommunityArea { get; set; }
    public string FBICode { get; set; }
    public int? XCoordinate { get; set; }
    public int? YCoordinate { get; set; }
    public int Year { get; set; }
    public DateTime UpdatedOn { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string Location { get; set; }
    public int? HistoricalWards { get; set;}
    public int? ZipCodes { get; set; }
    public int? CommunityAreas { get; set; }
    public int? CensusTracts { get; set; }
    public int? Wards { get; set; }
    public int? BoundariesZIPCodes { get; set; }
    public int? PoliceDistricts { get; set; }
    public int? PoliceBeats { get; set; }
    
}
