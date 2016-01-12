
/*MASϵͳPOSTת�������¼����վ��̨*/
/****** Object:  Table [dbo].[SpecTran]    Script Date: 12/24/2015 10:00:06 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SpecTran]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[SpecTran](
		[BarCode] [nvarchar](20) NOT NULL,
		[PreID] [bigint] NOT NULL,
		[Sex] [nvarchar](2) NOT NULL,
		[Age] [numeric](5, 2) NOT NULL,
		[Nationality] [nvarchar](12) NOT NULL,
		[Name] [nvarchar](40) NOT NULL,
		[Residence] [nvarchar](50) NULL,
		[Price] [numeric](8, 2) NOT NULL,
		[CurDisease] [nvarchar](200) NOT NULL,
		[PreOrgName] [nvarchar](50) NOT NULL,
		[PreDepName] [nvarchar](50) NOT NULL,
		[PreDoctorName] [nvarchar](50) NOT NULL,
		[curBedNo] [nvarchar](20) NOT NULL,
		[PreTime] [datetime] NOT NULL,
		[PreStatText] [nvarchar](10) NOT NULL,
		[ItemNames] [nvarchar](400) NOT NULL,
		[SpecimenTypeName] [nvarchar](50) NOT NULL,
		[Comment] [nvarchar](200) NOT NULL,
		[PreOrgID] [int] NOT NULL,
		[PreDepID] [int] NOT NULL,
		[PreDoctorID] [int] NOT NULL,
		[PatientID] [int] NOT NULL,
		[CheckRecID] [int] NOT NULL,
		[ItemID] [int] NOT NULL,
		[SpecimenTypeID] [int] NOT NULL,
		--����ΪMAS����
		[PostTime] [datetime] NOT NULL, --�ύת������ʱ��
		[OutTime] [datetime]  NULL,  --����ת��ʱ��
		[ReceiveTime] [datetime]  NULL, --��������ʱ��
		[TranStatus] [int] NOT NULL, --ת��״̬��0��������1�����ɹ���2����ת����3�������
	 CONSTRAINT [PK_SpecTran] PRIMARY KEY CLUSTERED 
	(
		[BarCode] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO


IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE name='SpecimentTypeTemperatureMax' AND [object_id]=OBJECT_ID('SpecTran'))
BEGIN
	ALTER TABLE SpecTran
		ADD [SpecimentTypeTemperatureMax] [float] NULL,
			[SpecimentTypeTemperatureMin] [float] NULL,
			[SpecimentTypeHumidityMax] [float] NULL,
			[SpecimentTypeHumidityMin] [float] NULL
END
GO