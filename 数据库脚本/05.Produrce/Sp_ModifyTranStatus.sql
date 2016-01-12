
/*ÐÞ¸Ä×ªÔËÉêÇë×´Ì¬*/
/****** Object:  StoredProcedure [dbo].[Sp_ModifyTranStatus]    Script Date: 01/05/2016 11:38:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sp_ModifyTranStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sp_ModifyTranStatus]
GO

/****** Object:  StoredProcedure [dbo].[Sp_ModifyTranStatus]    Script Date: 01/05/2016 11:38:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Sp_ModifyTranStatus]
(
	@BarCode NVARCHAR(20),
	@Status INT£ã
)
AS
BEGIN	
	 UPDATE dbo.SpecTran SET TranStatus=@Status WHERE BarCode=@BarCode
END


GO


