/*����ת�������¼��*/
/****** Object:  Table [dbo].[Trans]    Script Date: 12/24/2015 10:02:47 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Trans]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Trans](
		[TranID] [uniqueidentifier] NOT NULL, --ת��ID
		[DeviceCourierID] [int] NOT NULL, --�����˺ͳ����豸��ϵ��¼��
		[OutHospName] [nvarchar](100) NOT NULL, --ת��ҽԺ
		[OutPersonName] [nvarchar](50)  NULL, --ת����
		[ReceiveHospName] [nvarchar](100)  NULL, --����ҽԺ
		[ReceivePersonName] [nvarchar](50)  NULL,--������
		[OutTime] [datetime]  NULL, --ת��ʱ��
		[ReceiveTime] [datetime]  NULL, --����ʱ��
		[OutHospID] [int]  NULL, --ת��ҽԺID
		[OutPersonID] [int]  NULL, --ת����ID
		[ReceiveHospID] [int]  NULL, --ת��ҽԺID
		[ReceivePersonID] [int]  NULL, --ת����ԱID
		[Status]   [int]  NOT NULL
	) ON [PRIMARY]
END
GO
