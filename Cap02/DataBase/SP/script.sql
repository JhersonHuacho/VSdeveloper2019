CREATE PROCEDURE usp_GetArtist
(
	@pNombre NVARCHAR(100)
)
AS
BEGIN
	SELECT ArtistId, Name FROM Artist WHERE Name LIKE @pNombre
END

GO

CREATE PROCEDURE usp_InsertArtist
(
	@Name NVARCHAR(120)
)
AS
BEGIN
	INSERT INTO Artist (Name) VALUES (@Name)
	SELECT SCOPE_IDENTITY()
END

GO

CREATE PROCEDURE usp_InsertArtistWithOutput
(
	@Name NVARCHAR(120),
	@ID INT OUTPUT
)
AS
BEGIN
	INSERT INTO Artist (Name) VALUES (@Name)
	SET @ID = SCOPE_IDENTITY()
END

GO

CREATE PROCEDURE usp_GetGenre
(
	@pNombre NVARCHAR(100)
)
AS
BEGIN
	SELECT GenreId, Name FROM Genre WHERE Name LIKE @pNombre
END

GO
CREATE PROCEDURE usp_InsertGenre
(
	@pNombre NVARCHAR(120)
)
AS
BEGIN
	INSERT INTO Genre(Name) VALUES (@pNombre)
	SELECT SCOPE_IDENTITY()
END

GO

select * from Artist order by ArtistId desc
select * from Artist with (nolock) order by ArtistId desc -- transacción no confirmada
select * from Genre order by GenreId desc