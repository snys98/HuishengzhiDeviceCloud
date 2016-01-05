/*保存样本转运申请*/
/****** Object:  StoredProcedure [dbo].[Sp_PostSpecTran]    Script Date: 12/24/2015 11:43:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sp_PostSpecTran]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sp_PostSpecTran]
GO


/****** Object:  StoredProcedure [dbo].[Sp_PostSpecTran]    Script Date: 12/24/2015 11:43:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_PostSpecTran]
(
	@BarCode nvarchar(20),
	@PreID bigint,
	@Sex nvarchar(2),
	@Age numeric(5,2),
	@Nationality nvarchar(12),
	@Name nvarchar(40),
	@Residence nvarchar(50),
	@Price numeric(8,2),
	@CurDisease nvarchar(200),
	@PreOrgName nvarchar(50),
	@PreDepName nvarchar(50),
	@PreDoctorName nvarchar(50),
	@curBedNo nvarchar(20),
	@PreTime datetime,
	@PreStatText nvarchar(10),
	@ItemNames nvarchar(400),
	@SpecimenTypeName nvarchar(50),
	@Comment nvarchar(200),
	@PreOrgID int,
	@PreDepID int,
	@PreDoctorID int,
	@PatientID int,
	@CheckRecID int,
	@ItemID int,
	@SpecimenTypeID int,
	@PostTime datetime,
	@OutTime datetime,
	@ReceiveTime datetime,
	@TranStatus int
)
AS
BEGIN
IF @CurDisease IS NULL SET @CurDisease=''
IF @Comment IS NULL SET @Comment=''
IF @PostTime IS NULL SET @PostTime=GETDATE()
INSERT INTO [dbo].[SpecTran]
           ([BarCode]
           ,[PreID]
           ,[Sex]
           ,[Age]
           ,[Nationality]
           ,[Name]
           ,[Residence]
           ,[Price]
           ,[CurDisease]
           ,[PreOrgName]
           ,[PreDepName]
           ,[PreDoctorName]
           ,[curBedNo]
           ,[PreTime]
           ,[PreStatText]
           ,[ItemNames]
           ,[SpecimenTypeName]
           ,[Comment]
           ,[PreOrgID]
           ,[PreDepID]
           ,[PreDoctorID]
           ,[PatientID]
           ,[CheckRecID]
           ,[ItemID]
           ,[SpecimenTypeID]
           ,[PostTime]
           ,[OutTime]
           ,[ReceiveTime]
           ,[TranStatus])
     VALUES
           (@BarCode,
           @PreID,
           @Sex,
           @Age,
           @Nationality,
           @Name,
           @Residence,
           @Price,
           @CurDisease,
           @PreOrgName,
           @PreDepName,
           @PreDoctorName,
           @curBedNo,
           @PreTime,
           @PreStatText,
           @ItemNames,
           @SpecimenTypeName,
           @Comment,
           @PreOrgID,
           @PreDepID,
           @PreDoctorID,
           @PatientID,
           @CheckRecID,
           @ItemID,
           @SpecimenTypeID,
           @PostTime,
           @OutTime,
           @ReceiveTime,
           @TranStatus)       
END

GO


