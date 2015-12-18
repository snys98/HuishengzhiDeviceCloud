USE [MAS]
GO

/****** Object:  Table [dbo].[SpecimenType]    Script Date: 12/16/2015 09:50:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SpecimenType]') AND type in (N'U'))
DROP TABLE [dbo].[SpecimenType]
GO

USE [MAS]
GO

/****** Object:  Table [dbo].[SpecimenType]    Script Date: 12/16/2015 09:50:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SpecimenType](
	[SpecimenTypeID] [tinyint] IDENTITY(1,1) NOT NULL,
	[SpecimenTypeName] [nvarchar](50) NULL,
	[SpecimentTemperature] [int] NULL,
	[SpecimentHumidity] [int] NULL,
	[IsDelete] [bigint] NULL,
	[SpecimentTypeCode] [nvarchar](4) NULL,
 CONSTRAINT [PK_SPECIMENTYPE] PRIMARY KEY CLUSTERED 
(
	[SpecimenTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�ɾ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SpecimenType', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ϵͳ���ñ�
   ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SpecimenType'
GO


--����ԭʼ����
INSERT INTO [MAS].[dbo].[SpecimenType]  ([SpecimenTypeName] ,[SpecimentTemperature] ,[SpecimentHumidity] ,[IsDelete]) VALUES 
('����Ѫ',1,2,0,'01'),('ĩ��Ѫ',2,3,0,'02'),('Ѫ��',3,4,0,'03'),('Ѫ��',4,5,0,'04'),('��Һ',5,6,0,'05'),('�Լ�Һ',2,20,0,'06'),('����Ѫ',2,20,0,'07'),('��ˮ',2,20,0,'08')
GO






