CREATE DATABASE Hotel

CREATE TABLE Customers (
	CustomerID INT PRIMARY KEY IDENTITY,
	FullName VARCHAR(50),
	Gender VARCHAR(3),
	IdNumber VARCHAR(12),
	Birthday SMALLDATETIME,
	Email VARCHAR(50),
	PhoneNumber VARCHAR(10),
	HomeAddress VARCHAR(150)
)

CREATE TABLE Rooms (
	RoomID INT PRIMARY KEY IDENTITY,
	RoomNum VARCHAR(10),
	RoomType VARCHAR(20),
	Price MONEY,
	Booked VARCHAR(3) DEFAULT 'No',
	Overview IMAGE
)

CREATE TABLE RoomTypes (
	TypeID INT PRIMARY KEY IDENTITY,
	TypeName VARCHAR(20) UNIQUE,
)

INSERT INTO RoomTypes VALUES('Single')
INSERT INTO RoomTypes VALUES('Double')
INSERT INTO RoomTypes VALUES('Triple')
INSERT INTO RoomTypes VALUES('Premium')
INSERT INTO RoomTypes VALUES('Deluxe')




ALTER TABLE Rooms
ADD CONSTRAINT Booked_df DEFAULT 'No' FOR Booked
ALTER TABLE Rooms
ADD CONSTRAINT Overview_df DEFAULT NULL FOR Overview

CREATE TABLE RoomServices (
	ServiceID INT PRIMARY KEY IDENTITY,
	ServiceName VARCHAR(20) UNIQUE,
	Price MONEY
)

CREATE TABLE Staffs (
	StaffID INT PRIMARY KEY IDENTITY,
	FullName VARCHAR(50),
	Gender VARCHAR(3),
	Position VARCHAR(20),
	Email VARCHAR(50),
	PhoneNum VARCHAR(10),
	HomeAddress VARCHAR(150),
	LoginID VARCHAR(20),
	Password VARCHAR(50)
)

ALTER TABLE Staffs
ADD UNIQUE(LoginID)

CREATE TABLE Bookings (
	BookingID INT PRIMARY KEY IDENTITY,
	CustomerID INT REFERENCES Customers(CustomerID),
	RoomID INT REFERENCES Rooms(RoomID),
	CheckInTime SMALLDATETIME,
	CheckOutTime SMALLDATETIME
)

CREATE TABLE ServiceOrders (
	OrderID INT PRIMARY KEY IDENTITY,
	BookingID INT REFERENCES Bookings(BookingID),
	ServiceID INT REFERENCES RoomServices(ServiceID),
	Quantity INT,
	TotalCost MONEY
)

CREATE TABLE Bills (
	BillID INT PRIMARY KEY IDENTITY,
	CustomerID INT REFERENCES Customers(CustomerID),
	StaffID INT REFERENCES Staffs(StaffID),
	BookingID INT REFERENCES Bookings(BookingID),
	TotalCost MONEY
)