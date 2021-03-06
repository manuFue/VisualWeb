USE [_PAV_COD]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 06/22/2016 16:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[idLogin] [int] IDENTITY(1,1) NOT NULL,
	[nombreUsuario] [nvarchar](50) NULL,
	[password] [nchar](10) NULL,
	[activo] [bit] NULL,
	[idPermiso] [int] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[idLogin] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON
INSERT [dbo].[Usuarios] ([idLogin], [nombreUsuario], [password], [activo], [idPermiso]) VALUES (1, N'admin', N'123       ', 1, 1)
INSERT [dbo].[Usuarios] ([idLogin], [nombreUsuario], [password], [activo], [idPermiso]) VALUES (2, N'juan', N'123       ', 1, 3)
INSERT [dbo].[Usuarios] ([idLogin], [nombreUsuario], [password], [activo], [idPermiso]) VALUES (3, N'maria', N'123       ', 1, 2)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
/****** Object:  Table [dbo].[turnos]    Script Date: 06/22/2016 16:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[turnos](
	[idPaciente] [int] NOT NULL,
	[fecha] [smalldatetime] NOT NULL,
	[hora] [time](0) NOT NULL,
	[codEmpleado] [int] NULL,
	[asignado] [bit] NULL,
 CONSTRAINT [PK_turnos] PRIMARY KEY CLUSTERED 
(
	[idPaciente] ASC,
	[fecha] ASC,
	[hora] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[turnos] ([idPaciente], [fecha], [hora], [codEmpleado], [asignado]) VALUES (5, CAST(0xA5A00000 AS SmallDateTime), CAST(0x00F0D20000000000 AS Time), 8, 0)
INSERT [dbo].[turnos] ([idPaciente], [fecha], [hora], [codEmpleado], [asignado]) VALUES (5, CAST(0xA62E0000 AS SmallDateTime), CAST(0x00A08C0000000000 AS Time), 12, 1)
INSERT [dbo].[turnos] ([idPaciente], [fecha], [hora], [codEmpleado], [asignado]) VALUES (5, CAST(0xA62E0000 AS SmallDateTime), CAST(0x0000E10000000000 AS Time), 11, 1)
INSERT [dbo].[turnos] ([idPaciente], [fecha], [hora], [codEmpleado], [asignado]) VALUES (6, CAST(0xA60D0000 AS SmallDateTime), CAST(0x00F0D20000000000 AS Time), 11, 1)
INSERT [dbo].[turnos] ([idPaciente], [fecha], [hora], [codEmpleado], [asignado]) VALUES (6, CAST(0xA62E0000 AS SmallDateTime), CAST(0x0080700000000000 AS Time), 3, 1)
INSERT [dbo].[turnos] ([idPaciente], [fecha], [hora], [codEmpleado], [asignado]) VALUES (6, CAST(0xA62E0000 AS SmallDateTime), CAST(0x00B09A0000000000 AS Time), 10, 1)
INSERT [dbo].[turnos] ([idPaciente], [fecha], [hora], [codEmpleado], [asignado]) VALUES (6, CAST(0xA62E0000 AS SmallDateTime), CAST(0x00E0C40000000000 AS Time), 11, 0)
INSERT [dbo].[turnos] ([idPaciente], [fecha], [hora], [codEmpleado], [asignado]) VALUES (6, CAST(0xA65A0000 AS SmallDateTime), CAST(0x00A08C0000000000 AS Time), 10, 1)
INSERT [dbo].[turnos] ([idPaciente], [fecha], [hora], [codEmpleado], [asignado]) VALUES (6, CAST(0xA6A00000 AS SmallDateTime), CAST(0x00A08C0000000000 AS Time), 10, 1)
INSERT [dbo].[turnos] ([idPaciente], [fecha], [hora], [codEmpleado], [asignado]) VALUES (7, CAST(0xA62E0000 AS SmallDateTime), CAST(0x0020FD0000000000 AS Time), 8, 0)
INSERT [dbo].[turnos] ([idPaciente], [fecha], [hora], [codEmpleado], [asignado]) VALUES (7, CAST(0xA62E0000 AS SmallDateTime), CAST(0x00300B0100000000 AS Time), 11, 1)
INSERT [dbo].[turnos] ([idPaciente], [fecha], [hora], [codEmpleado], [asignado]) VALUES (8, CAST(0xA67F0000 AS SmallDateTime), CAST(0x0010EF0000000000 AS Time), 8, 1)
INSERT [dbo].[turnos] ([idPaciente], [fecha], [hora], [codEmpleado], [asignado]) VALUES (9, CAST(0xA6660000 AS SmallDateTime), CAST(0x00F0D20000000000 AS Time), 11, 1)
INSERT [dbo].[turnos] ([idPaciente], [fecha], [hora], [codEmpleado], [asignado]) VALUES (9, CAST(0xA6E70000 AS SmallDateTime), CAST(0x00A08C0000000000 AS Time), 12, 1)
INSERT [dbo].[turnos] ([idPaciente], [fecha], [hora], [codEmpleado], [asignado]) VALUES (12, CAST(0xA62E0000 AS SmallDateTime), CAST(0x00C0A80000000000 AS Time), 3, 1)
INSERT [dbo].[turnos] ([idPaciente], [fecha], [hora], [codEmpleado], [asignado]) VALUES (12, CAST(0xA62E0000 AS SmallDateTime), CAST(0x00E0C40000000000 AS Time), 2, 0)
INSERT [dbo].[turnos] ([idPaciente], [fecha], [hora], [codEmpleado], [asignado]) VALUES (12, CAST(0xA62E0000 AS SmallDateTime), CAST(0x00F0D20000000000 AS Time), 11, 1)
INSERT [dbo].[turnos] ([idPaciente], [fecha], [hora], [codEmpleado], [asignado]) VALUES (12, CAST(0xA63A0000 AS SmallDateTime), CAST(0x00907E0000000000 AS Time), 5, 1)
INSERT [dbo].[turnos] ([idPaciente], [fecha], [hora], [codEmpleado], [asignado]) VALUES (13, CAST(0xA62E0000 AS SmallDateTime), CAST(0x00907E0000000000 AS Time), 10, 0)
INSERT [dbo].[turnos] ([idPaciente], [fecha], [hora], [codEmpleado], [asignado]) VALUES (14, CAST(0xA62E0000 AS SmallDateTime), CAST(0x00B09A0000000000 AS Time), 5, 1)
INSERT [dbo].[turnos] ([idPaciente], [fecha], [hora], [codEmpleado], [asignado]) VALUES (14, CAST(0xA6BF0000 AS SmallDateTime), CAST(0x00907E0000000000 AS Time), 3, 0)
INSERT [dbo].[turnos] ([idPaciente], [fecha], [hora], [codEmpleado], [asignado]) VALUES (15, CAST(0xA69B0000 AS SmallDateTime), CAST(0x00E0C40000000000 AS Time), 2, 1)
INSERT [dbo].[turnos] ([idPaciente], [fecha], [hora], [codEmpleado], [asignado]) VALUES (16, CAST(0xA62E0000 AS SmallDateTime), CAST(0x00A08C0000000000 AS Time), 10, 1)
INSERT [dbo].[turnos] ([idPaciente], [fecha], [hora], [codEmpleado], [asignado]) VALUES (16, CAST(0xA62E0000 AS SmallDateTime), CAST(0x00B09A0000000000 AS Time), 3, 1)
INSERT [dbo].[turnos] ([idPaciente], [fecha], [hora], [codEmpleado], [asignado]) VALUES (16, CAST(0xA62E0000 AS SmallDateTime), CAST(0x00D0B60000000000 AS Time), 12, 0)
/****** Object:  Table [dbo].[tratamientos]    Script Date: 06/22/2016 16:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tratamientos](
	[idTratamiento] [int] IDENTITY(1,1) NOT NULL,
	[descripcionTratamiento] [nvarchar](50) NULL,
	[costo] [numeric](18, 0) NULL,
 CONSTRAINT [PK_tratamientos] PRIMARY KEY CLUSTERED 
(
	[idTratamiento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tratamientos] ON
INSERT [dbo].[tratamientos] ([idTratamiento], [descripcionTratamiento], [costo]) VALUES (1, N'Ortodoncia', CAST(1000 AS Numeric(18, 0)))
INSERT [dbo].[tratamientos] ([idTratamiento], [descripcionTratamiento], [costo]) VALUES (2, N'Implantologia', CAST(3000 AS Numeric(18, 0)))
INSERT [dbo].[tratamientos] ([idTratamiento], [descripcionTratamiento], [costo]) VALUES (3, N'Odontologia', CAST(500 AS Numeric(18, 0)))
INSERT [dbo].[tratamientos] ([idTratamiento], [descripcionTratamiento], [costo]) VALUES (4, N'Periodoncia', CAST(2000 AS Numeric(18, 0)))
INSERT [dbo].[tratamientos] ([idTratamiento], [descripcionTratamiento], [costo]) VALUES (5, N'Estetica Dental', CAST(2000 AS Numeric(18, 0)))
INSERT [dbo].[tratamientos] ([idTratamiento], [descripcionTratamiento], [costo]) VALUES (6, N'Endodoncia', CAST(2500 AS Numeric(18, 0)))
INSERT [dbo].[tratamientos] ([idTratamiento], [descripcionTratamiento], [costo]) VALUES (7, N'Cirugia Oral', CAST(5000 AS Numeric(18, 0)))
SET IDENTITY_INSERT [dbo].[tratamientos] OFF
/****** Object:  Table [dbo].[tipoDocumentos]    Script Date: 06/22/2016 16:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoDocumentos](
	[idTD] [int] IDENTITY(1,1) NOT NULL,
	[descripcionTD] [nvarchar](50) NULL,
 CONSTRAINT [PK_tipoDocumentos] PRIMARY KEY CLUSTERED 
(
	[idTD] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tipoDocumentos] ON
INSERT [dbo].[tipoDocumentos] ([idTD], [descripcionTD]) VALUES (1, N'DNI')
INSERT [dbo].[tipoDocumentos] ([idTD], [descripcionTD]) VALUES (2, N'Cedula')
INSERT [dbo].[tipoDocumentos] ([idTD], [descripcionTD]) VALUES (3, N'LE')
INSERT [dbo].[tipoDocumentos] ([idTD], [descripcionTD]) VALUES (4, N'LC')
INSERT [dbo].[tipoDocumentos] ([idTD], [descripcionTD]) VALUES (5, N'Pasaporte')
SET IDENTITY_INSERT [dbo].[tipoDocumentos] OFF
/****** Object:  Table [dbo].[proveedores]    Script Date: 06/22/2016 16:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedores](
	[idProveedor] [int] IDENTITY(4,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
	[nombreResponsable] [nvarchar](50) NULL,
	[cuit] [nvarchar](50) NULL,
	[telefono] [nvarchar](50) NULL,
	[celular] [nvarchar](50) NULL,
	[eMail] [nvarchar](50) NULL,
	[idLocalidad] [int] NULL,
	[calle] [nvarchar](50) NULL,
	[nroCalle] [int] NULL,
	[piso] [int] NULL,
	[departamento] [nvarchar](50) NULL,
	[fechaAlta] [smalldatetime] NULL,
	[activo] [bit] NULL,
 CONSTRAINT [PK_proveedores] PRIMARY KEY CLUSTERED 
(
	[idProveedor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[proveedores] ON
INSERT [dbo].[proveedores] ([idProveedor], [nombre], [nombreResponsable], [cuit], [telefono], [celular], [eMail], [idLocalidad], [calle], [nroCalle], [piso], [departamento], [fechaAlta], [activo]) VALUES (1, N'Luis', N'InsumosDen SA', N'20-12321654-6', N'767567657', N'121212342', N'insumosSA@gmail.com', 1, N'Salta', 100, 1, N'1', CAST(0x8FD20000 AS SmallDateTime), 0)
INSERT [dbo].[proveedores] ([idProveedor], [nombre], [nombreResponsable], [cuit], [telefono], [celular], [eMail], [idLocalidad], [calle], [nroCalle], [piso], [departamento], [fechaAlta], [activo]) VALUES (2, N'Matias', N' Dentales ', N'32-65478932-5', N'123654789', N'987456321', N'dent@gmail.com', 2, N'San Luis', 40, 0, N'0', CAST(0x90510000 AS SmallDateTime), 0)
INSERT [dbo].[proveedores] ([idProveedor], [nombre], [nombreResponsable], [cuit], [telefono], [celular], [eMail], [idLocalidad], [calle], [nroCalle], [piso], [departamento], [fechaAlta], [activo]) VALUES (3, N'angel', N'limpro', N'45-52369687-5', N'654987321', N'321654897', N'limpro@gmail.com', 1, N'la Rioja ', 465, 2, N'0', CAST(0x86310000 AS SmallDateTime), 1)
INSERT [dbo].[proveedores] ([idProveedor], [nombre], [nombreResponsable], [cuit], [telefono], [celular], [eMail], [idLocalidad], [calle], [nroCalle], [piso], [departamento], [fechaAlta], [activo]) VALUES (4, N'Rodrigo', N'ProtesisDentales', N'12-45698771-6', N'789654123', N'654987123', N'ProtesisDentales@hotmail.com', 5, N'CordobA', 456, 0, N'0', CAST(0xA5BD0000 AS SmallDateTime), 1)
INSERT [dbo].[proveedores] ([idProveedor], [nombre], [nombreResponsable], [cuit], [telefono], [celular], [eMail], [idLocalidad], [calle], [nroCalle], [piso], [departamento], [fechaAlta], [activo]) VALUES (5, N'Matias', N'Garcia SA', N'23-21456798-3', N'369852147', N'753159753', N'garma@gmail.com', 5, N' Rio Negro', 462, 0, N'0', CAST(0xA4300000 AS SmallDateTime), 1)
SET IDENTITY_INSERT [dbo].[proveedores] OFF
/****** Object:  Table [dbo].[Permisos]    Script Date: 06/22/2016 16:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos](
	[idPermiso] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](50) NULL,
 CONSTRAINT [PK_Permisos] PRIMARY KEY CLUSTERED 
(
	[idPermiso] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Permisos] ON
INSERT [dbo].[Permisos] ([idPermiso], [descripcion]) VALUES (1, N'Administrador')
INSERT [dbo].[Permisos] ([idPermiso], [descripcion]) VALUES (2, N'Especialista')
INSERT [dbo].[Permisos] ([idPermiso], [descripcion]) VALUES (3, N'Usuario')
SET IDENTITY_INSERT [dbo].[Permisos] OFF
/****** Object:  Table [dbo].[pacientes]    Script Date: 06/22/2016 16:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pacientes](
	[idPaciente] [int] IDENTITY(1,1) NOT NULL,
	[nroDoc] [int] NULL,
	[idTipoDoc] [int] NULL,
	[nombre] [nvarchar](50) NULL,
	[apellido] [nvarchar](50) NULL,
	[sexo] [bit] NULL,
	[fechaNacimiento] [smalldatetime] NULL,
	[idLocalidad] [int] NULL,
	[telefono] [nvarchar](50) NULL,
	[celular] [nvarchar](50) NULL,
	[calle] [nvarchar](50) NULL,
	[nroCalle] [int] NULL,
	[piso] [int] NULL,
	[departamento] [nvarchar](50) NULL,
 CONSTRAINT [PK_pacientes] PRIMARY KEY CLUSTERED 
(
	[idPaciente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[pacientes] ON
INSERT [dbo].[pacientes] ([idPaciente], [nroDoc], [idTipoDoc], [nombre], [apellido], [sexo], [fechaNacimiento], [idLocalidad], [telefono], [celular], [calle], [nroCalle], [piso], [departamento]) VALUES (5, 22222222, 3, N'Nicolas', N'Otamendi', 1, CAST(0x81F50000 AS SmallDateTime), 6, N'', N'', N'avenida', 50, 0, N'')
INSERT [dbo].[pacientes] ([idPaciente], [nroDoc], [idTipoDoc], [nombre], [apellido], [sexo], [fechaNacimiento], [idLocalidad], [telefono], [celular], [calle], [nroCalle], [piso], [departamento]) VALUES (6, 11111111, 1, N'Sergio', N'Romero', 1, CAST(0x80680000 AS SmallDateTime), 5, N'4702020', N'3511234567', N'calle', 100, 10, N'a7')
INSERT [dbo].[pacientes] ([idPaciente], [nroDoc], [idTipoDoc], [nombre], [apellido], [sexo], [fechaNacimiento], [idLocalidad], [telefono], [celular], [calle], [nroCalle], [piso], [departamento]) VALUES (7, 33333333, 1, N'Ramiro', N'Funes Mori', 1, CAST(0x84ED0000 AS SmallDateTime), 9, N'', N'', N'autopista', 500, 0, N'')
INSERT [dbo].[pacientes] ([idPaciente], [nroDoc], [idTipoDoc], [nombre], [apellido], [sexo], [fechaNacimiento], [idLocalidad], [telefono], [celular], [calle], [nroCalle], [piso], [departamento]) VALUES (8, 44444444, 5, N'Javier', N'Mascherano ', 1, CAST(0x7C7D0000 AS SmallDateTime), 8, N'4567897', N'3514875926', N'Av Evergreen', 578, 0, N'')
INSERT [dbo].[pacientes] ([idPaciente], [nroDoc], [idTipoDoc], [nombre], [apellido], [sexo], [fechaNacimiento], [idLocalidad], [telefono], [celular], [calle], [nroCalle], [piso], [departamento]) VALUES (9, 55555555, 5, N'Matias', N'Kranevitter', 1, CAST(0x7E0A0000 AS SmallDateTime), 6, N'', N'', N'sin salida', 777, 0, N'')
INSERT [dbo].[pacientes] ([idPaciente], [nroDoc], [idTipoDoc], [nombre], [apellido], [sexo], [fechaNacimiento], [idLocalidad], [telefono], [celular], [calle], [nroCalle], [piso], [departamento]) VALUES (10, 66666666, 3, N'Lucas', N'Biglia ', 1, CAST(0x81040000 AS SmallDateTime), 6, N'', N'03514687', N'calle', 147, 7, N'b9')
INSERT [dbo].[pacientes] ([idPaciente], [nroDoc], [idTipoDoc], [nombre], [apellido], [sexo], [fechaNacimiento], [idLocalidad], [telefono], [celular], [calle], [nroCalle], [piso], [departamento]) VALUES (12, 88888888, 1, N'Jesica', N'Cirio', 0, CAST(0x7FD60000 AS SmallDateTime), 4, N'1235467', N'987654321', N'doble mano', 159, 5, N'c2')
INSERT [dbo].[pacientes] ([idPaciente], [nroDoc], [idTipoDoc], [nombre], [apellido], [sexo], [fechaNacimiento], [idLocalidad], [telefono], [celular], [calle], [nroCalle], [piso], [departamento]) VALUES (13, 99999999, 4, N'Ingrid', N'Grudke', 0, CAST(0x7D1B0000 AS SmallDateTime), 5, N'', N'', N'sin asfaltar', 20, 0, N'')
INSERT [dbo].[pacientes] ([idPaciente], [nroDoc], [idTipoDoc], [nombre], [apellido], [sexo], [fechaNacimiento], [idLocalidad], [telefono], [celular], [calle], [nroCalle], [piso], [departamento]) VALUES (14, 10101010, 1, N'Liz', N'Solari', 0, CAST(0x81820000 AS SmallDateTime), 9, N'', N'', N'asfaltada', 159, 0, N'')
INSERT [dbo].[pacientes] ([idPaciente], [nroDoc], [idTipoDoc], [nombre], [apellido], [sexo], [fechaNacimiento], [idLocalidad], [telefono], [celular], [calle], [nroCalle], [piso], [departamento]) VALUES (15, 12345678, 1, N'Gabriel', N'Batistuta', 1, CAST(0xA4CE0000 AS SmallDateTime), 2, N'', N'', N'autopista', 100, 0, N'')
INSERT [dbo].[pacientes] ([idPaciente], [nroDoc], [idTipoDoc], [nombre], [apellido], [sexo], [fechaNacimiento], [idLocalidad], [telefono], [celular], [calle], [nroCalle], [piso], [departamento]) VALUES (16, 32165498, 5, N'Luciana', N'Aimar', 0, CAST(0xA3990000 AS SmallDateTime), 10, N'1235467', N'3511234', N'calle', 159, 105, N'b9')
SET IDENTITY_INSERT [dbo].[pacientes] OFF
/****** Object:  Table [dbo].[localidades]    Script Date: 06/22/2016 16:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[localidades](
	[idLoc] [int] IDENTITY(1,1) NOT NULL,
	[descripcionLoc] [varchar](100) NOT NULL,
 CONSTRAINT [PK__localida__3213E83F1273C1CD] PRIMARY KEY CLUSTERED 
(
	[idLoc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[localidades] ON
INSERT [dbo].[localidades] ([idLoc], [descripcionLoc]) VALUES (1, N'Cordoba Capital')
INSERT [dbo].[localidades] ([idLoc], [descripcionLoc]) VALUES (2, N'Cruz del Eje')
INSERT [dbo].[localidades] ([idLoc], [descripcionLoc]) VALUES (3, N'Villa Maria')
INSERT [dbo].[localidades] ([idLoc], [descripcionLoc]) VALUES (4, N'Carlos Paz')
INSERT [dbo].[localidades] ([idLoc], [descripcionLoc]) VALUES (5, N'Rio Ceballos')
INSERT [dbo].[localidades] ([idLoc], [descripcionLoc]) VALUES (6, N'Mina Clavero')
INSERT [dbo].[localidades] ([idLoc], [descripcionLoc]) VALUES (7, N'Rio Cuarto')
INSERT [dbo].[localidades] ([idLoc], [descripcionLoc]) VALUES (8, N'Rio Segundo')
INSERT [dbo].[localidades] ([idLoc], [descripcionLoc]) VALUES (9, N'Rio Tercero')
INSERT [dbo].[localidades] ([idLoc], [descripcionLoc]) VALUES (10, N'Villa del Rosario')
SET IDENTITY_INSERT [dbo].[localidades] OFF
/****** Object:  Table [dbo].[intervencion]    Script Date: 06/22/2016 16:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[intervencion](
	[codIntervencion] [int] IDENTITY(1,1) NOT NULL,
	[idPaciente] [int] NULL,
	[fecha] [datetime] NULL,
	[hora] [time](0) NULL,
	[codTratamiento] [int] NULL,
	[montoTotal] [numeric](18, 0) NULL,
	[observaciones] [nvarchar](300) NULL,
	[idCondicion] [int] NULL,
 CONSTRAINT [PK_intervencion] PRIMARY KEY CLUSTERED 
(
	[codIntervencion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[intervencion] ON
INSERT [dbo].[intervencion] ([codIntervencion], [idPaciente], [fecha], [hora], [codTratamiento], [montoTotal], [observaciones], [idCondicion]) VALUES (29, 15, CAST(0x0000A69B00000000 AS DateTime), CAST(0x00E0C40000000000 AS Time), 1, CAST(1050 AS Numeric(18, 0)), N'aaaaaaa', 2)
INSERT [dbo].[intervencion] ([codIntervencion], [idPaciente], [fecha], [hora], [codTratamiento], [montoTotal], [observaciones], [idCondicion]) VALUES (30, 12, CAST(0x0000A62E00000000 AS DateTime), CAST(0x00F0D20000000000 AS Time), 4, CAST(2100 AS Numeric(18, 0)), N'ASdfasfafgaddww', 1)
INSERT [dbo].[intervencion] ([codIntervencion], [idPaciente], [fecha], [hora], [codTratamiento], [montoTotal], [observaciones], [idCondicion]) VALUES (31, 5, CAST(0x0000A62E00000000 AS DateTime), CAST(0x00A08C0000000000 AS Time), 2, CAST(3100 AS Numeric(18, 0)), N'edwqdrwfqfqf', 2)
INSERT [dbo].[intervencion] ([codIntervencion], [idPaciente], [fecha], [hora], [codTratamiento], [montoTotal], [observaciones], [idCondicion]) VALUES (32, 16, CAST(0x0000A62E00000000 AS DateTime), CAST(0x00B09A0000000000 AS Time), 2, CAST(3050 AS Numeric(18, 0)), N'qerweqrwq', 2)
INSERT [dbo].[intervencion] ([codIntervencion], [idPaciente], [fecha], [hora], [codTratamiento], [montoTotal], [observaciones], [idCondicion]) VALUES (33, 16, CAST(0x0000A62E00000000 AS DateTime), CAST(0x00A08C0000000000 AS Time), 5, CAST(2100 AS Numeric(18, 0)), N'dadadads', 1)
INSERT [dbo].[intervencion] ([codIntervencion], [idPaciente], [fecha], [hora], [codTratamiento], [montoTotal], [observaciones], [idCondicion]) VALUES (34, 8, CAST(0x0000A67F00000000 AS DateTime), CAST(0x0010EF0000000000 AS Time), 4, CAST(2050 AS Numeric(18, 0)), N'adssfafdwqd', 1)
INSERT [dbo].[intervencion] ([codIntervencion], [idPaciente], [fecha], [hora], [codTratamiento], [montoTotal], [observaciones], [idCondicion]) VALUES (35, 12, CAST(0x0000A63A00000000 AS DateTime), CAST(0x00907E0000000000 AS Time), 5, CAST(2100 AS Numeric(18, 0)), N'dwqfdwqfwqfqw', 1)
INSERT [dbo].[intervencion] ([codIntervencion], [idPaciente], [fecha], [hora], [codTratamiento], [montoTotal], [observaciones], [idCondicion]) VALUES (36, 14, CAST(0x0000A62E00000000 AS DateTime), CAST(0x00B09A0000000000 AS Time), 3, CAST(550 AS Numeric(18, 0)), N'qewqewq', 2)
INSERT [dbo].[intervencion] ([codIntervencion], [idPaciente], [fecha], [hora], [codTratamiento], [montoTotal], [observaciones], [idCondicion]) VALUES (37, 9, CAST(0x0000A66600000000 AS DateTime), CAST(0x00F0D20000000000 AS Time), 7, CAST(5050 AS Numeric(18, 0)), N'qwerfqwew', 2)
INSERT [dbo].[intervencion] ([codIntervencion], [idPaciente], [fecha], [hora], [codTratamiento], [montoTotal], [observaciones], [idCondicion]) VALUES (38, 7, CAST(0x0000A62E00000000 AS DateTime), CAST(0x00300B0100000000 AS Time), 6, CAST(2600 AS Numeric(18, 0)), N'wqdwqfdqwfd', 2)
INSERT [dbo].[intervencion] ([codIntervencion], [idPaciente], [fecha], [hora], [codTratamiento], [montoTotal], [observaciones], [idCondicion]) VALUES (39, 12, CAST(0x0000A62E00000000 AS DateTime), CAST(0x00C0A80000000000 AS Time), 3, CAST(550 AS Numeric(18, 0)), N'asdasfsada', 1)
INSERT [dbo].[intervencion] ([codIntervencion], [idPaciente], [fecha], [hora], [codTratamiento], [montoTotal], [observaciones], [idCondicion]) VALUES (40, 6, CAST(0x0000A62E00000000 AS DateTime), CAST(0x00B09A0000000000 AS Time), 3, CAST(550 AS Numeric(18, 0)), N'fweqfwqew', 1)
INSERT [dbo].[intervencion] ([codIntervencion], [idPaciente], [fecha], [hora], [codTratamiento], [montoTotal], [observaciones], [idCondicion]) VALUES (41, 6, CAST(0x0000A65A00000000 AS DateTime), CAST(0x00A08C0000000000 AS Time), 7, CAST(5100 AS Numeric(18, 0)), N'asdafwqdqw', 1)
INSERT [dbo].[intervencion] ([codIntervencion], [idPaciente], [fecha], [hora], [codTratamiento], [montoTotal], [observaciones], [idCondicion]) VALUES (42, 5, CAST(0x0000A62E00000000 AS DateTime), CAST(0x0000E10000000000 AS Time), 6, CAST(2600 AS Numeric(18, 0)), N'sadfawqad', 2)
INSERT [dbo].[intervencion] ([codIntervencion], [idPaciente], [fecha], [hora], [codTratamiento], [montoTotal], [observaciones], [idCondicion]) VALUES (43, 6, CAST(0x0000A62E00000000 AS DateTime), CAST(0x0080700000000000 AS Time), 4, CAST(2100 AS Numeric(18, 0)), N'sadfsadaS', 1)
INSERT [dbo].[intervencion] ([codIntervencion], [idPaciente], [fecha], [hora], [codTratamiento], [montoTotal], [observaciones], [idCondicion]) VALUES (44, 6, CAST(0x0000A60D00000000 AS DateTime), CAST(0x00F0D20000000000 AS Time), 2, CAST(3100 AS Numeric(18, 0)), N'WQEWQERFWQ', 1)
INSERT [dbo].[intervencion] ([codIntervencion], [idPaciente], [fecha], [hora], [codTratamiento], [montoTotal], [observaciones], [idCondicion]) VALUES (45, 6, CAST(0x0000A6A000000000 AS DateTime), CAST(0x00A08C0000000000 AS Time), 3, CAST(600 AS Numeric(18, 0)), N'dsfdaffasfsaf', 1)
INSERT [dbo].[intervencion] ([codIntervencion], [idPaciente], [fecha], [hora], [codTratamiento], [montoTotal], [observaciones], [idCondicion]) VALUES (46, 9, CAST(0x0000A6E700000000 AS DateTime), CAST(0x00A08C0000000000 AS Time), 2, CAST(3100 AS Numeric(18, 0)), N'sadfasdsa', 1)
SET IDENTITY_INSERT [dbo].[intervencion] OFF
/****** Object:  Table [dbo].[InsumosXIntervencion]    Script Date: 06/22/2016 16:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InsumosXIntervencion](
	[codIntervencion] [int] NOT NULL,
	[idInsumo] [int] NOT NULL,
	[cantidadInsumos] [int] NULL,
 CONSTRAINT [PK_InsumosXIntervencion] PRIMARY KEY CLUSTERED 
(
	[codIntervencion] ASC,
	[idInsumo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (11, 7, 2)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (12, 7, 2)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (13, 7, 2)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (14, 2, 2)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (14, 3, 1)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (17, 1, 2)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (18, 1, 2)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (19, 2, 22)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (20, 1, 2)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (21, 2, 23)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (22, 3, 2)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (23, 2, 8)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (24, 2, 2)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (25, 2, 3)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (26, 1, 2)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (27, 1, 22)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (28, 3, 33)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (29, 2, 2)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (30, 2, 17)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (30, 3, 2)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (31, 2, 2)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (31, 6, 4)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (32, 4, 2)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (33, 4, 3)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (33, 5, 2)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (34, 3, 2)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (35, 2, 2)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (35, 5, 2)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (36, 1, 23)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (37, 5, 10)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (38, 4, 2)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (38, 6, 1)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (39, 2, 32)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (40, 6, 2)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (41, 1, 2)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (41, 6, 3)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (42, 2, 3)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (42, 4, 2)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (43, 1, 3)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (43, 4, 2)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (44, 2, 5)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (44, 6, 4)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (45, 4, 2)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (45, 5, 3)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (46, 3, 2)
INSERT [dbo].[InsumosXIntervencion] ([codIntervencion], [idInsumo], [cantidadInsumos]) VALUES (46, 4, 3)
/****** Object:  Table [dbo].[Insumos]    Script Date: 06/22/2016 16:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Insumos](
	[idInsumo] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](50) NULL,
	[cantidadStock] [int] NULL,
	[puntoReposicion] [int] NULL,
 CONSTRAINT [PK_Insumos] PRIMARY KEY CLUSTERED 
(
	[idInsumo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Insumos] ON
INSERT [dbo].[Insumos] ([idInsumo], [descripcion], [cantidadStock], [puntoReposicion]) VALUES (1, N'pasta', 211, 20)
INSERT [dbo].[Insumos] ([idInsumo], [descripcion], [cantidadStock], [puntoReposicion]) VALUES (2, N'dientes', 23310, 10)
INSERT [dbo].[Insumos] ([idInsumo], [descripcion], [cantidadStock], [puntoReposicion]) VALUES (3, N'tornos', 23152, 1)
INSERT [dbo].[Insumos] ([idInsumo], [descripcion], [cantidadStock], [puntoReposicion]) VALUES (4, N'espatulas', 392, 30)
INSERT [dbo].[Insumos] ([idInsumo], [descripcion], [cantidadStock], [puntoReposicion]) VALUES (5, N'ceramicass', 4617, 30)
INSERT [dbo].[Insumos] ([idInsumo], [descripcion], [cantidadStock], [puntoReposicion]) VALUES (6, N'coronas', 66, 36)
INSERT [dbo].[Insumos] ([idInsumo], [descripcion], [cantidadStock], [puntoReposicion]) VALUES (7, N'protesis', 55, 20)
SET IDENTITY_INSERT [dbo].[Insumos] OFF
/****** Object:  Table [dbo].[FormaPago]    Script Date: 06/22/2016 16:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormaPago](
	[idFP] [int] IDENTITY(1,1) NOT NULL,
	[descripcionFP] [nvarchar](50) NULL,
 CONSTRAINT [PK_FormaPago] PRIMARY KEY CLUSTERED 
(
	[idFP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FormaPago] ON
INSERT [dbo].[FormaPago] ([idFP], [descripcionFP]) VALUES (1, N'Efectivo')
INSERT [dbo].[FormaPago] ([idFP], [descripcionFP]) VALUES (2, N'Tarjeta de Credito')
INSERT [dbo].[FormaPago] ([idFP], [descripcionFP]) VALUES (3, N'Dinero Electronico')
INSERT [dbo].[FormaPago] ([idFP], [descripcionFP]) VALUES (4, N'Puntos de Pago')
SET IDENTITY_INSERT [dbo].[FormaPago] OFF
/****** Object:  Table [dbo].[Factura]    Script Date: 06/22/2016 16:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nroFactura] [int] NULL,
	[idPaciente] [int] NULL,
	[montoTotal] [numeric](18, 0) NULL,
	[fechaFac] [smalldatetime] NULL,
	[idFormaPago] [int] NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Factura] ON
INSERT [dbo].[Factura] ([id], [nroFactura], [idPaciente], [montoTotal], [fechaFac], [idFormaPago]) VALUES (1, 1, 5, CAST(100 AS Numeric(18, 0)), CAST(0xA3C00000 AS SmallDateTime), 2)
INSERT [dbo].[Factura] ([id], [nroFactura], [idPaciente], [montoTotal], [fechaFac], [idFormaPago]) VALUES (2, 2, 8, CAST(200 AS Numeric(18, 0)), CAST(0xA5930000 AS SmallDateTime), 2)
INSERT [dbo].[Factura] ([id], [nroFactura], [idPaciente], [montoTotal], [fechaFac], [idFormaPago]) VALUES (3, 3, 14, CAST(300 AS Numeric(18, 0)), CAST(0xA5FB0000 AS SmallDateTime), 3)
INSERT [dbo].[Factura] ([id], [nroFactura], [idPaciente], [montoTotal], [fechaFac], [idFormaPago]) VALUES (4, 4, 7, CAST(400 AS Numeric(18, 0)), CAST(0xA6070000 AS SmallDateTime), 2)
INSERT [dbo].[Factura] ([id], [nroFactura], [idPaciente], [montoTotal], [fechaFac], [idFormaPago]) VALUES (5, 5, 14, CAST(500 AS Numeric(18, 0)), CAST(0xA53F0000 AS SmallDateTime), 2)
INSERT [dbo].[Factura] ([id], [nroFactura], [idPaciente], [montoTotal], [fechaFac], [idFormaPago]) VALUES (6, 6, 7, CAST(600 AS Numeric(18, 0)), CAST(0xA59F0000 AS SmallDateTime), 2)
INSERT [dbo].[Factura] ([id], [nroFactura], [idPaciente], [montoTotal], [fechaFac], [idFormaPago]) VALUES (7, 7, 9, CAST(700 AS Numeric(18, 0)), CAST(0xA52B0000 AS SmallDateTime), 2)
INSERT [dbo].[Factura] ([id], [nroFactura], [idPaciente], [montoTotal], [fechaFac], [idFormaPago]) VALUES (8, 8, 8, CAST(800 AS Numeric(18, 0)), CAST(0xA4D00000 AS SmallDateTime), 2)
INSERT [dbo].[Factura] ([id], [nroFactura], [idPaciente], [montoTotal], [fechaFac], [idFormaPago]) VALUES (9, 9, 10, CAST(900 AS Numeric(18, 0)), CAST(0xA5FD0000 AS SmallDateTime), 2)
INSERT [dbo].[Factura] ([id], [nroFactura], [idPaciente], [montoTotal], [fechaFac], [idFormaPago]) VALUES (10, 10, 10, CAST(1000 AS Numeric(18, 0)), CAST(0xA5DE0000 AS SmallDateTime), 2)
INSERT [dbo].[Factura] ([id], [nroFactura], [idPaciente], [montoTotal], [fechaFac], [idFormaPago]) VALUES (11, 11, 8, CAST(400 AS Numeric(18, 0)), CAST(0xA5BE0000 AS SmallDateTime), 1)
INSERT [dbo].[Factura] ([id], [nroFactura], [idPaciente], [montoTotal], [fechaFac], [idFormaPago]) VALUES (12, 12, 15, CAST(3100 AS Numeric(18, 0)), CAST(0xA5A00000 AS SmallDateTime), 4)
INSERT [dbo].[Factura] ([id], [nroFactura], [idPaciente], [montoTotal], [fechaFac], [idFormaPago]) VALUES (13, 13, 6, CAST(3150 AS Numeric(18, 0)), CAST(0xA5800000 AS SmallDateTime), 3)
INSERT [dbo].[Factura] ([id], [nroFactura], [idPaciente], [montoTotal], [fechaFac], [idFormaPago]) VALUES (14, 14, 15, CAST(1050 AS Numeric(18, 0)), CAST(0xA5FD0000 AS SmallDateTime), 1)
INSERT [dbo].[Factura] ([id], [nroFactura], [idPaciente], [montoTotal], [fechaFac], [idFormaPago]) VALUES (15, 15, 14, CAST(550 AS Numeric(18, 0)), CAST(0xA5DE0000 AS SmallDateTime), 2)
INSERT [dbo].[Factura] ([id], [nroFactura], [idPaciente], [montoTotal], [fechaFac], [idFormaPago]) VALUES (16, 16, 16, CAST(3050 AS Numeric(18, 0)), CAST(0xA5BE0000 AS SmallDateTime), 4)
INSERT [dbo].[Factura] ([id], [nroFactura], [idPaciente], [montoTotal], [fechaFac], [idFormaPago]) VALUES (17, 17, 7, CAST(2600 AS Numeric(18, 0)), CAST(0xA5A00000 AS SmallDateTime), 1)
INSERT [dbo].[Factura] ([id], [nroFactura], [idPaciente], [montoTotal], [fechaFac], [idFormaPago]) VALUES (18, 18, 9, CAST(5050 AS Numeric(18, 0)), CAST(0xA5800000 AS SmallDateTime), 2)
INSERT [dbo].[Factura] ([id], [nroFactura], [idPaciente], [montoTotal], [fechaFac], [idFormaPago]) VALUES (19, 19, 5, CAST(5700 AS Numeric(18, 0)), CAST(0xA62D0000 AS SmallDateTime), 1)
SET IDENTITY_INSERT [dbo].[Factura] OFF
/****** Object:  Table [dbo].[empleados]    Script Date: 06/22/2016 16:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[empleados](
	[codEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[apellido] [nvarchar](50) NOT NULL,
	[idTipoDoc] [int] NOT NULL,
	[nroDoc] [int] NOT NULL,
	[fechaNacimiento] [smalldatetime] NULL,
	[telefono] [nvarchar](50) NULL,
	[celular] [nvarchar](50) NULL,
	[idLocalidad] [int] NULL,
	[calle] [nvarchar](50) NULL,
	[nroCalle] [int] NULL,
	[piso] [int] NULL,
	[departamento] [nvarchar](50) NULL,
	[idCargo] [int] NULL,
	[sueldo] [numeric](18, 0) NULL,
	[horaIngreso] [time](0) NULL,
	[horaEgreso] [time](0) NULL,
	[activo] [bit] NULL,
 CONSTRAINT [PK_empleados] PRIMARY KEY CLUSTERED 
(
	[codEmpleado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[empleados] ON
INSERT [dbo].[empleados] ([codEmpleado], [nombre], [apellido], [idTipoDoc], [nroDoc], [fechaNacimiento], [telefono], [celular], [idLocalidad], [calle], [nroCalle], [piso], [departamento], [idCargo], [sueldo], [horaIngreso], [horaEgreso], [activo]) VALUES (2, N'Maria', N'Fernandez', 1, 25458878, CAST(0x72260000 AS SmallDateTime), N'1225456', N'255448632', 4, N'Las Acacias', 1365, 1, N'D', 2, CAST(5000 AS Numeric(18, 0)), CAST(0x00E0C40000000000 AS Time), CAST(0x0040190100000000 AS Time), 1)
INSERT [dbo].[empleados] ([codEmpleado], [nombre], [apellido], [idTipoDoc], [nroDoc], [fechaNacimiento], [telefono], [celular], [idLocalidad], [calle], [nroCalle], [piso], [departamento], [idCargo], [sueldo], [horaIngreso], [horaEgreso], [activo]) VALUES (3, N'Federico', N'Guineo', 2, 45468112, CAST(0x78200000 AS SmallDateTime), N'48645643', N'213548421', 3, N'Los Cedros', 1245, 2, N'C', 2, CAST(5000 AS Numeric(18, 0)), CAST(0x0080700000000000 AS Time), CAST(0x00E0C40000000000 AS Time), 1)
INSERT [dbo].[empleados] ([codEmpleado], [nombre], [apellido], [idTipoDoc], [nroDoc], [fechaNacimiento], [telefono], [celular], [idLocalidad], [calle], [nroCalle], [piso], [departamento], [idCargo], [sueldo], [horaIngreso], [horaEgreso], [activo]) VALUES (4, N'Juan', N'Farias', 2, 54485462, CAST(0x7FD40000 AS SmallDateTime), N'248353523', N'351314482', 6, N'Los Ceibos', 1358, 0, N'1', 2, CAST(0 AS Numeric(18, 0)), CAST(0x0080700000000000 AS Time), CAST(0x00C0A80000000000 AS Time), 0)
INSERT [dbo].[empleados] ([codEmpleado], [nombre], [apellido], [idTipoDoc], [nroDoc], [fechaNacimiento], [telefono], [celular], [idLocalidad], [calle], [nroCalle], [piso], [departamento], [idCargo], [sueldo], [horaIngreso], [horaEgreso], [activo]) VALUES (5, N'Fernando', N'Olivero', 1, 32448756, CAST(0x76D70000 AS SmallDateTime), N'153452334', N'3514137482', 5, N'Chacabuco', 1502, 0, N'3', 2, CAST(5500 AS Numeric(18, 0)), CAST(0x0080700000000000 AS Time), CAST(0x0000E10000000000 AS Time), 1)
INSERT [dbo].[empleados] ([codEmpleado], [nombre], [apellido], [idTipoDoc], [nroDoc], [fechaNacimiento], [telefono], [celular], [idLocalidad], [calle], [nroCalle], [piso], [departamento], [idCargo], [sueldo], [horaIngreso], [horaEgreso], [activo]) VALUES (6, N'Pablo', N'Quinteros', 1, 36965985, CAST(0x73E20000 AS SmallDateTime), N'3514778958', N'3512548598', 2, N'Los Aromos', 252, 0, N'1', 1, CAST(8000 AS Numeric(18, 0)), CAST(0x0080700000000000 AS Time), CAST(0x0000E10000000000 AS Time), 1)
INSERT [dbo].[empleados] ([codEmpleado], [nombre], [apellido], [idTipoDoc], [nroDoc], [fechaNacimiento], [telefono], [celular], [idLocalidad], [calle], [nroCalle], [piso], [departamento], [idCargo], [sueldo], [horaIngreso], [horaEgreso], [activo]) VALUES (7, N'Lucia', N'Fontana', 1, 35486415, CAST(0x80F40000 AS SmallDateTime), N'35134352', N'3511562344', 7, N'Maipu', 1548, 0, N'2', 1, CAST(9000 AS Numeric(18, 0)), CAST(0x0080700000000000 AS Time), CAST(0x0040190100000000 AS Time), 0)
INSERT [dbo].[empleados] ([codEmpleado], [nombre], [apellido], [idTipoDoc], [nroDoc], [fechaNacimiento], [telefono], [celular], [idLocalidad], [calle], [nroCalle], [piso], [departamento], [idCargo], [sueldo], [horaIngreso], [horaEgreso], [activo]) VALUES (8, N'Dario', N'Ludueña', 1, 32586484, CAST(0x82160000 AS SmallDateTime), N'213854153', N'2315431', 8, N'Roca', 123, 0, N'1', 2, CAST(5000 AS Numeric(18, 0)), CAST(0x00E0C40000000000 AS Time), CAST(0x0040190100000000 AS Time), 1)
INSERT [dbo].[empleados] ([codEmpleado], [nombre], [apellido], [idTipoDoc], [nroDoc], [fechaNacimiento], [telefono], [celular], [idLocalidad], [calle], [nroCalle], [piso], [departamento], [idCargo], [sueldo], [horaIngreso], [horaEgreso], [activo]) VALUES (9, N'Miguel', N'Rodriguez', 2, 21357468, CAST(0x78CE0000 AS SmallDateTime), N'3513424', N'351233414', 10, N'Las Araucarias', 1546, 2, N'1', 1, CAST(8000 AS Numeric(18, 0)), CAST(0x0080700000000000 AS Time), CAST(0x0000E10000000000 AS Time), 1)
INSERT [dbo].[empleados] ([codEmpleado], [nombre], [apellido], [idTipoDoc], [nroDoc], [fechaNacimiento], [telefono], [celular], [idLocalidad], [calle], [nroCalle], [piso], [departamento], [idCargo], [sueldo], [horaIngreso], [horaEgreso], [activo]) VALUES (10, N'Lidia', N'Parra', 2, 15465335, CAST(0x7F7A0000 AS SmallDateTime), N'3513153431', N'351341243', 3, N'Buenos Aires', 456, 0, N'1', 2, CAST(4000 AS Numeric(18, 0)), CAST(0x0080700000000000 AS Time), CAST(0x00C0A80000000000 AS Time), 1)
INSERT [dbo].[empleados] ([codEmpleado], [nombre], [apellido], [idTipoDoc], [nroDoc], [fechaNacimiento], [telefono], [celular], [idLocalidad], [calle], [nroCalle], [piso], [departamento], [idCargo], [sueldo], [horaIngreso], [horaEgreso], [activo]) VALUES (11, N'Sofia', N'Arevalo', 1, 35544816, CAST(0x827A0000 AS SmallDateTime), N'35153243', N'35154232', 6, N'Buenos Aires', 1562, 0, N'', 2, CAST(500 AS Numeric(18, 0)), CAST(0x00E0C40000000000 AS Time), CAST(0x0040190100000000 AS Time), 1)
INSERT [dbo].[empleados] ([codEmpleado], [nombre], [apellido], [idTipoDoc], [nroDoc], [fechaNacimiento], [telefono], [celular], [idLocalidad], [calle], [nroCalle], [piso], [departamento], [idCargo], [sueldo], [horaIngreso], [horaEgreso], [activo]) VALUES (12, N'Manuel', N'Fuentes', 1, 35592451, CAST(0x82240000 AS SmallDateTime), N'56453151', N'32154156', 2, N'Independencia', 369, 1, N'3', 2, CAST(5000 AS Numeric(18, 0)), CAST(0x0080700000000000 AS Time), CAST(0x0040190100000000 AS Time), 1)
SET IDENTITY_INSERT [dbo].[empleados] OFF
/****** Object:  Table [dbo].[DetalleFactura]    Script Date: 06/22/2016 16:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleFactura](
	[nroFactura] [int] NULL,
	[codIntervencion] [int] NULL,
	[cantidad] [int] NULL,
	[precio] [numeric](18, 0) NULL,
	[cantidadAbonada] [numeric](18, 0) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[DetalleFactura] ([nroFactura], [codIntervencion], [cantidad], [precio], [cantidadAbonada]) VALUES (1, 1, 2, CAST(100 AS Numeric(18, 0)), CAST(100 AS Numeric(18, 0)))
INSERT [dbo].[DetalleFactura] ([nroFactura], [codIntervencion], [cantidad], [precio], [cantidadAbonada]) VALUES (2, 2, 4, CAST(200 AS Numeric(18, 0)), CAST(200 AS Numeric(18, 0)))
INSERT [dbo].[DetalleFactura] ([nroFactura], [codIntervencion], [cantidad], [precio], [cantidadAbonada]) VALUES (3, 3, 5, CAST(300 AS Numeric(18, 0)), CAST(300 AS Numeric(18, 0)))
INSERT [dbo].[DetalleFactura] ([nroFactura], [codIntervencion], [cantidad], [precio], [cantidadAbonada]) VALUES (4, 4, 2, CAST(400 AS Numeric(18, 0)), CAST(400 AS Numeric(18, 0)))
INSERT [dbo].[DetalleFactura] ([nroFactura], [codIntervencion], [cantidad], [precio], [cantidadAbonada]) VALUES (5, 5, 4, CAST(500 AS Numeric(18, 0)), CAST(500 AS Numeric(18, 0)))
INSERT [dbo].[DetalleFactura] ([nroFactura], [codIntervencion], [cantidad], [precio], [cantidadAbonada]) VALUES (6, 6, 2, CAST(600 AS Numeric(18, 0)), CAST(600 AS Numeric(18, 0)))
INSERT [dbo].[DetalleFactura] ([nroFactura], [codIntervencion], [cantidad], [precio], [cantidadAbonada]) VALUES (7, 7, 3, CAST(700 AS Numeric(18, 0)), CAST(700 AS Numeric(18, 0)))
INSERT [dbo].[DetalleFactura] ([nroFactura], [codIntervencion], [cantidad], [precio], [cantidadAbonada]) VALUES (8, 8, 3, CAST(800 AS Numeric(18, 0)), CAST(800 AS Numeric(18, 0)))
INSERT [dbo].[DetalleFactura] ([nroFactura], [codIntervencion], [cantidad], [precio], [cantidadAbonada]) VALUES (9, 9, 4, CAST(900 AS Numeric(18, 0)), CAST(900 AS Numeric(18, 0)))
INSERT [dbo].[DetalleFactura] ([nroFactura], [codIntervencion], [cantidad], [precio], [cantidadAbonada]) VALUES (10, 10, 2, CAST(1000 AS Numeric(18, 0)), CAST(1000 AS Numeric(18, 0)))
INSERT [dbo].[DetalleFactura] ([nroFactura], [codIntervencion], [cantidad], [precio], [cantidadAbonada]) VALUES (11, 4, 1, CAST(400 AS Numeric(18, 0)), CAST(400 AS Numeric(18, 0)))
INSERT [dbo].[DetalleFactura] ([nroFactura], [codIntervencion], [cantidad], [precio], [cantidadAbonada]) VALUES (12, 14, 1, CAST(3100 AS Numeric(18, 0)), CAST(3100 AS Numeric(18, 0)))
INSERT [dbo].[DetalleFactura] ([nroFactura], [codIntervencion], [cantidad], [precio], [cantidadAbonada]) VALUES (13, 11, 1, CAST(1050 AS Numeric(18, 0)), CAST(1050 AS Numeric(18, 0)))
INSERT [dbo].[DetalleFactura] ([nroFactura], [codIntervencion], [cantidad], [precio], [cantidadAbonada]) VALUES (13, 12, 1, CAST(1050 AS Numeric(18, 0)), CAST(1050 AS Numeric(18, 0)))
INSERT [dbo].[DetalleFactura] ([nroFactura], [codIntervencion], [cantidad], [precio], [cantidadAbonada]) VALUES (13, 13, 1, CAST(1050 AS Numeric(18, 0)), CAST(1050 AS Numeric(18, 0)))
INSERT [dbo].[DetalleFactura] ([nroFactura], [codIntervencion], [cantidad], [precio], [cantidadAbonada]) VALUES (14, 29, 1, CAST(1050 AS Numeric(18, 0)), CAST(1050 AS Numeric(18, 0)))
INSERT [dbo].[DetalleFactura] ([nroFactura], [codIntervencion], [cantidad], [precio], [cantidadAbonada]) VALUES (15, 36, 1, CAST(550 AS Numeric(18, 0)), CAST(550 AS Numeric(18, 0)))
INSERT [dbo].[DetalleFactura] ([nroFactura], [codIntervencion], [cantidad], [precio], [cantidadAbonada]) VALUES (16, 32, 1, CAST(3050 AS Numeric(18, 0)), CAST(3050 AS Numeric(18, 0)))
INSERT [dbo].[DetalleFactura] ([nroFactura], [codIntervencion], [cantidad], [precio], [cantidadAbonada]) VALUES (17, 38, 1, CAST(2600 AS Numeric(18, 0)), CAST(2600 AS Numeric(18, 0)))
INSERT [dbo].[DetalleFactura] ([nroFactura], [codIntervencion], [cantidad], [precio], [cantidadAbonada]) VALUES (18, 37, 1, CAST(5050 AS Numeric(18, 0)), CAST(5050 AS Numeric(18, 0)))
INSERT [dbo].[DetalleFactura] ([nroFactura], [codIntervencion], [cantidad], [precio], [cantidadAbonada]) VALUES (19, 31, 1, CAST(3100 AS Numeric(18, 0)), CAST(3100 AS Numeric(18, 0)))
INSERT [dbo].[DetalleFactura] ([nroFactura], [codIntervencion], [cantidad], [precio], [cantidadAbonada]) VALUES (19, 42, 1, CAST(2600 AS Numeric(18, 0)), CAST(2600 AS Numeric(18, 0)))
/****** Object:  Table [dbo].[detalleCompraInsumos]    Script Date: 06/22/2016 16:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalleCompraInsumos](
	[idProveedor] [int] NOT NULL,
	[fechaHora] [datetime] NOT NULL,
	[codInsumo] [int] NOT NULL,
	[cantidad] [int] NULL,
	[precioUnitario] [numeric](18, 0) NULL,
 CONSTRAINT [PK_detalleCompraInsumos] PRIMARY KEY CLUSTERED 
(
	[idProveedor] ASC,
	[fechaHora] ASC,
	[codInsumo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[detalleCompraInsumos] ([idProveedor], [fechaHora], [codInsumo], [cantidad], [precioUnitario]) VALUES (1, CAST(0x0000A62D010CE0A5 AS DateTime), 2, 3, CAST(20 AS Numeric(18, 0)))
INSERT [dbo].[detalleCompraInsumos] ([idProveedor], [fechaHora], [codInsumo], [cantidad], [precioUnitario]) VALUES (1, CAST(0x0000A62D010FF792 AS DateTime), 1, 2, CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[detalleCompraInsumos] ([idProveedor], [fechaHora], [codInsumo], [cantidad], [precioUnitario]) VALUES (2, CAST(0x0000A62D010CE0A5 AS DateTime), 3, 32, CAST(20 AS Numeric(18, 0)))
INSERT [dbo].[detalleCompraInsumos] ([idProveedor], [fechaHora], [codInsumo], [cantidad], [precioUnitario]) VALUES (2, CAST(0x0000A62D010FF792 AS DateTime), 2, 58, CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[detalleCompraInsumos] ([idProveedor], [fechaHora], [codInsumo], [cantidad], [precioUnitario]) VALUES (3, CAST(0x0000A62D010D55B0 AS DateTime), 4, 3, CAST(10 AS Numeric(18, 0)))
/****** Object:  Table [dbo].[condicion]    Script Date: 06/22/2016 16:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[condicion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](50) NULL,
 CONSTRAINT [PK_condicion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[condicion] ON
INSERT [dbo].[condicion] ([id], [descripcion]) VALUES (1, N'Pendiente')
INSERT [dbo].[condicion] ([id], [descripcion]) VALUES (2, N'Paga')
SET IDENTITY_INSERT [dbo].[condicion] OFF
/****** Object:  Table [dbo].[compraInsumos]    Script Date: 06/22/2016 16:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[compraInsumos](
	[idProveedor] [int] NOT NULL,
	[fechaHora] [datetime] NOT NULL,
	[montoTotal] [numeric](18, 0) NULL,
 CONSTRAINT [PK_compraInsumos] PRIMARY KEY CLUSTERED 
(
	[idProveedor] ASC,
	[fechaHora] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[compraInsumos] ([idProveedor], [fechaHora], [montoTotal]) VALUES (1, CAST(0x0000A62D010CE0A5 AS DateTime), CAST(700 AS Numeric(18, 0)))
INSERT [dbo].[compraInsumos] ([idProveedor], [fechaHora], [montoTotal]) VALUES (2, CAST(0x0000A62D010FF792 AS DateTime), CAST(156 AS Numeric(18, 0)))
INSERT [dbo].[compraInsumos] ([idProveedor], [fechaHora], [montoTotal]) VALUES (3, CAST(0x0000A62D010D55B0 AS DateTime), CAST(30 AS Numeric(18, 0)))
/****** Object:  Table [dbo].[Cargo]    Script Date: 06/22/2016 16:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cargo](
	[idCargo] [int] IDENTITY(1,1) NOT NULL,
	[descripcionCargo] [nvarchar](50) NULL,
 CONSTRAINT [PK_Cargo] PRIMARY KEY CLUSTERED 
(
	[idCargo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cargo] ON
INSERT [dbo].[Cargo] ([idCargo], [descripcionCargo]) VALUES (1, N'Administrativo')
INSERT [dbo].[Cargo] ([idCargo], [descripcionCargo]) VALUES (2, N'Especialista')
SET IDENTITY_INSERT [dbo].[Cargo] OFF
