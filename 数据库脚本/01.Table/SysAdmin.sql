
--系统操作员表
/****** Object:  Table [dbo].[SysAdmin]    Script Date: 12/31/2015 10:13:56 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SysAdmin]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[SysAdmin](
		[UserName] [nvarchar](50) NOT NULL,
		[Password] [nvarchar](200) NOT NULL,
		[DisplayName] [nvarchar](50) NOT NULL
	) ON [PRIMARY]
END
GO

