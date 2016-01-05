/*转运样本关系表*/
/****** Object:  Table [dbo].[TranSpecRelation]    Script Date: 12/24/2015 10:08:23 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TranSpecRelation]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[TranSpecRelation](
		[TranID] [uniqueidentifier] NOT NULL,
		[BarCode] [nvarchar](20) NOT NULL,
	 CONSTRAINT [PK_TranSpecRelation] PRIMARY KEY CLUSTERED 
	(
		[TranID] ASC,
		[BarCode] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO
