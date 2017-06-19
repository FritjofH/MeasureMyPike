
USE [MeasureMyPike]   
GO
ALTER TABLE [dbo].[User]   
ADD CONSTRAINT UQ_Username UNIQUE (Username);   
GO

