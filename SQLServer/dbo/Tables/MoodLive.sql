CREATE TABLE [dbo].[MoodLive]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,     
	[JoinSessionId] INT NOT NULL,
    [Anger] FLOAT NOT NULL, 
    [Joy] FLOAT NOT NULL, 
	[Contempt] FLOAT NOT NULL, 
	[Disgust] FLOAT NOT NULL, 
	[Engagement] FLOAT NOT NULL,
	[Fear] FLOAT NOT NULL, 
	[Sadness] FLOAT NOT NULL, 
	[Suprise] FLOAT NOT NULL, 
	[Valence] FLOAT NOT NULL, 
	[Emoji] VARCHAR(5),
	CONSTRAINT [FK_MoodLive_JoinSession] FOREIGN KEY ([JoinSessionId]) REFERENCES [JoinSession]([Id])    
)