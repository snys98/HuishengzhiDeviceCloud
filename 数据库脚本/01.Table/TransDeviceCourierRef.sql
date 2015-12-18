/**承运人设备关联表**/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TransDeviceCourierRef]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[TransDeviceCourierRef](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[CourierId] [int] NOT NULL,
		[TransDeviceId] [nchar](30) NOT NULL,
		[ReceiveTime] [datetime] NOT NULL, --领取时间
		[BackTime] [datetime] NULL, --归还时间
		[Statuts] [int] NOT NULL, --状态：1:使用;0:归还
	 CONSTRAINT [PK__TransDev__3214EC070DAF0CB0] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO


