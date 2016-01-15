
/*保存派工记录*/
/****** Object:  StoredProcedure [dbo].[Sp_SaveDispatch]    Script Date: 01/05/2016 11:38:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sp_SaveDispatch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sp_SaveDispatch]
GO

/****** Object:  StoredProcedure [dbo].[Sp_SaveDispatch]    Script Date: 01/05/2016 11:38:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Sp_SaveDispatch]
(
	@TranID UNIQUEIDENTIFIER,
	@DeviceCourierID INT,
	@OutHospName NVARCHAR(200)
)
AS
BEGIN
	--如果没有对该医院该承运人的派工数据才新增派工单
    IF NOT EXISTS(SELECT 1 FROM Trans WHERE OutHospName=@OutHospName AND DeviceCourierID=@DeviceCourierID AND [Status]=1)
    BEGIN
		INSERT INTO dbo.Trans
				(
				  TranID,
				  DeviceCourierID ,
				  OutHospName,
				  [Status]
				)
		VALUES  ( @TranID , -- TranID - uniqueidentifier
				  @DeviceCourierID , -- DeviceCourierID - int
				  @OutHospName ,
				  1 --已派工
				) 
	 END
END


GO


