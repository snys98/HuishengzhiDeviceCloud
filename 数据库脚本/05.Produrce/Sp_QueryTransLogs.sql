/*根据时间段和设备Id获取转运记录的集合*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sp_QueryTransLogs]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sp_QueryTransLogs]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Sp_QueryTransLogs]
(
	@DeviceId NVARCHAR(30),
	@StartTime DATETIME,
	@Endtime DATETIME
)
AS
BEGIN
	SELECT a.Longitude,a.Latitude,a.UploadTime,a.Humidity,a.Temperature 
	FROM dbo.TranLog as a WHERE UploadTime>@StartTime and UploadTime<@Endtime AND DeviceAddress = @DeviceId
	ORDER BY UploadTime
END
GO