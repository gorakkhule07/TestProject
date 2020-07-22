CREATE TABLE [dbo].[contact] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [FirstName]   VARCHAR (45) NULL,
    [LastName]    VARCHAR (45) NULL,
    [PhoneNumber] VARCHAR(50)   NULL,
    [Status]      VARCHAR (45) NULL,
    [Email]       VARCHAR(45)   NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO

CREATE PROCEDURE [dbo].SP_Contacts_D_ById_contact(
	@iId int 
	 )
AS
BEGIN
	update contact set Status = 'InActive' where Id= @iId;
END

GO

CREATE PROCEDURE [dbo].SP_Contacts_G_ALL_contact
AS
BEGIN
	select * from contact;
END

GO

CREATE PROCEDURE [dbo].SP_Contacts_G_ById_contact
	@iId int
AS
BEGIN
	select * from contact where Id = @iId;
END

GO

CREATE PROCEDURE [dbo].SP_Contacts_G_Email_count
(
 @iId int,
 @iEmail varchar(45)
 )
AS
BEGIN

	IF @iId = 0
		BEGIN
			select count(*) from contact where LOWER(Email) = LOWER(@iEmail);
		END
	ELSE
		BEGIN
		   select count(*) from contact where LOWER(Email)= LOWER(@iEmail) and Id <> @iId;
		end;
	

END


GO
CREATE PROCEDURE [dbo].SP_Contacts_I_contact(
@iEmail Varchar(45),
@iFirstName Varchar(45),
@iLastName Varchar(45),
@iPhoneNumber Varchar(45),
@iStatus Varchar(45)
)
	
AS
	BEGIN
		insert into contact(
		FirstName,
		LastName,
		PhoneNumber,
		Status,
		Email
		)
		values(
		@iFirstName,
		@iLastName,
		@iPhoneNumber,
		@iStatus,
		@iEmail
		);

	END
	
GO

CREATE PROCEDURE [dbo].SP_Contacts_U_contact
(
@iId int,
@iEmail Varchar(45),
@iFirstName Varchar(45),
@iLastName Varchar(45),
@iPhoneNumber Varchar(45),
@iStatus Varchar(45)
)
AS
BEGIN
UPDATE  
contact SET
FirstName=@iFirstName,
LastName=@iLastName,
PhoneNumber=@iPhoneNumber,
Status=@iStatus,
Email=@iEmail where Id=@iId;

END