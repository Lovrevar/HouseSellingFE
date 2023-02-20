using System.Text;
using System.Text.Json;
using BlazorWASM.Services.ClientInterfaces;
using Model.DTOs;
using Model.Model;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BlazorWASM.Services.Http;

public class ListingService : IListingService
{
    private readonly HttpClient client;

    
    
    public ListingService(HttpClient client)
    {
        this.client = client;
    }
    
    

    public async Task<HouseListing> CreateListing(HouseListingCreationDTO dto)
    {
        string listingAsJson = JsonSerializer.Serialize(dto);
        Console.WriteLine(listingAsJson);
        StringContent content = new(listingAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync("http://localhost:8888/listing/houselisting", content);
        
        
        string responseContent = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }
        
        HouseListing listing = JsonSerializer.Deserialize<HouseListing>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return listing;
    }

    public async Task<HouseListing> GetById(long id)
    {
        HttpResponseMessage response = await client.GetAsync("http://localhost:8888/listing/houselisting/"+id);
        string responseContent = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }
        HouseListing listing = JsonSerializer.Deserialize<HouseListing>(responseContent, new JsonSerializerOptions{
            PropertyNameCaseInsensitive = true
        })!;
        return listing;
    }
    
    /*public async Task<HouseListing> addListing(HouseListingCreationDTO dto)
    {
        string listingAsJson = JsonSerializer.Serialize(dto);
        StringContent content = new(listingAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync("https://localhost:7164/houselisting", content);
        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }
        HouseListing listing = JsonSerializer.Deserialize<HouseListing>(responseContent, new JsonSerializerOptions{
            PropertyNameCaseInsensitive = true
        })!;
        return listing;
        
    }*/

    public async Task<ICollection<ShortHouseListing>> getAsync(int? price, int? minArea, string? city)
    {
        string query = "";
        if (city != null || price != 0 || minArea != 0)
        {
            query = "?";
        }

        if (city != null) 
        {
            query += $"city={city}";
            if (price != 0||minArea != 0)
            {
                query += $"&";
            }
        }
        if (price != 0) 
        {
            query += $"maxPrice={price}";
            if (minArea != 0)
            {
                query += $"&";
            }
        }
        if (minArea != 0) 
        {
            query += $"minArea={minArea}";
        }
        
        
        HttpResponseMessage response = await client.GetAsync("/listing/houselisting" + query);
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<ShortHouseListing> listings = JsonSerializer.Deserialize<ICollection<ShortHouseListing>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return listings;
    }

    public async Task<HouseListing> UpdateListing(HouseListing updatedListing)
    {
        string listingAsJson = JsonSerializer.Serialize(updatedListing);
        Console.WriteLine(listingAsJson);
        StringContent content = new(listingAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PutAsync("http://localhost:8888/listing/houselisting", content);
        
        
        string responseContent = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }
        HouseListing listing = JsonSerializer.Deserialize<HouseListing>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return listing;
    }

    public async Task<ICollection<ShortHouseListing>> getByEmailAsync(string email)
    {
        HttpResponseMessage response = await client.GetAsync("/listing/mylistings" + "?email="+email);
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<ShortHouseListing> listings = JsonSerializer.Deserialize<ICollection<ShortHouseListing>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return listings;
    }
}