
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'tUsers')
BEGIN

	CREATE TABLE [dbo].[tUsers](
		[UserId] [bigint] IDENTITY(1000000000,1) NOT NULL,
		[UserName] [varchar](250) NULL,
		[Password] [varchar](250) NULL,
		[Email] [varchar](500) NULL,
		[Name] [varchar](500) NULL,
		[RoleId] [bigint] NULL,
		[DTCreated] [DateTime] NOT NULL,
		[DTUpdated] [DateTime] NULL,
	 CONSTRAINT [PK_tUsers] PRIMARY KEY CLUSTERED 
	(
		[UserId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END
GO


IF NOT EXISTS(SELECT 1 FROM SYS.FOREIGN_KEYS WHERE PARENT_OBJECT_ID = OBJECT_ID(N'tUsers'))
BEGIN
	
	ALTER TABLE [dbo].[tUsers]  WITH CHECK ADD  CONSTRAINT [FK_tUsers_tRoles] FOREIGN KEY([RoleId])
	REFERENCES [dbo].[tRoles] ([RoleId])
	
END
GO