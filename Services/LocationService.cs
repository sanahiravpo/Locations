using Locations.Context;
using Locations.Interfaces;
using Locations.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Locations.Services
{
    public class LocationService: ILocation
    {


       
        private readonly ApplicationContext _context;
        public LocationService( ApplicationContext context)
        {

          
            _context = context;

        }

        public async Task<List<LocationDetail>> GetAllLocation()
        {
            var getallLocation = await _context.Locationdetail.ToListAsync();
            return getallLocation;
        }
        public async Task<bool> DeleteLocation(string Name)
        {
            var locationToBeDelete = await _context.Locationdetail.FirstOrDefaultAsync(v => v.Name == Name);
            if (locationToBeDelete != null)
            {

                     _context.Remove(locationToBeDelete);
                await _context.SaveChangesAsync();
              
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> updateLocation(LocationDTO location, int id)
        {
            var locationToUpdate = await _context.Locationdetail.FindAsync(id);

            if (locationToUpdate != null)
            {
                locationToUpdate.phone=location.phone;
                locationToUpdate.longitude=location.longitude;
                locationToUpdate.latitude=location.latitude;
                
                locationToUpdate.Name=location.Name;
               
                locationToUpdate.Address=location.Address;
                locationToUpdate.Company=location.Company;

               
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> AddLocation(LocationDTO location)
        {
            try
            {
                var newDetail = new LocationDetail
                {
                    phone = location.phone, 
                    longitude = location.longitude,
                    latitude = location.latitude,
                    Name = location.Name,
                    Address = location.Address,
                    Company = location.Company
                };

                _context.Locationdetail.Add(newDetail);


                await _context.SaveChangesAsync();

                return true;
            }
            catch 
            {
              
                return false;
            }
        }


        public async Task<LocationDetail> GetAllLocationbyid(string Name )
        {
            var data = await _context.Locationdetail.FirstOrDefaultAsync(o=>o.Name==Name);
            if (data != null)
            {
                return data;
            }

            else
            {
                return null;
            }
        }

    }
}
