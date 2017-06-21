
USE [MeasureMyPike]   
GO
ALTER TABLE [dbo].[User]   
ADD CONSTRAINT UQ_Username UNIQUE ([Username]);   
GO

USE [MeasureMyPike]   
GO
ALTER TABLE [dbo].[Brand]   
ADD CONSTRAINT UQ_Brandname UNIQUE ([Name]);   
GO

USE [MeasureMyPike]   
GO
ALTER TABLE [dbo].[Lure]   
ADD CONSTRAINT UQ_Lure UNIQUE ([Name], [Weight], [Colour]);   
GO
