
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/10/2017 12:41:03
-- Generated from EDMX file: C:\src\Repos\MeasureMyPike\MeasureMyPike.Domain\Models\MeasureMyPikeModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MeasureMyPike];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserCatch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Catch] DROP CONSTRAINT [FK_UserCatch];
GO
IF OBJECT_ID(N'[dbo].[FK_CatchComment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Catch] DROP CONSTRAINT [FK_CatchComment];
GO
IF OBJECT_ID(N'[dbo].[FK_CatchFish]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Catch] DROP CONSTRAINT [FK_CatchFish];
GO
IF OBJECT_ID(N'[dbo].[FK_CatchMedia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Media] DROP CONSTRAINT [FK_CatchMedia];
GO
IF OBJECT_ID(N'[dbo].[FK_MediaImage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Media] DROP CONSTRAINT [FK_MediaImage];
GO
IF OBJECT_ID(N'[dbo].[FK_CatchLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Catch] DROP CONSTRAINT [FK_CatchLocation];
GO
IF OBJECT_ID(N'[dbo].[FK_CatchLures]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Catch] DROP CONSTRAINT [FK_CatchLures];
GO
IF OBJECT_ID(N'[dbo].[FK_LuresBrand]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Lure] DROP CONSTRAINT [FK_LuresBrand];
GO
IF OBJECT_ID(N'[dbo].[FK_CatchWeatherData]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Catch] DROP CONSTRAINT [FK_CatchWeatherData];
GO
IF OBJECT_ID(N'[dbo].[FK_SecurityUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Security] DROP CONSTRAINT [FK_SecurityUser];
GO
IF OBJECT_ID(N'[dbo].[FK_UserTackleBox]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_UserTackleBox];
GO
IF OBJECT_ID(N'[dbo].[FK_LureTackleBox_Lure]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LureTackleBox] DROP CONSTRAINT [FK_LureTackleBox_Lure];
GO
IF OBJECT_ID(N'[dbo].[FK_LureTackleBox_TackleBox]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LureTackleBox] DROP CONSTRAINT [FK_LureTackleBox_TackleBox];
GO
IF OBJECT_ID(N'[dbo].[FK_LakeLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Location] DROP CONSTRAINT [FK_LakeLocation];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Catch]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Catch];
GO
IF OBJECT_ID(N'[dbo].[Fish]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Fish];
GO
IF OBJECT_ID(N'[dbo].[Comment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comment];
GO
IF OBJECT_ID(N'[dbo].[Media]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Media];
GO
IF OBJECT_ID(N'[dbo].[MediaData]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MediaData];
GO
IF OBJECT_ID(N'[dbo].[Location]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Location];
GO
IF OBJECT_ID(N'[dbo].[Brand]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Brand];
GO
IF OBJECT_ID(N'[dbo].[Lure]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lure];
GO
IF OBJECT_ID(N'[dbo].[WeatherData]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WeatherData];
GO
IF OBJECT_ID(N'[dbo].[Security]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Security];
GO
IF OBJECT_ID(N'[dbo].[TackleBox]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TackleBox];
GO
IF OBJECT_ID(N'[dbo].[Lake]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lake];
GO
IF OBJECT_ID(N'[dbo].[LureTackleBox]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LureTackleBox];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(max)  NULL,
    [FirstName] nvarchar(max)  NULL,
    [MemberSince] datetime  NOT NULL,
    [TackleBox_Id] int  NOT NULL
);
GO

-- Creating table 'Catch'
CREATE TABLE [dbo].[Catch] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Timestamp] datetime  NOT NULL,
    [User_Id] int  NOT NULL,
    [Comment_Id] int  NOT NULL,
    [Fish_Id] int  NOT NULL,
    [Location_Id] int  NOT NULL,
    [Lure_Id] int  NOT NULL,
    [WeatherData_Id] int  NOT NULL
);
GO

-- Creating table 'Fish'
CREATE TABLE [dbo].[Fish] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Length] nvarchar(max)  NULL,
    [Weight] nvarchar(max)  NULL
);
GO

-- Creating table 'Comment'
CREATE TABLE [dbo].[Comment] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Media'
CREATE TABLE [dbo].[Media] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MediaFormat] nvarchar(max)  NOT NULL,
    [Catch_Id] int  NOT NULL,
    [Image_Id] int  NOT NULL
);
GO

-- Creating table 'MediaData'
CREATE TABLE [dbo].[MediaData] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Data] varbinary(max)  NOT NULL,
    [Length] int  NOT NULL
);
GO

-- Creating table 'Location'
CREATE TABLE [dbo].[Location] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Coordinates] nvarchar(max)  NULL,
    [Lake_Id] int  NOT NULL
);
GO

-- Creating table 'Brand'
CREATE TABLE [dbo].[Brand] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Lure'
CREATE TABLE [dbo].[Lure] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Weight] int  NULL,
    [Colour] nvarchar(35)  NULL,
    [Brand_Id] int  NOT NULL
);
GO

-- Creating table 'WeatherData'
CREATE TABLE [dbo].[WeatherData] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [WaterTemperature] float  NULL,
    [Weather] nvarchar(max)  NOT NULL,
    [MoonPosition] nvarchar(max)  NOT NULL,
    [AirTemperature] float  NULL
);
GO

-- Creating table 'Security'
CREATE TABLE [dbo].[Security] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'TackleBox'
CREATE TABLE [dbo].[TackleBox] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DatePurchased] datetime  NULL
);
GO

-- Creating table 'Lake'
CREATE TABLE [dbo].[Lake] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'LureTackleBox'
CREATE TABLE [dbo].[LureTackleBox] (
    [Lure_Id] int  NOT NULL,
    [TackleBox_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Catch'
ALTER TABLE [dbo].[Catch]
ADD CONSTRAINT [PK_Catch]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Fish'
ALTER TABLE [dbo].[Fish]
ADD CONSTRAINT [PK_Fish]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comment'
ALTER TABLE [dbo].[Comment]
ADD CONSTRAINT [PK_Comment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Media'
ALTER TABLE [dbo].[Media]
ADD CONSTRAINT [PK_Media]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MediaData'
ALTER TABLE [dbo].[MediaData]
ADD CONSTRAINT [PK_MediaData]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Location'
ALTER TABLE [dbo].[Location]
ADD CONSTRAINT [PK_Location]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Brand'
ALTER TABLE [dbo].[Brand]
ADD CONSTRAINT [PK_Brand]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Lure'
ALTER TABLE [dbo].[Lure]
ADD CONSTRAINT [PK_Lure]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WeatherData'
ALTER TABLE [dbo].[WeatherData]
ADD CONSTRAINT [PK_WeatherData]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Security'
ALTER TABLE [dbo].[Security]
ADD CONSTRAINT [PK_Security]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TackleBox'
ALTER TABLE [dbo].[TackleBox]
ADD CONSTRAINT [PK_TackleBox]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Lake'
ALTER TABLE [dbo].[Lake]
ADD CONSTRAINT [PK_Lake]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Lure_Id], [TackleBox_Id] in table 'LureTackleBox'
ALTER TABLE [dbo].[LureTackleBox]
ADD CONSTRAINT [PK_LureTackleBox]
    PRIMARY KEY CLUSTERED ([Lure_Id], [TackleBox_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_Id] in table 'Catch'
ALTER TABLE [dbo].[Catch]
ADD CONSTRAINT [FK_UserCatch]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserCatch'
CREATE INDEX [IX_FK_UserCatch]
ON [dbo].[Catch]
    ([User_Id]);
GO

-- Creating foreign key on [Comment_Id] in table 'Catch'
ALTER TABLE [dbo].[Catch]
ADD CONSTRAINT [FK_CatchComment]
    FOREIGN KEY ([Comment_Id])
    REFERENCES [dbo].[Comment]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CatchComment'
CREATE INDEX [IX_FK_CatchComment]
ON [dbo].[Catch]
    ([Comment_Id]);
GO

-- Creating foreign key on [Fish_Id] in table 'Catch'
ALTER TABLE [dbo].[Catch]
ADD CONSTRAINT [FK_CatchFish]
    FOREIGN KEY ([Fish_Id])
    REFERENCES [dbo].[Fish]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CatchFish'
CREATE INDEX [IX_FK_CatchFish]
ON [dbo].[Catch]
    ([Fish_Id]);
GO

-- Creating foreign key on [Catch_Id] in table 'Media'
ALTER TABLE [dbo].[Media]
ADD CONSTRAINT [FK_CatchMedia]
    FOREIGN KEY ([Catch_Id])
    REFERENCES [dbo].[Catch]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CatchMedia'
CREATE INDEX [IX_FK_CatchMedia]
ON [dbo].[Media]
    ([Catch_Id]);
GO

-- Creating foreign key on [Image_Id] in table 'Media'
ALTER TABLE [dbo].[Media]
ADD CONSTRAINT [FK_MediaImage]
    FOREIGN KEY ([Image_Id])
    REFERENCES [dbo].[MediaData]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MediaImage'
CREATE INDEX [IX_FK_MediaImage]
ON [dbo].[Media]
    ([Image_Id]);
GO

-- Creating foreign key on [Location_Id] in table 'Catch'
ALTER TABLE [dbo].[Catch]
ADD CONSTRAINT [FK_CatchLocation]
    FOREIGN KEY ([Location_Id])
    REFERENCES [dbo].[Location]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CatchLocation'
CREATE INDEX [IX_FK_CatchLocation]
ON [dbo].[Catch]
    ([Location_Id]);
GO

-- Creating foreign key on [Lure_Id] in table 'Catch'
ALTER TABLE [dbo].[Catch]
ADD CONSTRAINT [FK_CatchLures]
    FOREIGN KEY ([Lure_Id])
    REFERENCES [dbo].[Lure]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CatchLures'
CREATE INDEX [IX_FK_CatchLures]
ON [dbo].[Catch]
    ([Lure_Id]);
GO

-- Creating foreign key on [Brand_Id] in table 'Lure'
ALTER TABLE [dbo].[Lure]
ADD CONSTRAINT [FK_LuresBrand]
    FOREIGN KEY ([Brand_Id])
    REFERENCES [dbo].[Brand]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LuresBrand'
CREATE INDEX [IX_FK_LuresBrand]
ON [dbo].[Lure]
    ([Brand_Id]);
GO

-- Creating foreign key on [WeatherData_Id] in table 'Catch'
ALTER TABLE [dbo].[Catch]
ADD CONSTRAINT [FK_CatchWeatherData]
    FOREIGN KEY ([WeatherData_Id])
    REFERENCES [dbo].[WeatherData]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CatchWeatherData'
CREATE INDEX [IX_FK_CatchWeatherData]
ON [dbo].[Catch]
    ([WeatherData_Id]);
GO

-- Creating foreign key on [User_Id] in table 'Security'
ALTER TABLE [dbo].[Security]
ADD CONSTRAINT [FK_SecurityUser]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SecurityUser'
CREATE INDEX [IX_FK_SecurityUser]
ON [dbo].[Security]
    ([User_Id]);
GO

-- Creating foreign key on [TackleBox_Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_UserTackleBox]
    FOREIGN KEY ([TackleBox_Id])
    REFERENCES [dbo].[TackleBox]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTackleBox'
CREATE INDEX [IX_FK_UserTackleBox]
ON [dbo].[User]
    ([TackleBox_Id]);
GO

-- Creating foreign key on [Lure_Id] in table 'LureTackleBox'
ALTER TABLE [dbo].[LureTackleBox]
ADD CONSTRAINT [FK_LureTackleBox_Lure]
    FOREIGN KEY ([Lure_Id])
    REFERENCES [dbo].[Lure]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TackleBox_Id] in table 'LureTackleBox'
ALTER TABLE [dbo].[LureTackleBox]
ADD CONSTRAINT [FK_LureTackleBox_TackleBox]
    FOREIGN KEY ([TackleBox_Id])
    REFERENCES [dbo].[TackleBox]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LureTackleBox_TackleBox'
CREATE INDEX [IX_FK_LureTackleBox_TackleBox]
ON [dbo].[LureTackleBox]
    ([TackleBox_Id]);
GO

-- Creating foreign key on [Lake_Id] in table 'Location'
ALTER TABLE [dbo].[Location]
ADD CONSTRAINT [FK_LakeLocation]
    FOREIGN KEY ([Lake_Id])
    REFERENCES [dbo].[Lake]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LakeLocation'
CREATE INDEX [IX_FK_LakeLocation]
ON [dbo].[Location]
    ([Lake_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------