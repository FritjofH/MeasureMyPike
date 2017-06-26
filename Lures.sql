﻿USE MeasureMyPike
GO
INSERT INTO Lure (Name, Weight, Colour, Brand_Id) select 'HI-LO 15 CM', 40, 'Atomic Perch', Id from Brand where Name like 'Abu Garcia'
INSERT INTO Lure (Name, Weight, Colour, Brand_Id) select 'TORMENTOR 11 CM', 20, 'Green/Orange', Id from Brand where Name like 'Abu Garcia'
INSERT INTO Lure (Name, Weight, Colour, Brand_Id) select 'Berkley Power Blade', 11, 'Assassin', Id from Brand where Name like 'Berkley'
INSERT INTO Lure (Name, Weight, Colour, Brand_Id) select 'Berkley Power Blade', 11, 'Bluegill', Id from Brand where Name like 'Berkley'
INSERT INTO Lure (Name, Weight, Colour, Brand_Id) select 'Berkley Power Blade', 11, 'Fire Tiger', Id from Brand where Name like 'Berkley'
INSERT INTO Lure (Name, Weight, Colour, Brand_Id) select 'X-Rap Twitchin Minnow', 14, 'Albino Shiner', Id from Brand where Name like 'Rapala'
INSERT INTO Lure (Name, Weight, Colour, Brand_Id) select 'X-Rap Twitchin Mullet', 20, 'Blue Sardine', Id from Brand where Name like 'Rapala'
INSERT INTO Lure (Name, Weight, Colour, Brand_Id) select 'Deviator Belly Up', 22, 'Dirty Roach', Id from Brand where Name like 'Savage Gear'
INSERT INTO Lure (Name, Weight, Colour, Brand_Id) select 'Freestyler V2', 42, 'Firetiger', Id from Brand where Name like 'Savage Gear'
INSERT INTO Lure (Name, Weight, Colour, Brand_Id) select '3D Roach Jerkster', 66, 'Dirty Roach', Id from Brand where Name like 'Savage Gear'
INSERT INTO Lure (Name, Weight, Colour, Brand_Id) select 'Zalt11F10', 20, 'Red/White', Id from Brand where Name like 'Zalt' 
INSERT INTO Lure (Name, Weight, Colour, Brand_Id) select 'Zalt11F02', 20, 'Parrot', Id from Brand where Name like 'Zalt' 