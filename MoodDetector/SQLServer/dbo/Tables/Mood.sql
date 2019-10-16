CREATE TABLE [dbo].[Mood]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SessionId] INT NOT NULL, 
    [Anger] FLOAT NOT NULL, 
    [Joy] FLOAT NOT NULL, 
	[Contempt] FLOAT NOT NULL, 
	[Disgust] FLOAT NOT NULL, 
	[Engagement] FLOAT NOT NULL,
	[Fear] FLOAT NOT NULL, 
	[Sadness] FLOAT NOT NULL, 
	[Suprise] FLOAT NOT NULL, 
	[Valence] FLOAT NOT NULL, 
    CONSTRAINT [FK_Mood_Session] FOREIGN KEY ([SessionId]) REFERENCES [Session]([Id])
)
