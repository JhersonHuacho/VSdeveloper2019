alter PROCEDURE usp_InsertAlbum
(
	@pTitle VARCHAR(10),
	@pArtistId INT
)
AS
BEGIN
	INSERT INTO Album (Title, ArtistId) 
	VALUES(@pTitle, @pArtistId)

	select SCOPE_IDENTITY()
END

GO

create PROCEDURE usp_UpdateAlbum
(
	@pAlbumId int,
	@pTitle VARCHAR(10),
	@pArtistId INT
)
AS
BEGIN
	update Album set Title = @pTitle, ArtistId = @pArtistId where AlbumId = @pAlbumId
END

GO

alter PROCEDURE usp_InsertCustomer
(
	@pFirstName VARCHAR(100),
	@pLastName VARCHAR(100),
	@pCompany VARCHAR(100),
	@pAddress VARCHAR(100),
	@pCity VARCHAR(100),
	@pState VARCHAR(100),
	@pCountry VARCHAR(100),
	@pPostalCode VARCHAR(100),
	@pPhone VARCHAR(100),
	@pFax VARCHAR(100),
	@pEmail VARCHAR(100),
	@pSupportRepId INT
)
AS
BEGIN

	INSERT INTO Customer (FirstName, LastName, Company, Address, City, State, Country, PostalCode, Phone, Fax, Email, SupportRepId)
	VALUES (@pFirstName,
	@pLastName,
	@pCompany,
	@pAddress,
	@pCity ,
	@pState ,
	@pCountry,
	@pPostalCode ,
	@pPhone,
	@pFax,
	@pEmail,
	@pSupportRepId)

	select SCOPE_IDENTITY()
END
GO

ALTER PROCEDURE usp_UpdateCustomer
(
	@pCustomerId int,
    @pFirstName varchar(100),
    @pLastName varchar(200)
)
AS
BEGIN
	update Customer set FirstName = @pFirstName,  LastName = @pLastName where CustomerId = @pCustomerId
END

GO

SELECT TOP 100 * FROM Customer

SELECT TOP 100 * FROM Album