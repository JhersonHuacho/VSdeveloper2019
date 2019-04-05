 exec usp_GetTrack '%'
go

CREATE PROCEDURE usp_GetTrack
(
@name NVARCHAR(200)
)
AS
BEGIN
SELECT      A.TrackId, A.Name as TrackName,
	A.AlbumId, B.Title, A.MediaTypeId,
	 F.Name AS MediaTypeName, A.GenreId, D.Name AS GenreName, B.ArtistId, 
            C.Name AS ArtistName
FROM        dbo.Track AS A INNER JOIN
    dbo.Album AS B ON A.AlbumId =  B.AlbumId INNER JOIN
    dbo.Artist AS C ON B.ArtistId = C.ArtistId INNER JOIN
    dbo.Genre AS D ON A.GenreId = D.GenreId INNER JOIN
    dbo.MediaType AS F ON A.MediaTypeId = F.MediaTypeId

END