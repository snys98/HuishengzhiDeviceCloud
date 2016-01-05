/****** 转运设备表 ******/
IF NOT  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TransDevice]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[TransDevice](
	[DeviceId] [nvarchar](30) NOT NULL,
	[DeviceName] [nvarchar](50) NULL,
	PRIMARY KEY CLUSTERED 
	(
		[DeviceId] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

