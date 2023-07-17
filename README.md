# Async-Inn

**Name:** Mhamad Belal yusef Al Msalma

**Today’s date:**  07/17/2023

## ERD diagram

![ERD diagram](./Assets/Lab11ERD.PNG)

## textual representation of the ERD diagram

Here's a textual representation of the ERD diagram for the Async Inn hotel chain:


Table: Hotel
- LocationID (Primary Key)
- Name
- City
- State
- Address
- PhoneNumber

Table: RoomLocation
- LocationID (Foreign Key to Location)
- RoomNumber (Foreign Key to Room)
- (Composite Primary Key)
- price

Table: Amenity
- AmenityID (Primary Key)
- Name
- Description

Table: Room
- RoomNumber (Primary Key)
- layout
- Nickname
- IsPetFriendly
- Enm {studio=0 , one_bedroom = 1, two_bedroom=3}

Table: RoomAmenity
- RoomNumber (Foreign Key to Room)
- AmenityID (Foreign Key to Amenity)
- (Composite Primary Key)




## Explanation of the components in the ERD diagram:

Here's the explanation of the components in the updated ERD diagram for the Async Inn hotel chain:

Table: Hotel

- The Hotel table represents the hotel locations and stores information such as the location ID, name, city, state, address, and phone number.
- The LocationID is the primary key of the Hotel table, uniquely identifying each hotel location.

Table: RoomLocation

- The RoomLocation table represents the relationship between hotels and rooms.
- It stores the LocationID and RoomNumber, forming a composite primary key, to associate rooms with each hotel location.
- The price attribute in the RoomLocation table represents the price of the room at a specific hotel location.

Table: Amenity

- The Amenity table represents the amenities available in the rooms.
- It stores information such as the AmenityID, name, and description.
- The AmenityID is the primary key of the Amenity table, uniquely identifying each amenity.

Table: Room

- The Room table represents individual rooms in the hotel and stores information such as the room number, layout, nickname, and pet-friendliness.
- The RoomNumber is the primary key of the Room table, uniquely identifying each room.
- The layout attribute represents the type of room layout (e.g., studio, one-bedroom, two-bedroom).
- The nickname attribute represents a customized name given to each room.
- The IsPetFriendly attribute indicates whether the room is pet-friendly or not.
- The Enm attribute represents an enum for the different room layouts, with values corresponding to the respective layouts (0 for studio, 1 for one-bedroom, 2 for two-bedroom).

Table: RoomAmenity

- The RoomAmenity table is a join table that represents the relationship between rooms and amenities.
- It stores the RoomNumber and AmenityID, forming a composite primary key, to associate amenities with each room.


In this ERD diagram, we have identified primary keys, foreign keys, composite keys, and the relationships between tables. The Hotel table has a one-to-many relationship with the RoomLocation table (one hotel can have multiple room locations), and the Room table has a one-to-many relationship with the RoomAmenity table (one room can have multiple amenities). Additionally, the Hotel table has a one-to-many relationship with the RoomLocation table through the LocationID.

