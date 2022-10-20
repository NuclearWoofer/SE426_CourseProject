CREATE PROCEDURE [dbo].[spOrders_Inserts]
	@OrderName nvarchar(50),
	@OrderDate datetime2(7),
	@FoodId int,
	@Quantity int,
	@Total float,
	@Id int output

AS

begin
	set nocount on;

	Insert Into dbo.[Order](OrderName,OrderDate, FoodId, Quantity, Total)
	values (@OrderName,@OrderDate,@FoodId,@Quantity,@Total);

	set @Id = SCOPE_IDENTITY();

end
