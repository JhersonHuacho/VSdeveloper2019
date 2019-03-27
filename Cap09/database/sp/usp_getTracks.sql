CREATE PROCEDURE usp_GeTracks
(
@TrackName NVARCHAR(200)
)
AS
BEGIN
SELECT  C.TrackId, C.Name AS TrackName, 
		C.AlbumId, A.Title, 
		C.MediaTypeId, E.Name AS MediaTypeName, 
		C.GenreId, D.Name AS GenreName, C.Composer, B.ArtistId, 
        B.Name AS ArtistName, C.Milliseconds, C.Bytes, C.UnitPrice
FROM    dbo.Album AS A INNER JOIN
        dbo.Artist AS B ON A.ArtistId = B.ArtistId INNER JOIN
        dbo.Track AS C ON A.AlbumId = C.AlbumId INNER JOIN
        dbo.Genre AS D ON C.GenreId = D.GenreId INNER JOIN
        dbo.MediaType AS E ON C.MediaTypeId = E.MediaTypeId
WHERE	C.Name LIKE @TrackName

END