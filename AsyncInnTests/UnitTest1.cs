using AsyncInn.Models;
using AsyncInn.Models.DTOs;
using AsyncInn.Models.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace AsyncInnTests
{
    public class UnitTest1 : Mock
    {
        #region Room Tests
        [Fact]
        public async void Test_Create_Room_Object()
        {
            var Room = await CreateAndSaveTestRoom();
            var Service = new RoomsService(_db);

            var RoomDTO = new RoomDTO()
            {
                Name = Room.Name,
                Layout = Room.Layout.ToString()
            };

            await Service.Create(RoomDTO);

            var actualRoom = await Service.GetbyId(RoomDTO.ID);

            Assert.NotEqual(0, actualRoom.ID);
        }


        [Fact]
        public async void Test_Delete_Room_Object()
        {
            var room = await CreateAndSaveTestRoom();

            var Service = new RoomsService(_db);

            var beforeDeletedRoom = await Service.GetAll();

            Assert.Equal(4, beforeDeletedRoom.Count);


            await Service.Delete(room.ID);

            var afterDeletedRoom = await Service.GetAll();

            Assert.Equal(3, afterDeletedRoom.Count);
        }



        [Fact]
        public async void Test_Update_Room_Object()
        {
            var room = await CreateAndSaveTestRoom();

            var updatedRoom = await UpdateAndSaveRoomTest(room.ID);

            var updatedRoomDTO = new RoomDTO()
            {
                ID= updatedRoom.ID,
                Name= updatedRoom.Name,
                Layout= updatedRoom.Layout.ToString()
            };

            var Service = new RoomsService(_db);

            var Name = "updateTest";

            var UpdatedRoom = await Service.Update(room.ID, updatedRoomDTO);

            Assert.Equal(Name, UpdatedRoom.Name);

        }


        [Fact]
        public async void Add_Amenity_To_Room_Test()
        {
            var Room=await CreateAndSaveTestRoom();
            var Amenity=await CreateAndSaveTestAmenity();
            var RoomAmenity = await AddAmenityToRoomTest(Room.ID,Amenity.ID);
            var Service = new RoomsService(_db);

            Assert.NotNull(RoomAmenity);

        }


        [Fact]
        public async void Remove_Amenity_From_Room_Test()
        {
            var Room = await CreateAndSaveTestRoom();
            var Amenity = await CreateAndSaveTestAmenity();

            var RoomAmenity = await AddAmenityToRoomTest(Room.ID, Amenity.ID);

            await RemoveAmentityFromRoomTest(Room.ID, Amenity.ID);

            var AmenityBeforeDelete = await _db.RoomAmenities.FirstOrDefaultAsync(x => x.AmenityID == Amenity.ID && x.RoomID == Room.ID); ;


            Assert.Null(AmenityBeforeDelete);

        }


        [Fact]
        public async void get_All_Romms()
        {
            var Rooms = await getAllRoomsTest();

            var Service = new RoomsService(_db);

            var RoomsFromService =await Service.GetAll();

            Assert.Equal(RoomsFromService.Count, Rooms.Count);

        }

        [Fact]
        public async void get_A_Specific_Room_Test()
        {
            var Room = await CreateAndSaveTestRoom();

            var Service = new RoomsService(_db);

            var RoomsFromService = await Service.GetbyId(Room.ID);

            Assert.NotNull(RoomsFromService);

        }
        #endregion


        #region Hotel Tests
        [Fact]
        public async void Test_Create_Hotel_Object()
        {
            var Hotel = await CreateAndSaveTestHotel();
            var Service = new HotelsSevice(_db);

            var HotelDTO = new HotelDTO()
            {
                ID=Hotel.ID,
                Name = Hotel.Name,
                StreetAddress= Hotel.StreetAddress,
                City= Hotel.City,
                State=Hotel.State,
                Phone=Hotel.Phone
            };

            await Service.Create(HotelDTO);

            var actualHotel = await Service.GetbyId(HotelDTO.ID);

            Assert.NotEqual(0, actualHotel.ID);
        }


        [Fact]
        public async void Test_Delete_Hotel_Object()
        {
            var hotel = await CreateAndSaveTestHotel();

            var Service = new HotelsSevice(_db);

            var beforeDeletedHotel = await Service.GetAll();

            Assert.Equal(4, beforeDeletedHotel.Count);


            await Service.Delete(hotel.ID);

            var afterDeletedHotel = await Service.GetAll();

            Assert.Equal(3, afterDeletedHotel.Count);
        }



        [Fact]
        public async void Test_Update_Hotel_Object()
        {
            var hotel = await CreateAndSaveTestHotel();

            var updatedHotel = await UpdateAndSaveHotelTest(hotel.ID);

            var updatedHotelDTO = new HotelDTO()
            {
                ID = updatedHotel.ID,
                Name = updatedHotel.Name,
                StreetAddress= updatedHotel.StreetAddress,
                City= updatedHotel.City,
                State= updatedHotel.State,
                Phone= updatedHotel.Phone
            };

            var Service = new HotelsSevice(_db);

            var Name = "updateTest";

            var UpdatedRoom = await Service.Update(hotel.ID, updatedHotelDTO);

            Assert.Equal(Name, UpdatedRoom.Name);

        }

        [Fact]
        public async void get_All_Hotels()
        {
            var Hotels = await getAllHotelsTest();

            var Service = new HotelsSevice(_db);

            var HotelsFromService = await Service.GetAll();

            Assert.Equal(HotelsFromService.Count, Hotels.Count);

        }

        [Fact]
        public async void get_A_Specific_Hotel_Test()
        {
            var Hotel = await CreateAndSaveTestHotel();

            var Service = new HotelsSevice(_db);

            var HotelsFromService = await Service.GetbyId(Hotel.ID);

            Assert.NotNull(HotelsFromService);

        }
        #endregion
    }
}