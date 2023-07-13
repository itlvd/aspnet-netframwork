create database webshopping

go
 
use webshopping

go

create table Category(
Id int primary key,
Title nvarchar(150),
Description nvarchar(150),
Position int,
SeoTitle nvarchar(250),
SeoDescription nvarchar(250),
SeoKeywords nvarchar(250),
CreateDate datetime,
CreateBy nvarchar(150),
ModifiedDate datetime,
ModifiedBy nvarchar(150)
);
go
create table Adv(
Id int primary key,
Title nvarchar(250),
Description nvarchar(500),
Image nvarchar(500),
Type int,
Link nvarchar(500),
CreateDate datetime,
CreateBy nvarchar(150),
ModifiedDate datetime,
ModifiedBy nvarchar(150)
);

go
create table Contact(
Id int primary key,
Name nvarchar(150),
Website nvarchar(150),
Email nvarchar(150),
Message nvarchar(4000),
IsRead bit,
CreateDate datetime,
CreateBy nvarchar(150),
ModifiedDate datetime,
ModifiedBy nvarchar(150)
);

go
create table ProductCategory(
Id int primary key,
Title nvarchar(150),
Description nvarchar(500),
Icon nvarchar(500),
CreateDate datetime,
CreateBy nvarchar(150),
ModifiedDate datetime,
ModifiedBy nvarchar(150)
);



go
create table Product(
Id int primary key,
Title nvarchar(150),
ProductCategoryId int,
Description nvarchar(4000),
Detail nvarchar(MAX),
Image nvarchar(500),
Price decimal(10,2),
PriceSale decimal(10,2),
Quantity int,
SeoTitle nvarchar(250),
SeoDescription nvarchar(250),
SeoKeywords nvarchar(250),
CreateDate datetime,
CreateBy nvarchar(150),
ModifiedDate datetime,
ModifiedBy nvarchar(150)
);


go
create table News(
Id int primary key,
Title nvarchar(150),
CategoryId int,
Description nvarchar(4000),
Detail nvarchar(MAX),
Image nvarchar(500),
SeoTitle nvarchar(250),
SeoDescription nvarchar(250),
SeoKeywords nvarchar(250),
CreateDate datetime,
CreateBy nvarchar(150),
ModifiedDate datetime,
ModifiedBy nvarchar(150)
);

go
create table Post(
Id int primary key,
Title nvarchar(150),
CategoryId int,
Description nvarchar(4000),
Detail nvarchar(MAX),
Image nvarchar(500),
SeoTitle nvarchar(250),
SeoDescription nvarchar(250),
SeoKeywords nvarchar(250),
CreateDate datetime,
CreateBy nvarchar(150),
ModifiedDate datetime,
ModifiedBy nvarchar(150)
);


go
create table [Order] (
Id int primary key,
Code nvarchar(50),
CustomerName nvarchar(150),
Phone nvarchar(15),
Address nvarchar(500),
TotalAmount decimal(18,0),
Quantity int,
CreateDate datetime,
CreateBy nvarchar(150),
ModifiedDate datetime,
ModifiedBy nvarchar(150)
);

go 
create table [OrderDetail] (
Id int primary key,
OrderId int,
ProductId int,
Price decimal(18,0),
Quantity int
);

go 
create table Subscribe (
Id int primary key,
Email nvarchar(150),
CreateDate datetime
);

go 
create table SystemSetting (
SettingKey nvarchar(50) primary key,
SettingValue nvarchar(MAX),
SettingDescription nvarchar(250)
);