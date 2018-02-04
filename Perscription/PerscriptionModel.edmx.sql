
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/27/2018 17:11:04
-- Generated from EDMX file: C:\Users\inf138537\Desktop\Perscription\Perscription\PerscriptionModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Perscription];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DoctorRecepDoctor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DoctorRecep] DROP CONSTRAINT [FK_DoctorRecepDoctor];
GO
IF OBJECT_ID(N'[dbo].[FK_PerscriptMedicine_Perscript]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PerscriptMedicine] DROP CONSTRAINT [FK_PerscriptMedicine_Perscript];
GO
IF OBJECT_ID(N'[dbo].[FK_PerscriptMedicine_Medicine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PerscriptMedicine] DROP CONSTRAINT [FK_PerscriptMedicine_Medicine];
GO
IF OBJECT_ID(N'[dbo].[FK_PerscriptDoctorRecep]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Perscript] DROP CONSTRAINT [FK_PerscriptDoctorRecep];
GO
IF OBJECT_ID(N'[dbo].[FK_PerscriptPatient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Perscript] DROP CONSTRAINT [FK_PerscriptPatient];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Doctor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Doctor];
GO
IF OBJECT_ID(N'[dbo].[DoctorRecep]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DoctorRecep];
GO
IF OBJECT_ID(N'[dbo].[Level]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Level];
GO
IF OBJECT_ID(N'[dbo].[Medicine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Medicine];
GO
IF OBJECT_ID(N'[dbo].[Patient]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Patient];
GO
IF OBJECT_ID(N'[dbo].[Perscript]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Perscript];
GO
IF OBJECT_ID(N'[dbo].[PerscriptMedicine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PerscriptMedicine];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Doctor'
CREATE TABLE [dbo].[Doctor] (
    [IdDoctor] int IDENTITY(1,1) NOT NULL,
    [PESEL] nchar(11)  NOT NULL,
    [ProfessionNo] int  NOT NULL,
    [Name] varchar(50)  NULL,
    [Surname] varchar(50)  NULL
);
GO

-- Creating table 'DoctorRecep'
CREATE TABLE [dbo].[DoctorRecep] (
    [IdReceiptNo] int IDENTITY(1,1) NOT NULL,
    [ReceiptNumber] bigint  NULL,
    [ReceiptType] varchar(10)  NULL,
    [ReceiptCat] varchar(10)  NULL,
    [IdDoctor] int  NOT NULL
);
GO

-- Creating table 'Level'
CREATE TABLE [dbo].[Level] (
    [IdLevel] int IDENTITY(1,1) NOT NULL,
    [LevelName] varchar(50)  NULL,
    [Description] varchar(300)  NULL,
    [MedicineBL7] int  NOT NULL
);
GO

-- Creating table 'Medicine'
CREATE TABLE [dbo].[Medicine] (
    [BL7] int  NOT NULL,
    [EAN] bigint  NOT NULL,
    [Psychotrop] bit  NOT NULL,
    [Senior] bit  NOT NULL,
    [Vaccine] bit  NOT NULL,
    [Cost] decimal(18,0)  NOT NULL,
    [Name] varchar(250)  NOT NULL,
    [NameInt] varchar(100)  NOT NULL,
    [Form] varchar(100)  NULL,
    [Dose] varchar(100)  NOT NULL,
    [Wrapping] varchar(100)  NULL,
    [Used] bit  NOT NULL
);
GO

-- Creating table 'Patient'
CREATE TABLE [dbo].[Patient] (
    [IdPatient] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Surname] varchar(50)  NOT NULL,
    [PESEL] nvarchar(max)  NOT NULL,
    [Birthday] datetime  NOT NULL,
    [Adddres] varchar(250)  NULL
);
GO

-- Creating table 'Perscript'
CREATE TABLE [dbo].[Perscript] (
    [IdReceipt] int IDENTITY(1,1) NOT NULL,
    [DoctorRecep_IdReceiptNo] int  NOT NULL,
    [Patient_IdPatient] int  NOT NULL
);
GO

-- Creating table 'PerscriptMedicine'
CREATE TABLE [dbo].[PerscriptMedicine] (
    [Perscript_IdReceipt] int  NOT NULL,
    [Medicine_BL7] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdDoctor] in table 'Doctor'
ALTER TABLE [dbo].[Doctor]
ADD CONSTRAINT [PK_Doctor]
    PRIMARY KEY CLUSTERED ([IdDoctor] ASC);
GO

-- Creating primary key on [IdReceiptNo] in table 'DoctorRecep'
ALTER TABLE [dbo].[DoctorRecep]
ADD CONSTRAINT [PK_DoctorRecep]
    PRIMARY KEY CLUSTERED ([IdReceiptNo] ASC);
GO

-- Creating primary key on [IdLevel] in table 'Level'
ALTER TABLE [dbo].[Level]
ADD CONSTRAINT [PK_Level]
    PRIMARY KEY CLUSTERED ([IdLevel] ASC);
GO

-- Creating primary key on [BL7] in table 'Medicine'
ALTER TABLE [dbo].[Medicine]
ADD CONSTRAINT [PK_Medicine]
    PRIMARY KEY CLUSTERED ([BL7] ASC);
GO

-- Creating primary key on [IdPatient] in table 'Patient'
ALTER TABLE [dbo].[Patient]
ADD CONSTRAINT [PK_Patient]
    PRIMARY KEY CLUSTERED ([IdPatient] ASC);
GO

-- Creating primary key on [IdReceipt] in table 'Perscript'
ALTER TABLE [dbo].[Perscript]
ADD CONSTRAINT [PK_Perscript]
    PRIMARY KEY CLUSTERED ([IdReceipt] ASC);
GO

-- Creating primary key on [Perscript_IdReceipt], [Medicine_BL7] in table 'PerscriptMedicine'
ALTER TABLE [dbo].[PerscriptMedicine]
ADD CONSTRAINT [PK_PerscriptMedicine]
    PRIMARY KEY CLUSTERED ([Perscript_IdReceipt], [Medicine_BL7] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdDoctor] in table 'DoctorRecep'
ALTER TABLE [dbo].[DoctorRecep]
ADD CONSTRAINT [FK_DoctorRecepDoctor]
    FOREIGN KEY ([IdDoctor])
    REFERENCES [dbo].[Doctor]
        ([IdDoctor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoctorRecepDoctor'
CREATE INDEX [IX_FK_DoctorRecepDoctor]
ON [dbo].[DoctorRecep]
    ([IdDoctor]);
GO

-- Creating foreign key on [Perscript_IdReceipt] in table 'PerscriptMedicine'
ALTER TABLE [dbo].[PerscriptMedicine]
ADD CONSTRAINT [FK_PerscriptMedicine_Perscript]
    FOREIGN KEY ([Perscript_IdReceipt])
    REFERENCES [dbo].[Perscript]
        ([IdReceipt])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Medicine_BL7] in table 'PerscriptMedicine'
ALTER TABLE [dbo].[PerscriptMedicine]
ADD CONSTRAINT [FK_PerscriptMedicine_Medicine]
    FOREIGN KEY ([Medicine_BL7])
    REFERENCES [dbo].[Medicine]
        ([BL7])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PerscriptMedicine_Medicine'
CREATE INDEX [IX_FK_PerscriptMedicine_Medicine]
ON [dbo].[PerscriptMedicine]
    ([Medicine_BL7]);
GO

-- Creating foreign key on [DoctorRecep_IdReceiptNo] in table 'Perscript'
ALTER TABLE [dbo].[Perscript]
ADD CONSTRAINT [FK_PerscriptDoctorRecep]
    FOREIGN KEY ([DoctorRecep_IdReceiptNo])
    REFERENCES [dbo].[DoctorRecep]
        ([IdReceiptNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PerscriptDoctorRecep'
CREATE INDEX [IX_FK_PerscriptDoctorRecep]
ON [dbo].[Perscript]
    ([DoctorRecep_IdReceiptNo]);
GO

-- Creating foreign key on [Patient_IdPatient] in table 'Perscript'
ALTER TABLE [dbo].[Perscript]
ADD CONSTRAINT [FK_PerscriptPatient]
    FOREIGN KEY ([Patient_IdPatient])
    REFERENCES [dbo].[Patient]
        ([IdPatient])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PerscriptPatient'
CREATE INDEX [IX_FK_PerscriptPatient]
ON [dbo].[Perscript]
    ([Patient_IdPatient]);
GO

-- Creating foreign key on [MedicineBL7] in table 'Level'
ALTER TABLE [dbo].[Level]
ADD CONSTRAINT [FK_MedicineLevel]
    FOREIGN KEY ([MedicineBL7])
    REFERENCES [dbo].[Medicine]
        ([BL7])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MedicineLevel'
CREATE INDEX [IX_FK_MedicineLevel]
ON [dbo].[Level]
    ([MedicineBL7]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------