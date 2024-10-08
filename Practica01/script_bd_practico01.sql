USE [master]
GO
/****** Object:  Database [Practico01]    Script Date: 31/8/2024 17:13:02 ******/
CREATE DATABASE [Practico01]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Practico01', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Practico01.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Practico01_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Practico01_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Practico01] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Practico01].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Practico01] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Practico01] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Practico01] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Practico01] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Practico01] SET ARITHABORT OFF 
GO
ALTER DATABASE [Practico01] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Practico01] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Practico01] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Practico01] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Practico01] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Practico01] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Practico01] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Practico01] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Practico01] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Practico01] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Practico01] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Practico01] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Practico01] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Practico01] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Practico01] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Practico01] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Practico01] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Practico01] SET RECOVERY FULL 
GO
ALTER DATABASE [Practico01] SET  MULTI_USER 
GO
ALTER DATABASE [Practico01] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Practico01] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Practico01] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Practico01] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Practico01] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Practico01] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Practico01', N'ON'
GO
ALTER DATABASE [Practico01] SET QUERY_STORE = ON
GO
ALTER DATABASE [Practico01] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Practico01]
GO
/****** Object:  Table [dbo].[Articulos]    Script Date: 31/8/2024 17:13:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulos](
	[id_articulo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[precio_unitario] [varchar](50) NULL,
 CONSTRAINT [pk_articulos] PRIMARY KEY CLUSTERED 
(
	[id_articulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleFacturas]    Script Date: 31/8/2024 17:13:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleFacturas](
	[nro_factura] [int] NOT NULL,
	[id_articulo] [int] NOT NULL,
	[cantidad] [int] NULL,
 CONSTRAINT [pk_detalle_facturas] PRIMARY KEY CLUSTERED 
(
	[nro_factura] ASC,
	[id_articulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facturas]    Script Date: 31/8/2024 17:13:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facturas](
	[nro_factura] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NULL,
	[id_forma_pago] [int] NULL,
	[cliente] [varchar](50) NULL,
 CONSTRAINT [pk_facturas] PRIMARY KEY CLUSTERED 
(
	[nro_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormasDePago]    Script Date: 31/8/2024 17:13:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormasDePago](
	[id_forma_pago] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [pk_formas_pago] PRIMARY KEY CLUSTERED 
(
	[id_forma_pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DetalleFacturas]  WITH CHECK ADD  CONSTRAINT [fk_detalleFacturas_articulos] FOREIGN KEY([id_articulo])
REFERENCES [dbo].[Articulos] ([id_articulo])
GO
ALTER TABLE [dbo].[DetalleFacturas] CHECK CONSTRAINT [fk_detalleFacturas_articulos]
GO
ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD  CONSTRAINT [fk_facturas_formasPago] FOREIGN KEY([id_forma_pago])
REFERENCES [dbo].[FormasDePago] ([id_forma_pago])
GO
ALTER TABLE [dbo].[Facturas] CHECK CONSTRAINT [fk_facturas_formasPago]
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_FACTURA_SIMPLE]    Script Date: 31/8/2024 17:13:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ACTUALIZAR_FACTURA_SIMPLE]
    @factura_id INT,
    @fecha DATETIME = NULL,
    @id_forma_pago INT = NULL,
    @cliente NVARCHAR(100) = NULL
AS
BEGIN
    UPDATE Facturas
    SET 
        fecha = ISNULL(@fecha, fecha),
        id_forma_pago = ISNULL(@id_forma_pago, id_forma_pago),
        cliente = ISNULL(@cliente, cliente)
    WHERE nro_factura = @factura_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_DETALLES_POR_FACTURA]    Script Date: 31/8/2024 17:13:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ELIMINAR_DETALLES_POR_FACTURA]
    @factura_id INT
AS
BEGIN
    DELETE FROM DetalleFacturas
    WHERE nro_factura = @factura_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_FACTURA]    Script Date: 31/8/2024 17:13:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ELIMINAR_FACTURA]
    @factura_id INT
AS
BEGIN
    DELETE FROM Facturas
    WHERE nro_factura = @factura_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_DETALLE_FACTURA]    Script Date: 31/8/2024 17:13:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_DETALLE_FACTURA]
    @factura_id INT,
    @id_articulo INT,
    @cantidad INT
AS
BEGIN
    INSERT INTO DetalleFacturas (nro_factura, id_articulo, cantidad)
    VALUES (@factura_id, @id_articulo, @cantidad);
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_FACTURA]    Script Date: 31/8/2024 17:13:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_FACTURA]
    @fecha DATETIME,
    @id_forma_pago INT,
    @cliente NVARCHAR(50),
    @NewFacturaId INT OUTPUT
AS
BEGIN
    INSERT INTO Facturas (fecha, id_forma_pago, cliente)
    VALUES (@fecha, @id_forma_pago, @cliente);
    
    SET @NewFacturaId = SCOPE_IDENTITY();
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_FORMA_PAGO_POR_ID]    Script Date: 31/8/2024 17:13:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_OBTENER_FORMA_PAGO_POR_ID] 
	@id_forma_pago int
AS
BEGIN
	select nombre
	from FormasDePago
	where id_forma_pago = @id_forma_pago
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_FACTURA_POR_ID]    Script Date: 31/8/2024 17:13:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_RECUPERAR_FACTURA_POR_ID] 
	@id_factura int
AS
BEGIN
	
	SELECT *
	FROM Facturas
	WHERE nro_factura = @id_factura
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_FACTURAS]    Script Date: 31/8/2024 17:13:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_RECUPERAR_FACTURAS]
AS
BEGIN
	select * from Facturas
END
GO
USE [master]
GO
ALTER DATABASE [Practico01] SET  READ_WRITE 
GO
