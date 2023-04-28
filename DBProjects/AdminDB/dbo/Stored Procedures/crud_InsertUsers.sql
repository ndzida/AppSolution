-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	Insert data to AdminDB.dbo.Users table
-- =============================================
CREATE PROCEDURE crud_InsertUsers 
	-- Add the parameters for the stored procedure here
    @Username varchar(100),
	@Email varchar(255),
	@PasswordHash varchar(200),
	@IsActive bit,
	@IsRegistered bit,
    @UserCreated varchar(20),
    @DateCreated datetime,
    @UserModified varchar(20),
    @DateModified datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Users
          (Username,
           Email,
           PasswordHash,
           IsActive,
           IsRegistered,
           UserCreated,
           DateCreated,
           UserModified,
           DateModified)
     VALUES
          (@Username,
           @Email,
           @PasswordHash,
           @IsActive,
           @IsRegistered,
           @UserCreated,
           @DateCreated,
           @UserModified,
           @DateModified)
END
