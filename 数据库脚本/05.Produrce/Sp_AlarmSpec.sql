/*
获取该转运批次中是否有温度异常
*/
/****** Object:  StoredProcedure [dbo].[Sp_AlarmSpec]    Script Date: 01/13/2016 17:46:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sp_AlarmSpec]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sp_AlarmSpec]
GO


/****** Object:  StoredProcedure [dbo].[Sp_AlarmSpec]    Script Date: 01/13/2016 17:46:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_AlarmSpec]
(
	@TranID UNIQUEIDENTIFIER,
	@Temperature decimal(18,6),
    @Humidity decimal(18,6)
)
AS
BEGIN
	SELECT '温度' AS AlType, cr.Tel,cr.wxcode,  MAX(spec.SpecimentTypeTemperatureMin) AS MinValue,MIN(spec.SpecimentTypeTemperatureMax) AS MaxValue FROM dbo.Trans t
		INNER JOIN dbo.TranSpecRelation relation ON t.TranID=relation.TranID
		INNER JOIN dbo.SpecTran spec ON spec.BarCode = relation.BarCode
		INNER JOIN dbo.TransDeviceCourierRef ref ON t.DeviceCourierID=ref.Id
		INNER JOIN dbo.Courier cr ON ref.CourierId=cr.CourierId
	WHERE t.TranID=@TranID 
	AND (spec.SpecimentTypeTemperatureMax<=@Temperature OR spec.SpecimentTypeTemperatureMin>=@Temperature)
	GROUP BY cr.Tel,cr.wxcode
	UNION ALL
	SELECT '湿度' AS AlType,cr.Tel,cr.wxcode,  MAX(spec.SpecimentTypeHumidityMin)  AS MinValue,MIN(spec.SpecimentTypeHumidityMax)  AS MaxValue  FROM dbo.Trans t
		INNER JOIN dbo.TranSpecRelation relation ON t.TranID=relation.TranID
		INNER JOIN dbo.SpecTran spec ON spec.BarCode = relation.BarCode
		INNER JOIN dbo.TransDeviceCourierRef ref ON t.DeviceCourierID=ref.Id
		INNER JOIN dbo.Courier cr ON ref.CourierId=cr.CourierId
	WHERE t.TranID=@TranID 
	AND (spec.SpecimentTypeHumidityMax<=@Humidity OR spec.SpecimentTypeHumidityMin>=@Humidity)
	GROUP BY cr.Tel,cr.wxcode
END

GO

