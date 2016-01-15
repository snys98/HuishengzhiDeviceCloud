/*根据转运记录Id获取转运中途信息的集合*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sp_QueryFineTranLogsByTimeAndDeviceId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].Sp_QueryFineTranLogsByTimeAndDeviceId
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Sp_QueryFineTranLogsByTimeAndDeviceId]
(
	@DeviceId NVARCHAR(30),
	@StartTime DATETIME,
	@Endtime DATETIME
)
AS
BEGIN
	SELECT tranLog.Longitude,tranLog.Latitude,tranLog.UploadTime,tranLog.Humidity,tranLog.Temperature 
	FROM dbo.FineTranLogs as tranLog WHERE UploadTime>@StartTime and UploadTime<@Endtime AND DeviceAddress = @DeviceId
	ORDER BY UploadTime
END
GO