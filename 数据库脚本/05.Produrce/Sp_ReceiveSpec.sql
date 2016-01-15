/*接收样本*/
/****** Object:  StoredProcedure [dbo].[Sp_ReceiveSpec]    Script Date: 01/05/2016 17:01:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sp_ReceiveSpec]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sp_ReceiveSpec]
GO


/****** Object:  StoredProcedure [dbo].[Sp_ReceiveSpec]    Script Date: 01/05/2016 17:01:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_ReceiveSpec]
(
	@PersonName nvarchar(50),
	@PersonID INT,
	@BarCode nvarchar(20)
) 
AS
BEGIN
	UPDATE dbo.SpecTran SET [TranStatus]=3,[ReceiveTime]=GETDATE() WHERE BarCode=@BarCode
	UPDATE dbo.Trans SET ReceivePersonName=@PersonName,ReceivePersonID=@PersonID,ReceiveTime=GETDATE(),[Status]=3
		WHERE TranID=(SELECT TOP 1 TranID FROM dbo.TranSpecRelation WHERE BarCode=@BarCode)
END

GO


