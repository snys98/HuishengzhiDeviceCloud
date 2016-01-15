
/*保存派工记录明细*/
/****** Object:  StoredProcedure [dbo].[Sp_SaveDispatchDetail]    Script Date: 01/05/2016 11:38:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sp_SaveDispatchDetail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sp_SaveDispatchDetail]
GO

/****** Object:  StoredProcedure [dbo].[Sp_SaveDispatchDetail]    Script Date: 01/05/2016 11:38:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Sp_SaveDispatchDetail]
(
	@TranID UNIQUEIDENTIFIER,
	@BarCode NVARCHAR(20),
	@SpecimentTypeTemperatureMax [float],
	@SpecimentTypeTemperatureMin [float] ,
	@SpecimentTypeHumidityMax [float] ,
	@SpecimentTypeHumidityMin [float] 	
)
AS
BEGIN
	INSERT INTO dbo.TranSpecRelation
	        ( TranID, BarCode )
	VALUES  ( @TranID, -- TranID - uniqueidentifier
	          @BarCode  -- BarCode - nvarchar(20)
	          )
	 UPDATE dbo.SpecTran SET TranStatus=2,
		SpecimentTypeTemperatureMax=@SpecimentTypeTemperatureMax,
		SpecimentTypeTemperatureMin=@SpecimentTypeTemperatureMin,
		SpecimentTypeHumidityMax=@SpecimentTypeHumidityMax,
		SpecimentTypeHumidityMin=@SpecimentTypeHumidityMin
		 WHERE BarCode=@BarCode
END


GO


