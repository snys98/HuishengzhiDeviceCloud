/*��ȡ���г�����*/
/****** Object:  StoredProcedure [dbo].[Sp_QueryAllCourier]    Script Date: 12/18/2015 15:12:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sp_QueryAllCourier]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sp_QueryAllCourier]
GO


/****** Object:  StoredProcedure [dbo].[Sp_QueryAllCourier]    Script Date: 12/18/2015 15:12:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		����
-- Create date: <Create Date,,>
-- Description:	���������ȡ��������Ϣ
-- =============================================
CREATE PROCEDURE [dbo].[Sp_QueryAllCourier]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT a.*,c.*,b.Id AS DeviceCourierID FROM dbo.Courier a
		INNER JOIN dbo.TransDeviceCourierRef b  ON b.CourierId = a.CourierId
		INNER JOIN dbo.TransDevice c ON c.DeviceId=b.TransDeviceId
END

GO


