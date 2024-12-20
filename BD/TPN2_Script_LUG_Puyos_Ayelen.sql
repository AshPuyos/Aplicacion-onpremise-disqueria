USE [LUG_TP2_ Puyos_Ayelen]
GO
/****** Object:  Table [dbo].[Genero]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genero](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Genero_1] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Artista] [nvarchar](50) NOT NULL,
	[Album] [nvarchar](50) NOT NULL,
	[Precio] [float] NOT NULL,
	[Lanzamiento] [int] NOT NULL,
	[Estado] [bit] NULL,
	[Usado] [bit] NULL,
	[CodGenero] [int] NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto_Vendedor]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto_Vendedor](
	[CodProducto] [int] NOT NULL,
	[CodVendedor] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vendedor]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendedor](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Vendedor] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Genero] FOREIGN KEY([CodGenero])
REFERENCES [dbo].[Genero] ([Codigo])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Genero]
GO
ALTER TABLE [dbo].[Producto_Vendedor]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Vendedor_Producto] FOREIGN KEY([CodProducto])
REFERENCES [dbo].[Producto] ([Codigo])
GO
ALTER TABLE [dbo].[Producto_Vendedor] CHECK CONSTRAINT [FK_Producto_Vendedor_Producto]
GO
ALTER TABLE [dbo].[Producto_Vendedor]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Vendedor_Vendedor] FOREIGN KEY([CodVendedor])
REFERENCES [dbo].[Vendedor] ([Codigo])
GO
ALTER TABLE [dbo].[Producto_Vendedor] CHECK CONSTRAINT [FK_Producto_Vendedor_Vendedor]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarCd]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ActualizarCd]
    @Codigo INT,
    @Artista NVARCHAR(100),
    @Album NVARCHAR(100),
    @Precio FLOAT,
    @Lanzamiento INT,
    @Estado BIT,
    @CodGenero INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Producto
    SET Artista = @Artista,
        Album = @Album,
        Precio = @Precio,
        Lanzamiento = @Lanzamiento,
        Estado = @Estado,
        CodGenero = @CodGenero,
        Usado = NULL -- CDs no son usados
    WHERE Codigo = @Codigo;
END

GO
/****** Object:  StoredProcedure [dbo].[ActualizarGenero]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ActualizarGenero]
    @Codigo INT,
    @Nombre VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Genero
    SET Nombre = @Nombre
    WHERE Codigo = @Codigo;
END
GO
/****** Object:  StoredProcedure [dbo].[ActualizarProducto]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Your Name>
-- Create date: <Today's Date>
-- Description:	Actualiza un producto existente
-- =============================================
CREATE PROCEDURE [dbo].[ActualizarProducto]
    @Codigo INT,
    @Artista NVARCHAR(50),
    @Album NVARCHAR(50),
    @Precio FLOAT,
    @Lanzamiento INT,
    @Estado BIT,
    @Usado BIT,
    @CodGenero INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Producto
    SET Artista = @Artista, Album = @Album, Precio = @Precio, Lanzamiento = @Lanzamiento, 
        Estado = @Estado, Usado = @Usado, CodGenero = @CodGenero
    WHERE Codigo = @Codigo;
END
GO
/****** Object:  StoredProcedure [dbo].[ActualizarVendedor]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ActualizarVendedor]
    @Codigo INT,
    @Nombre VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Vendedor
    SET Nombre = @Nombre
    WHERE Codigo = @Codigo;
END
GO
/****** Object:  StoredProcedure [dbo].[ActualizarVinilo]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ActualizarVinilo]
    @Codigo INT,
    @Artista NVARCHAR(100),
    @Album NVARCHAR(100),
    @Precio FLOAT,
    @Lanzamiento INT,
    @Estado BIT,
    @CodGenero INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Producto
    SET Artista = @Artista,
        Album = @Album,
        Precio = @Precio,
        Lanzamiento = @Lanzamiento,
        Estado = @Estado,
        CodGenero = @CodGenero,
        Usado = 1 -- Vinilos son usados
    WHERE Codigo = @Codigo;
END
GO
/****** Object:  StoredProcedure [dbo].[CancelarVentaProducto]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CancelarVentaProducto]
    @CodProducto INT,
    @CodVendedor INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Marcar el producto como disponible (Estado = 1)
    UPDATE Producto
    SET Estado = 1
    WHERE Codigo = @CodProducto;

    -- Eliminar el registro de la venta de Producto_Vendedor
    DELETE FROM Producto_Vendedor
    WHERE CodProducto = @CodProducto AND CodVendedor = @CodVendedor;
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarCd]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EliminarCd]
    @Codigo INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Producto
    WHERE Codigo = @Codigo AND Usado IS NULL;
END

GO
/****** Object:  StoredProcedure [dbo].[EliminarGenero]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EliminarGenero]
    @Codigo INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Genero
    WHERE Codigo = @Codigo;
END

GO
/****** Object:  StoredProcedure [dbo].[EliminarProducto]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Your Name>
-- Create date: <Today's Date>
-- Description:	Elimina un producto por código
-- =============================================
CREATE PROCEDURE [dbo].[EliminarProducto]
    @Codigo INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Producto
    WHERE Codigo = @Codigo;
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarVendedor]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarVendedor]
    @Codigo INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Vendedor
    WHERE Codigo = @Codigo;
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarVinilo]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EliminarVinilo]
    @Codigo INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Producto
    WHERE Codigo = @Codigo AND Usado = 1;
END

GO
/****** Object:  StoredProcedure [dbo].[GuardarCd]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GuardarCd]
    @Codigo INT = NULL,
    @Artista NVARCHAR(100),
    @Album NVARCHAR(100),
    @Precio FLOAT,
    @Lanzamiento INT,
    @Estado BIT,
    @CodGenero INT
AS
BEGIN
    SET NOCOUNT ON;

    IF @Codigo IS NULL
    BEGIN
        INSERT INTO Producto (Artista, Album, Precio, Lanzamiento, Estado, CodGenero, Usado)
        VALUES (@Artista, @Album, @Precio, @Lanzamiento, @Estado, @CodGenero, 0);
    END
    ELSE
    BEGIN
        UPDATE Producto
        SET Artista = @Artista,
            Album = @Album,
            Precio = @Precio,
            Lanzamiento = @Lanzamiento,
            Estado = @Estado,
            CodGenero = @CodGenero,
            Usado = 0
        WHERE Codigo = @Codigo;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[GuardarVinilo]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GuardarVinilo]
    @Codigo INT = NULL,
    @Artista NVARCHAR(100),
    @Album NVARCHAR(100),
    @Precio FLOAT,
    @Lanzamiento INT,
    @Estado BIT,
    @CodGenero INT
AS
BEGIN
    SET NOCOUNT ON;

    IF @Codigo IS NULL
    BEGIN
        INSERT INTO Producto (Artista, Album, Precio, Lanzamiento, Estado, CodGenero, Usado)
        VALUES (@Artista, @Album, @Precio, @Lanzamiento, @Estado, @CodGenero, 1);
    END
    ELSE
    BEGIN
        UPDATE Producto
        SET Artista = @Artista,
            Album = @Album,
            Precio = @Precio,
            Lanzamiento = @Lanzamiento,
            Estado = @Estado,
            CodGenero = @CodGenero,
            Usado = 1
        WHERE Codigo = @Codigo;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarCd]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertarCd]
    @Artista NVARCHAR(100),
    @Album NVARCHAR(100),
    @Precio FLOAT,
    @Lanzamiento INT,
    @Estado BIT,
    @CodGenero INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Producto (Artista, Album, Precio, Lanzamiento, Estado, CodGenero, Usado)
    VALUES (@Artista, @Album, @Precio, @Lanzamiento, @Estado, @CodGenero, NULL); -- CDs no son usados, se establece en 0
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarGenero]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertarGenero]
    @Nombre VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Genero (Nombre)
    VALUES (@Nombre);
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarProducto]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Your Name>
-- Create date: <Today's Date>
-- Description:	Inserta un nuevo producto
-- =============================================
CREATE PROCEDURE [dbo].[InsertarProducto]
    @Artista NVARCHAR(50),
    @Album NVARCHAR(50),
    @Precio FLOAT,
    @Lanzamiento INT,
    @Estado BIT,
    @Usado BIT,
    @CodGenero INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Producto (Artista, Album, Precio, Lanzamiento, Estado, Usado, CodGenero)
    VALUES (@Artista, @Album, @Precio, @Lanzamiento, @Estado, @Usado, @CodGenero);
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarVendedor]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarVendedor]
    @Nombre VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Vendedor (Nombre)
    VALUES (@Nombre);
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarVinilo]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertarVinilo]
    @Artista NVARCHAR(100),
    @Album NVARCHAR(100),
    @Precio FLOAT,
    @Lanzamiento INT,
    @Estado BIT,
    @CodGenero INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Producto (Artista, Album, Precio, Lanzamiento, Estado, CodGenero, Usado)
    VALUES (@Artista, @Album, @Precio, @Lanzamiento, @Estado, @CodGenero, 1); -- Vinilos son usados, se establece en 1
END
GO
/****** Object:  StoredProcedure [dbo].[ListarCds]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarCds]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        P.Codigo, 
        P.Artista, 
        P.Album, 
        P.Precio, 
        P.Lanzamiento, 
        P.Estado, 
        P.CodGenero, 
        G.Nombre
    FROM 
        Producto P
    INNER JOIN 
        Genero G ON P.CodGenero = G.Codigo
    WHERE 
        P.Usado = 0 OR P.Usado IS NULL;  -- 0 o NULL para CDs
END
GO
/****** Object:  StoredProcedure [dbo].[ListarGeneros]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarGeneros]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Codigo, Nombre
    FROM Genero;
END
GO
/****** Object:  StoredProcedure [dbo].[ListarProductos]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Your Name>
-- Create date: <Today's Date>
-- Description:	Lista todos los productos
-- =============================================
CREATE PROCEDURE [dbo].[ListarProductos]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM Producto;
END
GO
/****** Object:  StoredProcedure [dbo].[ListarProductosPorVendedor]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Your Name>
-- Create date: <Date>
-- Description:	Listar productos vendidos por vendedor
-- =============================================
CREATE PROCEDURE [dbo].[ListarProductosPorVendedor]
    @VendedorCodigo INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        P.Codigo,
        P.Artista,
        P.Album,
        P.Precio,
        P.Lanzamiento,
        P.Estado,
        P.Usado,
        P.CodGenero,
        G.Nombre
    FROM 
        Producto_Vendedor PV
    JOIN 
        Producto P ON PV.CodProducto = P.Codigo
    JOIN 
        Genero G ON P.CodGenero = G.Codigo
    WHERE 
        PV.CodVendedor = @VendedorCodigo;
END
GO
/****** Object:  StoredProcedure [dbo].[ListarVendedores]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Your Name>
-- Create date: <Today's Date>
-- Description:	Lista todos los vendedores
-- =============================================
CREATE PROCEDURE [dbo].[ListarVendedores]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM Vendedor;
END
GO
/****** Object:  StoredProcedure [dbo].[ListarVinilos]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Your Name>
-- Create date: <Today's Date>
-- Description:	Lista todos los vinilos
-- =============================================
CREATE PROCEDURE [dbo].[ListarVinilos]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
        P.Codigo, 
        P.Artista, 
        P.Album, 
        P.Precio, 
        P.Lanzamiento, 
        P.Estado, 
        P.CodGenero, 
        G.Nombre AS Genero
    FROM 
        Producto P
    INNER JOIN 
        Genero G ON P.CodGenero = G.Codigo
    WHERE 
        P.Usado = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerCd]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerCd]
    @Codigo INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Codigo, Artista, Album, Precio, Lanzamiento, Estado, CodGenero
    FROM Producto
    WHERE Codigo = @Codigo AND Usado = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerProducto]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Your Name>
-- Create date: <Today's Date>
-- Description:	Obtiene un producto por código
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerProducto]
    @Codigo INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM Producto
    WHERE Codigo = @Codigo;
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerVendedor]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Your Name>
-- Create date: <Today's Date>
-- Description:	Obtiene un vendedor por código
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerVendedor]
    @Codigo INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM Vendedor
    WHERE Codigo = @Codigo;
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerVinilo]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerVinilo]
    @Codigo INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Codigo, Artista, Album, Precio, Lanzamiento, Estado, CodGenero
    FROM Producto
    WHERE Codigo = @Codigo AND Usado = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[VenderProducto]    Script Date: 1/7/2024 12:29:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[VenderProducto]
    @CodProducto INT,
    @CodVendedor INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Marcar el producto como vendido (Estado = 0)
    UPDATE Producto
    SET Estado = 0
    WHERE Codigo = @CodProducto;

    -- Insertar el registro de la venta en Producto_Vendedor
    INSERT INTO Producto_Vendedor (CodProducto, CodVendedor)
    VALUES (@CodProducto, @CodVendedor);
END
GO
