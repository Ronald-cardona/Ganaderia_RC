CREATE DATABASE GanaderiaRC
GO
USE GanaderiaRC



CREATE TABLE Usuarios (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR (50) NOT NULL,
	Apellido NVARCHAR (50) NOT NULL,
	Correo NVARCHAR (50) NOT NULL,
	Telefono NVARCHAR (20) NOT NULL,
	Contraseña NVARCHAR (20) NOT NULL,
	Activo BIT DEFAULT 1,
	Fecha DATETIME NOT NULL



	)

	CREATE TABLE Roles (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Tipo NVARCHAR (20) NOT NULL,
	RolUsuario INT UNIQUE NOT NULL,

	CONSTRAINT Fk_RolUsuario FOREIGN KEY (RolUsuario)
	REFERENCES Usuarios(Id)

	)

CREATE TABLE Configuraciones(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Idioma NVARCHAR (20) NOT NULL,
	Moneda NVARCHAR (20) NOT NULL,
	Tema BIT DEFAULT 1 NOT NULL,
	UsuarioId INT UNIQUE  NOT NULL,

	CONSTRAINT Fk_ConfiguracionUsuario FOREIGN KEY (UsuarioId)
	REFERENCES Usuarios(Id)
	)

CREATE TABLE Fincas(    --esta relacionada con empleados y LugarAnimales 
	Id INT PRIMARY KEY IDENTITY(1,1),
	Codigo NVARCHAR (20) NOT NULL,
	Nombre NVARCHAR (50) NOT NULL,
	Direcccion NVARCHAR (50) NOT NULL,
	ExtensionMetro DECIMAL(18,4) NOT NULL,

	
	)

CREATE TABLE Personas(  --esta relacionada con gastos, veterinarios y trabajadores
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR (50) NOT NULL,
	Apellido NVARCHAR (50) NOT NULL,
	Cedula NVARCHAR (20) NOT NULL,
	Telefono NVARCHAR (20) NOT NULL,
	Sueldo DECIMAL(14,2) NOT NULL,
	Activo BIT DEFAULT 1 NOT NULL,

	)


CREATE TABLE Ingresos(  --esta relacionada con Ventas
	Id INT PRIMARY KEY IDENTITY(1,1),
	FechaIngreso DATETIME NOT NULL,
	CantidadIngreso DECIMAL(14,2) NOT NULL,
	DescripcionIngreso NVARCHAR (200) 
	
	)

CREATE TABLE Lotes(  --esta relacionada con Animales 
	Id INT PRIMARY KEY IDENTITY(1,1),
	Codigo NVARCHAR(30) NOT NULL,
	FechaCreacion DATETIME NOT NULL,
	CantidadAnimales INT NOT NULL

	)


CREATE TABLE Proveedores(  --esta relacionada con subasta, natural y compras 
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(100) NOT NULL,
	Telefono NVARCHAR(20) NOT NULL,
	Direccion NVARCHAR(100) NOT NULL

	)

CREATE TABLE Clientes (  --esta relacionada con subasta, natural y ventas 
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(100) NOT NULL,
	Telefono NVARCHAR(20) NOT NULL,
	Direccion NVARCHAR(100) NOT NULL

	)

CREATE TABLE LugarAnimales (  --esta relacionada con potreros , corrales y animales 

	Id INT PRIMARY KEY IDENTITY(1,1),
	Codigo NVARCHAR(100) NOT NULL,
	Metros DECIMAL(14,2) NOT NULL,
	Direccion NVARCHAR(100) NOT NULL,
	FechaIngreso DATETIME NOT NULL,
	FechaSalida DATETIME,
	FincaId INT NOT NULL,

	CONSTRAINT FK_LugaresFinca FOREIGN KEY (FincaId)
	REFERENCES Fincas(Id)
	)

CREATE TABLE Ventas (  --esta relacionada con ingresos , Clientes y animales  

	Id INT PRIMARY KEY IDENTITY(1,1),
	FechaVenta DATETIME NOT NULL,
	PesoFinal DECIMAL(6,2) NOT NULL,
	PrecioKilo DECIMAL(14,2),
	DescripcionVenta NVARCHAR(200) NOT NULL,

	IngresoId INT NOT NULL,
	ClienteId INT NOT NULL,

	CONSTRAINT FK_IngresoVenta FOREIGN KEY (IngresoId)
	REFERENCES Ingresos(Id),
	CONSTRAINT FK_ClienteVenta FOREIGN KEY (ClienteId)
	REFERENCES Clientes(Id)

	)

CREATE TABLE Compras (  --esta relacionada con gastos  , proveedores y animales  

	Id INT PRIMARY KEY IDENTITY(1,1),
	FechaCompra DATETIME NOT NULL,
	PesoCompra DECIMAL(6,2) NOT NULL,
	PrecioKilo DECIMAL(14,2),
	Descripcioncompra NVARCHAR(200) NOT NULL,

	ProveedorId INT NOT NULL,

	CONSTRAINT FK_ProveedorVenta FOREIGN KEY (ProveedorId)
	REFERENCES Proveedores(Id)


	)

