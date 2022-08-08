USE [master];
GO

CREATE DATABASE [inocureport_db];
GO


CREATE TABLE [dbo].[Clinica] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [nombre]           VARCHAR (50)  NOT NULL,
    [cedula_juridica]  VARCHAR (50)  NOT NULL,
    [pais]             VARCHAR (50)  NOT NULL,
    [estado_provincia] VARCHAR (50)  NOT NULL,
    [distrito]         VARCHAR (50)  NULL,
    [telefono]         VARCHAR (50)  NOT NULL,
    [email]            VARCHAR (50)  NOT NULL,
    [sitio_web]        VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Inyeccion] (
    [Id]                INT           IDENTITY (1, 1) NOT NULL,
    [nombre]            VARCHAR (50)  NOT NULL,
    [marca]             VARCHAR (50)  NOT NULL,
    [fecha_aplicacion]  DATE          NOT NULL,
    [numero_lote]       VARCHAR (50)  NOT NULL,
    [fecha_vencimiento] DATE          NOT NULL,
    [lugar_aplicacion]  VARCHAR (50)  NOT NULL,
    [observaciones]     VARCHAR (500) NOT NULL,
    [cuestionario]      VARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Medico] (
    [Id]                 INT          IDENTITY (1, 1) NOT NULL,
    [identificacion]     VARCHAR (50) NOT NULL,
    [codigo_profesional] VARCHAR (50) NOT NULL,
    [nombre_completo]    VARCHAR (50) NOT NULL,
    [email]              VARCHAR (50) NOT NULL,
    [pais]               VARCHAR (50) NOT NULL,
    [estado_provincia]   VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Paciente] (
    [Id]                INT          IDENTITY (1, 1) NOT NULL,
    [identificacion]    VARCHAR (50) NOT NULL,
    [nombre]            VARCHAR (50) NOT NULL,
    [primer_apellido]   VARCHAR (50) NOT NULL,
    [segundo_apellido]  VARCHAR (50) NOT NULL,
    [fecha_nacimiento]  DATE         NOT NULL,
    [sexo_natural]      VARCHAR (50) NOT NULL,
    [telefono_contacto] VARCHAR (50) NOT NULL,
    [pais]              VARCHAR (50) NOT NULL,
    [estado_provincia]  VARCHAR (50) NOT NULL,
    [distrito]          VARCHAR (50) NULL,
    [estado_civil]      VARCHAR (50) NOT NULL,
    [telefono_personal] VARCHAR (50) NOT NULL,
    [email]             VARCHAR (50) NOT NULL,
    [fecha_registro]    DATE         NOT NULL,
    [ocupacion]         VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Reporte] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [codigo_registro] VARCHAR (50)  NOT NULL,
    [id_medico]       INT           NOT NULL,
    [id_clinica]      INT           NULL,
    [id_paciente]     INT           NOT NULL,
    [id_inyeccion]    INT           NOT NULL,
    [cuestionario]    VARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([id_medico]) REFERENCES [dbo].[Medico] ([Id]),
    FOREIGN KEY ([id_clinica]) REFERENCES [dbo].[Clinica] ([Id]),
    FOREIGN KEY ([id_paciente]) REFERENCES [dbo].[Paciente] ([Id]),
    FOREIGN KEY ([id_inyeccion]) REFERENCES [dbo].[Inyeccion] ([Id])
);

CREATE PROCEDURE GetClinicaByCedula
	@cedula_juridica varchar(50)

as 
begin
select * from Clinica 
where Clinica.cedula_juridica =@cedula_juridica;
end

CREATE PROCEDURE GetClinicaByNombre
	@nombre varchar(50)



as 
begin
select * from Clinica 
where Clinica.nombre =@nombre;
end

CREATE PROCEDURE GetClinicas



as 
begin
select * from Clinica 
end

CREATE PROCEDURE GetInyeccionById
	@id int



as 
begin
select * from Inyeccion 
where Inyeccion.Id =@id;
end

CREATE PROCEDURE GetMedicoByCodigoProfesional
	@codigo_profesional varchar(50) 



as 
begin
select * from Medico 
where Medico.codigo_profesional =@codigo_profesional;
end

