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

---

## Introduction to your web app

The Async Inn Hotel Asset Management System is a web-based API that assists Async Inn, a local hotel chain, in efficiently managing their hotel assets at various locations. The project's primary goal is to create a RESTful API server, enabling the management of rooms, amenities, and the addition of new hotel locations. The system utilizes a relational database to store and ensure data integrity.

## Relations between tables

**Hotel table:**

* LocationID (Primary Key) uniquely identifies each hotel.
* Each hotel has a Name, City, State, Address, and PhoneNumber.

**RoomLocation table:**

* The LocationID (Foreign Key to Location) links to the Hotel table, indicating which hotel the room is in.
* The RoomNumber (Foreign Key to Room) links to the Room table, indicating the specific room within the hotel.
* The combination of LocationID and RoomNumber forms a Composite Primary Key, ensuring uniqueness.
* The price column represents the price of that particular room at the given location.

**Amenity table:**

* AmenityID (Primary Key) uniquely identifies each amenity.
* Each amenity has a Name and Description.

**Room table:**

* RoomNumber (Primary Key) uniquely identifies each room within the system.
* The layout column may store information about the room's physical layout (e.g., single, double, suite).
* The Nickname column might be used to give the room a custom name.
* The IsPetFriendly column indicates whether the room is pet-friendly or not.
* The Enm column appears to represent an enumeration, with values 0, 1, or 3, corresponding to different room types (e.g., studio, one-bedroom, two-bedroom).

**RoomAmenity table:**

* The RoomNumber (Foreign Key to Room) links to the Room table, specifying which room the amenity is associated with.
* The AmenityID (Foreign Key to Amenity) links to the Amenity table, specifying which amenity is associated with the room.
* The combination of RoomNumber and AmenityID forms a Composite Primary Key, ensuring uniqueness.

---

## Repository Design Pattern in Hotel Management Application

### Architecture Pattern: Repository Design Pattern

The Repository Design Pattern is a widely used architectural pattern that helps in separating the business logic from the data access layer in an application. It provides an abstraction layer between the application and the data source (e.g., a database or an external service), allowing the application to interact with data without having to know the underlying implementation details. The pattern promotes a clean and maintainable codebase by organizing data access operations in a central repository.

### How it is used in the Hotel Management Application:

In the Hotel Management Application, the Repository Design Pattern is employed to handle the data access operations for entities such as Hotel, Amenity, and Room. The pattern is implemented using the IbaseRepo interface, which contains the CRUD (Create, GetAll, GetbyId, Update, Delete) operations that all repositories for different entities must implement. Each entity (Hotel, Amenity, and Room) has its own repository class that implements the IbaseRepo interface, providing specific implementations for interacting with the data source.
