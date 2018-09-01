create database testauthen
go
use testauthen 
go

create table UserRole (
	ID int primary key not null,
	RoleName varchar(50) not null
);
INSERT INTO UserRole values ('11','Admin')
INSERT INTO UserRole  values ('22','User')

create table ApplicationUser (
	Id int primary key not null,
	EmailID varchar(50) not null,
	UserName varchar(50)not null,
	Password varchar(50),
	RoleId int  FOREIGN KEY REFERENCES UserRole(ID) not null 
);
INSERT INTO ApplicationUser values ('01','team6@gmail.com','team6','12345678','11')

create table Designation (
	Id int primary key not null,
	Name varchar(50) not null
);
INSERT INTO Designation values ('33','CEO')
INSERT INTO Designation values ('44','OSIN')

create table Employee (
	Id int primary key not null,
	EmloyeeName varchar(50) not null,
	DesignationId int FOREIGN KEY REFERENCES Designation(Id) not null,
	Address varchar(150) not null,
	Department varchar(50),
	Salary float  
);
INSERT INTO Employee values ('01','Osamabinladen','33','US','','5000')
INSERT INTO Employee values ('02','Obame','33','China','','15000')
INSERT INTO Employee values ('03','DonaldTrump','33','LAO','','25000')

drop table ApplicationUser ;