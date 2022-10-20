CREATE PROCEDURE [dbo].[spOrders_GetByID]
	@Id int
AS
	

begin

	set nocount on;

	Select [Id], [OrderName], [OrderDate], [FoodId], [Total], [Quantity]
	FROM dbo.[Order]
	WHERE Id = @Id;

end
