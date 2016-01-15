

/****** Object:  StoredProcedure [dbo].[Gp_SaveFineGprsLog]    Script Date: 12/21/2015 15:41:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Gp_SaveFineGprsLog]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Gp_SaveFineGprsLog]
GO



/****** Object:  StoredProcedure [dbo].[Gp_SaveFineGprsLog]    Script Date: 12/21/2015 15:41:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		уелз
-- Create date: 2015-12-10
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[Gp_SaveFineGprsLog]
(
   @Id uniqueidentifier,
   @TranId varchar(50),
   @DataLength int,
   @ProtocolVersion int,
   @UploadInterval int,
   @ChannelCount int,
   @IsLargeBattery bit,
   @Voltage decimal(18,6),
   @SignalStrength int,
   @UploadTime datetime,
   @DeviceAddress varchar(20),
   @CRC16 varchar(20),
   @IsNorth bit,
   @IsEast bit,
   @Longitude decimal(18,6),
   @Latitude decimal(18,6),
   @Temperature decimal(18,6),
   @Humidity decimal(18,6)
)
AS
BEGIN
	
	SET NOCOUNT ON;
	INSERT INTO [dbo].[FineTranLog]
			   ([Id]
			   ,[TranId]
			   ,[DataLength]
			   ,[ProtocolVersion]
			   ,[UploadInterval]
			   ,[ChannelCount]
			   ,[IsLargeBattery]
			   ,[Voltage]
			   ,[SignalStrength]
			   ,[UploadTime]
			   ,[DeviceAddress]
			   ,[CRC16]
			   ,[IsNorth]
			   ,[IsEast]
			   ,[Longitude]
			   ,[Latitude]
			   ,[Temperature]
			   ,[Humidity]
			   ,[Created])
		 VALUES
			   (@Id,
			   @TranId,
			   @DataLength,
			   @ProtocolVersion,
			   @UploadInterval,
			   @ChannelCount,
			   @IsLargeBattery,
			   @Voltage,
			   @SignalStrength,
			   @UploadTime,
			   @DeviceAddress,
			   @CRC16,
			   @IsNorth,
			   @IsEast,
			   @Longitude ,
			   @Latitude ,
			   @Temperature ,
			   @Humidity ,
			   getdate())
END

GO


