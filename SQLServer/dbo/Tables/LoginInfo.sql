CREATE TABLE [dbo].[LoginInfo]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[UserId] INT NOT NULL,
    [Username] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_LoginInfo_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]) 
)
