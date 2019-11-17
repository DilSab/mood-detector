CREATE PROCEDURE [dbo].[addUsers]
AS
BEGIN
	INSERT INTO [User] (Firstname, Lastname, AccessRights) VALUES ('Firstname', 'Lastname', 'Admin');
	INSERT INTO LoginInfo (UserId, Username, Password, Email) VALUES ((SELECT SCOPE_IDENTITY()), 'admin', 'password', 'admin@mooddetector.com');
	INSERT INTO [User] (Firstname, Lastname, AccessRights) VALUES ('James', 'Smith', 'Teacher');
	INSERT INTO LoginInfo (UserId, Username, Password, Email) VALUES ((SELECT SCOPE_IDENTITY()), 'james1', 'passjames1', 'james@mooddetector.com');
	INSERT INTO [User] (Firstname, Lastname, AccessRights) VALUES ('Patricia', 'Johnson', 'Teacher');
	INSERT INTO LoginInfo (UserId, Username, Password, Email) VALUES ((SELECT SCOPE_IDENTITY()), 'patricia1', 'passpatricia1', 'patricia@mooddetector.com');
	INSERT INTO [User] (Firstname, Lastname, AccessRights) VALUES ('Linda', 'Williams', 'Teacher');
	INSERT INTO LoginInfo (UserId, Username, Password, Email) VALUES ((SELECT SCOPE_IDENTITY()), 'linda1', 'passlinda1', 'linda@mooddetector.com');
	INSERT INTO [User] (Firstname, Lastname, AccessRights) VALUES ('Robert', 'Brown', 'Teacher');
	INSERT INTO LoginInfo (UserId, Username, Password, Email) VALUES ((SELECT SCOPE_IDENTITY()), 'robert1', 'passrobert1', 'robert@mooddetector.com');
	INSERT INTO [User] (Firstname, Lastname, AccessRights) VALUES ('William', 'Jones', 'Teacher');
	INSERT INTO LoginInfo (UserId, Username, Password, Email) VALUES ((SELECT SCOPE_IDENTITY()), 'william1', 'passwilliam1', 'william@mooddetector.com');
	INSERT INTO [User] (Firstname, Lastname, AccessRights) VALUES ('Elizabeth', 'Miller', 'Teacher');
	INSERT INTO LoginInfo (UserId, Username, Password, Email) VALUES ((SELECT SCOPE_IDENTITY()), 'elizabeth1', 'passelizabeth1', 'elizabeth@mooddetector.com');
	INSERT INTO [User] (Firstname, Lastname, AccessRights) VALUES ('Bla', 'Cha', 'Teacher');
	INSERT INTO LoginInfo (UserId, Username, Password, Email) VALUES ((SELECT SCOPE_IDENTITY()), 'blacha', 'Haha888?', 'blacha@mooddetector.com');
END
