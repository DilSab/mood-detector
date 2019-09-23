CREATE TABLE [dbo].[ClassMood]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
	[Subject] NVARCHAR(30) NOT NULL, 
    [Class] NVARCHAR(5) NOT NULL, 
    [AverageMood] INT NOT NULL, 
    CONSTRAINT [FK_ClassMood_Teacher] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)
