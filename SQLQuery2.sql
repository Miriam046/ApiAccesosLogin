CREATE DATABASE SistemaAcceso;
GO

-- Usar la base de datos recién creada
USE SistemaAcceso;
GO

-- Tabla: Residentes
CREATE TABLE Residentes (
    id_residente INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    apellido_paterno NVARCHAR(100) NOT NULL,
    apellido_materno NVARCHAR(100) NOT NULL,
    calle NVARCHAR(100),
    numero NVARCHAR(10),
    telefono NVARCHAR(20)
);

-- Tabla: Invitados
CREATE TABLE Invitados (
    id_invitado INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    apellido_paterno NVARCHAR(100) NOT NULL,
    apellido_materno NVARCHAR(100) NOT NULL,
    tipo_invitacion NVARCHAR(50),
    codigo NVARCHAR(100),
    fecha_validez DATE,
    estado NVARCHAR(50),
    id_residente INT NOT NULL,
    FOREIGN KEY (id_residente) REFERENCES Residentes(id_residente)
);

-- Tabla: Codigos
CREATE TABLE Codigos (
    codigo NVARCHAR(100) PRIMARY KEY,
    id_residenteS INT NOT NULL,
    FOREIGN KEY (id_residenteS) REFERENCES Residentes(id_residente)
);

-- Tabla: Guardias
CREATE TABLE Guardias (
    id_guardia INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    apellido_paterno NVARCHAR(100) NOT NULL,
    apellido_materno NVARCHAR(100) NOT NULL
);

-- Tabla: Accesos
CREATE TABLE Accesos (
    id_acceso INT PRIMARY KEY IDENTITY(1,1),
    fecha DATE,
    tipo_acceso NVARCHAR(50),
    id_residente INT NULL,
    id_invitado INT NULL,
    id_guardia INT NOT NULL,
    FOREIGN KEY (id_residente) REFERENCES Residentes(id_residente),
    FOREIGN KEY (id_invitado) REFERENCES Invitados(id_invitado),
    FOREIGN KEY (id_guardia) REFERENCES Guardias(id_guardia)
);

-- Tabla: UsuariosResidentes
CREATE TABLE UsuariosResidentes (
    id_usuario INT PRIMARY KEY IDENTITY(1,1),
    id_residente INT NOT NULL,
    correo NVARCHAR(150) NOT NULL,
    contraseña NVARCHAR(150) NOT NULL,
    FOREIGN KEY (id_residente) REFERENCES Residentes(id_residente)
);