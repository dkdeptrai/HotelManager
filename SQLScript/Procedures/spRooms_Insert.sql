-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.spRooms_Insert
	@RoomNum VARCHAR(20),
	@RoomType VARCHAR(50),
	@Price MONEY,
	@Overview IMAGE
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.Rooms(RoomNum, RoomType, Price, Overview, Booked)
	VALUES(@RoomNum, @RoomType, @Price, @Overview, 'No')

END
GO