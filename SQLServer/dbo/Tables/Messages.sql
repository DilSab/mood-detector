CREATE TABLE [dbo].[Messages]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [SenderUserId] INT NOT NULL, 
    [ReceiverUserId] INT NOT NULL, 
    [DateSent] DATETIME NOT NULL, 
    [Content] TEXT NULL, 
    [Status] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Messages_SenderUser] FOREIGN KEY ([SenderUserId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Messages_ReceiverUser] FOREIGN KEY ([ReceiverUserId]) REFERENCES [User]([Id])
)
