/*根据设备编号获取当前的转运批号记录ID*/
/****** Object:  StoredProcedure [dbo].[Sp_GetTranID]    Script Date: 01/13/2016 17:34:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sp_GetTranID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sp_GetTranID]
GO

/****** Object:  StoredProcedure [dbo].[Sp_GetTranID]    Script Date: 01/13/2016 17:34:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_GetTranID]
(
	@DevCode NVARCHAR(30)
)
AS
BEGIN
	SELECT t.TranID FROM dbo.Trans t
		INNER JOIN dbo.TransDeviceCourierRef ref ON t.DeviceCourierID=ref.Id
		WHERE ref.TransDeviceId=@DevCode AND t.[Status]=2
END

GO


