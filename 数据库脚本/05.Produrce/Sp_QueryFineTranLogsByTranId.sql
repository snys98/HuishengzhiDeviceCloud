/*����ת�˼�¼Id��ȡת����;��Ϣ�ļ���*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sp_QueryFineTranLogsByTranId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sp_QueryFineTranLogsByTranId]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Sp_QueryFineTranLogsByTranId]
(
	@TranId [uniqueidentifier]
)
AS
BEGIN
	SELECT tranLog.Longitude,tranLog.Latitude,tranLog.UploadTime,tranLog.Humidity,tranLog.Temperature 
	FROM dbo.FineTranLogs as tranLog WHERE tranLog.TranId = @TranId
	ORDER BY UploadTime
END
GO