namespace Model.Model;
public class HouseListing
{
    public long id { get; set; }
    public Address address{ get; set; }
    public int ConstructionYear{ get; set; }
    public int LastRebuilt{ get; set; }
    public bool HasInspection{ get; set; }
    public double GroundArea{ get; set; }
    public double FloorArea{ get; set; }
    public List<ImageFile> images{ get; set; }
    //private date listing date;
    public double price{ get; set; }
    
    public string description{ get; set; }
    public string userEmail{ get; set; }
    public HouseListing(Address address, int ConstructionYear, int LastRebuilt, bool HasInspection, double GroundArea, double FloorArea,
        List<ImageFile> images, double price,string userEmail, string description,long id)
    {
        this.address = address;
        this.ConstructionYear = ConstructionYear;
        this.LastRebuilt = LastRebuilt;
        this.HasInspection = HasInspection;
        this.GroundArea = GroundArea;
        this.FloorArea = FloorArea;
        this.images = images;
        this.price = price;
        this.id = id;
        this.userEmail = userEmail;
        this.description = description;
    }

    public HouseListing()
    {
        
    }
    
}