CREATE TABLE Alimentos  (   

	Id INT PRIMARY KEY IDENTITY(1,1),
	TipoAlimento NVARCHAR(50) NOT NULL,
	CostoAlimento DECIMAL(14,2) NOT NULL,
	CantidadAlimento DECIMAL(7,2) NOT NULL,
	FechaCompraAlimento DATETIME NOT NULL
	)

CREATE TABLE Vacunas  (  --esta relacionada con aplicacionVacunas , Gastos.

	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(50) NOT NULL,
	CostoVacuna DECIMAL(14,2) NOT NULL,
	LoteVacuna NVARCHAR(50) NOT NULL,
	FechaCompraVacuna DATETIME NOT NULL
	)

CREATE TABLE Suplementos  (  --esta relacionada con brindarSuplemento , Gastos.

	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(50) NOT NULL,
	CostoSuplemento DECIMAL(14,2) NOT NULL,
	CantidadSuplemento DECIMAL(7,2) NOT NULL,
	FechaCompraSuplemento DATETIME NOT NULL

	)

CREATE TABLE Gastos  (  --esta relacionada con brindarSuplemento , Gastos.

	Id INT PRIMARY KEY IDENTITY(1,1),
	CostoGasto DECIMAL(14,2) NOT NULL,
	FechaGasto DATETIME NOT NULL,
	DescripcionGasto NVARCHAR(200) NOT NULL,

	CompraId INT NOT NULL,
	AlimentoId INT NOT NULL,
	VacunaId INT NOT NULL,
	SuplementoId INT NOT NULL,
	PersonaId INT NOT NULL,

	CONSTRAINT FK_GastoCompra FOREIGN KEY (CompraId)
	REFERENCES Compras(Id),
	CONSTRAINT FK_GastoAlimento FOREIGN KEY (AlimentoId)
	REFERENCES Alimentos(Id),
	CONSTRAINT FK_GastoVacuna FOREIGN KEY (VacunaId)
	REFERENCES Vacunas(Id),
	CONSTRAINT FK_GastoSuplemento FOREIGN KEY (SuplementoId)
	REFERENCES Suplementos(Id),
	CONSTRAINT FK_GastoPersona FOREIGN KEY (PersonaId)
	REFERENCES Personas(Id)

	)

CREATE TABLE Estados (
    Id INT PRIMARY KEY IDENTITY(1,1),
    descripcion NVARCHAR(20) UNIQUE

    );

INSERT INTO Estados VALUES 
(1, 'en la finca'),
(2, 'vendido'),
(3, 'muerto');

CREATE TABLE Animales (  

	Id INT PRIMARY KEY IDENTITY(1,1),
	Codigo NVARCHAR(15)NOT NULL,
	PesoInicial DECIMAL(6,2) NOT NULL,
	Raza NVARCHAR(30) NOT NULL,
	Edad INT NOT NULL,
	Sexo BIT DEFAULT 1 NOT NULL, --1:hembra 0 :macho

	EstadoId INT NOT NULL,
	LoteId INT NOT NULL,
	CompraId INT NOT NULL,
	VentaId INT NOT NULL,
	LugarAnimalId INT NOT NULL,

	CONSTRAINT FK_EstadoAnimal FOREIGN KEY (EstadoId)
	REFERENCES Estados(Id),
	CONSTRAINT FK_LoteAnimal FOREIGN KEY (LoteId)
	REFERENCES Lotes(Id),
	CONSTRAINT FK_CompraAnimal FOREIGN KEY (CompraId)
	REFERENCES Compras(Id),
	CONSTRAINT FK_VentaAnimal FOREIGN KEY (VentaId)
	REFERENCES Ventas(Id),
	CONSTRAINT FK_LugarAnimal FOREIGN KEY (LugarAnimalId)
	REFERENCES LugarAnimales(Id)


	)
	

CREATE TABLE HistorialPesos (  --esta relacionada con potreros , corrales y animales  

	Id INT PRIMARY KEY IDENTITY(1,1),
	FechaUltimoPesaje DATETIME NOT NULL,
	FechaPesajeActual DATETIME ,
	UltimoPeso DECIMAL(6,2) NOT NULL,
	PesoActual DECIMAL(6,2),

	IdAnimal INT NOT NULL,

	CONSTRAINT FK_PesoAnimal FOREIGN KEY (IdAnimal)
	REFERENCES Animales(Id)

	)



	--TABLAS POR HERENCIA -->  1:N


CREATE TABLE Veterinarios (

	Id INT PRIMARY KEY IDENTITY(1,1),

	IdPersona INT NOT NULL,

	CONSTRAINT FK_PVeterinario FOREIGN KEY (IdPersona)
	REFERENCES Personas(Id)


	)

