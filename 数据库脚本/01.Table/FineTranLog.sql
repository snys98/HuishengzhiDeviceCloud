
/*设备跟踪记录表*/
/****** Object:  Table [dbo].[FineTranLog]    Script Date: 12/31/2015 10:15:18 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FineTranLog]') AND type in (N'U'))
BEGIN
	 CREATE TABLE [dbo].[FineTranLog](
		[Id] [uniqueidentifier] NOT NULL,
		[TranId] [uniqueidentifier] NOT NULL,
		[DataLength] [int] NOT NULL,
		[ProtocolVersion] [int] NOT NULL,
		[UploadInterval] [int] NOT NULL,
		[ChannelCount] [int] NOT NULL,
		[IsLargeBattery] [bit] NOT NULL,
		[Voltage] [decimal](18, 6) NOT NULL,
		[SignalStrength] [int] NOT NULL,
		[UploadTime] [datetime] NOT NULL,
		[DeviceAddress] [varchar](20) NOT NULL,
		[CRC16] [varchar](20) NOT NULL,
		[IsNorth] [bit] NOT NULL,
		[IsEast] [bit] NOT NULL,
		[Longitude] [decimal](18, 6) NOT NULL,
		[Latitude] [decimal](18, 6) NOT NULL,
		[Temperature] [decimal](18, 6) NOT NULL,
		[Humidity] [decimal](18, 6) NOT NULL,
		[Created] [datetime] NOT NULL
	) ON [PRIMARY]
END
GO

