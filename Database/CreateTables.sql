DROP TABLE Products;
DROP TABLE Orders;
DROP TABLE Customers;
DROP TABLE OrderItems;

CREATE TABLE Products
(
ProductID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
Name nvarchar(50),
);
CREATE TABLE Orders
(
OrderID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
Date datetime null,
CustomerID int NOT NULL,
 FOREIGN KEY( CustomerID ) references Customers (CustomerID)
);
CREATE TABLE Customers
(
CustomerID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
Name nvarchar(50),
StreetAddress nvarchar(50),
City nvarchar(50),
State nvarchar(50),
Zip nvarchar(50)
);
CREATE TABLE OrderItems
(
OrderID int IDENTITY(1,1) NOT NULL ,
ProductID int NOT NULL,
PRIMARY KEY(OrderID,ProductID)
);