CREATE TABLE Empleados (

	Id INT PRIMARY KEY IDENTITY(1,1),

	IdPersona INT NOT NULL,
	IdFinca INT NOT NULL,

	CONSTRAINT FK_PEmpleado FOREIGN KEY (IdPersona)
	REFERENCES Personas(Id),

	CONSTRAINT FK_FincaEmpleado FOREIGN KEY (IdFinca)
	REFERENCES Fincas(Id)


	)

CREATE TABLE PersonasNaturalesP (   --personas a las que compramos ganado

	Id INT PRIMARY KEY IDENTITY(1,1),
	Cedula NVARCHAR(18),

	IdProveedor INT NOT NULL,

	CONSTRAINT FK_ProveedorNatural FOREIGN KEY (IdProveedor)
	REFERENCES Proveedores(Id),

	)


CREATE TABLE SubastasP (   --Subastas a las que compramos ganado

	Id INT PRIMARY KEY IDENTITY(1,1),

	IdProveedor INT NOT NULL,

	CONSTRAINT FK_ProveedorSubasta FOREIGN KEY (IdProveedor)
	REFERENCES Proveedores(Id),

	)



CREATE TABLE PersonasNaturalesC (   --personas a las que le vendemos ganado

	Id INT PRIMARY KEY IDENTITY(1,1),
	Cedula NVARCHAR(18),

	IdCliente INT NOT NULL,

	CONSTRAINT FK_ClienteNatural FOREIGN KEY (IdCliente)
	REFERENCES Clientes(Id),

	)


CREATE TABLE SubastasC (   --Subastas  a las que le vendemos ganado

	Id INT PRIMARY KEY IDENTITY(1,1),
	
	IdCliente INT NOT NULL,

	CONSTRAINT FK_ClienteSubasta FOREIGN KEY (IdCliente)
	REFERENCES Clientes(Id),

	)

CREATE TABLE Corrales (  

	Id INT PRIMARY KEY IDENTITY(1,1),
	
	IdLugarAnimal INT NOT NULL,

	CONSTRAINT FK_LugarCorral FOREIGN KEY (IdLugarAnimal)
	REFERENCES LugarAnimales(Id),

	)

CREATE TABLE Potreros (   

	Id INT PRIMARY KEY IDENTITY(1,1),
	
	IdLugarAnimal INT NOT NULL,

	CONSTRAINT FK_LugarPotrero FOREIGN KEY (IdLugarAnimal)
	REFERENCES LugarAnimales(Id),

	)





	--TABLAS MUCHOS A MUCHOS 


CREATE TABLE AplicacionVacunas (  

	FechaAplicacion DATETIME NOT NULL,

	IdAnimal INT NOT NULL,
	VacunaId INT NOT NULL,

	PRIMARY KEY(IdAnimal,VacunaId),

	CONSTRAINT FK_AnimalVacunado FOREIGN KEY (IdAnimal)
	REFERENCES Animales(Id),
	CONSTRAINT FK_VacunaAnimal FOREIGN KEY (VacunaId)
	REFERENCES Vacunas(Id)

	)

CREATE TABLE VisitasVeterinarias (  

	FechaVisita DATETIME NOT NULL,

	IdAnimal INT NOT NULL,
	VeterinarioId INT NOT NULL,

	PRIMARY KEY(IdAnimal,VeterinarioId),

	CONSTRAINT FK_VisitaVeterinaria FOREIGN KEY (IdAnimal)
	REFERENCES Animales(Id),
	CONSTRAINT FK_VisitaVeterinario FOREIGN KEY (VeterinarioId)
	REFERENCES Veterinarios(Id)

	)

CREATE TABLE BrindarAlimentos (  

	FechaBrindarAlimentos DATETIME NOT NULL,

	IdAnimal INT NOT NULL,
	AlimentoId INT NOT NULL,

	PRIMARY KEY(IdAnimal,AlimentoId),

	CONSTRAINT FK_AnimalAlimentado FOREIGN KEY (IdAnimal)
	REFERENCES Animales(Id),
	CONSTRAINT FK_AlimentoAnimal FOREIGN KEY (AlimentoId)
	REFERENCES Alimentos(Id)

	)


CREATE TABLE BrindarSuplementos (  

	FechaBrindarSuplemetos DATETIME NOT NULL,

	IdAnimal INT NOT NULL,
	SuplementoId INT NOT NULL,

	PRIMARY KEY(IdAnimal,SuplementoId),

	CONSTRAINT FK_AnimalSuplementado FOREIGN KEY (IdAnimal)
	REFERENCES Animales(Id),
	CONSTRAINT FK_SuplementoAnimal FOREIGN KEY (SuplementoId)
	REFERENCES Suplementos(Id)

	)