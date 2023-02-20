using Model.DTOs;
using Model.Model;

namespace BlazorWASM.Services.ClientInterfaces;

public interface IListingService
{
    Task<ICollection<ShortHouseListing>> getAsync(int? price, int? minArea, string? city);
    Task<HouseListing> CreateListing(HouseListingCreationDTO dto);
    Task<HouseListing> GetById(long id);
    Task<HouseListing> UpdateListing(HouseListing listing);
    Task<ICollection<ShortHouseListing>> getByEmailAsync(string email);
}