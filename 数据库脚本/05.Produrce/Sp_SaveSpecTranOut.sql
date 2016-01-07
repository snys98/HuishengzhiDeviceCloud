/*样本转出保存*/
/****** Object:  StoredProcedure [dbo].[Sp_SaveSpecTranOut]    Script Date: 01/05/2016 17:01:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sp_SaveSpecTranOut]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sp_SaveSpecTranOut]
GO


/****** Object:  StoredProcedure [dbo].[Sp_SaveSpecTranOut]    Script Date: 01/05/2016 17:01:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_SaveSpecTranOut]
(
	@TranID UNIQUEIDENTIFIER,
	@DeviceCourierID INT,
	@OutPersonName nvarchar(50),
	@OutHospID int,
	@OutPersonID INT,
	@ReceiveHospName nvarchar(100),
	@ReceiveHospID INT
) 
AS
BEGIN
	UPDATE dbo.Trans
		SET OutPersonName=@OutPersonName,
		     OutHospID=@OutHospID,
		     OutPersonID=@OutPersonID,
		     OutTime=GETDATE(),
		     ReceiveHospName=@ReceiveHospName,
		     ReceiveHospID=@ReceiveHospID,
		     [Status]=2
		   WHERE TranID=@TranID AND [Status]=1
END

GO


