CREATE PROCEDURE [dbo].[spRooms_View]
	@RoomNum VARCHAR(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Rooms
	WHERE RoomNum = @RoomNum
END
