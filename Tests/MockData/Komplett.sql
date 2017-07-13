Use MeasureMyPike
go

insert into [Lake] values (N'Storsj�n')
insert into [Lake] values (N'�stersj�n')
insert into [Lake] values (N'M�laren')
insert into [Lake] values (N'K�ppesj�n')
insert into [Lake] values (N'V�nern')

Insert into [TackleBox] values (CAST(N'2017-07-13T08:54:26.830' AS DateTime))
Insert into [TackleBox] values (CAST(N'2017-07-13T08:55:26.830' AS DateTime))
Insert into [TackleBox] values (CAST(N'2017-07-13T08:56:26.830' AS DateTime))
Insert into [TackleBox] values (CAST(N'2017-07-13T08:57:26.830' AS DateTime))
Insert into [TackleBox] values (CAST(N'2017-07-13T08:58:26.830' AS DateTime))

INSERT [User] ([Username], [LastName], [FirstName], [MemberSince], [TackleBox_Id]) VALUES (N'hostf', N'H�st', N'Fritjof', CAST(N'2017-07-13T08:54:26.830' AS DateTime), 1)
INSERT [User] ([Username], [LastName], [FirstName], [MemberSince], [TackleBox_Id]) VALUES (N'nilspelle', N'Nilsson', N'P�r Anders', CAST(N'2017-07-13T08:55:40.953' AS DateTime), 2)
INSERT [User] ([Username], [LastName], [FirstName], [MemberSince], [TackleBox_Id]) VALUES (N'johhny2d', N'Karlsson', N'Johnny', CAST(N'2017-07-13T08:56:56.357' AS DateTime), 3)
INSERT [User] ([Username], [LastName], [FirstName], [MemberSince], [TackleBox_Id]) VALUES (N'chilimannen', N'Andersson', N'Mattias', CAST(N'2017-07-13T08:57:10.383' AS DateTime), 4)
INSERT [User] ([Username], [LastName], [FirstName], [MemberSince], [TackleBox_Id]) VALUES (N'G�ddXterminator7000', N'Josefsson', N'Janne', CAST(N'2017-07-13T08:58:28.040' AS DateTime), 5)

insert into [Security] select 'HAt0N0WoGgOBhhXd6Y2jpIcBJ6H1pzzR5nBxzD8CLNjlA/pD', id from [User] where Username = 'hostf'
insert into [Security] select 'dE0pI9tX+IhKe1IsfHownZLq5X28FXxCM+xsyxkVyuTuZavD', id from [User] where Username = 'nilspelle'
insert into [Security] select '4FruhBTLncNjSZ/M8uuM5qufSwuSKi1JwC8V5HeKZ08dBWXF', id from [User] where Username = 'johhny2d'
insert into [Security] select '50Ilk2ZI3t6FoIUzmA05rZr7ip+A8lmbGPtXyRlM1rk4qOQi', id from [User] where Username = 'chilimannen'
insert into [Security] select 'I6oLRrdD9mEYh30IIrAHurb4UBwGP9yc4e5kNxyVzJ2kgVaM', id from [User] where Username = 'G�ddXterminator7000'

insert into [Location] (Lake_Id) select id from [Lake] where Name = 'Storsj�n'
insert into [Location] (Lake_Id) select id from [Lake] where Name = '�stersj�n'
insert into [Location] (Lake_Id) select id from [Lake] where Name = 'M�laren'
insert into [Location] (Lake_Id) select id from [Lake] where Name = 'K�ppesj�n'
insert into [Location] (Lake_Id) select id from [Lake] where Name = 'V�nern'

INSERT INTO [Brand] (Name) VALUES (N'Abu Garcia')
INSERT INTO [Brand] (Name) VALUES (N'Berkley')
INSERT INTO [Brand] (Name) VALUES (N'Blue Fox')
INSERT INTO [Brand] (Name) VALUES (N'Myran')
INSERT INTO [Brand] (Name) VALUES (N'Rapala')
INSERT INTO [Brand] (Name) VALUES (N'Salmo')
INSERT INTO [Brand] (Name) VALUES (N'Savage Gear')
INSERT INTO [Brand] (Name) VALUES (N'Storm')
INSERT INTO [Brand] (Name) VALUES (N'Strike Pro')
INSERT INTO [Brand] (Name) VALUES (N'Svartzonker')
INSERT INTO [Brand] (Name) VALUES (N'Westin')
INSERT INTO [Brand] (Name) VALUES (N'Wolfcreek Lures')
INSERT INTO [Brand] (Name) VALUES (N'Zalt')

