/*获取承运人信息,根据设备Id*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sp_QueryCourierByDeviceId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sp_QueryCourierByDeviceId]
GO



SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Sp_QueryCourierByDeviceId]
(
	@DeviceId VARCHAR(30)
)
AS
BEGIN
	SELECT * FROM dbo.Courier courier inner JOIN dbo.TransDeviceCourierRef deviceCourierRef 
	ON deviceCourierRef.TransDeviceId = @DeviceId
END
GO