/*样本转运运输记录表*/
/****** Object:  Table [dbo].[Trans]    Script Date: 12/24/2015 10:02:47 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Trans]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Trans](
		[TranID] [uniqueidentifier] NOT NULL, --转运ID
		[DeviceCourierID] [int] NOT NULL, --承运人和承运设备关系记录表
		[OutHospName] [nvarchar](100) NOT NULL, --转出医院
		[OutPersonName] [nvarchar](50)  NULL, --转出人
		[ReceiveHospName] [nvarchar](100)  NULL, --接收医院
		[ReceivePersonName] [nvarchar](50)  NULL,--接收人
		[OutTime] [datetime]  NULL, --转出时间
		[ReceiveTime] [datetime]  NULL, --接收时间
		[OutHospID] [int]  NULL, --转出医院ID
		[OutPersonID] [int]  NULL, --转出人ID
		[ReceiveHospID] [int]  NULL, --转入医院ID
		[ReceivePersonID] [int]  NULL, --转入人员ID
		[Status]   [int]  NOT NULL
	) ON [PRIMARY]
END
GO
