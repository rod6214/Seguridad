
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/26/2018 00:42:48
-- Generated from EDMX file: C:\Desarrollo\backend\Data\Seguridad\Data.Usuarios\Entities\SeguridadEntity.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [seguridad];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UsuarioSesion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sesion] DROP CONSTRAINT [FK_UsuarioSesion];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario];
GO
IF OBJECT_ID(N'[dbo].[Sesion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sesion];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Usuario'
CREATE TABLE [dbo].[Usuario] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [pass] nvarchar(max)  NOT NULL,
    [role] tinyint  NOT NULL
);
GO

-- Creating table 'Sesion'
CREATE TABLE [dbo].[Sesion] (
    [id] int IDENTITY(1,1) NOT NULL,
    [key] nvarchar(max)  NOT NULL,
    [value] nvarchar(max)  NOT NULL,
    [duration] bigint  NOT NULL,
    [initTime] datetime  NOT NULL,
    [Usuario_id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [PK_Usuario]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Sesion'
ALTER TABLE [dbo].[Sesion]
ADD CONSTRAINT [PK_Sesion]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Usuario_id] in table 'Sesion'
ALTER TABLE [dbo].[Sesion]
ADD CONSTRAINT [FK_UsuarioSesion]
    FOREIGN KEY ([Usuario_id])
    REFERENCES [dbo].[Usuario]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioSesion'
CREATE INDEX [IX_FK_UsuarioSesion]
ON [dbo].[Sesion]
    ([Usuario_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------