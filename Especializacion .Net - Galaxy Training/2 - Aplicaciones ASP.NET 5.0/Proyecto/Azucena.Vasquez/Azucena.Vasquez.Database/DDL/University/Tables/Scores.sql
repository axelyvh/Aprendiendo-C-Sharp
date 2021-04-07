CREATE TABLE [University].[Scores]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[User_Id] nvarchar(450) NOT NULL,
	[Course_Id] int NOT NULL,
	[Score] int NOT NULL,

	CONSTRAINT FK_UserId FOREIGN KEY (User_Id) REFERENCES [Security].[Users](Id),
	CONSTRAINT FK_CourseId FOREIGN KEY (Course_Id) REFERENCES [University].[Courses](Id)

)
