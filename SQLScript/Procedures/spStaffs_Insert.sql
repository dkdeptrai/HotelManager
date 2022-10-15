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
CREATE PROCEDURE dbo.spStaffs_Insert 
	@FullName VARCHAR(50),
	@Gender VARCHAR(3),
	@Position VARCHAR(20),
	@Email VARCHAR(50),
	@PhoneNum VARCHAR(10),
	@HomeAddress VARCHAR(150),
	@LoginID VARCHAR(20),
	@Password VARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.Staffs(FullName, Gender, Position, Email, PhoneNum, HomeAddress, LoginID, Password)
	VALUES(@FullName, @Gender, @Position, @Email, @PhoneNum, @HomeAddress, @LoginID, @Password)
END
GO
