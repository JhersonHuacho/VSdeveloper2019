SELECT AlumnoID, Nombres, Apellidos, Direccion, Sexo, FechaNacimiento 
FROM Alumno WHERE Nombres LIKE @nombre

GO

CREATE PROCEDURE usp_InsertarAlumno
(
	@Nombres varchar(50),
	@Apellidos varchar(50),
	@Direccion varchar(100),
	@Sexo varchar(10),
	@FechaNacimiento Datetime
)
AS
BEGIN
 INSERT INTO Alumno (Nombres, Apellidos, Direccion, Sexo, FechaNacimiento)
 VALUES (@Nombres, @Apellidos, @Direccion, @Sexo, @FechaNacimiento)

 SELECT SCOPE_IDENTITY()

END

GO
SELECT * FROM Grado
SELECT * FROM Curso
GO
--usp_ReporteDeNotas 2, 1
GO
CREATE PROCEDURE usp_ReporteDeNotas
(
	@GradoID INT,
	@CursoID INT
)
AS
BEGIN
	SELECT Grado = G.Nivel, Curso = C.Nombre, Alumno = A.Nombres, N.Nota
	FROM Alumno A
	INNER JOIN Notas N ON A.AlumnoID = N.AlumnoID
	INNER JOIN Curso C ON N.CursoID = C.CursoID
	INNER JOIN Grado G ON C.GradoID = G.GradoID
	WHERE G.GradoID = @GradoID AND C.CursoID = @CursoID
END