CREATE PROCEDURE GetMedicoByIdentificacion
	@identificacion varchar(50) 



as 
begin
select * from Medico 
where Medico.identificacion =@identificacion;
end

create procedure GetMedicos

as 
begin
select * from Medico
end

CREATE PROCEDURE GetPacienteByIdentificacion
	@identificacion varchar(50)



as 
begin
select * from Paciente 
where Paciente.identificacion =@identificacion;
end


CREATE PROCEDURE GetPacientes



as 
begin
select * from Paciente 
end

CREATE PROCEDURE GetReporteByCodigoRegistro
	@codigo_registro varchar(50)



as 
begin
select * from Reporte 
where Reporte.codigo_registro =@codigo_registro;
end

CREATE PROCEDURE GetReporteById
	@id int



as 
begin
select * from Reporte 
where Reporte.Id =@id;
end

create procedure GetReportes

as 
begin
select * from Reporte
end

CREATE procedure GuardarClinica
@nombre varchar(50),
@cedula_juridica varchar(50),
@pais varchar(50),
@estado_provincia varchar(50),
@distrito varchar(50),
@telefono varchar(50),
@email varchar(50),
@sitio_web varchar(100)

as 
begin
insert into Clinica(nombre,cedula_juridica,pais,estado_provincia,distrito,telefono,email,sitio_web)
output INSERTED.ID
values(@nombre,@cedula_juridica,@pais,@estado_provincia,@distrito,@telefono,@email,@sitio_web)
end

CREATE procedure GuardarInyeccion
@nombre varchar(50),
@marca varchar(50),
@fecha_aplicacion date,
@numero_lote varchar(50),
@fecha_vencimiento date,
@lugar_aplicacion varchar(50),
@observaciones varchar(500),
@cuestionario varchar(MAX)

as 
begin
insert into Inyeccion(nombre,marca,fecha_aplicacion,numero_lote,fecha_vencimiento,lugar_aplicacion,observaciones,cuestionario)
output INSERTED.ID
values(@nombre,@marca,@fecha_aplicacion,@numero_lote,@fecha_vencimiento,@lugar_aplicacion,@observaciones,@cuestionario)
end

CREATE procedure GuardarMedico
@identificacion varchar(50),
@codigo_profesional varchar(50),
@nombre_completo varchar(50),
@email varchar(50),
@pais varchar(50),
@estado_provincia varchar(50)

as 
begin
insert into Medico(identificacion,codigo_profesional,nombre_completo,email,pais,estado_provincia)
output INSERTED.ID
values(@identificacion,@codigo_profesional,@nombre_completo,@email,@pais,@estado_provincia)
end

CREATE procedure GuardarPaciente
@identificacion varchar(50),
@nombre varchar(50),
@primer_apellido varchar(50),
@segundo_apellido varchar(50),
@fecha_nacimiento date,
@sexo_natural varchar(50),
@telefono_contacto varchar(50),
@pais varchar(50),
@estado_provincia varchar(50),
@distrito varchar(50),
@estado_civil varchar(50),
@telefono_personal varchar(50),
@email varchar(50),
@ocupacion varchar(50)

as 
begin
insert into Paciente(identificacion,nombre,primer_apellido,segundo_apellido,fecha_nacimiento,sexo_natural,telefono_contacto,pais,estado_provincia,distrito,estado_civil,telefono_personal,email,fecha_registro,ocupacion)
output INSERTED.ID
values(@identificacion,@nombre,@primer_apellido,@segundo_apellido,@fecha_nacimiento,@sexo_natural,@telefono_contacto,@pais,@estado_provincia,@distrito,@estado_civil,@telefono_personal,@email,GETDATE(),@ocupacion)
end


CREATE procedure GuardarReporte
@codigo_registro varchar(50),
@id_medico int,
@id_clinica int,
@id_paciente int,
@id_inyeccion int,
@cuestionario varchar(MAX)

as 
begin
insert into Reporte(codigo_registro,id_medico,id_clinica,id_paciente,id_inyeccion,cuestionario)
output INSERTED.ID
values(@codigo_registro,@id_medico,@id_clinica,@id_paciente,@id_inyeccion,@cuestionario)
end


