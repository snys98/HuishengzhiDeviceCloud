/*获取承运人信息,根据转运记录Id*/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sp_QueryCourierByTranId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sp_QueryCourierByTranId]
GO



SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Sp_QueryCourierByTranId]
(
	@TranId [uniqueidentifier]
)
AS
BEGIN
	SELECT * FROM dbo.Courier courier inner JOIN dbo.Trans trans
	ON trans.TranID = @TranId and trans.DeviceCourierId = courier.CourierId
END
GO