
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
-- Author:		����
-- Create date: <Create Date,,>
-- Description:	���������ȡ��������Ϣ
-- =============================================
CREATE PROCEDURE [dbo].[Sp_QueryCourierForBarCode]
	@BarCode NVARCHAR(50),
	@OrgName NVARCHAR(100) --ҽԺ
AS
BEGIN
	SET NOCOUNT ON;
	--û���ɹ���¼�Զ�����һ���ɹ���¼
	IF NOT EXISTS(SELECT 1 FROM dbo.Trans a 
			INNER JOIN dbo.TransDeviceCourierRef b  ON a.DeviceCourierID=b.Id
			INNER JOIN dbo.Courier c ON b.CourierId=c.CourierId
			WHERE c.BarCode=@BarCode AND a.OutHospName=@OrgName AND a.[Status]=1)
	BEGIN
		DECLARE @id INT,@tranid UNIQUEIDENTIFIER
		SET @tranid=NEWID()
		SELECT @id=b.id FROM TransDeviceCourierRef b INNER JOIN dbo.Courier c ON b.CourierId=c.CourierId
			WHERE c.BarCode=@BarCode AND b.Statuts=1
		IF(@id IS NOT NULL)
		BEGIN
			EXEC Sp_SaveDispatch @tranid,@id,@OrgName
		END
	END
	SELECT a.*,c.*,b.Id AS DeviceCourierID,d.TranID FROM dbo.Courier a
		INNER JOIN dbo.TransDeviceCourierRef b  ON b.CourierId = a.CourierId
		INNER JOIN dbo.TransDevice c ON c.DeviceId=b.TransDeviceId
		INNER JOIN dbo.Trans d ON b.Id=d.DeviceCourierID AND d.OutHospName=@OrgName AND d.[Status]=1
	WHERE a.BarCode LIKE @BarCode 
END

GO


