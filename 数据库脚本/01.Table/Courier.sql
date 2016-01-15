/*承运人员信息表*/
/****** Object:  Table [dbo].[Courier]    Script Date: 12/18/2015 14:37:02 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Courier]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Courier](
		[CourierId] [int] IDENTITY(1,1) NOT NULL,
		[BarCode] [nvarchar](50) NOT NULL,
		[Name] [nvarchar](50) NOT NULL,
		[Tel] [nvarchar](50) NOT NULL,
		[DefaultTool] [nvarchar](50) NOT NULL,
		[Status] [int] NOT NULL  --1:正常；0：删除
	) ON [PRIMARY]
END
GO

--增加微信号列
IF NOT EXISTS(SELECT 1 FROM sys.columns WHERE name='wxcode' AND [object_id]=OBJECT_ID('Courier'))
BEGIN
	ALTER TABLE dbo.Courier
		ADD wxcode NVARCHAR(100)
END
GO