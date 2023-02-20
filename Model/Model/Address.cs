namespace Model.Model;

public class Address
{
    public string street { get; set; }
    public int postnumber{ get; set; }
    public string city{ get; set; }
    public int houseno{ get; set; }

    public Address(string street, int postnumber, string city, int houseno)
    {
        this.street = street;
        this.postnumber = postnumber;
        this.city = city;
        this.houseno = houseno;
    }

    public override string ToString()
    {
        return street+" "+houseno+", "+city+" "+postnumber;
    }
}