INSERT INTO [Lure] (Name, Weight, Colour, Brand_Id) select N'HI-LO 15 CM', 40, N'Atomic Perch', Id from Brand where Name like 'Abu Garcia'
INSERT INTO [Lure] (Name, Weight, Colour, Brand_Id) select N'TORMENTOR 11 CM', 20, N'Green/Orange', Id from Brand where Name like 'Abu Garcia'
INSERT INTO [Lure] (Name, Weight, Colour, Brand_Id) select N'Berkley Power Blade', 11, N'Assassin', Id from Brand where Name like 'Berkley'
INSERT INTO [Lure] (Name, Weight, Colour, Brand_Id) select N'Berkley Power Blade', 11, N'Bluegill', Id from Brand where Name like 'Berkley'
INSERT INTO [Lure] (Name, Weight, Colour, Brand_Id) select N'Berkley Power Blade', 11, N'Fire Tiger', Id from Brand where Name like 'Berkley'
INSERT INTO [Lure] (Name, Weight, Colour, Brand_Id) select N'X-Rap Twitchin Minnow', 14, N'Albino Shiner', Id from Brand where Name like 'Rapala'
INSERT INTO [Lure] (Name, Weight, Colour, Brand_Id) select N'X-Rap Twitchin Mullet', 20, N'Blue Sardine', Id from Brand where Name like 'Rapala'
INSERT INTO [Lure] (Name, Weight, Colour, Brand_Id) select N'Deviator Belly Up', 22, N'Dirty Roach', Id from Brand where Name like 'Savage Gear'
INSERT INTO [Lure] (Name, Weight, Colour, Brand_Id) select N'Freestyler V2', 42, N'Firetiger', Id from Brand where Name like 'Savage Gear'
INSERT INTO [Lure] (Name, Weight, Colour, Brand_Id) select N'3D Roach Jerkster', 66, N'Dirty Roach', Id from Brand where Name like 'Savage Gear'
INSERT INTO [Lure] (Name, Weight, Colour, Brand_Id) select N'Zalt11F10', 20, N'Red/White', Id from Brand where Name like 'Zalt' 
INSERT INTO [Lure] (Name, Weight, Colour, Brand_Id) select N'Zalt11F02', 20, N'Parrot', Id from Brand where Name like 'Zalt' 

insert into [LureTackleBox] select 1, id from [User] where Username = 'hostf'
insert into [LureTackleBox] select 4, id from [User] where Username = 'hostf'
insert into [LureTackleBox] select 7, id from [User] where Username = 'hostf'
insert into [LureTackleBox] select 10, id from [User] where Username = 'hostf'
insert into [LureTackleBox] select 1, id from [User] where Username = 'nilspelle'
insert into [LureTackleBox] select 3, id from [User] where Username = 'nilspelle'
insert into [LureTackleBox] select 4, id from [User] where Username = 'nilspelle'
insert into [LureTackleBox] select 8, id from [User] where Username = 'nilspelle'
insert into [LureTackleBox] select 1, id from [User] where Username = 'johhny2d'
insert into [LureTackleBox] select 3, id from [User] where Username = 'johhny2d'
insert into [LureTackleBox] select 4, id from [User] where Username = 'johhny2d'
insert into [LureTackleBox] select 12, id from [User] where Username = 'johhny2d'
insert into [LureTackleBox] select 6, id from [User] where Username = 'chilimannen'
insert into [LureTackleBox] select 11, id from [User] where Username = 'chilimannen'
insert into [LureTackleBox] select 9, id from [User] where Username = 'chilimannen'
insert into [LureTackleBox] select 8, id from [User] where Username = 'chilimannen'
insert into [LureTackleBox] select 1, id from [User] where Username = 'G�ddXterminator7000'
insert into [LureTackleBox] select 7, id from [User] where Username = 'G�ddXterminator7000'
insert into [LureTackleBox] select 12, id from [User] where Username = 'G�ddXterminator7000'
insert into [LureTackleBox] select 10, id from [User] where Username = 'G�ddXterminator7000'

insert into [Fish] values (55, 12000)
insert into [Fish] values (90, 17000)
insert into [Fish] values (30, 5000)
insert into [Fish] values (150, 40000)
insert into [Fish] values (110, 22000)

insert into [WeatherData] values (12, N'Molnigt', N'Nym�ne', 22)
insert into [WeatherData] values (8, N'Soligt', N'Tilltagande sk�ra', 18)
insert into [WeatherData] values (7, N'Regnigt', N'Tilltagande halvm�ne', 15)
insert into [WeatherData] values (9, N'Vindstilla', N'Fullm�ne', 19)
insert into [WeatherData] values (14, N'Orkan', N'Halvm�ne', 28)

insert into [Comment] values (N'Var lite k�mpigt, men fick upp honom')
insert into [Comment] values (N'Fan vilken stor!')
insert into [Comment] values (N'Det var en m�rk kv�ll n�r jag var ute med harpunen...')
insert into [Comment] values (N'En liten babyg�dda, hoppades p� mer')
insert into [Comment] values (N'Efter att ha jagat den h�r j�veln i 7 �r fick jag upp honom. Han har k�kat upp alla mina fiskedrag sedan jag b�rjade fiska, men nu ska han d�!')

insert into [Catch] values (CAST(N'2017-07-13 08:54:26.830' AS DateTime), 1, 3, 4, 4, 10, 5)
insert into [Catch] values (CAST(N'2017-07-13 08:54:26.830' AS DateTime), 2, 1, 1, 1, 1, 1)
insert into [Catch] values (CAST(N'2017-07-13 08:54:26.830' AS DateTime), 3, 2, 2, 2, 3, 2)
insert into [Catch] values (CAST(N'2017-07-13 08:54:26.830' AS DateTime), 4, 4, 3, 3, 6, 3)
insert into [Catch] values (CAST(N'2017-07-13 08:54:26.830' AS DateTime), 5, 5, 5, 5, 12, 4)