using Model.Model;

namespace Model.DTOs;

public class HouseListingCreationDTO
{
    public Address address { get; set; }

    public int ConstructionYear{ get; set; }
    public int LastRebuilt{ get; set; }
    public bool HasInspection{ get; set; }
    public double GroundArea{ get; set; }
    public double FloorArea{ get; set; }
    public List<ImageFile> images{ get; set; }
    public long price{ get; set; }
    
    public string description{ get; set; }
    
    public string email{ get; set; }
    public HouseListingCreationDTO(Address address, int constructionYear, int lastRebuilt, bool hasInspection, double groundArea, 
        double floorArea, List<ImageFile> images, long price, string description, string email)
    {
        this.address = address;
        ConstructionYear = constructionYear;
        LastRebuilt = lastRebuilt;
        HasInspection = hasInspection;
        GroundArea = groundArea;
        FloorArea = floorArea;
        this.images = images;
        this.price = price;
        this.description = description;
        this.email = email;
    }
    
}