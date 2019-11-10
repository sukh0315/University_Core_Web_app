SET IDENTITY_INSERT [dbo].[Module] ON
INSERT INTO [dbo].[Module] ([Id], [Name], [Credits]) VALUES (1, N'CSC01 - Artificial Intelligence', 60)
INSERT INTO [dbo].[Module] ([Id], [Name], [Credits]) VALUES (2, N'BIO01 - Micro Biology', 70)
INSERT INTO [dbo].[Module] ([Id], [Name], [Credits]) VALUES (3, N'MATH-01 Differential  Equations', 80)
INSERT INTO [dbo].[Module] ([Id], [Name], [Credits]) VALUES (4, N'MATH 02 - Advanced Calculus', 80)
SET IDENTITY_INSERT [dbo].[Module] OFF
SET IDENTITY_INSERT [dbo].[Lecturer] ON
INSERT INTO [dbo].[Lecturer] ([Id], [Name], [Email]) VALUES (1, N'Dr Frank Hardy', N'frank@uni.com')
INSERT INTO [dbo].[Lecturer] ([Id], [Name], [Email]) VALUES (2, N'Dr David Tyler', N'david@uni.com')
INSERT INTO [dbo].[Lecturer] ([Id], [Name], [Email]) VALUES (3, N'Dr Allan Watson', N'allan@uni.com')
SET IDENTITY_INSERT [dbo].[Lecturer] OFF
SET IDENTITY_INSERT [dbo].[Department] ON
INSERT INTO [dbo].[Department] ([Id], [Name], [DepartmentEmail]) VALUES (1, N'Computer Science', N'compusc@uni.com')
INSERT INTO [dbo].[Department] ([Id], [Name], [DepartmentEmail]) VALUES (2, N'Mathematics', N'math@uni.com')
INSERT INTO [dbo].[Department] ([Id], [Name], [DepartmentEmail]) VALUES (3, N'Bio Technology', N'biotec@uni.com')
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Allocation] ON
INSERT INTO [dbo].[Allocation] ([Id], [DepartmentId], [LecturerId], [ModuleId]) VALUES (1, 1, 1, 1)
INSERT INTO [dbo].[Allocation] ([Id], [DepartmentId], [LecturerId], [ModuleId]) VALUES (2, 2, 2, 3)
INSERT INTO [dbo].[Allocation] ([Id], [DepartmentId], [LecturerId], [ModuleId]) VALUES (3, 3, 3, 2)
INSERT INTO [dbo].[Allocation] ([Id], [DepartmentId], [LecturerId], [ModuleId]) VALUES (4, 2, 2, 4)
SET IDENTITY_INSERT [dbo].[Allocation] OFF

