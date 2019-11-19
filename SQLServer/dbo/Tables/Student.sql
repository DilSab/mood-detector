CREATE TABLE [dbo].[Student]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[StudentID] INT NULL,
	[Firstname] NVARCHAR (50) NULL,
	[Lastname] NVARCHAR (50) NULL,
	[ContactPerson] NVARCHAR (50) NULL,
)
