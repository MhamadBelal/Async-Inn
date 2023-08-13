using AsyncInn.Models.DTOs;
using AsyncInn.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncInnTests
{
    public class Lab19Tests : Mock
    {
        [Fact]
        public async void Test_Create_Amenity_Object()
        {
            var Amenity = await CreateAndSaveTestAmenity();
            var Service = new AmenitiesService(_db);

            var AmenityDTO = new AmenityDTO()
            {
                ID = Amenity.ID
            };

            await Service.Create(AmenityDTO);

            var actualHotel = await Service.GetbyId(AmenityDTO.ID);

            Assert.NotEqual(0, actualHotel.ID);
        }

        [Fact]
        public async void get_All_Amenity()
        {
            var Amenities = await getAllAmenitiesTest();

            var Service = new AmenitiesService(_db);

            var AmenitiesFromService = await Service.GetAll();

            Assert.Equal(AmenitiesFromService.Count, Amenities.Count);

        }

        [Fact]
        public async void get_A_Specific_Amenity_Test()
        {
            var Amenity = await CreateAndSaveTestAmenity();

            var Service = new AmenitiesService(_db);

            var AmenitiesFromService = await Service.GetbyId(Amenity.ID);

            Assert.NotNull(AmenitiesFromService);

        }


        [Fact]
        public async void Test_Amenity_Hotel_Object()
        {
            var amenity = await CreateAndSaveTestAmenity();

            var updatedAmenity = await UpdateAndSaveAmenityTest(amenity.ID);

            var updatedAmenityDTO = new AmenityDTO()
            {
                ID = updatedAmenity.ID,
                Name = updatedAmenity.Name
            };

            var Service = new AmenitiesService(_db);

            var Name = "updateTest";

            var UpdatedAmenity = await Service.Update(amenity.ID, updatedAmenityDTO);

            Assert.Equal(Name, UpdatedAmenity.Name);

        }
    }
}
