/*根据转运记录Id获取转运中途信息的集合*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sp_QueryTranLogsByTranId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sp_QueryTranLogsByTranId]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Sp_QueryTranLogsByTranId]
(
	@TranId [uniqueidentifier]
)
AS
BEGIN
	SELECT tranLog.Longitude,tranLog.Latitude,tranLog.UploadTime,tranLog.Humidity,tranLog.Temperature 
	FROM dbo.TranLog as tranLog WHERE tranLog.TranId = @TranId
	ORDER BY UploadTime
END
GO