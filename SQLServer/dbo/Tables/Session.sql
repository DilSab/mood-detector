CREATE TABLE [dbo].[Session]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
	[Subject] NVARCHAR(30) NOT NULL, 
    [Class] NVARCHAR(30) NOT NULL, 
	[DateTime] DATETIME Not NULL, 
    [Comments] TEXT NOT NULL, 
    [MessageSeen] INT NOT NULL , 
    CONSTRAINT [FK_Session_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
)
