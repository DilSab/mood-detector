CREATE TABLE [dbo].[ClassMood]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TeacherId] INT NOT NULL, 
    [Class] NVARCHAR(5) NOT NULL, 
    [AverageMood] INT NOT NULL, 
    CONSTRAINT [FK_ClassMood_Teacher] FOREIGN KEY ([TeacherId]) REFERENCES [Teacher]([Id])
)
