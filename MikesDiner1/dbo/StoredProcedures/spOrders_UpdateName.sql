CREATE PROCEDURE [dbo].[spOrders_UpdateName]
	@Id int,
	@OrderName nvarchar(50)
AS
	set nocount on;

BEGIN 

	UPDATE dbo.[Order]
	SET OrderName = @OrderName
	WHERE Id = @Id;

end