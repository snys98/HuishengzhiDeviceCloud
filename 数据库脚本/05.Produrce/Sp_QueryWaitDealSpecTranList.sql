/*获取需要派工的转运申请记录*/
/****** Object:  StoredProcedure [dbo].[Sp_QueryWaitDealSpecTranList]    Script Date: 12/29/2015 17:48:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sp_QueryWaitDealSpecTranList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sp_QueryWaitDealSpecTranList]
GO


/****** Object:  StoredProcedure [dbo].[Sp_QueryWaitDealSpecTranList]    Script Date: 12/29/2015 17:48:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Sp_QueryWaitDealSpecTranList]
(
	@PageSize INT,
	@PageIndex INT,
	@OrgName NVARCHAR(100),
	@RecordCount INT OUT
)
AS
BEGIN
;WITH t AS 
(
SELECT PreOrgName,PreDepName,SpecimenTypeName,ItemNames,BarCode,MIN(PostTime) AS PostTime	
	 FROM dbo.SpecTran 
	WHERE TranStatus=0 AND (@OrgName='' OR PreOrgName LIKE '%'+@OrgName+'%')
	GROUP BY PreOrgName,PreDepName,SpecimenTypeName,ItemNames,BarCode
)
SELECT *,ROW_NUMBER() OVER(ORDER BY PreOrgName,PostTime) AS Id INTO #t FROM t;

SELECT * FROM #t WHERE Id>@PageSize*@PageIndex AND Id<=@PageSize*(@PageIndex+1)
SELECT @RecordCount=COUNT(1) FROM #t
DROP TABLE #t
END
GO


