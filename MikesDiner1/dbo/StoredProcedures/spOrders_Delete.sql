CREATE PROCEDURE [dbo].[spOrders_Delete]
	@Id int 
AS
begin 
	set nocount on;

	DELETE from dbo.[Order]
	where Id = @Id;

end
