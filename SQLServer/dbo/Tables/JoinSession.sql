CREATE TABLE [dbo].[JoinSession]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[JoinSessionId] INT NOT NULL,
	[JoinId] NVARCHAR(15) NOT NULL,
	[StudentID] INT NULL,
	CONSTRAINT [FK_JoinSession_Session] FOREIGN KEY ([JoinSessionId]) REFERENCES [Session]([Id])
)
