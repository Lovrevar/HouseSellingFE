namespace Model.Model;

public class ShortHouseListing
{
    public int id { get; set; }
    public ImageFile image{ get; set; }
    public Address address{ get; set; }
    public long price{ get; set; }
    public int postalCode{ get; set; }

    public ShortHouseListing(int id, ImageFile image, Address address, long price, int postalCode)
    {
        this.id = id;
        this.image = image;
        this.address = address;
        this.price = price;
        this.postalCode = postalCode;
    }
}