
USE [MeasureMyPike]   
GO
ALTER TABLE [dbo].[Users]   
ADD CONSTRAINT UQ_Username UNIQUE (Username);   
GO

