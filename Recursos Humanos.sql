USE [master]
GO
/****** Object:  Database [Recursos_Humanos]    Script Date: 04-Dec-19 2:11:42 PM ******/
CREATE DATABASE [Recursos_Humanos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Recursos_Humanos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Recursos_Humanos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Recursos_Humanos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Recursos_Humanos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Recursos_Humanos] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Recursos_Humanos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Recursos_Humanos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Recursos_Humanos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Recursos_Humanos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Recursos_Humanos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Recursos_Humanos] SET ARITHABORT OFF 
GO
ALTER DATABASE [Recursos_Humanos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Recursos_Humanos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Recursos_Humanos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Recursos_Humanos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Recursos_Humanos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Recursos_Humanos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Recursos_Humanos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Recursos_Humanos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Recursos_Humanos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Recursos_Humanos] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Recursos_Humanos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Recursos_Humanos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Recursos_Humanos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Recursos_Humanos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Recursos_Humanos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Recursos_Humanos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Recursos_Humanos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Recursos_Humanos] SET RECOVERY FULL 
GO
ALTER DATABASE [Recursos_Humanos] SET  MULTI_USER 
GO
ALTER DATABASE [Recursos_Humanos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Recursos_Humanos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Recursos_Humanos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Recursos_Humanos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Recursos_Humanos] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Recursos_Humanos', N'ON'
GO
ALTER DATABASE [Recursos_Humanos] SET QUERY_STORE = OFF
GO
USE [Recursos_Humanos]
GO
/****** Object:  User [app]    Script Date: 04-Dec-19 2:11:42 PM ******/
CREATE USER [app] FOR LOGIN [app] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [app]
GO
/****** Object:  Table [dbo].[Cargos]    Script Date: 04-Dec-19 2:11:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cargos](
	[IdCargos] [int] IDENTITY(1,1) NOT NULL,
	[CodigoCargo] [int] NOT NULL,
	[Cargo1] [varchar](20) NULL,
 CONSTRAINT [PK_Cargos] PRIMARY KEY CLUSTERED 
(
	[IdCargos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamentos]    Script Date: 04-Dec-19 2:11:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamentos](
	[IdDepartamento] [int] IDENTITY(1,1) NOT NULL,
	[CodigoDep] [int] NOT NULL,
	[Nombre] [varchar](20) NULL,
	[Encargado] [varchar](30) NULL,
 CONSTRAINT [PK_Departamentos] PRIMARY KEY CLUSTERED 
(
	[IdDepartamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 04-Dec-19 2:11:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[IdEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [int] NOT NULL,
	[Nombre] [varchar](20) NULL,
	[Apellido] [varchar](20) NULL,
	[Telefono] [varchar](15) NULL,
	[Departamento] [int] NULL,
	[Cargo] [int] NULL,
	[FechaIngreso] [datetime] NULL,
	[Salario] [float] NULL,
	[Estatus] [varchar](20) NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Licencias]    Script Date: 04-Dec-19 2:11:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Licencias](
	[IdLicencias] [int] IDENTITY(1,1) NOT NULL,
	[Empleado] [int] NOT NULL,
	[Desde] [datetime] NULL,
	[Hasta] [datetime] NULL,
	[motivo] [varchar](50) NULL,
	[Comentarios] [varchar](50) NULL,
 CONSTRAINT [PK_Licencias] PRIMARY KEY CLUSTERED 
(
	[IdLicencias] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nomina]    Script Date: 04-Dec-19 2:11:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nomina](
	[IdNomina] [int] IDENTITY(1,1) NOT NULL,
	[Año] [int] NOT NULL,
	[Mes] [int] NOT NULL,
	[MontoTotal] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdNomina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 04-Dec-19 2:11:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos](
	[IdPermiso] [int] IDENTITY(1,1) NOT NULL,
	[Empleado] [int] NOT NULL,
	[Desde] [datetime] NULL,
	[Hasta] [datetime] NULL,
	[Comentarios] [varchar](50) NULL,
 CONSTRAINT [PK_Permisos] PRIMARY KEY CLUSTERED 
(
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalidaEmpleado]    Script Date: 04-Dec-19 2:11:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalidaEmpleado](
	[IdSalidaEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[Empleado] [int] NULL,
	[TipoSalida] [varchar](10) NOT NULL,
	[Motivo] [varchar](40) NULL,
	[FechaSalida] [datetime] NULL,
 CONSTRAINT [PK_SalidaEmpleadoes] PRIMARY KEY CLUSTERED 
(
	[IdSalidaEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vacaciones]    Script Date: 04-Dec-19 2:11:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vacaciones](
	[IdVacaciones] [int] IDENTITY(1,1) NOT NULL,
	[Empleado] [int] NOT NULL,
	[Desde] [datetime] NULL,
	[Hasta] [datetime] NULL,
	[Comentario] [varchar](50) NULL,
 CONSTRAINT [PK_Vacaciones] PRIMARY KEY CLUSTERED 
(
	[IdVacaciones] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cargos] ON 

INSERT [dbo].[Cargos] ([IdCargos], [CodigoCargo], [Cargo1]) VALUES (1, 1, N'Encargado')
INSERT [dbo].[Cargos] ([IdCargos], [CodigoCargo], [Cargo1]) VALUES (2, 2, N'Gerente')
INSERT [dbo].[Cargos] ([IdCargos], [CodigoCargo], [Cargo1]) VALUES (3, 3, N'Developer')
SET IDENTITY_INSERT [dbo].[Cargos] OFF
SET IDENTITY_INSERT [dbo].[Departamentos] ON 

INSERT [dbo].[Departamentos] ([IdDepartamento], [CodigoDep], [Nombre], [Encargado]) VALUES (1, 1, N'TI', N'Esteban')
INSERT [dbo].[Departamentos] ([IdDepartamento], [CodigoDep], [Nombre], [Encargado]) VALUES (2, 2, N'Contabilidad', N'Nieves')
INSERT [dbo].[Departamentos] ([IdDepartamento], [CodigoDep], [Nombre], [Encargado]) VALUES (3, 3, N'Financiero', N'Gerardo')
INSERT [dbo].[Departamentos] ([IdDepartamento], [CodigoDep], [Nombre], [Encargado]) VALUES (4, 3234, N'ff', N'wf')
SET IDENTITY_INSERT [dbo].[Departamentos] OFF
SET IDENTITY_INSERT [dbo].[Empleados] ON 

INSERT [dbo].[Empleados] ([IdEmpleado], [Codigo], [Nombre], [Apellido], [Telefono], [Departamento], [Cargo], [FechaIngreso], [Salario], [Estatus]) VALUES (1, 34, N'ef', N'df', N'34324', NULL, 1, NULL, 34, N'A')
INSERT [dbo].[Empleados] ([IdEmpleado], [Codigo], [Nombre], [Apellido], [Telefono], [Departamento], [Cargo], [FechaIngreso], [Salario], [Estatus]) VALUES (2, 3434, N'fddf', N'sadsad', N'sds', NULL, 1, NULL, 32, N'A')
SET IDENTITY_INSERT [dbo].[Empleados] OFF
SET IDENTITY_INSERT [dbo].[Nomina] ON 

INSERT [dbo].[Nomina] ([IdNomina], [Año], [Mes], [MontoTotal]) VALUES (1, 2019, 12, 66)
INSERT [dbo].[Nomina] ([IdNomina], [Año], [Mes], [MontoTotal]) VALUES (2, 2019, 12, 66)
SET IDENTITY_INSERT [dbo].[Nomina] OFF
SET IDENTITY_INSERT [dbo].[Vacaciones] ON 

INSERT [dbo].[Vacaciones] ([IdVacaciones], [Empleado], [Desde], [Hasta], [Comentario]) VALUES (1, 2, NULL, NULL, NULL)
INSERT [dbo].[Vacaciones] ([IdVacaciones], [Empleado], [Desde], [Hasta], [Comentario]) VALUES (2, 1, CAST(N'2019-12-12T00:00:00.000' AS DateTime), CAST(N'2019-12-12T00:00:00.000' AS DateTime), N'Gabriel')
SET IDENTITY_INSERT [dbo].[Vacaciones] OFF
/****** Object:  Index [IX_FK_IdEmpleadoCargos]    Script Date: 04-Dec-19 2:11:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_IdEmpleadoCargos] ON [dbo].[Empleados]
(
	[Cargo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_IdEmpleadoDepartamentos]    Script Date: 04-Dec-19 2:11:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_IdEmpleadoDepartamentos] ON [dbo].[Empleados]
(
	[Departamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_empleadoLicencia]    Script Date: 04-Dec-19 2:11:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_empleadoLicencia] ON [dbo].[Licencias]
(
	[Empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_EmpleadoPermiso]    Script Date: 04-Dec-19 2:11:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_EmpleadoPermiso] ON [dbo].[Permisos]
(
	[Empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_SalidaEmpleado]    Script Date: 04-Dec-19 2:11:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_SalidaEmpleado] ON [dbo].[SalidaEmpleado]
(
	[Empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_IdEmpleadoVacaciones]    Script Date: 04-Dec-19 2:11:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_IdEmpleadoVacaciones] ON [dbo].[Vacaciones]
(
	[Empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_Departamentos] FOREIGN KEY([Departamento])
REFERENCES [dbo].[Departamentos] ([IdDepartamento])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Empleados_Departamentos]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_IdEmpleadoCargos] FOREIGN KEY([Cargo])
REFERENCES [dbo].[Cargos] ([IdCargos])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_IdEmpleadoCargos]
GO
ALTER TABLE [dbo].[Licencias]  WITH CHECK ADD  CONSTRAINT [FK_empleadoLicencia] FOREIGN KEY([Empleado])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
GO
ALTER TABLE [dbo].[Licencias] CHECK CONSTRAINT [FK_empleadoLicencia]
GO
ALTER TABLE [dbo].[Permisos]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadoPermiso] FOREIGN KEY([Empleado])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
GO
ALTER TABLE [dbo].[Permisos] CHECK CONSTRAINT [FK_EmpleadoPermiso]
GO
ALTER TABLE [dbo].[SalidaEmpleado]  WITH CHECK ADD  CONSTRAINT [FK_SalidaEmpleadoes_Empleados] FOREIGN KEY([Empleado])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
GO
ALTER TABLE [dbo].[SalidaEmpleado] CHECK CONSTRAINT [FK_SalidaEmpleadoes_Empleados]
GO
ALTER TABLE [dbo].[Vacaciones]  WITH CHECK ADD  CONSTRAINT [FK_IdEmpleadoVacaciones] FOREIGN KEY([Empleado])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
GO
ALTER TABLE [dbo].[Vacaciones] CHECK CONSTRAINT [FK_IdEmpleadoVacaciones]
GO
ALTER TABLE [dbo].[Nomina]  WITH CHECK ADD  CONSTRAINT [checkaño] CHECK  (([Año]>(2017)))
GO
ALTER TABLE [dbo].[Nomina] CHECK CONSTRAINT [checkaño]
GO
ALTER TABLE [dbo].[Nomina]  WITH CHECK ADD  CONSTRAINT [checkMes] CHECK  (([Mes]>=(1) AND [Mes]<=(12)))
GO
ALTER TABLE [dbo].[Nomina] CHECK CONSTRAINT [checkMes]
GO
USE [master]
GO
ALTER DATABASE [Recursos_Humanos] SET  READ_WRITE 
GO
