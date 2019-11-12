CREATE TABLE [dbo].[GlobalMessage]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[Title] NVARCHAR(50) NOT NULL, 
    [UserId] INT NOT NULL, 
    [Content] TEXT NOT NULL, 
    [PostedDate] DATETIME NOT NULL, 
    [ExpirationDate] DATETIME NULL, 
    [RecipientType] INT NOT NULL, 
    CONSTRAINT [FK_GlobalMessage_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)
