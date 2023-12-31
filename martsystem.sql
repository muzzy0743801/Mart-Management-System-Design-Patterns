USE [Mart_System]
GO
/****** Object:  StoredProcedure [dbo].[Customer_Delete]    Script Date: 05-Dec-18 1:59:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Customer_Delete]

@ID AS NUMERIC

AS

DELETE FROM Customer
WHERE ID = @ID

GO
/****** Object:  StoredProcedure [dbo].[Customer_Insert_Update]    Script Date: 05-Dec-18 1:59:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Customer_Insert_Update]

@ID AS NUMERIC, 
@Name AS VARCHAR(100),
@Contact AS VARCHAR(100)

AS 

DECLARE @ReturnValue int 

IF (@ID IS NULL) -- New Item 
BEGIN 
 INSERT INTO Customer
 (Name, Contact) 
 VALUES 
 (@Name, @Contact)
 
 SELECT @ReturnValue = SCOPE_IDENTITY() 
END
ELSE
BEGIN 
 UPDATE Customer
 SET   
 Name=@Name, 
 Contact=@Contact

 WHERE ID = @ID
  
 SELECT @ReturnValue = @ID 
END  
 IF (@@ERROR !=0)
BEGIN
 RETURN -1
END
ELSE 

BEGIN 
 RETURN @ReturnValue 
END

GO
/****** Object:  StoredProcedure [dbo].[OrderPlace_Delete]    Script Date: 05-Dec-18 1:59:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[OrderPlace_Delete]

@ID AS NUMERIC

AS

DELETE FROM OrderPlace
WHERE ID = @ID

GO
/****** Object:  StoredProcedure [dbo].[OrderPlace_Insert_Update]    Script Date: 05-Dec-18 1:59:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[OrderPlace_Insert_Update]

@ID AS NUMERIC, 
@FK_Customer_ID AS NUMERIC,
@FK_Product_ID AS NUMERIC,
@OrderPrice AS float,
@OrderQuantity AS NUMERIC

AS 

DECLARE @ReturnValue int 

IF (@ID IS NULL) -- New Item 
BEGIN 
 INSERT INTO OrderPlace
 (FK_Customer_ID, FK_Product_ID, OrderPrice, OrderQuantity) 
 VALUES 
 (@FK_Customer_ID, @FK_Product_ID, @OrderPrice, @OrderQuantity)
 
 SELECT @ReturnValue = SCOPE_IDENTITY() 
END
ELSE
BEGIN 
 UPDATE OrderPlace
 SET   
 FK_Customer_ID=@FK_Customer_ID, 
 FK_Product_ID=@FK_Product_ID, 
 OrderPrice=@OrderPrice, 
 OrderQuantity=@OrderQuantity

 WHERE ID = @ID
  
 SELECT @ReturnValue = @ID 
END  
 IF (@@ERROR !=0)
BEGIN
 RETURN -1
END
ELSE 

BEGIN 
 RETURN @ReturnValue 
END

GO
/****** Object:  StoredProcedure [dbo].[Product_Delete]    Script Date: 05-Dec-18 1:59:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Product_Delete]

@ID AS NUMERIC

AS

DELETE FROM Product
WHERE ID = @ID

GO
/****** Object:  Table [dbo].[Cashier]    Script Date: 05-Dec-18 1:59:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cashier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PIN] [nvarchar](50) NOT NULL,
	[Contact] [nvarchar](11) NULL,
	[Salary] [nvarchar](50) NULL,
	[Address] [nvarchar](150) NULL,
	[Email] [nvarchar](128) NULL,
	[JoinDate] [datetime] NULL,
	[Status] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CashierLoginRecord]    Script Date: 05-Dec-18 1:59:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashierLoginRecord](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CashierName] [nvarchar](50) NOT NULL,
	[LoginDate] [nvarchar](50) NULL,
	[LoginTime] [nvarchar](50) NULL,
	[LogoutDate] [nvarchar](50) NULL,
	[LogoutTime] [nvarchar](50) NULL,
	[SalesOfProduct] [nvarchar](50) NULL,
	[TotalOfSales] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 05-Dec-18 1:59:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Contact] [varchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Login]    Script Date: 05-Dec-18 1:59:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderPlace]    Script Date: 05-Dec-18 1:59:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderPlace](
	[ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[FK_Customer_ID] [numeric](18, 0) NULL,
	[FK_Product_ID] [numeric](18, 0) NULL,
	[OrderPrice] [float] NULL,
	[OrderQuantity] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 05-Dec-18 1:59:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
	[Barcode] [nvarchar](50) NULL,
	[Quantity] [nvarchar](50) NULL,
	[Price] [nvarchar](50) NULL,
	[Image] [image] NULL,
	[Detail] [text] NULL,
	[ManufactureDate] [date] NULL,
	[ExpireDate] [date] NULL,
	[Status] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sales]    Script Date: 05-Dec-18 1:59:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CashierName] [nvarchar](50) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[CustomerName] [nvarchar](50) NOT NULL,
	[Quantity] [nvarchar](50) NULL,
	[Discount] [nvarchar](50) NULL,
	[Price] [nvarchar](50) NULL,
	[TotalPrice] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[Time] [nvarchar](50) NULL,
	[Total] [int] NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[OrderPlace]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([FK_Customer_ID])
REFERENCES [dbo].[Customer] ([ID])
GO
ALTER TABLE [dbo].[OrderPlace] CHECK CONSTRAINT [FK_Order_Customer]
GO
