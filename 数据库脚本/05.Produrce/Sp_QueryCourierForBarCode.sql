
/****** Object:  StoredProcedure [dbo].[Sp_QueryCourierForBarCode]    Script Date: 12/18/2015 15:12:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sp_QueryCourierForBarCode]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sp_QueryCourierForBarCode]
GO


/****** Object:  StoredProcedure [dbo].[Sp_QueryCourierForBarCode]    Script Date: 12/18/2015 15:12:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		张腾
-- Create date: <Create Date,,>
-- Description:	根据条码获取承运人信息
-- =============================================
CREATE PROCEDURE [dbo].[Sp_QueryCourierForBarCode]
	@BarCode NVARCHAR(50),
	@OrgName NVARCHAR(100) --医院
AS
BEGIN
	SET NOCOUNT ON;
	SELECT a.*,c.*,b.Id AS DeviceCourierID,d.TranID FROM dbo.Courier a
		INNER JOIN dbo.TransDeviceCourierRef b  ON b.CourierId = a.CourierId
		INNER JOIN dbo.TransDevice c ON c.DeviceId=b.TransDeviceId
		INNER JOIN dbo.Trans d ON b.Id=d.DeviceCourierID AND d.OutHospName=@OrgName AND d.[Status]=1
	WHERE a.BarCode LIKE @BarCode 
END

GO


