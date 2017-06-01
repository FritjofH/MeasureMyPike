
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/01/2017 16:20:03
-- Generated from EDMX file: C:\Repos\MeasureMyPike\MeasureMyPike\Model.edmx
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
    ALTER TABLE [dbo].[CatchSet] DROP CONSTRAINT [FK_UserCatch];
GO
IF OBJECT_ID(N'[dbo].[FK_CatchComment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CatchSet] DROP CONSTRAINT [FK_CatchComment];
GO
IF OBJECT_ID(N'[dbo].[FK_CatchFish]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FishSet] DROP CONSTRAINT [FK_CatchFish];
GO
IF OBJECT_ID(N'[dbo].[FK_CatchMedia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MediaSet] DROP CONSTRAINT [FK_CatchMedia];
GO
IF OBJECT_ID(N'[dbo].[FK_MediaImage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MediaSet] DROP CONSTRAINT [FK_MediaImage];
GO
IF OBJECT_ID(N'[dbo].[FK_CatchLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LocationSet] DROP CONSTRAINT [FK_CatchLocation];
GO
IF OBJECT_ID(N'[dbo].[FK_CatchLures]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CatchSet] DROP CONSTRAINT [FK_CatchLures];
GO
IF OBJECT_ID(N'[dbo].[FK_LuresBrand]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LuresSet] DROP CONSTRAINT [FK_LuresBrand];
GO
IF OBJECT_ID(N'[dbo].[FK_LuresStatistics]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LuresSet] DROP CONSTRAINT [FK_LuresStatistics];
GO
IF OBJECT_ID(N'[dbo].[FK_FishStatistics]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FishSet] DROP CONSTRAINT [FK_FishStatistics];
GO
IF OBJECT_ID(N'[dbo].[FK_LocationStatistics]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LocationSet] DROP CONSTRAINT [FK_LocationStatistics];
GO
IF OBJECT_ID(N'[dbo].[FK_CatchStatistics]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CatchSet] DROP CONSTRAINT [FK_CatchStatistics];
GO
IF OBJECT_ID(N'[dbo].[FK_CatchWeatherData]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WeatherDataSet] DROP CONSTRAINT [FK_CatchWeatherData];
GO
IF OBJECT_ID(N'[dbo].[FK_WeatherDataStatistics]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WeatherDataSet] DROP CONSTRAINT [FK_WeatherDataStatistics];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserConnections_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserUserConnections] DROP CONSTRAINT [FK_UserUserConnections_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserConnections_UserConnections]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserUserConnections] DROP CONSTRAINT [FK_UserUserConnections_UserConnections];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[CatchSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatchSet];
GO
IF OBJECT_ID(N'[dbo].[FishSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FishSet];
GO
IF OBJECT_ID(N'[dbo].[CommentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CommentSet];
GO
IF OBJECT_ID(N'[dbo].[MediaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MediaSet];
GO
IF OBJECT_ID(N'[dbo].[MediaDataSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MediaDataSet];
GO
IF OBJECT_ID(N'[dbo].[LocationSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LocationSet];
GO
IF OBJECT_ID(N'[dbo].[BrandSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BrandSet];
GO
IF OBJECT_ID(N'[dbo].[LuresSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LuresSet];
GO
IF OBJECT_ID(N'[dbo].[StatisticsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StatisticsSet];
GO
IF OBJECT_ID(N'[dbo].[WeatherDataSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WeatherDataSet];
GO
IF OBJECT_ID(N'[dbo].[UserConnectionsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserConnectionsSet];
GO
IF OBJECT_ID(N'[dbo].[UserUserConnections]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserUserConnections];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NULL,
    [FirstName] nvarchar(max)  NULL,
    [Password] nvarchar(max)  NOT NULL,
    [MemberSince] datetime  NOT NULL
);
GO

-- Creating table 'Catch'
CREATE TABLE [dbo].[Catch] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Timestamp] datetime  NOT NULL,
    [User_Id] int  NOT NULL,
    [Comment_Id] int  NOT NULL,
    [Lures_Id] int  NOT NULL,
    [Statistics_Id] int  NOT NULL
);
GO

-- Creating table 'Fish'
CREATE TABLE [dbo].[Fish] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Length] nvarchar(max)  NULL,
    [Weight] nvarchar(max)  NULL,
    [Catch_Id] int  NOT NULL,
    [Statistics_Id] int  NOT NULL
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
    [MediaType] nvarchar(max)  NOT NULL,
    [Catch_Id] int  NOT NULL,
    [Image_Id] int  NOT NULL
);
GO

-- Creating table 'MediaData'
CREATE TABLE [dbo].[MediaData] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Data] tinyint  NOT NULL,
    [Length] int  NOT NULL,
    [Format] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Location'
CREATE TABLE [dbo].[Location] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Lake] nvarchar(max)  NOT NULL,
    [Coordinates] nvarchar(max)  NULL,
    [Catch_Id] int  NOT NULL,
    [Statistics_Id] int  NOT NULL
);
GO

-- Creating table 'Brand'
CREATE TABLE [dbo].[Brand] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Lures'
CREATE TABLE [dbo].[Lures] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Brand_Id] int  NOT NULL,
    [Statistics_Id] int  NOT NULL
);
GO

-- Creating table 'Statistics'
CREATE TABLE [dbo].[Statistics] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'WeatherData'
CREATE TABLE [dbo].[WeatherData] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Temperature] nvarchar(max)  NOT NULL,
    [Weather] nvarchar(max)  NOT NULL,
    [MoonPosition] nvarchar(max)  NOT NULL,
    [Catch_Id] int  NOT NULL,
    [Statistics_Id] int  NOT NULL
);
GO

-- Creating table 'UserConnections'
CREATE TABLE [dbo].[UserConnections] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FriendsSince] datetime  NOT NULL
);
GO

-- Creating table 'UserUserConnections'
CREATE TABLE [dbo].[UserUserConnections] (
    [User_Id] int  NOT NULL,
    [UserConnections_Id] int  NOT NULL
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

-- Creating primary key on [Id] in table 'Lures'
ALTER TABLE [dbo].[Lures]
ADD CONSTRAINT [PK_Lures]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Statistics'
ALTER TABLE [dbo].[Statistics]
ADD CONSTRAINT [PK_Statistics]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WeatherData'
ALTER TABLE [dbo].[WeatherData]
ADD CONSTRAINT [PK_WeatherData]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserConnections'
ALTER TABLE [dbo].[UserConnections]
ADD CONSTRAINT [PK_UserConnections]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [User_Id], [UserConnections_Id] in table 'UserUserConnections'
ALTER TABLE [dbo].[UserUserConnections]
ADD CONSTRAINT [PK_UserUserConnections]
    PRIMARY KEY CLUSTERED ([User_Id], [UserConnections_Id] ASC);
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

-- Creating foreign key on [Catch_Id] in table 'Fish'
ALTER TABLE [dbo].[Fish]
ADD CONSTRAINT [FK_CatchFish]
    FOREIGN KEY ([Catch_Id])
    REFERENCES [dbo].[Catch]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CatchFish'
CREATE INDEX [IX_FK_CatchFish]
ON [dbo].[Fish]
    ([Catch_Id]);
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

-- Creating foreign key on [Catch_Id] in table 'Location'
ALTER TABLE [dbo].[Location]
ADD CONSTRAINT [FK_CatchLocation]
    FOREIGN KEY ([Catch_Id])
    REFERENCES [dbo].[Catch]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CatchLocation'
CREATE INDEX [IX_FK_CatchLocation]
ON [dbo].[Location]
    ([Catch_Id]);
GO

-- Creating foreign key on [Lures_Id] in table 'Catch'
ALTER TABLE [dbo].[Catch]
ADD CONSTRAINT [FK_CatchLures]
    FOREIGN KEY ([Lures_Id])
    REFERENCES [dbo].[Lures]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CatchLures'
CREATE INDEX [IX_FK_CatchLures]
ON [dbo].[Catch]
    ([Lures_Id]);
GO

-- Creating foreign key on [Brand_Id] in table 'Lures'
ALTER TABLE [dbo].[Lures]
ADD CONSTRAINT [FK_LuresBrand]
    FOREIGN KEY ([Brand_Id])
    REFERENCES [dbo].[Brand]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LuresBrand'
CREATE INDEX [IX_FK_LuresBrand]
ON [dbo].[Lures]
    ([Brand_Id]);
GO

-- Creating foreign key on [Statistics_Id] in table 'Lures'
ALTER TABLE [dbo].[Lures]
ADD CONSTRAINT [FK_LuresStatistics]
    FOREIGN KEY ([Statistics_Id])
    REFERENCES [dbo].[Statistics]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LuresStatistics'
CREATE INDEX [IX_FK_LuresStatistics]
ON [dbo].[Lures]
    ([Statistics_Id]);
GO

-- Creating foreign key on [Statistics_Id] in table 'Fish'
ALTER TABLE [dbo].[Fish]
ADD CONSTRAINT [FK_FishStatistics]
    FOREIGN KEY ([Statistics_Id])
    REFERENCES [dbo].[Statistics]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FishStatistics'
CREATE INDEX [IX_FK_FishStatistics]
ON [dbo].[Fish]
    ([Statistics_Id]);
GO

-- Creating foreign key on [Statistics_Id] in table 'Location'
ALTER TABLE [dbo].[Location]
ADD CONSTRAINT [FK_LocationStatistics]
    FOREIGN KEY ([Statistics_Id])
    REFERENCES [dbo].[Statistics]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LocationStatistics'
CREATE INDEX [IX_FK_LocationStatistics]
ON [dbo].[Location]
    ([Statistics_Id]);
GO

-- Creating foreign key on [Statistics_Id] in table 'Catch'
ALTER TABLE [dbo].[Catch]
ADD CONSTRAINT [FK_CatchStatistics]
    FOREIGN KEY ([Statistics_Id])
    REFERENCES [dbo].[Statistics]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CatchStatistics'
CREATE INDEX [IX_FK_CatchStatistics]
ON [dbo].[Catch]
    ([Statistics_Id]);
GO

-- Creating foreign key on [Catch_Id] in table 'WeatherData'
ALTER TABLE [dbo].[WeatherData]
ADD CONSTRAINT [FK_CatchWeatherData]
    FOREIGN KEY ([Catch_Id])
    REFERENCES [dbo].[Catch]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CatchWeatherData'
CREATE INDEX [IX_FK_CatchWeatherData]
ON [dbo].[WeatherData]
    ([Catch_Id]);
GO

-- Creating foreign key on [Statistics_Id] in table 'WeatherData'
ALTER TABLE [dbo].[WeatherData]
ADD CONSTRAINT [FK_WeatherDataStatistics]
    FOREIGN KEY ([Statistics_Id])
    REFERENCES [dbo].[Statistics]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WeatherDataStatistics'
CREATE INDEX [IX_FK_WeatherDataStatistics]
ON [dbo].[WeatherData]
    ([Statistics_Id]);
GO

-- Creating foreign key on [User_Id] in table 'UserUserConnections'
ALTER TABLE [dbo].[UserUserConnections]
ADD CONSTRAINT [FK_UserUserConnections_User]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserConnections_Id] in table 'UserUserConnections'
ALTER TABLE [dbo].[UserUserConnections]
ADD CONSTRAINT [FK_UserUserConnections_UserConnections]
    FOREIGN KEY ([UserConnections_Id])
    REFERENCES [dbo].[UserConnections]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUserConnections_UserConnections'
CREATE INDEX [IX_FK_UserUserConnections_UserConnections]
ON [dbo].[UserUserConnections]
    ([UserConnections_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------