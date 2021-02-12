# ShopBridge
Change App config connection string with DB details

Add Table

CREATE TABLE [dbo].[Inventory] ( [ID] INT IDENTITY (1, 1) NOT NULL, [Name] VARCHAR (100) NULL, [Description] VARCHAR (100) NULL, [Price] DECIMAL (18) NULL, [ImagePath] VARCHAR (100) NULL, PRIMARY KEY CLUSTERED ([ID] ASC) );

procs

create procedure spDeleteInventory
(
@ID int
)
as
begin
Delete from Inventory where ID=@ID
End

create procedure spGetAllInventories as Begin select * from Inventory End

Create procedure spGetInventory
(
@ID int
)
as
begin
select * from Inventory where ID=@ID
End

CREATE procedure spSaveInventory ( @Name nvarchar(50), @Price decimal, @Description nvarchar(100), @ImagePath nvarchar(50) ) as Begin Insert into Inventory(Name,Price, Description,ImagePath)
Values (@Name,@Price,@Description, @ImagePath) End
