using Locations.Models;
using Microsoft.AspNetCore.Mvc;

namespace Locations.Interfaces
{
    public interface ILocation
    {
        public Task<List<LocationDetail>> GetAllLocation();
        public Task<LocationDetail> GetAllLocationbyid(string Name);
        public Task<bool> DeleteLocation(string Name);

        public Task<bool> updateLocation(LocationDTO location, int id);
        public Task<bool> AddLocation(LocationDTO location);
       
    }
}
