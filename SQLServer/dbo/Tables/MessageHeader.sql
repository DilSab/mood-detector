CREATE TABLE [dbo].[MessageHeader]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(50) NULL, 
    [SentDate] DATETIME NOT NULL, 
    [SenderUserId] NCHAR(10) NULL, 
    [Recipients] NCHAR(10) NULL
)
