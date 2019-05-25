create database UsuariosDb
go
use UsuariosDb
go
create table Usuarios
(
	UsuarioId int primary key identity,
	Nombre varchar(30),
	Email varchar(max),
	NivelUsuario varchar(30),
	Usuario varchar(30),
	Clave varchar(30),
	FechaIngreso Datetime
)

CREATE TABLE Cargos
(
	CargosId int primary key identity,
	Descripcion varchar(max)
)