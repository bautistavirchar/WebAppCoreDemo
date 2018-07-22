CREATE DATABASE DbDemo
use DbDemo

-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************

--************************************** [dbo].[Status]

CREATE TABLE [dbo].[Status]
(
 [Id]   INT IDENTITY(1,1) NOT NULL ,
 [Name] NVARCHAR(50) NOT NULL ,

 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

INSERT INTO dbo.Status([Name])
VALUES('Available'),('Out-of-stocked')

--************************************** [dbo].[Customers]

CREATE TABLE [dbo].[Customers]
(
 [Id]   INT IDENTITY(1,1) NOT NULL ,
 [Name] NVARCHAR(255) NOT NULL ,

 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO


--************************************** [dbo].[OrderedStatus]

CREATE TABLE [dbo].[OrderedStatus]
(
 [Id]   INT IDENTITY(1,1) NOT NULL ,
 [Name] NVARCHAR(50) NOT NULL ,

 CONSTRAINT [PK_OrderedStatus] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

INSERT INTO dbo.OrderedStatus([Name])
VALUES  ('Cancelled'),
        ('Delivered'),
        ('Reserved')

--************************************** [dbo].[Products]

CREATE TABLE [dbo].[Products]
(
 [Id]     INT IDENTITY(1,1) NOT NULL ,
 [Name]   NVARCHAR(255) NOT NULL ,
 [Status] INT NOT NULL ,

 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [FK_ProductStatus] FOREIGN KEY ([Status])
  REFERENCES [dbo].[Status]([Id])
);
GO


--SKIP Index: [fkIdx_60]


--************************************** [dbo].[OrderedItems]

CREATE TABLE [dbo].[OrderedItems]
(
 [Id]        INT IDENTITY(1,1) NOT NULL ,
 [Customer]  INT NOT NULL ,
 [Product]   INT NOT NULL ,
 [Status]    INT NOT NULL ,
 [TimeStamp] DATETIME NOT NULL ,

 CONSTRAINT [PK_OrderedItems] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [FK_Customer] FOREIGN KEY ([Customer])
  REFERENCES [dbo].[Customers]([Id]),
 CONSTRAINT [FK_Product] FOREIGN KEY ([Product])
  REFERENCES [dbo].[Products]([Id]),
 CONSTRAINT [FK_ItemStatus] FOREIGN KEY ([Status])
  REFERENCES [dbo].[OrderedStatus]([Id])
);
GO


--SKIP Index: [fkIdx_38]

--SKIP Index: [fkIdx_42]

--SKIP Index: [fkIdx_47]


