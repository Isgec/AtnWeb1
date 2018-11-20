SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spatnSiteAttendApprovalSelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spatnSiteAttendApprovalSelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[spatnSiteAttendApprovalSelectListSearch]
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @KeyWord VarChar(250),
  @FinYear NVarChar(4),
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
    DECLARE @KeyWord1 VarChar(260)
    SET @KeyWord1 = '%' + LOWER(@KeyWord) + '%'
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,FinYear NVarChar(4) NOT NULL
 ,MonthID Int NOT NULL
 ,CardNo NVarChar(8) NOT NULL
  )
  INSERT INTO #PageIndex (FinYear, MonthID, CardNo)
  SELECT [ATN_SiteAttendance].[FinYear], [ATN_SiteAttendance].[MonthID], [ATN_SiteAttendance].[CardNo] FROM [ATN_SiteAttendance]
  LEFT OUTER JOIN [ATN_ApplicationStatus] AS [ATN_ApplicationStatus1]
    ON [ATN_SiteAttendance].[ATNStatusID] = [ATN_ApplicationStatus1].[ApplStatusID]
  INNER JOIN [ATN_FinYear] AS [ATN_FinYear2]
    ON [ATN_SiteAttendance].[FinYear] = [ATN_FinYear2].[FinYear]
  INNER JOIN [ATN_Months] AS [ATN_Months3]
    ON [ATN_SiteAttendance].[MonthID] = [ATN_Months3].[MonthID]
  LEFT OUTER JOIN [ATN_SAStatus] AS [ATN_SAStatus4]
    ON [ATN_SiteAttendance].[SAStatusID] = [ATN_SAStatus4].[StatusID]
  INNER JOIN [HRM_Employees] AS [HRM_Employees5]
    ON [ATN_SiteAttendance].[CardNo] = [HRM_Employees5].[CardNo]
  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees6]
    ON [ATN_SiteAttendance].[ApprovedBy] = [HRM_Employees6].[CardNo]
  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees7]
    ON [ATN_SiteAttendance].[PostedBy] = [HRM_Employees7].[CardNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI1]
    ON [ATN_SiteAttendance].[SN01] = [ATN_SABySI1].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI3]
    ON [ATN_SiteAttendance].[SN03] = [ATN_SABySI3].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI4]
    ON [ATN_SiteAttendance].[SN04] = [ATN_SABySI4].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI5]
    ON [ATN_SiteAttendance].[SN05] = [ATN_SABySI5].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI6]
    ON [ATN_SiteAttendance].[SN06] = [ATN_SABySI6].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI7]
    ON [ATN_SiteAttendance].[SN07] = [ATN_SABySI7].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI8]
    ON [ATN_SiteAttendance].[SN08] = [ATN_SABySI8].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI9]
    ON [ATN_SiteAttendance].[SN09] = [ATN_SABySI9].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI10]
    ON [ATN_SiteAttendance].[SN10] = [ATN_SABySI10].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI11]
    ON [ATN_SiteAttendance].[SN11] = [ATN_SABySI11].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI12]
    ON [ATN_SiteAttendance].[SN12] = [ATN_SABySI12].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI13]
    ON [ATN_SiteAttendance].[SN13] = [ATN_SABySI13].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI14]
    ON [ATN_SiteAttendance].[SN14] = [ATN_SABySI14].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI15]
    ON [ATN_SiteAttendance].[SN15] = [ATN_SABySI15].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI16]
    ON [ATN_SiteAttendance].[SN16] = [ATN_SABySI16].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI17]
    ON [ATN_SiteAttendance].[SN17] = [ATN_SABySI17].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI18]
    ON [ATN_SiteAttendance].[SN18] = [ATN_SABySI18].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI19]
    ON [ATN_SiteAttendance].[SN19] = [ATN_SABySI19].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI20]
    ON [ATN_SiteAttendance].[SN20] = [ATN_SABySI20].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI21]
    ON [ATN_SiteAttendance].[SN21] = [ATN_SABySI21].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI22]
    ON [ATN_SiteAttendance].[SN22] = [ATN_SABySI22].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI23]
    ON [ATN_SiteAttendance].[SN23] = [ATN_SABySI23].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI24]
    ON [ATN_SiteAttendance].[SN24] = [ATN_SABySI24].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI25]
    ON [ATN_SiteAttendance].[SN25] = [ATN_SABySI25].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI26]
    ON [ATN_SiteAttendance].[SN26] = [ATN_SABySI26].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI27]
    ON [ATN_SiteAttendance].[SN27] = [ATN_SABySI27].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI28]
    ON [ATN_SiteAttendance].[SN28] = [ATN_SABySI28].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI29]
    ON [ATN_SiteAttendance].[SN29] = [ATN_SABySI29].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI30]
    ON [ATN_SiteAttendance].[SN30] = [ATN_SABySI30].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI31]
    ON [ATN_SiteAttendance].[SN31] = [ATN_SABySI31].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI2]
    ON [ATN_SiteAttendance].[SN02] = [ATN_SABySI2].[SerialNo]
 WHERE  
      [ATN_SiteAttendance].[FinYear] = (@FinYear)
   AND ( 
         LOWER(ISNULL([ATN_SiteAttendance].[FinYear],'')) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[MonthID], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[CardNo],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD01],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD02],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD03],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD04],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD05],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD06],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD07],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD08],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD09],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD10],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD11],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD12],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD13],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD14],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD15],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD16],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD17],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD18],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD19],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD20],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD21],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD22],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD23],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD24],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD25],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD26],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD27],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD28],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD29],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD30],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[VD31],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD25],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD18],'')) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SAStatusID], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD07],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD08],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD06],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD29],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD05],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD19],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD30],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD11],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD03],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD20],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD24],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD27],'')) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN09], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN08], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN07], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD17],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PostedBy],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD12],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD13],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PostingRemarks],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[ApprovedBy],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD09],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD04],'')) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN05], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD15],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD16],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD14],'')) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN04], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD02],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD28],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD22],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD21],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD24],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD23],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD18],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD17],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD20],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD19],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD30],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD29],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[ApproverRemarks],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD31],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD26],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD25],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD28],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD27],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD16],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD05],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD04],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD07],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD06],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD01],'')) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[ATNStatusID], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD03],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD02],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD13],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD12],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD15],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD14],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD09],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD08],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD11],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[AD10],'')) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN22], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN30], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN20], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN23], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN11], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN14], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN13], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN12], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN06], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN10], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN31], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN25], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN18], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN24], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD31],'')) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN21], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN16], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN03], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN27], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN28], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD10],'')) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN19], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN02], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN17], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN15], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN26], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD22],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD21],'')) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN29], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD23],'')) LIKE @KeyWord1
     OR STR(ISNULL([ATN_SiteAttendance].[SN01], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD26],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ATN_SiteAttendance].[PD01],'')) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 'FinYear' THEN [ATN_SiteAttendance].[FinYear] END,
     CASE @OrderBy WHEN 'FinYear DESC' THEN [ATN_SiteAttendance].[FinYear] END DESC,
     CASE @OrderBy WHEN 'MonthID' THEN [ATN_SiteAttendance].[MonthID] END,
     CASE @OrderBy WHEN 'MonthID DESC' THEN [ATN_SiteAttendance].[MonthID] END DESC,
     CASE @OrderBy WHEN 'CardNo' THEN [ATN_SiteAttendance].[CardNo] END,
     CASE @OrderBy WHEN 'CardNo DESC' THEN [ATN_SiteAttendance].[CardNo] END DESC,
     CASE @OrderBy WHEN 'VD01' THEN [ATN_SiteAttendance].[VD01] END,
     CASE @OrderBy WHEN 'VD01 DESC' THEN [ATN_SiteAttendance].[VD01] END DESC,
     CASE @OrderBy WHEN 'VD02' THEN [ATN_SiteAttendance].[VD02] END,
     CASE @OrderBy WHEN 'VD02 DESC' THEN [ATN_SiteAttendance].[VD02] END DESC,
     CASE @OrderBy WHEN 'VD03' THEN [ATN_SiteAttendance].[VD03] END,
     CASE @OrderBy WHEN 'VD03 DESC' THEN [ATN_SiteAttendance].[VD03] END DESC,
     CASE @OrderBy WHEN 'VD04' THEN [ATN_SiteAttendance].[VD04] END,
     CASE @OrderBy WHEN 'VD04 DESC' THEN [ATN_SiteAttendance].[VD04] END DESC,
     CASE @OrderBy WHEN 'VD05' THEN [ATN_SiteAttendance].[VD05] END,
     CASE @OrderBy WHEN 'VD05 DESC' THEN [ATN_SiteAttendance].[VD05] END DESC,
     CASE @OrderBy WHEN 'VD06' THEN [ATN_SiteAttendance].[VD06] END,
     CASE @OrderBy WHEN 'VD06 DESC' THEN [ATN_SiteAttendance].[VD06] END DESC,
     CASE @OrderBy WHEN 'VD07' THEN [ATN_SiteAttendance].[VD07] END,
     CASE @OrderBy WHEN 'VD07 DESC' THEN [ATN_SiteAttendance].[VD07] END DESC,
     CASE @OrderBy WHEN 'VD08' THEN [ATN_SiteAttendance].[VD08] END,
     CASE @OrderBy WHEN 'VD08 DESC' THEN [ATN_SiteAttendance].[VD08] END DESC,
     CASE @OrderBy WHEN 'VD09' THEN [ATN_SiteAttendance].[VD09] END,
     CASE @OrderBy WHEN 'VD09 DESC' THEN [ATN_SiteAttendance].[VD09] END DESC,
     CASE @OrderBy WHEN 'VD10' THEN [ATN_SiteAttendance].[VD10] END,
     CASE @OrderBy WHEN 'VD10 DESC' THEN [ATN_SiteAttendance].[VD10] END DESC,
     CASE @OrderBy WHEN 'VD11' THEN [ATN_SiteAttendance].[VD11] END,
     CASE @OrderBy WHEN 'VD11 DESC' THEN [ATN_SiteAttendance].[VD11] END DESC,
     CASE @OrderBy WHEN 'VD12' THEN [ATN_SiteAttendance].[VD12] END,
     CASE @OrderBy WHEN 'VD12 DESC' THEN [ATN_SiteAttendance].[VD12] END DESC,
     CASE @OrderBy WHEN 'VD13' THEN [ATN_SiteAttendance].[VD13] END,
     CASE @OrderBy WHEN 'VD13 DESC' THEN [ATN_SiteAttendance].[VD13] END DESC,
     CASE @OrderBy WHEN 'VD14' THEN [ATN_SiteAttendance].[VD14] END,
     CASE @OrderBy WHEN 'VD14 DESC' THEN [ATN_SiteAttendance].[VD14] END DESC,
     CASE @OrderBy WHEN 'VD15' THEN [ATN_SiteAttendance].[VD15] END,
     CASE @OrderBy WHEN 'VD15 DESC' THEN [ATN_SiteAttendance].[VD15] END DESC,
     CASE @OrderBy WHEN 'VD16' THEN [ATN_SiteAttendance].[VD16] END,
     CASE @OrderBy WHEN 'VD16 DESC' THEN [ATN_SiteAttendance].[VD16] END DESC,
     CASE @OrderBy WHEN 'VD17' THEN [ATN_SiteAttendance].[VD17] END,
     CASE @OrderBy WHEN 'VD17 DESC' THEN [ATN_SiteAttendance].[VD17] END DESC,
     CASE @OrderBy WHEN 'VD18' THEN [ATN_SiteAttendance].[VD18] END,
     CASE @OrderBy WHEN 'VD18 DESC' THEN [ATN_SiteAttendance].[VD18] END DESC,
     CASE @OrderBy WHEN 'VD19' THEN [ATN_SiteAttendance].[VD19] END,
     CASE @OrderBy WHEN 'VD19 DESC' THEN [ATN_SiteAttendance].[VD19] END DESC,
     CASE @OrderBy WHEN 'VD20' THEN [ATN_SiteAttendance].[VD20] END,
     CASE @OrderBy WHEN 'VD20 DESC' THEN [ATN_SiteAttendance].[VD20] END DESC,
     CASE @OrderBy WHEN 'VD21' THEN [ATN_SiteAttendance].[VD21] END,
     CASE @OrderBy WHEN 'VD21 DESC' THEN [ATN_SiteAttendance].[VD21] END DESC,
     CASE @OrderBy WHEN 'VD22' THEN [ATN_SiteAttendance].[VD22] END,
     CASE @OrderBy WHEN 'VD22 DESC' THEN [ATN_SiteAttendance].[VD22] END DESC,
     CASE @OrderBy WHEN 'VD23' THEN [ATN_SiteAttendance].[VD23] END,
     CASE @OrderBy WHEN 'VD23 DESC' THEN [ATN_SiteAttendance].[VD23] END DESC,
     CASE @OrderBy WHEN 'VD24' THEN [ATN_SiteAttendance].[VD24] END,
     CASE @OrderBy WHEN 'VD24 DESC' THEN [ATN_SiteAttendance].[VD24] END DESC,
     CASE @OrderBy WHEN 'VD25' THEN [ATN_SiteAttendance].[VD25] END,
     CASE @OrderBy WHEN 'VD25 DESC' THEN [ATN_SiteAttendance].[VD25] END DESC,
     CASE @OrderBy WHEN 'VD26' THEN [ATN_SiteAttendance].[VD26] END,
     CASE @OrderBy WHEN 'VD26 DESC' THEN [ATN_SiteAttendance].[VD26] END DESC,
     CASE @OrderBy WHEN 'VD27' THEN [ATN_SiteAttendance].[VD27] END,
     CASE @OrderBy WHEN 'VD27 DESC' THEN [ATN_SiteAttendance].[VD27] END DESC,
     CASE @OrderBy WHEN 'VD28' THEN [ATN_SiteAttendance].[VD28] END,
     CASE @OrderBy WHEN 'VD28 DESC' THEN [ATN_SiteAttendance].[VD28] END DESC,
     CASE @OrderBy WHEN 'VD29' THEN [ATN_SiteAttendance].[VD29] END,
     CASE @OrderBy WHEN 'VD29 DESC' THEN [ATN_SiteAttendance].[VD29] END DESC,
     CASE @OrderBy WHEN 'VD30' THEN [ATN_SiteAttendance].[VD30] END,
     CASE @OrderBy WHEN 'VD30 DESC' THEN [ATN_SiteAttendance].[VD30] END DESC,
     CASE @OrderBy WHEN 'VD31' THEN [ATN_SiteAttendance].[VD31] END,
     CASE @OrderBy WHEN 'VD31 DESC' THEN [ATN_SiteAttendance].[VD31] END DESC,
     CASE @OrderBy WHEN 'PD25' THEN [ATN_SiteAttendance].[PD25] END,
     CASE @OrderBy WHEN 'PD25 DESC' THEN [ATN_SiteAttendance].[PD25] END DESC,
     CASE @OrderBy WHEN 'PD18' THEN [ATN_SiteAttendance].[PD18] END,
     CASE @OrderBy WHEN 'PD18 DESC' THEN [ATN_SiteAttendance].[PD18] END DESC,
     CASE @OrderBy WHEN 'SAStatusID' THEN [ATN_SiteAttendance].[SAStatusID] END,
     CASE @OrderBy WHEN 'SAStatusID DESC' THEN [ATN_SiteAttendance].[SAStatusID] END DESC,
     CASE @OrderBy WHEN 'PD07' THEN [ATN_SiteAttendance].[PD07] END,
     CASE @OrderBy WHEN 'PD07 DESC' THEN [ATN_SiteAttendance].[PD07] END DESC,
     CASE @OrderBy WHEN 'PD08' THEN [ATN_SiteAttendance].[PD08] END,
     CASE @OrderBy WHEN 'PD08 DESC' THEN [ATN_SiteAttendance].[PD08] END DESC,
     CASE @OrderBy WHEN 'PD06' THEN [ATN_SiteAttendance].[PD06] END,
     CASE @OrderBy WHEN 'PD06 DESC' THEN [ATN_SiteAttendance].[PD06] END DESC,
     CASE @OrderBy WHEN 'PD29' THEN [ATN_SiteAttendance].[PD29] END,
     CASE @OrderBy WHEN 'PD29 DESC' THEN [ATN_SiteAttendance].[PD29] END DESC,
     CASE @OrderBy WHEN 'PD05' THEN [ATN_SiteAttendance].[PD05] END,
     CASE @OrderBy WHEN 'PD05 DESC' THEN [ATN_SiteAttendance].[PD05] END DESC,
     CASE @OrderBy WHEN 'PD19' THEN [ATN_SiteAttendance].[PD19] END,
     CASE @OrderBy WHEN 'PD19 DESC' THEN [ATN_SiteAttendance].[PD19] END DESC,
     CASE @OrderBy WHEN 'PD30' THEN [ATN_SiteAttendance].[PD30] END,
     CASE @OrderBy WHEN 'PD30 DESC' THEN [ATN_SiteAttendance].[PD30] END DESC,
     CASE @OrderBy WHEN 'PD11' THEN [ATN_SiteAttendance].[PD11] END,
     CASE @OrderBy WHEN 'PD11 DESC' THEN [ATN_SiteAttendance].[PD11] END DESC,
     CASE @OrderBy WHEN 'PD03' THEN [ATN_SiteAttendance].[PD03] END,
     CASE @OrderBy WHEN 'PD03 DESC' THEN [ATN_SiteAttendance].[PD03] END DESC,
     CASE @OrderBy WHEN 'PD20' THEN [ATN_SiteAttendance].[PD20] END,
     CASE @OrderBy WHEN 'PD20 DESC' THEN [ATN_SiteAttendance].[PD20] END DESC,
     CASE @OrderBy WHEN 'PD24' THEN [ATN_SiteAttendance].[PD24] END,
     CASE @OrderBy WHEN 'PD24 DESC' THEN [ATN_SiteAttendance].[PD24] END DESC,
     CASE @OrderBy WHEN 'PD27' THEN [ATN_SiteAttendance].[PD27] END,
     CASE @OrderBy WHEN 'PD27 DESC' THEN [ATN_SiteAttendance].[PD27] END DESC,
     CASE @OrderBy WHEN 'SN09' THEN [ATN_SiteAttendance].[SN09] END,
     CASE @OrderBy WHEN 'SN09 DESC' THEN [ATN_SiteAttendance].[SN09] END DESC,
     CASE @OrderBy WHEN 'SN08' THEN [ATN_SiteAttendance].[SN08] END,
     CASE @OrderBy WHEN 'SN08 DESC' THEN [ATN_SiteAttendance].[SN08] END DESC,
     CASE @OrderBy WHEN 'SN07' THEN [ATN_SiteAttendance].[SN07] END,
     CASE @OrderBy WHEN 'SN07 DESC' THEN [ATN_SiteAttendance].[SN07] END DESC,
     CASE @OrderBy WHEN 'PD17' THEN [ATN_SiteAttendance].[PD17] END,
     CASE @OrderBy WHEN 'PD17 DESC' THEN [ATN_SiteAttendance].[PD17] END DESC,
     CASE @OrderBy WHEN 'PostedBy' THEN [ATN_SiteAttendance].[PostedBy] END,
     CASE @OrderBy WHEN 'PostedBy DESC' THEN [ATN_SiteAttendance].[PostedBy] END DESC,
     CASE @OrderBy WHEN 'PD12' THEN [ATN_SiteAttendance].[PD12] END,
     CASE @OrderBy WHEN 'PD12 DESC' THEN [ATN_SiteAttendance].[PD12] END DESC,
     CASE @OrderBy WHEN 'PD13' THEN [ATN_SiteAttendance].[PD13] END,
     CASE @OrderBy WHEN 'PD13 DESC' THEN [ATN_SiteAttendance].[PD13] END DESC,
     CASE @OrderBy WHEN 'PostingRemarks' THEN [ATN_SiteAttendance].[PostingRemarks] END,
     CASE @OrderBy WHEN 'PostingRemarks DESC' THEN [ATN_SiteAttendance].[PostingRemarks] END DESC,
     CASE @OrderBy WHEN 'ApprovedBy' THEN [ATN_SiteAttendance].[ApprovedBy] END,
     CASE @OrderBy WHEN 'ApprovedBy DESC' THEN [ATN_SiteAttendance].[ApprovedBy] END DESC,
     CASE @OrderBy WHEN 'PD09' THEN [ATN_SiteAttendance].[PD09] END,
     CASE @OrderBy WHEN 'PD09 DESC' THEN [ATN_SiteAttendance].[PD09] END DESC,
     CASE @OrderBy WHEN 'PD04' THEN [ATN_SiteAttendance].[PD04] END,
     CASE @OrderBy WHEN 'PD04 DESC' THEN [ATN_SiteAttendance].[PD04] END DESC,
     CASE @OrderBy WHEN 'SN05' THEN [ATN_SiteAttendance].[SN05] END,
     CASE @OrderBy WHEN 'SN05 DESC' THEN [ATN_SiteAttendance].[SN05] END DESC,
     CASE @OrderBy WHEN 'PD15' THEN [ATN_SiteAttendance].[PD15] END,
     CASE @OrderBy WHEN 'PD15 DESC' THEN [ATN_SiteAttendance].[PD15] END DESC,
     CASE @OrderBy WHEN 'PD16' THEN [ATN_SiteAttendance].[PD16] END,
     CASE @OrderBy WHEN 'PD16 DESC' THEN [ATN_SiteAttendance].[PD16] END DESC,
     CASE @OrderBy WHEN 'PD14' THEN [ATN_SiteAttendance].[PD14] END,
     CASE @OrderBy WHEN 'PD14 DESC' THEN [ATN_SiteAttendance].[PD14] END DESC,
     CASE @OrderBy WHEN 'SN04' THEN [ATN_SiteAttendance].[SN04] END,
     CASE @OrderBy WHEN 'SN04 DESC' THEN [ATN_SiteAttendance].[SN04] END DESC,
     CASE @OrderBy WHEN 'ApprovedOn' THEN [ATN_SiteAttendance].[ApprovedOn] END,
     CASE @OrderBy WHEN 'ApprovedOn DESC' THEN [ATN_SiteAttendance].[ApprovedOn] END DESC,
     CASE @OrderBy WHEN 'PD02' THEN [ATN_SiteAttendance].[PD02] END,
     CASE @OrderBy WHEN 'PD02 DESC' THEN [ATN_SiteAttendance].[PD02] END DESC,
     CASE @OrderBy WHEN 'PostedOn' THEN [ATN_SiteAttendance].[PostedOn] END,
     CASE @OrderBy WHEN 'PostedOn DESC' THEN [ATN_SiteAttendance].[PostedOn] END DESC,
     CASE @OrderBy WHEN 'PD28' THEN [ATN_SiteAttendance].[PD28] END,
     CASE @OrderBy WHEN 'PD28 DESC' THEN [ATN_SiteAttendance].[PD28] END DESC,
     CASE @OrderBy WHEN 'AD22' THEN [ATN_SiteAttendance].[AD22] END,
     CASE @OrderBy WHEN 'AD22 DESC' THEN [ATN_SiteAttendance].[AD22] END DESC,
     CASE @OrderBy WHEN 'AD21' THEN [ATN_SiteAttendance].[AD21] END,
     CASE @OrderBy WHEN 'AD21 DESC' THEN [ATN_SiteAttendance].[AD21] END DESC,
     CASE @OrderBy WHEN 'AD24' THEN [ATN_SiteAttendance].[AD24] END,
     CASE @OrderBy WHEN 'AD24 DESC' THEN [ATN_SiteAttendance].[AD24] END DESC,
     CASE @OrderBy WHEN 'AD23' THEN [ATN_SiteAttendance].[AD23] END,
     CASE @OrderBy WHEN 'AD23 DESC' THEN [ATN_SiteAttendance].[AD23] END DESC,
     CASE @OrderBy WHEN 'AD18' THEN [ATN_SiteAttendance].[AD18] END,
     CASE @OrderBy WHEN 'AD18 DESC' THEN [ATN_SiteAttendance].[AD18] END DESC,
     CASE @OrderBy WHEN 'AD17' THEN [ATN_SiteAttendance].[AD17] END,
     CASE @OrderBy WHEN 'AD17 DESC' THEN [ATN_SiteAttendance].[AD17] END DESC,
     CASE @OrderBy WHEN 'AD20' THEN [ATN_SiteAttendance].[AD20] END,
     CASE @OrderBy WHEN 'AD20 DESC' THEN [ATN_SiteAttendance].[AD20] END DESC,
     CASE @OrderBy WHEN 'AD19' THEN [ATN_SiteAttendance].[AD19] END,
     CASE @OrderBy WHEN 'AD19 DESC' THEN [ATN_SiteAttendance].[AD19] END DESC,
     CASE @OrderBy WHEN 'AD30' THEN [ATN_SiteAttendance].[AD30] END,
     CASE @OrderBy WHEN 'AD30 DESC' THEN [ATN_SiteAttendance].[AD30] END DESC,
     CASE @OrderBy WHEN 'AD29' THEN [ATN_SiteAttendance].[AD29] END,
     CASE @OrderBy WHEN 'AD29 DESC' THEN [ATN_SiteAttendance].[AD29] END DESC,
     CASE @OrderBy WHEN 'ApproverRemarks' THEN [ATN_SiteAttendance].[ApproverRemarks] END,
     CASE @OrderBy WHEN 'ApproverRemarks DESC' THEN [ATN_SiteAttendance].[ApproverRemarks] END DESC,
     CASE @OrderBy WHEN 'AD31' THEN [ATN_SiteAttendance].[AD31] END,
     CASE @OrderBy WHEN 'AD31 DESC' THEN [ATN_SiteAttendance].[AD31] END DESC,
     CASE @OrderBy WHEN 'AD26' THEN [ATN_SiteAttendance].[AD26] END,
     CASE @OrderBy WHEN 'AD26 DESC' THEN [ATN_SiteAttendance].[AD26] END DESC,
     CASE @OrderBy WHEN 'AD25' THEN [ATN_SiteAttendance].[AD25] END,
     CASE @OrderBy WHEN 'AD25 DESC' THEN [ATN_SiteAttendance].[AD25] END DESC,
     CASE @OrderBy WHEN 'AD28' THEN [ATN_SiteAttendance].[AD28] END,
     CASE @OrderBy WHEN 'AD28 DESC' THEN [ATN_SiteAttendance].[AD28] END DESC,
     CASE @OrderBy WHEN 'AD27' THEN [ATN_SiteAttendance].[AD27] END,
     CASE @OrderBy WHEN 'AD27 DESC' THEN [ATN_SiteAttendance].[AD27] END DESC,
     CASE @OrderBy WHEN 'AD16' THEN [ATN_SiteAttendance].[AD16] END,
     CASE @OrderBy WHEN 'AD16 DESC' THEN [ATN_SiteAttendance].[AD16] END DESC,
     CASE @OrderBy WHEN 'AD05' THEN [ATN_SiteAttendance].[AD05] END,
     CASE @OrderBy WHEN 'AD05 DESC' THEN [ATN_SiteAttendance].[AD05] END DESC,
     CASE @OrderBy WHEN 'AD04' THEN [ATN_SiteAttendance].[AD04] END,
     CASE @OrderBy WHEN 'AD04 DESC' THEN [ATN_SiteAttendance].[AD04] END DESC,
     CASE @OrderBy WHEN 'AD07' THEN [ATN_SiteAttendance].[AD07] END,
     CASE @OrderBy WHEN 'AD07 DESC' THEN [ATN_SiteAttendance].[AD07] END DESC,
     CASE @OrderBy WHEN 'AD06' THEN [ATN_SiteAttendance].[AD06] END,
     CASE @OrderBy WHEN 'AD06 DESC' THEN [ATN_SiteAttendance].[AD06] END DESC,
     CASE @OrderBy WHEN 'AD01' THEN [ATN_SiteAttendance].[AD01] END,
     CASE @OrderBy WHEN 'AD01 DESC' THEN [ATN_SiteAttendance].[AD01] END DESC,
     CASE @OrderBy WHEN 'ATNStatusID' THEN [ATN_SiteAttendance].[ATNStatusID] END,
     CASE @OrderBy WHEN 'ATNStatusID DESC' THEN [ATN_SiteAttendance].[ATNStatusID] END DESC,
     CASE @OrderBy WHEN 'AD03' THEN [ATN_SiteAttendance].[AD03] END,
     CASE @OrderBy WHEN 'AD03 DESC' THEN [ATN_SiteAttendance].[AD03] END DESC,
     CASE @OrderBy WHEN 'AD02' THEN [ATN_SiteAttendance].[AD02] END,
     CASE @OrderBy WHEN 'AD02 DESC' THEN [ATN_SiteAttendance].[AD02] END DESC,
     CASE @OrderBy WHEN 'AD13' THEN [ATN_SiteAttendance].[AD13] END,
     CASE @OrderBy WHEN 'AD13 DESC' THEN [ATN_SiteAttendance].[AD13] END DESC,
     CASE @OrderBy WHEN 'AD12' THEN [ATN_SiteAttendance].[AD12] END,
     CASE @OrderBy WHEN 'AD12 DESC' THEN [ATN_SiteAttendance].[AD12] END DESC,
     CASE @OrderBy WHEN 'AD15' THEN [ATN_SiteAttendance].[AD15] END,
     CASE @OrderBy WHEN 'AD15 DESC' THEN [ATN_SiteAttendance].[AD15] END DESC,
     CASE @OrderBy WHEN 'AD14' THEN [ATN_SiteAttendance].[AD14] END,
     CASE @OrderBy WHEN 'AD14 DESC' THEN [ATN_SiteAttendance].[AD14] END DESC,
     CASE @OrderBy WHEN 'AD09' THEN [ATN_SiteAttendance].[AD09] END,
     CASE @OrderBy WHEN 'AD09 DESC' THEN [ATN_SiteAttendance].[AD09] END DESC,
     CASE @OrderBy WHEN 'AD08' THEN [ATN_SiteAttendance].[AD08] END,
     CASE @OrderBy WHEN 'AD08 DESC' THEN [ATN_SiteAttendance].[AD08] END DESC,
     CASE @OrderBy WHEN 'AD11' THEN [ATN_SiteAttendance].[AD11] END,
     CASE @OrderBy WHEN 'AD11 DESC' THEN [ATN_SiteAttendance].[AD11] END DESC,
     CASE @OrderBy WHEN 'AD10' THEN [ATN_SiteAttendance].[AD10] END,
     CASE @OrderBy WHEN 'AD10 DESC' THEN [ATN_SiteAttendance].[AD10] END DESC,
     CASE @OrderBy WHEN 'SN22' THEN [ATN_SiteAttendance].[SN22] END,
     CASE @OrderBy WHEN 'SN22 DESC' THEN [ATN_SiteAttendance].[SN22] END DESC,
     CASE @OrderBy WHEN 'SN30' THEN [ATN_SiteAttendance].[SN30] END,
     CASE @OrderBy WHEN 'SN30 DESC' THEN [ATN_SiteAttendance].[SN30] END DESC,
     CASE @OrderBy WHEN 'SN20' THEN [ATN_SiteAttendance].[SN20] END,
     CASE @OrderBy WHEN 'SN20 DESC' THEN [ATN_SiteAttendance].[SN20] END DESC,
     CASE @OrderBy WHEN 'SN23' THEN [ATN_SiteAttendance].[SN23] END,
     CASE @OrderBy WHEN 'SN23 DESC' THEN [ATN_SiteAttendance].[SN23] END DESC,
     CASE @OrderBy WHEN 'SN11' THEN [ATN_SiteAttendance].[SN11] END,
     CASE @OrderBy WHEN 'SN11 DESC' THEN [ATN_SiteAttendance].[SN11] END DESC,
     CASE @OrderBy WHEN 'SN14' THEN [ATN_SiteAttendance].[SN14] END,
     CASE @OrderBy WHEN 'SN14 DESC' THEN [ATN_SiteAttendance].[SN14] END DESC,
     CASE @OrderBy WHEN 'SN13' THEN [ATN_SiteAttendance].[SN13] END,
     CASE @OrderBy WHEN 'SN13 DESC' THEN [ATN_SiteAttendance].[SN13] END DESC,
     CASE @OrderBy WHEN 'SN12' THEN [ATN_SiteAttendance].[SN12] END,
     CASE @OrderBy WHEN 'SN12 DESC' THEN [ATN_SiteAttendance].[SN12] END DESC,
     CASE @OrderBy WHEN 'SN06' THEN [ATN_SiteAttendance].[SN06] END,
     CASE @OrderBy WHEN 'SN06 DESC' THEN [ATN_SiteAttendance].[SN06] END DESC,
     CASE @OrderBy WHEN 'SN10' THEN [ATN_SiteAttendance].[SN10] END,
     CASE @OrderBy WHEN 'SN10 DESC' THEN [ATN_SiteAttendance].[SN10] END DESC,
     CASE @OrderBy WHEN 'SN31' THEN [ATN_SiteAttendance].[SN31] END,
     CASE @OrderBy WHEN 'SN31 DESC' THEN [ATN_SiteAttendance].[SN31] END DESC,
     CASE @OrderBy WHEN 'SN25' THEN [ATN_SiteAttendance].[SN25] END,
     CASE @OrderBy WHEN 'SN25 DESC' THEN [ATN_SiteAttendance].[SN25] END DESC,
     CASE @OrderBy WHEN 'SN18' THEN [ATN_SiteAttendance].[SN18] END,
     CASE @OrderBy WHEN 'SN18 DESC' THEN [ATN_SiteAttendance].[SN18] END DESC,
     CASE @OrderBy WHEN 'SN24' THEN [ATN_SiteAttendance].[SN24] END,
     CASE @OrderBy WHEN 'SN24 DESC' THEN [ATN_SiteAttendance].[SN24] END DESC,
     CASE @OrderBy WHEN 'PD31' THEN [ATN_SiteAttendance].[PD31] END,
     CASE @OrderBy WHEN 'PD31 DESC' THEN [ATN_SiteAttendance].[PD31] END DESC,
     CASE @OrderBy WHEN 'SN21' THEN [ATN_SiteAttendance].[SN21] END,
     CASE @OrderBy WHEN 'SN21 DESC' THEN [ATN_SiteAttendance].[SN21] END DESC,
     CASE @OrderBy WHEN 'SN16' THEN [ATN_SiteAttendance].[SN16] END,
     CASE @OrderBy WHEN 'SN16 DESC' THEN [ATN_SiteAttendance].[SN16] END DESC,
     CASE @OrderBy WHEN 'SN03' THEN [ATN_SiteAttendance].[SN03] END,
     CASE @OrderBy WHEN 'SN03 DESC' THEN [ATN_SiteAttendance].[SN03] END DESC,
     CASE @OrderBy WHEN 'SN27' THEN [ATN_SiteAttendance].[SN27] END,
     CASE @OrderBy WHEN 'SN27 DESC' THEN [ATN_SiteAttendance].[SN27] END DESC,
     CASE @OrderBy WHEN 'SN28' THEN [ATN_SiteAttendance].[SN28] END,
     CASE @OrderBy WHEN 'SN28 DESC' THEN [ATN_SiteAttendance].[SN28] END DESC,
     CASE @OrderBy WHEN 'PD10' THEN [ATN_SiteAttendance].[PD10] END,
     CASE @OrderBy WHEN 'PD10 DESC' THEN [ATN_SiteAttendance].[PD10] END DESC,
     CASE @OrderBy WHEN 'SN19' THEN [ATN_SiteAttendance].[SN19] END,
     CASE @OrderBy WHEN 'SN19 DESC' THEN [ATN_SiteAttendance].[SN19] END DESC,
     CASE @OrderBy WHEN 'SN02' THEN [ATN_SiteAttendance].[SN02] END,
     CASE @OrderBy WHEN 'SN02 DESC' THEN [ATN_SiteAttendance].[SN02] END DESC,
     CASE @OrderBy WHEN 'SN17' THEN [ATN_SiteAttendance].[SN17] END,
     CASE @OrderBy WHEN 'SN17 DESC' THEN [ATN_SiteAttendance].[SN17] END DESC,
     CASE @OrderBy WHEN 'SN15' THEN [ATN_SiteAttendance].[SN15] END,
     CASE @OrderBy WHEN 'SN15 DESC' THEN [ATN_SiteAttendance].[SN15] END DESC,
     CASE @OrderBy WHEN 'SN26' THEN [ATN_SiteAttendance].[SN26] END,
     CASE @OrderBy WHEN 'SN26 DESC' THEN [ATN_SiteAttendance].[SN26] END DESC,
     CASE @OrderBy WHEN 'PD22' THEN [ATN_SiteAttendance].[PD22] END,
     CASE @OrderBy WHEN 'PD22 DESC' THEN [ATN_SiteAttendance].[PD22] END DESC,
     CASE @OrderBy WHEN 'PD21' THEN [ATN_SiteAttendance].[PD21] END,
     CASE @OrderBy WHEN 'PD21 DESC' THEN [ATN_SiteAttendance].[PD21] END DESC,
     CASE @OrderBy WHEN 'SN29' THEN [ATN_SiteAttendance].[SN29] END,
     CASE @OrderBy WHEN 'SN29 DESC' THEN [ATN_SiteAttendance].[SN29] END DESC,
     CASE @OrderBy WHEN 'PD23' THEN [ATN_SiteAttendance].[PD23] END,
     CASE @OrderBy WHEN 'PD23 DESC' THEN [ATN_SiteAttendance].[PD23] END DESC,
     CASE @OrderBy WHEN 'SN01' THEN [ATN_SiteAttendance].[SN01] END,
     CASE @OrderBy WHEN 'SN01 DESC' THEN [ATN_SiteAttendance].[SN01] END DESC,
     CASE @OrderBy WHEN 'PD26' THEN [ATN_SiteAttendance].[PD26] END,
     CASE @OrderBy WHEN 'PD26 DESC' THEN [ATN_SiteAttendance].[PD26] END DESC,
     CASE @OrderBy WHEN 'PD01' THEN [ATN_SiteAttendance].[PD01] END,
     CASE @OrderBy WHEN 'PD01 DESC' THEN [ATN_SiteAttendance].[PD01] END DESC,
     CASE @OrderBy WHEN 'ATN_ApplicationStatus1_Description' THEN [ATN_ApplicationStatus1].[Description] END,
     CASE @OrderBy WHEN 'ATN_ApplicationStatus1_Description DESC' THEN [ATN_ApplicationStatus1].[Description] END DESC,
     CASE @OrderBy WHEN 'ATN_FinYear2_Description' THEN [ATN_FinYear2].[Description] END,
     CASE @OrderBy WHEN 'ATN_FinYear2_Description DESC' THEN [ATN_FinYear2].[Description] END DESC,
     CASE @OrderBy WHEN 'ATN_Months3_Description' THEN [ATN_Months3].[Description] END,
     CASE @OrderBy WHEN 'ATN_Months3_Description DESC' THEN [ATN_Months3].[Description] END DESC,
     CASE @OrderBy WHEN 'ATN_SAStatus4_Description' THEN [ATN_SAStatus4].[Description] END,
     CASE @OrderBy WHEN 'ATN_SAStatus4_Description DESC' THEN [ATN_SAStatus4].[Description] END DESC,
     CASE @OrderBy WHEN 'HRM_Employees5_EmployeeName' THEN [HRM_Employees5].[EmployeeName] END,
     CASE @OrderBy WHEN 'HRM_Employees5_EmployeeName DESC' THEN [HRM_Employees5].[EmployeeName] END DESC,
     CASE @OrderBy WHEN 'HRM_Employees6_EmployeeName' THEN [HRM_Employees6].[EmployeeName] END,
     CASE @OrderBy WHEN 'HRM_Employees6_EmployeeName DESC' THEN [HRM_Employees6].[EmployeeName] END DESC,
     CASE @OrderBy WHEN 'HRM_Employees7_EmployeeName' THEN [HRM_Employees7].[EmployeeName] END,
     CASE @OrderBy WHEN 'HRM_Employees7_EmployeeName DESC' THEN [HRM_Employees7].[EmployeeName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI1_SiteName' THEN [ATN_SABySI1].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI1_SiteName DESC' THEN [ATN_SABySI1].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI3_SiteName' THEN [ATN_SABySI3].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI3_SiteName DESC' THEN [ATN_SABySI3].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI4_SiteName' THEN [ATN_SABySI4].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI4_SiteName DESC' THEN [ATN_SABySI4].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI5_SiteName' THEN [ATN_SABySI5].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI5_SiteName DESC' THEN [ATN_SABySI5].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI6_SiteName' THEN [ATN_SABySI6].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI6_SiteName DESC' THEN [ATN_SABySI6].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI7_SiteName' THEN [ATN_SABySI7].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI7_SiteName DESC' THEN [ATN_SABySI7].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI8_SiteName' THEN [ATN_SABySI8].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI8_SiteName DESC' THEN [ATN_SABySI8].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI9_SiteName' THEN [ATN_SABySI9].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI9_SiteName DESC' THEN [ATN_SABySI9].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI10_SiteName' THEN [ATN_SABySI10].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI10_SiteName DESC' THEN [ATN_SABySI10].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI11_SiteName' THEN [ATN_SABySI11].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI11_SiteName DESC' THEN [ATN_SABySI11].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI12_SiteName' THEN [ATN_SABySI12].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI12_SiteName DESC' THEN [ATN_SABySI12].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI13_SiteName' THEN [ATN_SABySI13].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI13_SiteName DESC' THEN [ATN_SABySI13].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI14_SiteName' THEN [ATN_SABySI14].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI14_SiteName DESC' THEN [ATN_SABySI14].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI15_SiteName' THEN [ATN_SABySI15].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI15_SiteName DESC' THEN [ATN_SABySI15].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI16_SiteName' THEN [ATN_SABySI16].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI16_SiteName DESC' THEN [ATN_SABySI16].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI17_SiteName' THEN [ATN_SABySI17].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI17_SiteName DESC' THEN [ATN_SABySI17].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI18_SiteName' THEN [ATN_SABySI18].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI18_SiteName DESC' THEN [ATN_SABySI18].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI19_SiteName' THEN [ATN_SABySI19].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI19_SiteName DESC' THEN [ATN_SABySI19].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI20_SiteName' THEN [ATN_SABySI20].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI20_SiteName DESC' THEN [ATN_SABySI20].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI21_SiteName' THEN [ATN_SABySI21].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI21_SiteName DESC' THEN [ATN_SABySI21].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI22_SiteName' THEN [ATN_SABySI22].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI22_SiteName DESC' THEN [ATN_SABySI22].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI23_SiteName' THEN [ATN_SABySI23].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI23_SiteName DESC' THEN [ATN_SABySI23].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI24_SiteName' THEN [ATN_SABySI24].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI24_SiteName DESC' THEN [ATN_SABySI24].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI25_SiteName' THEN [ATN_SABySI25].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI25_SiteName DESC' THEN [ATN_SABySI25].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI26_SiteName' THEN [ATN_SABySI26].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI26_SiteName DESC' THEN [ATN_SABySI26].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI27_SiteName' THEN [ATN_SABySI27].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI27_SiteName DESC' THEN [ATN_SABySI27].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI28_SiteName' THEN [ATN_SABySI28].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI28_SiteName DESC' THEN [ATN_SABySI28].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI29_SiteName' THEN [ATN_SABySI29].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI29_SiteName DESC' THEN [ATN_SABySI29].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI30_SiteName' THEN [ATN_SABySI30].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI30_SiteName DESC' THEN [ATN_SABySI30].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI31_SiteName' THEN [ATN_SABySI31].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI31_SiteName DESC' THEN [ATN_SABySI31].[SiteName] END DESC,
     CASE @OrderBy WHEN 'ATN_SABySI2_SiteName' THEN [ATN_SABySI2].[SiteName] END,
     CASE @OrderBy WHEN 'ATN_SABySI2_SiteName DESC' THEN [ATN_SABySI2].[SiteName] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [ATN_SiteAttendance].* ,
    [ATN_ApplicationStatus1].[Description] AS ATN_ApplicationStatus1_Description,
    [ATN_FinYear2].[Description] AS ATN_FinYear2_Description,
    [ATN_Months3].[Description] AS ATN_Months3_Description,
    [ATN_SAStatus4].[Description] AS ATN_SAStatus4_Description,
    [HRM_Employees5].[EmployeeName] AS HRM_Employees5_EmployeeName,
    [HRM_Employees6].[EmployeeName] AS HRM_Employees6_EmployeeName,
    [HRM_Employees7].[EmployeeName] AS HRM_Employees7_EmployeeName,
    [ATN_SABySI1].[SiteName] AS ATN_SABySI1_SiteName,
    [ATN_SABySI3].[SiteName] AS ATN_SABySI3_SiteName,
    [ATN_SABySI4].[SiteName] AS ATN_SABySI4_SiteName,
    [ATN_SABySI5].[SiteName] AS ATN_SABySI5_SiteName,
    [ATN_SABySI6].[SiteName] AS ATN_SABySI6_SiteName,
    [ATN_SABySI7].[SiteName] AS ATN_SABySI7_SiteName,
    [ATN_SABySI8].[SiteName] AS ATN_SABySI8_SiteName,
    [ATN_SABySI9].[SiteName] AS ATN_SABySI9_SiteName,
    [ATN_SABySI10].[SiteName] AS ATN_SABySI10_SiteName,
    [ATN_SABySI11].[SiteName] AS ATN_SABySI11_SiteName,
    [ATN_SABySI12].[SiteName] AS ATN_SABySI12_SiteName,
    [ATN_SABySI13].[SiteName] AS ATN_SABySI13_SiteName,
    [ATN_SABySI14].[SiteName] AS ATN_SABySI14_SiteName,
    [ATN_SABySI15].[SiteName] AS ATN_SABySI15_SiteName,
    [ATN_SABySI16].[SiteName] AS ATN_SABySI16_SiteName,
    [ATN_SABySI17].[SiteName] AS ATN_SABySI17_SiteName,
    [ATN_SABySI18].[SiteName] AS ATN_SABySI18_SiteName,
    [ATN_SABySI19].[SiteName] AS ATN_SABySI19_SiteName,
    [ATN_SABySI20].[SiteName] AS ATN_SABySI20_SiteName,
    [ATN_SABySI21].[SiteName] AS ATN_SABySI21_SiteName,
    [ATN_SABySI22].[SiteName] AS ATN_SABySI22_SiteName,
    [ATN_SABySI23].[SiteName] AS ATN_SABySI23_SiteName,
    [ATN_SABySI24].[SiteName] AS ATN_SABySI24_SiteName,
    [ATN_SABySI25].[SiteName] AS ATN_SABySI25_SiteName,
    [ATN_SABySI26].[SiteName] AS ATN_SABySI26_SiteName,
    [ATN_SABySI27].[SiteName] AS ATN_SABySI27_SiteName,
    [ATN_SABySI28].[SiteName] AS ATN_SABySI28_SiteName,
    [ATN_SABySI29].[SiteName] AS ATN_SABySI29_SiteName,
    [ATN_SABySI30].[SiteName] AS ATN_SABySI30_SiteName,
    [ATN_SABySI31].[SiteName] AS ATN_SABySI31_SiteName,
    [ATN_SABySI2].[SiteName] AS ATN_SABySI2_SiteName 
  FROM [ATN_SiteAttendance] 
      INNER JOIN #PageIndex
          ON [ATN_SiteAttendance].[FinYear] = #PageIndex.FinYear
          AND [ATN_SiteAttendance].[MonthID] = #PageIndex.MonthID
          AND [ATN_SiteAttendance].[CardNo] = #PageIndex.CardNo
  LEFT OUTER JOIN [ATN_ApplicationStatus] AS [ATN_ApplicationStatus1]
    ON [ATN_SiteAttendance].[ATNStatusID] = [ATN_ApplicationStatus1].[ApplStatusID]
  INNER JOIN [ATN_FinYear] AS [ATN_FinYear2]
    ON [ATN_SiteAttendance].[FinYear] = [ATN_FinYear2].[FinYear]
  INNER JOIN [ATN_Months] AS [ATN_Months3]
    ON [ATN_SiteAttendance].[MonthID] = [ATN_Months3].[MonthID]
  LEFT OUTER JOIN [ATN_SAStatus] AS [ATN_SAStatus4]
    ON [ATN_SiteAttendance].[SAStatusID] = [ATN_SAStatus4].[StatusID]
  INNER JOIN [HRM_Employees] AS [HRM_Employees5]
    ON [ATN_SiteAttendance].[CardNo] = [HRM_Employees5].[CardNo]
  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees6]
    ON [ATN_SiteAttendance].[ApprovedBy] = [HRM_Employees6].[CardNo]
  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees7]
    ON [ATN_SiteAttendance].[PostedBy] = [HRM_Employees7].[CardNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI1]
    ON [ATN_SiteAttendance].[SN01] = [ATN_SABySI1].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI3]
    ON [ATN_SiteAttendance].[SN03] = [ATN_SABySI3].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI4]
    ON [ATN_SiteAttendance].[SN04] = [ATN_SABySI4].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI5]
    ON [ATN_SiteAttendance].[SN05] = [ATN_SABySI5].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI6]
    ON [ATN_SiteAttendance].[SN06] = [ATN_SABySI6].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI7]
    ON [ATN_SiteAttendance].[SN07] = [ATN_SABySI7].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI8]
    ON [ATN_SiteAttendance].[SN08] = [ATN_SABySI8].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI9]
    ON [ATN_SiteAttendance].[SN09] = [ATN_SABySI9].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI10]
    ON [ATN_SiteAttendance].[SN10] = [ATN_SABySI10].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI11]
    ON [ATN_SiteAttendance].[SN11] = [ATN_SABySI11].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI12]
    ON [ATN_SiteAttendance].[SN12] = [ATN_SABySI12].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI13]
    ON [ATN_SiteAttendance].[SN13] = [ATN_SABySI13].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI14]
    ON [ATN_SiteAttendance].[SN14] = [ATN_SABySI14].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI15]
    ON [ATN_SiteAttendance].[SN15] = [ATN_SABySI15].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI16]
    ON [ATN_SiteAttendance].[SN16] = [ATN_SABySI16].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI17]
    ON [ATN_SiteAttendance].[SN17] = [ATN_SABySI17].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI18]
    ON [ATN_SiteAttendance].[SN18] = [ATN_SABySI18].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI19]
    ON [ATN_SiteAttendance].[SN19] = [ATN_SABySI19].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI20]
    ON [ATN_SiteAttendance].[SN20] = [ATN_SABySI20].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI21]
    ON [ATN_SiteAttendance].[SN21] = [ATN_SABySI21].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI22]
    ON [ATN_SiteAttendance].[SN22] = [ATN_SABySI22].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI23]
    ON [ATN_SiteAttendance].[SN23] = [ATN_SABySI23].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI24]
    ON [ATN_SiteAttendance].[SN24] = [ATN_SABySI24].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI25]
    ON [ATN_SiteAttendance].[SN25] = [ATN_SABySI25].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI26]
    ON [ATN_SiteAttendance].[SN26] = [ATN_SABySI26].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI27]
    ON [ATN_SiteAttendance].[SN27] = [ATN_SABySI27].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI28]
    ON [ATN_SiteAttendance].[SN28] = [ATN_SABySI28].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI29]
    ON [ATN_SiteAttendance].[SN29] = [ATN_SABySI29].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI30]
    ON [ATN_SiteAttendance].[SN30] = [ATN_SABySI30].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI31]
    ON [ATN_SiteAttendance].[SN31] = [ATN_SABySI31].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI2]
    ON [ATN_SiteAttendance].[SN02] = [ATN_SABySI2].[SerialNo]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spatnSiteAttendApprovalSelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spatnSiteAttendApprovalSelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[spatnSiteAttendApprovalSelectListFilteres]
  @Filter_MonthID Int,
  @Filter_ApprovedBy NVarChar(8),
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @FinYear NVarChar(4),
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,FinYear NVarChar(4) NOT NULL
 ,MonthID Int NOT NULL
 ,CardNo NVarChar(8) NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 'FinYear'
  SET @LGSQL = @LGSQL + ', MonthID'
  SET @LGSQL = @LGSQL + ', CardNo'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[ATN_SiteAttendance].[FinYear]'
  SET @LGSQL = @LGSQL + ', [ATN_SiteAttendance].[MonthID]'
  SET @LGSQL = @LGSQL + ', [ATN_SiteAttendance].[CardNo]'
  SET @LGSQL = @LGSQL + ' FROM [ATN_SiteAttendance] '
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_ApplicationStatus] AS [ATN_ApplicationStatus1]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[ATNStatusID] = [ATN_ApplicationStatus1].[ApplStatusID]'
  SET @LGSQL = @LGSQL + '  INNER JOIN [ATN_FinYear] AS [ATN_FinYear2]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[FinYear] = [ATN_FinYear2].[FinYear]'
  SET @LGSQL = @LGSQL + '  INNER JOIN [ATN_Months] AS [ATN_Months3]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[MonthID] = [ATN_Months3].[MonthID]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SAStatus] AS [ATN_SAStatus4]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SAStatusID] = [ATN_SAStatus4].[StatusID]'
  SET @LGSQL = @LGSQL + '  INNER JOIN [HRM_Employees] AS [HRM_Employees5]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[CardNo] = [HRM_Employees5].[CardNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees6]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[ApprovedBy] = [HRM_Employees6].[CardNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees7]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[PostedBy] = [HRM_Employees7].[CardNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI1]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN01] = [ATN_SABySI1].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI3]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN03] = [ATN_SABySI3].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI4]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN04] = [ATN_SABySI4].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI5]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN05] = [ATN_SABySI5].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI6]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN06] = [ATN_SABySI6].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI7]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN07] = [ATN_SABySI7].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI8]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN08] = [ATN_SABySI8].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI9]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN09] = [ATN_SABySI9].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI10]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN10] = [ATN_SABySI10].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI11]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN11] = [ATN_SABySI11].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI12]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN12] = [ATN_SABySI12].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI13]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN13] = [ATN_SABySI13].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI14]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN14] = [ATN_SABySI14].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI15]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN15] = [ATN_SABySI15].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI16]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN16] = [ATN_SABySI16].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI17]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN17] = [ATN_SABySI17].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI18]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN18] = [ATN_SABySI18].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI19]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN19] = [ATN_SABySI19].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI20]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN20] = [ATN_SABySI20].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI21]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN21] = [ATN_SABySI21].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI22]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN22] = [ATN_SABySI22].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI23]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN23] = [ATN_SABySI23].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI24]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN24] = [ATN_SABySI24].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI25]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN25] = [ATN_SABySI25].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI26]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN26] = [ATN_SABySI26].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI27]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN27] = [ATN_SABySI27].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI28]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN28] = [ATN_SABySI28].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI29]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN29] = [ATN_SABySI29].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI30]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN30] = [ATN_SABySI30].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI31]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN31] = [ATN_SABySI31].[SerialNo]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI2]'
  SET @LGSQL = @LGSQL + '    ON [ATN_SiteAttendance].[SN02] = [ATN_SABySI2].[SerialNo]'
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  SET @LGSQL = @LGSQL + ' AND [ATN_SiteAttendance].[FinYear] = (''' + @FinYear + ''')'
  IF (@Filter_MonthID > 0) 
    SET @LGSQL = @LGSQL + ' AND [ATN_SiteAttendance].[MonthID] = ' + STR(@Filter_MonthID)
  IF (@Filter_ApprovedBy > '') 
    SET @LGSQL = @LGSQL + ' AND [ATN_SiteAttendance].[ApprovedBy] = ''' + @Filter_ApprovedBy + ''''
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 'FinYear' THEN '[ATN_SiteAttendance].[FinYear]'
                        WHEN 'FinYear DESC' THEN '[ATN_SiteAttendance].[FinYear] DESC'
                        WHEN 'MonthID' THEN '[ATN_SiteAttendance].[MonthID]'
                        WHEN 'MonthID DESC' THEN '[ATN_SiteAttendance].[MonthID] DESC'
                        WHEN 'CardNo' THEN '[ATN_SiteAttendance].[CardNo]'
                        WHEN 'CardNo DESC' THEN '[ATN_SiteAttendance].[CardNo] DESC'
                        WHEN 'VD01' THEN '[ATN_SiteAttendance].[VD01]'
                        WHEN 'VD01 DESC' THEN '[ATN_SiteAttendance].[VD01] DESC'
                        WHEN 'VD02' THEN '[ATN_SiteAttendance].[VD02]'
                        WHEN 'VD02 DESC' THEN '[ATN_SiteAttendance].[VD02] DESC'
                        WHEN 'VD03' THEN '[ATN_SiteAttendance].[VD03]'
                        WHEN 'VD03 DESC' THEN '[ATN_SiteAttendance].[VD03] DESC'
                        WHEN 'VD04' THEN '[ATN_SiteAttendance].[VD04]'
                        WHEN 'VD04 DESC' THEN '[ATN_SiteAttendance].[VD04] DESC'
                        WHEN 'VD05' THEN '[ATN_SiteAttendance].[VD05]'
                        WHEN 'VD05 DESC' THEN '[ATN_SiteAttendance].[VD05] DESC'
                        WHEN 'VD06' THEN '[ATN_SiteAttendance].[VD06]'
                        WHEN 'VD06 DESC' THEN '[ATN_SiteAttendance].[VD06] DESC'
                        WHEN 'VD07' THEN '[ATN_SiteAttendance].[VD07]'
                        WHEN 'VD07 DESC' THEN '[ATN_SiteAttendance].[VD07] DESC'
                        WHEN 'VD08' THEN '[ATN_SiteAttendance].[VD08]'
                        WHEN 'VD08 DESC' THEN '[ATN_SiteAttendance].[VD08] DESC'
                        WHEN 'VD09' THEN '[ATN_SiteAttendance].[VD09]'
                        WHEN 'VD09 DESC' THEN '[ATN_SiteAttendance].[VD09] DESC'
                        WHEN 'VD10' THEN '[ATN_SiteAttendance].[VD10]'
                        WHEN 'VD10 DESC' THEN '[ATN_SiteAttendance].[VD10] DESC'
                        WHEN 'VD11' THEN '[ATN_SiteAttendance].[VD11]'
                        WHEN 'VD11 DESC' THEN '[ATN_SiteAttendance].[VD11] DESC'
                        WHEN 'VD12' THEN '[ATN_SiteAttendance].[VD12]'
                        WHEN 'VD12 DESC' THEN '[ATN_SiteAttendance].[VD12] DESC'
                        WHEN 'VD13' THEN '[ATN_SiteAttendance].[VD13]'
                        WHEN 'VD13 DESC' THEN '[ATN_SiteAttendance].[VD13] DESC'
                        WHEN 'VD14' THEN '[ATN_SiteAttendance].[VD14]'
                        WHEN 'VD14 DESC' THEN '[ATN_SiteAttendance].[VD14] DESC'
                        WHEN 'VD15' THEN '[ATN_SiteAttendance].[VD15]'
                        WHEN 'VD15 DESC' THEN '[ATN_SiteAttendance].[VD15] DESC'
                        WHEN 'VD16' THEN '[ATN_SiteAttendance].[VD16]'
                        WHEN 'VD16 DESC' THEN '[ATN_SiteAttendance].[VD16] DESC'
                        WHEN 'VD17' THEN '[ATN_SiteAttendance].[VD17]'
                        WHEN 'VD17 DESC' THEN '[ATN_SiteAttendance].[VD17] DESC'
                        WHEN 'VD18' THEN '[ATN_SiteAttendance].[VD18]'
                        WHEN 'VD18 DESC' THEN '[ATN_SiteAttendance].[VD18] DESC'
                        WHEN 'VD19' THEN '[ATN_SiteAttendance].[VD19]'
                        WHEN 'VD19 DESC' THEN '[ATN_SiteAttendance].[VD19] DESC'
                        WHEN 'VD20' THEN '[ATN_SiteAttendance].[VD20]'
                        WHEN 'VD20 DESC' THEN '[ATN_SiteAttendance].[VD20] DESC'
                        WHEN 'VD21' THEN '[ATN_SiteAttendance].[VD21]'
                        WHEN 'VD21 DESC' THEN '[ATN_SiteAttendance].[VD21] DESC'
                        WHEN 'VD22' THEN '[ATN_SiteAttendance].[VD22]'
                        WHEN 'VD22 DESC' THEN '[ATN_SiteAttendance].[VD22] DESC'
                        WHEN 'VD23' THEN '[ATN_SiteAttendance].[VD23]'
                        WHEN 'VD23 DESC' THEN '[ATN_SiteAttendance].[VD23] DESC'
                        WHEN 'VD24' THEN '[ATN_SiteAttendance].[VD24]'
                        WHEN 'VD24 DESC' THEN '[ATN_SiteAttendance].[VD24] DESC'
                        WHEN 'VD25' THEN '[ATN_SiteAttendance].[VD25]'
                        WHEN 'VD25 DESC' THEN '[ATN_SiteAttendance].[VD25] DESC'
                        WHEN 'VD26' THEN '[ATN_SiteAttendance].[VD26]'
                        WHEN 'VD26 DESC' THEN '[ATN_SiteAttendance].[VD26] DESC'
                        WHEN 'VD27' THEN '[ATN_SiteAttendance].[VD27]'
                        WHEN 'VD27 DESC' THEN '[ATN_SiteAttendance].[VD27] DESC'
                        WHEN 'VD28' THEN '[ATN_SiteAttendance].[VD28]'
                        WHEN 'VD28 DESC' THEN '[ATN_SiteAttendance].[VD28] DESC'
                        WHEN 'VD29' THEN '[ATN_SiteAttendance].[VD29]'
                        WHEN 'VD29 DESC' THEN '[ATN_SiteAttendance].[VD29] DESC'
                        WHEN 'VD30' THEN '[ATN_SiteAttendance].[VD30]'
                        WHEN 'VD30 DESC' THEN '[ATN_SiteAttendance].[VD30] DESC'
                        WHEN 'VD31' THEN '[ATN_SiteAttendance].[VD31]'
                        WHEN 'VD31 DESC' THEN '[ATN_SiteAttendance].[VD31] DESC'
                        WHEN 'PD25' THEN '[ATN_SiteAttendance].[PD25]'
                        WHEN 'PD25 DESC' THEN '[ATN_SiteAttendance].[PD25] DESC'
                        WHEN 'PD18' THEN '[ATN_SiteAttendance].[PD18]'
                        WHEN 'PD18 DESC' THEN '[ATN_SiteAttendance].[PD18] DESC'
                        WHEN 'SAStatusID' THEN '[ATN_SiteAttendance].[SAStatusID]'
                        WHEN 'SAStatusID DESC' THEN '[ATN_SiteAttendance].[SAStatusID] DESC'
                        WHEN 'PD07' THEN '[ATN_SiteAttendance].[PD07]'
                        WHEN 'PD07 DESC' THEN '[ATN_SiteAttendance].[PD07] DESC'
                        WHEN 'PD08' THEN '[ATN_SiteAttendance].[PD08]'
                        WHEN 'PD08 DESC' THEN '[ATN_SiteAttendance].[PD08] DESC'
                        WHEN 'PD06' THEN '[ATN_SiteAttendance].[PD06]'
                        WHEN 'PD06 DESC' THEN '[ATN_SiteAttendance].[PD06] DESC'
                        WHEN 'PD29' THEN '[ATN_SiteAttendance].[PD29]'
                        WHEN 'PD29 DESC' THEN '[ATN_SiteAttendance].[PD29] DESC'
                        WHEN 'PD05' THEN '[ATN_SiteAttendance].[PD05]'
                        WHEN 'PD05 DESC' THEN '[ATN_SiteAttendance].[PD05] DESC'
                        WHEN 'PD19' THEN '[ATN_SiteAttendance].[PD19]'
                        WHEN 'PD19 DESC' THEN '[ATN_SiteAttendance].[PD19] DESC'
                        WHEN 'PD30' THEN '[ATN_SiteAttendance].[PD30]'
                        WHEN 'PD30 DESC' THEN '[ATN_SiteAttendance].[PD30] DESC'
                        WHEN 'PD11' THEN '[ATN_SiteAttendance].[PD11]'
                        WHEN 'PD11 DESC' THEN '[ATN_SiteAttendance].[PD11] DESC'
                        WHEN 'PD03' THEN '[ATN_SiteAttendance].[PD03]'
                        WHEN 'PD03 DESC' THEN '[ATN_SiteAttendance].[PD03] DESC'
                        WHEN 'PD20' THEN '[ATN_SiteAttendance].[PD20]'
                        WHEN 'PD20 DESC' THEN '[ATN_SiteAttendance].[PD20] DESC'
                        WHEN 'PD24' THEN '[ATN_SiteAttendance].[PD24]'
                        WHEN 'PD24 DESC' THEN '[ATN_SiteAttendance].[PD24] DESC'
                        WHEN 'PD27' THEN '[ATN_SiteAttendance].[PD27]'
                        WHEN 'PD27 DESC' THEN '[ATN_SiteAttendance].[PD27] DESC'
                        WHEN 'SN09' THEN '[ATN_SiteAttendance].[SN09]'
                        WHEN 'SN09 DESC' THEN '[ATN_SiteAttendance].[SN09] DESC'
                        WHEN 'SN08' THEN '[ATN_SiteAttendance].[SN08]'
                        WHEN 'SN08 DESC' THEN '[ATN_SiteAttendance].[SN08] DESC'
                        WHEN 'SN07' THEN '[ATN_SiteAttendance].[SN07]'
                        WHEN 'SN07 DESC' THEN '[ATN_SiteAttendance].[SN07] DESC'
                        WHEN 'PD17' THEN '[ATN_SiteAttendance].[PD17]'
                        WHEN 'PD17 DESC' THEN '[ATN_SiteAttendance].[PD17] DESC'
                        WHEN 'PostedBy' THEN '[ATN_SiteAttendance].[PostedBy]'
                        WHEN 'PostedBy DESC' THEN '[ATN_SiteAttendance].[PostedBy] DESC'
                        WHEN 'PD12' THEN '[ATN_SiteAttendance].[PD12]'
                        WHEN 'PD12 DESC' THEN '[ATN_SiteAttendance].[PD12] DESC'
                        WHEN 'PD13' THEN '[ATN_SiteAttendance].[PD13]'
                        WHEN 'PD13 DESC' THEN '[ATN_SiteAttendance].[PD13] DESC'
                        WHEN 'PostingRemarks' THEN '[ATN_SiteAttendance].[PostingRemarks]'
                        WHEN 'PostingRemarks DESC' THEN '[ATN_SiteAttendance].[PostingRemarks] DESC'
                        WHEN 'ApprovedBy' THEN '[ATN_SiteAttendance].[ApprovedBy]'
                        WHEN 'ApprovedBy DESC' THEN '[ATN_SiteAttendance].[ApprovedBy] DESC'
                        WHEN 'PD09' THEN '[ATN_SiteAttendance].[PD09]'
                        WHEN 'PD09 DESC' THEN '[ATN_SiteAttendance].[PD09] DESC'
                        WHEN 'PD04' THEN '[ATN_SiteAttendance].[PD04]'
                        WHEN 'PD04 DESC' THEN '[ATN_SiteAttendance].[PD04] DESC'
                        WHEN 'SN05' THEN '[ATN_SiteAttendance].[SN05]'
                        WHEN 'SN05 DESC' THEN '[ATN_SiteAttendance].[SN05] DESC'
                        WHEN 'PD15' THEN '[ATN_SiteAttendance].[PD15]'
                        WHEN 'PD15 DESC' THEN '[ATN_SiteAttendance].[PD15] DESC'
                        WHEN 'PD16' THEN '[ATN_SiteAttendance].[PD16]'
                        WHEN 'PD16 DESC' THEN '[ATN_SiteAttendance].[PD16] DESC'
                        WHEN 'PD14' THEN '[ATN_SiteAttendance].[PD14]'
                        WHEN 'PD14 DESC' THEN '[ATN_SiteAttendance].[PD14] DESC'
                        WHEN 'SN04' THEN '[ATN_SiteAttendance].[SN04]'
                        WHEN 'SN04 DESC' THEN '[ATN_SiteAttendance].[SN04] DESC'
                        WHEN 'ApprovedOn' THEN '[ATN_SiteAttendance].[ApprovedOn]'
                        WHEN 'ApprovedOn DESC' THEN '[ATN_SiteAttendance].[ApprovedOn] DESC'
                        WHEN 'PD02' THEN '[ATN_SiteAttendance].[PD02]'
                        WHEN 'PD02 DESC' THEN '[ATN_SiteAttendance].[PD02] DESC'
                        WHEN 'PostedOn' THEN '[ATN_SiteAttendance].[PostedOn]'
                        WHEN 'PostedOn DESC' THEN '[ATN_SiteAttendance].[PostedOn] DESC'
                        WHEN 'PD28' THEN '[ATN_SiteAttendance].[PD28]'
                        WHEN 'PD28 DESC' THEN '[ATN_SiteAttendance].[PD28] DESC'
                        WHEN 'AD22' THEN '[ATN_SiteAttendance].[AD22]'
                        WHEN 'AD22 DESC' THEN '[ATN_SiteAttendance].[AD22] DESC'
                        WHEN 'AD21' THEN '[ATN_SiteAttendance].[AD21]'
                        WHEN 'AD21 DESC' THEN '[ATN_SiteAttendance].[AD21] DESC'
                        WHEN 'AD24' THEN '[ATN_SiteAttendance].[AD24]'
                        WHEN 'AD24 DESC' THEN '[ATN_SiteAttendance].[AD24] DESC'
                        WHEN 'AD23' THEN '[ATN_SiteAttendance].[AD23]'
                        WHEN 'AD23 DESC' THEN '[ATN_SiteAttendance].[AD23] DESC'
                        WHEN 'AD18' THEN '[ATN_SiteAttendance].[AD18]'
                        WHEN 'AD18 DESC' THEN '[ATN_SiteAttendance].[AD18] DESC'
                        WHEN 'AD17' THEN '[ATN_SiteAttendance].[AD17]'
                        WHEN 'AD17 DESC' THEN '[ATN_SiteAttendance].[AD17] DESC'
                        WHEN 'AD20' THEN '[ATN_SiteAttendance].[AD20]'
                        WHEN 'AD20 DESC' THEN '[ATN_SiteAttendance].[AD20] DESC'
                        WHEN 'AD19' THEN '[ATN_SiteAttendance].[AD19]'
                        WHEN 'AD19 DESC' THEN '[ATN_SiteAttendance].[AD19] DESC'
                        WHEN 'AD30' THEN '[ATN_SiteAttendance].[AD30]'
                        WHEN 'AD30 DESC' THEN '[ATN_SiteAttendance].[AD30] DESC'
                        WHEN 'AD29' THEN '[ATN_SiteAttendance].[AD29]'
                        WHEN 'AD29 DESC' THEN '[ATN_SiteAttendance].[AD29] DESC'
                        WHEN 'ApproverRemarks' THEN '[ATN_SiteAttendance].[ApproverRemarks]'
                        WHEN 'ApproverRemarks DESC' THEN '[ATN_SiteAttendance].[ApproverRemarks] DESC'
                        WHEN 'AD31' THEN '[ATN_SiteAttendance].[AD31]'
                        WHEN 'AD31 DESC' THEN '[ATN_SiteAttendance].[AD31] DESC'
                        WHEN 'AD26' THEN '[ATN_SiteAttendance].[AD26]'
                        WHEN 'AD26 DESC' THEN '[ATN_SiteAttendance].[AD26] DESC'
                        WHEN 'AD25' THEN '[ATN_SiteAttendance].[AD25]'
                        WHEN 'AD25 DESC' THEN '[ATN_SiteAttendance].[AD25] DESC'
                        WHEN 'AD28' THEN '[ATN_SiteAttendance].[AD28]'
                        WHEN 'AD28 DESC' THEN '[ATN_SiteAttendance].[AD28] DESC'
                        WHEN 'AD27' THEN '[ATN_SiteAttendance].[AD27]'
                        WHEN 'AD27 DESC' THEN '[ATN_SiteAttendance].[AD27] DESC'
                        WHEN 'AD16' THEN '[ATN_SiteAttendance].[AD16]'
                        WHEN 'AD16 DESC' THEN '[ATN_SiteAttendance].[AD16] DESC'
                        WHEN 'AD05' THEN '[ATN_SiteAttendance].[AD05]'
                        WHEN 'AD05 DESC' THEN '[ATN_SiteAttendance].[AD05] DESC'
                        WHEN 'AD04' THEN '[ATN_SiteAttendance].[AD04]'
                        WHEN 'AD04 DESC' THEN '[ATN_SiteAttendance].[AD04] DESC'
                        WHEN 'AD07' THEN '[ATN_SiteAttendance].[AD07]'
                        WHEN 'AD07 DESC' THEN '[ATN_SiteAttendance].[AD07] DESC'
                        WHEN 'AD06' THEN '[ATN_SiteAttendance].[AD06]'
                        WHEN 'AD06 DESC' THEN '[ATN_SiteAttendance].[AD06] DESC'
                        WHEN 'AD01' THEN '[ATN_SiteAttendance].[AD01]'
                        WHEN 'AD01 DESC' THEN '[ATN_SiteAttendance].[AD01] DESC'
                        WHEN 'ATNStatusID' THEN '[ATN_SiteAttendance].[ATNStatusID]'
                        WHEN 'ATNStatusID DESC' THEN '[ATN_SiteAttendance].[ATNStatusID] DESC'
                        WHEN 'AD03' THEN '[ATN_SiteAttendance].[AD03]'
                        WHEN 'AD03 DESC' THEN '[ATN_SiteAttendance].[AD03] DESC'
                        WHEN 'AD02' THEN '[ATN_SiteAttendance].[AD02]'
                        WHEN 'AD02 DESC' THEN '[ATN_SiteAttendance].[AD02] DESC'
                        WHEN 'AD13' THEN '[ATN_SiteAttendance].[AD13]'
                        WHEN 'AD13 DESC' THEN '[ATN_SiteAttendance].[AD13] DESC'
                        WHEN 'AD12' THEN '[ATN_SiteAttendance].[AD12]'
                        WHEN 'AD12 DESC' THEN '[ATN_SiteAttendance].[AD12] DESC'
                        WHEN 'AD15' THEN '[ATN_SiteAttendance].[AD15]'
                        WHEN 'AD15 DESC' THEN '[ATN_SiteAttendance].[AD15] DESC'
                        WHEN 'AD14' THEN '[ATN_SiteAttendance].[AD14]'
                        WHEN 'AD14 DESC' THEN '[ATN_SiteAttendance].[AD14] DESC'
                        WHEN 'AD09' THEN '[ATN_SiteAttendance].[AD09]'
                        WHEN 'AD09 DESC' THEN '[ATN_SiteAttendance].[AD09] DESC'
                        WHEN 'AD08' THEN '[ATN_SiteAttendance].[AD08]'
                        WHEN 'AD08 DESC' THEN '[ATN_SiteAttendance].[AD08] DESC'
                        WHEN 'AD11' THEN '[ATN_SiteAttendance].[AD11]'
                        WHEN 'AD11 DESC' THEN '[ATN_SiteAttendance].[AD11] DESC'
                        WHEN 'AD10' THEN '[ATN_SiteAttendance].[AD10]'
                        WHEN 'AD10 DESC' THEN '[ATN_SiteAttendance].[AD10] DESC'
                        WHEN 'SN22' THEN '[ATN_SiteAttendance].[SN22]'
                        WHEN 'SN22 DESC' THEN '[ATN_SiteAttendance].[SN22] DESC'
                        WHEN 'SN30' THEN '[ATN_SiteAttendance].[SN30]'
                        WHEN 'SN30 DESC' THEN '[ATN_SiteAttendance].[SN30] DESC'
                        WHEN 'SN20' THEN '[ATN_SiteAttendance].[SN20]'
                        WHEN 'SN20 DESC' THEN '[ATN_SiteAttendance].[SN20] DESC'
                        WHEN 'SN23' THEN '[ATN_SiteAttendance].[SN23]'
                        WHEN 'SN23 DESC' THEN '[ATN_SiteAttendance].[SN23] DESC'
                        WHEN 'SN11' THEN '[ATN_SiteAttendance].[SN11]'
                        WHEN 'SN11 DESC' THEN '[ATN_SiteAttendance].[SN11] DESC'
                        WHEN 'SN14' THEN '[ATN_SiteAttendance].[SN14]'
                        WHEN 'SN14 DESC' THEN '[ATN_SiteAttendance].[SN14] DESC'
                        WHEN 'SN13' THEN '[ATN_SiteAttendance].[SN13]'
                        WHEN 'SN13 DESC' THEN '[ATN_SiteAttendance].[SN13] DESC'
                        WHEN 'SN12' THEN '[ATN_SiteAttendance].[SN12]'
                        WHEN 'SN12 DESC' THEN '[ATN_SiteAttendance].[SN12] DESC'
                        WHEN 'SN06' THEN '[ATN_SiteAttendance].[SN06]'
                        WHEN 'SN06 DESC' THEN '[ATN_SiteAttendance].[SN06] DESC'
                        WHEN 'SN10' THEN '[ATN_SiteAttendance].[SN10]'
                        WHEN 'SN10 DESC' THEN '[ATN_SiteAttendance].[SN10] DESC'
                        WHEN 'SN31' THEN '[ATN_SiteAttendance].[SN31]'
                        WHEN 'SN31 DESC' THEN '[ATN_SiteAttendance].[SN31] DESC'
                        WHEN 'SN25' THEN '[ATN_SiteAttendance].[SN25]'
                        WHEN 'SN25 DESC' THEN '[ATN_SiteAttendance].[SN25] DESC'
                        WHEN 'SN18' THEN '[ATN_SiteAttendance].[SN18]'
                        WHEN 'SN18 DESC' THEN '[ATN_SiteAttendance].[SN18] DESC'
                        WHEN 'SN24' THEN '[ATN_SiteAttendance].[SN24]'
                        WHEN 'SN24 DESC' THEN '[ATN_SiteAttendance].[SN24] DESC'
                        WHEN 'PD31' THEN '[ATN_SiteAttendance].[PD31]'
                        WHEN 'PD31 DESC' THEN '[ATN_SiteAttendance].[PD31] DESC'
                        WHEN 'SN21' THEN '[ATN_SiteAttendance].[SN21]'
                        WHEN 'SN21 DESC' THEN '[ATN_SiteAttendance].[SN21] DESC'
                        WHEN 'SN16' THEN '[ATN_SiteAttendance].[SN16]'
                        WHEN 'SN16 DESC' THEN '[ATN_SiteAttendance].[SN16] DESC'
                        WHEN 'SN03' THEN '[ATN_SiteAttendance].[SN03]'
                        WHEN 'SN03 DESC' THEN '[ATN_SiteAttendance].[SN03] DESC'
                        WHEN 'SN27' THEN '[ATN_SiteAttendance].[SN27]'
                        WHEN 'SN27 DESC' THEN '[ATN_SiteAttendance].[SN27] DESC'
                        WHEN 'SN28' THEN '[ATN_SiteAttendance].[SN28]'
                        WHEN 'SN28 DESC' THEN '[ATN_SiteAttendance].[SN28] DESC'
                        WHEN 'PD10' THEN '[ATN_SiteAttendance].[PD10]'
                        WHEN 'PD10 DESC' THEN '[ATN_SiteAttendance].[PD10] DESC'
                        WHEN 'SN19' THEN '[ATN_SiteAttendance].[SN19]'
                        WHEN 'SN19 DESC' THEN '[ATN_SiteAttendance].[SN19] DESC'
                        WHEN 'SN02' THEN '[ATN_SiteAttendance].[SN02]'
                        WHEN 'SN02 DESC' THEN '[ATN_SiteAttendance].[SN02] DESC'
                        WHEN 'SN17' THEN '[ATN_SiteAttendance].[SN17]'
                        WHEN 'SN17 DESC' THEN '[ATN_SiteAttendance].[SN17] DESC'
                        WHEN 'SN15' THEN '[ATN_SiteAttendance].[SN15]'
                        WHEN 'SN15 DESC' THEN '[ATN_SiteAttendance].[SN15] DESC'
                        WHEN 'SN26' THEN '[ATN_SiteAttendance].[SN26]'
                        WHEN 'SN26 DESC' THEN '[ATN_SiteAttendance].[SN26] DESC'
                        WHEN 'PD22' THEN '[ATN_SiteAttendance].[PD22]'
                        WHEN 'PD22 DESC' THEN '[ATN_SiteAttendance].[PD22] DESC'
                        WHEN 'PD21' THEN '[ATN_SiteAttendance].[PD21]'
                        WHEN 'PD21 DESC' THEN '[ATN_SiteAttendance].[PD21] DESC'
                        WHEN 'SN29' THEN '[ATN_SiteAttendance].[SN29]'
                        WHEN 'SN29 DESC' THEN '[ATN_SiteAttendance].[SN29] DESC'
                        WHEN 'PD23' THEN '[ATN_SiteAttendance].[PD23]'
                        WHEN 'PD23 DESC' THEN '[ATN_SiteAttendance].[PD23] DESC'
                        WHEN 'SN01' THEN '[ATN_SiteAttendance].[SN01]'
                        WHEN 'SN01 DESC' THEN '[ATN_SiteAttendance].[SN01] DESC'
                        WHEN 'PD26' THEN '[ATN_SiteAttendance].[PD26]'
                        WHEN 'PD26 DESC' THEN '[ATN_SiteAttendance].[PD26] DESC'
                        WHEN 'PD01' THEN '[ATN_SiteAttendance].[PD01]'
                        WHEN 'PD01 DESC' THEN '[ATN_SiteAttendance].[PD01] DESC'
                        WHEN 'ATN_ApplicationStatus1_Description' THEN '[ATN_ApplicationStatus1].[Description]'
                        WHEN 'ATN_ApplicationStatus1_Description DESC' THEN '[ATN_ApplicationStatus1].[Description] DESC'
                        WHEN 'ATN_FinYear2_Description' THEN '[ATN_FinYear2].[Description]'
                        WHEN 'ATN_FinYear2_Description DESC' THEN '[ATN_FinYear2].[Description] DESC'
                        WHEN 'ATN_Months3_Description' THEN '[ATN_Months3].[Description]'
                        WHEN 'ATN_Months3_Description DESC' THEN '[ATN_Months3].[Description] DESC'
                        WHEN 'ATN_SAStatus4_Description' THEN '[ATN_SAStatus4].[Description]'
                        WHEN 'ATN_SAStatus4_Description DESC' THEN '[ATN_SAStatus4].[Description] DESC'
                        WHEN 'HRM_Employees5_EmployeeName' THEN '[HRM_Employees5].[EmployeeName]'
                        WHEN 'HRM_Employees5_EmployeeName DESC' THEN '[HRM_Employees5].[EmployeeName] DESC'
                        WHEN 'HRM_Employees6_EmployeeName' THEN '[HRM_Employees6].[EmployeeName]'
                        WHEN 'HRM_Employees6_EmployeeName DESC' THEN '[HRM_Employees6].[EmployeeName] DESC'
                        WHEN 'HRM_Employees7_EmployeeName' THEN '[HRM_Employees7].[EmployeeName]'
                        WHEN 'HRM_Employees7_EmployeeName DESC' THEN '[HRM_Employees7].[EmployeeName] DESC'
                        WHEN 'ATN_SABySI1_SiteName' THEN '[ATN_SABySI1].[SiteName]'
                        WHEN 'ATN_SABySI1_SiteName DESC' THEN '[ATN_SABySI1].[SiteName] DESC'
                        WHEN 'ATN_SABySI3_SiteName' THEN '[ATN_SABySI3].[SiteName]'
                        WHEN 'ATN_SABySI3_SiteName DESC' THEN '[ATN_SABySI3].[SiteName] DESC'
                        WHEN 'ATN_SABySI4_SiteName' THEN '[ATN_SABySI4].[SiteName]'
                        WHEN 'ATN_SABySI4_SiteName DESC' THEN '[ATN_SABySI4].[SiteName] DESC'
                        WHEN 'ATN_SABySI5_SiteName' THEN '[ATN_SABySI5].[SiteName]'
                        WHEN 'ATN_SABySI5_SiteName DESC' THEN '[ATN_SABySI5].[SiteName] DESC'
                        WHEN 'ATN_SABySI6_SiteName' THEN '[ATN_SABySI6].[SiteName]'
                        WHEN 'ATN_SABySI6_SiteName DESC' THEN '[ATN_SABySI6].[SiteName] DESC'
                        WHEN 'ATN_SABySI7_SiteName' THEN '[ATN_SABySI7].[SiteName]'
                        WHEN 'ATN_SABySI7_SiteName DESC' THEN '[ATN_SABySI7].[SiteName] DESC'
                        WHEN 'ATN_SABySI8_SiteName' THEN '[ATN_SABySI8].[SiteName]'
                        WHEN 'ATN_SABySI8_SiteName DESC' THEN '[ATN_SABySI8].[SiteName] DESC'
                        WHEN 'ATN_SABySI9_SiteName' THEN '[ATN_SABySI9].[SiteName]'
                        WHEN 'ATN_SABySI9_SiteName DESC' THEN '[ATN_SABySI9].[SiteName] DESC'
                        WHEN 'ATN_SABySI10_SiteName' THEN '[ATN_SABySI10].[SiteName]'
                        WHEN 'ATN_SABySI10_SiteName DESC' THEN '[ATN_SABySI10].[SiteName] DESC'
                        WHEN 'ATN_SABySI11_SiteName' THEN '[ATN_SABySI11].[SiteName]'
                        WHEN 'ATN_SABySI11_SiteName DESC' THEN '[ATN_SABySI11].[SiteName] DESC'
                        WHEN 'ATN_SABySI12_SiteName' THEN '[ATN_SABySI12].[SiteName]'
                        WHEN 'ATN_SABySI12_SiteName DESC' THEN '[ATN_SABySI12].[SiteName] DESC'
                        WHEN 'ATN_SABySI13_SiteName' THEN '[ATN_SABySI13].[SiteName]'
                        WHEN 'ATN_SABySI13_SiteName DESC' THEN '[ATN_SABySI13].[SiteName] DESC'
                        WHEN 'ATN_SABySI14_SiteName' THEN '[ATN_SABySI14].[SiteName]'
                        WHEN 'ATN_SABySI14_SiteName DESC' THEN '[ATN_SABySI14].[SiteName] DESC'
                        WHEN 'ATN_SABySI15_SiteName' THEN '[ATN_SABySI15].[SiteName]'
                        WHEN 'ATN_SABySI15_SiteName DESC' THEN '[ATN_SABySI15].[SiteName] DESC'
                        WHEN 'ATN_SABySI16_SiteName' THEN '[ATN_SABySI16].[SiteName]'
                        WHEN 'ATN_SABySI16_SiteName DESC' THEN '[ATN_SABySI16].[SiteName] DESC'
                        WHEN 'ATN_SABySI17_SiteName' THEN '[ATN_SABySI17].[SiteName]'
                        WHEN 'ATN_SABySI17_SiteName DESC' THEN '[ATN_SABySI17].[SiteName] DESC'
                        WHEN 'ATN_SABySI18_SiteName' THEN '[ATN_SABySI18].[SiteName]'
                        WHEN 'ATN_SABySI18_SiteName DESC' THEN '[ATN_SABySI18].[SiteName] DESC'
                        WHEN 'ATN_SABySI19_SiteName' THEN '[ATN_SABySI19].[SiteName]'
                        WHEN 'ATN_SABySI19_SiteName DESC' THEN '[ATN_SABySI19].[SiteName] DESC'
                        WHEN 'ATN_SABySI20_SiteName' THEN '[ATN_SABySI20].[SiteName]'
                        WHEN 'ATN_SABySI20_SiteName DESC' THEN '[ATN_SABySI20].[SiteName] DESC'
                        WHEN 'ATN_SABySI21_SiteName' THEN '[ATN_SABySI21].[SiteName]'
                        WHEN 'ATN_SABySI21_SiteName DESC' THEN '[ATN_SABySI21].[SiteName] DESC'
                        WHEN 'ATN_SABySI22_SiteName' THEN '[ATN_SABySI22].[SiteName]'
                        WHEN 'ATN_SABySI22_SiteName DESC' THEN '[ATN_SABySI22].[SiteName] DESC'
                        WHEN 'ATN_SABySI23_SiteName' THEN '[ATN_SABySI23].[SiteName]'
                        WHEN 'ATN_SABySI23_SiteName DESC' THEN '[ATN_SABySI23].[SiteName] DESC'
                        WHEN 'ATN_SABySI24_SiteName' THEN '[ATN_SABySI24].[SiteName]'
                        WHEN 'ATN_SABySI24_SiteName DESC' THEN '[ATN_SABySI24].[SiteName] DESC'
                        WHEN 'ATN_SABySI25_SiteName' THEN '[ATN_SABySI25].[SiteName]'
                        WHEN 'ATN_SABySI25_SiteName DESC' THEN '[ATN_SABySI25].[SiteName] DESC'
                        WHEN 'ATN_SABySI26_SiteName' THEN '[ATN_SABySI26].[SiteName]'
                        WHEN 'ATN_SABySI26_SiteName DESC' THEN '[ATN_SABySI26].[SiteName] DESC'
                        WHEN 'ATN_SABySI27_SiteName' THEN '[ATN_SABySI27].[SiteName]'
                        WHEN 'ATN_SABySI27_SiteName DESC' THEN '[ATN_SABySI27].[SiteName] DESC'
                        WHEN 'ATN_SABySI28_SiteName' THEN '[ATN_SABySI28].[SiteName]'
                        WHEN 'ATN_SABySI28_SiteName DESC' THEN '[ATN_SABySI28].[SiteName] DESC'
                        WHEN 'ATN_SABySI29_SiteName' THEN '[ATN_SABySI29].[SiteName]'
                        WHEN 'ATN_SABySI29_SiteName DESC' THEN '[ATN_SABySI29].[SiteName] DESC'
                        WHEN 'ATN_SABySI30_SiteName' THEN '[ATN_SABySI30].[SiteName]'
                        WHEN 'ATN_SABySI30_SiteName DESC' THEN '[ATN_SABySI30].[SiteName] DESC'
                        WHEN 'ATN_SABySI31_SiteName' THEN '[ATN_SABySI31].[SiteName]'
                        WHEN 'ATN_SABySI31_SiteName DESC' THEN '[ATN_SABySI31].[SiteName] DESC'
                        WHEN 'ATN_SABySI2_SiteName' THEN '[ATN_SABySI2].[SiteName]'
                        WHEN 'ATN_SABySI2_SiteName DESC' THEN '[ATN_SABySI2].[SiteName] DESC'
                        ELSE '[ATN_SiteAttendance].[FinYear],[ATN_SiteAttendance].[MonthID],[ATN_SiteAttendance].[CardNo]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [ATN_SiteAttendance].* ,
    [ATN_ApplicationStatus1].[Description] AS ATN_ApplicationStatus1_Description,
    [ATN_FinYear2].[Description] AS ATN_FinYear2_Description,
    [ATN_Months3].[Description] AS ATN_Months3_Description,
    [ATN_SAStatus4].[Description] AS ATN_SAStatus4_Description,
    [HRM_Employees5].[EmployeeName] AS HRM_Employees5_EmployeeName,
    [HRM_Employees6].[EmployeeName] AS HRM_Employees6_EmployeeName,
    [HRM_Employees7].[EmployeeName] AS HRM_Employees7_EmployeeName,
    [ATN_SABySI1].[SiteName] AS ATN_SABySI1_SiteName,
    [ATN_SABySI3].[SiteName] AS ATN_SABySI3_SiteName,
    [ATN_SABySI4].[SiteName] AS ATN_SABySI4_SiteName,
    [ATN_SABySI5].[SiteName] AS ATN_SABySI5_SiteName,
    [ATN_SABySI6].[SiteName] AS ATN_SABySI6_SiteName,
    [ATN_SABySI7].[SiteName] AS ATN_SABySI7_SiteName,
    [ATN_SABySI8].[SiteName] AS ATN_SABySI8_SiteName,
    [ATN_SABySI9].[SiteName] AS ATN_SABySI9_SiteName,
    [ATN_SABySI10].[SiteName] AS ATN_SABySI10_SiteName,
    [ATN_SABySI11].[SiteName] AS ATN_SABySI11_SiteName,
    [ATN_SABySI12].[SiteName] AS ATN_SABySI12_SiteName,
    [ATN_SABySI13].[SiteName] AS ATN_SABySI13_SiteName,
    [ATN_SABySI14].[SiteName] AS ATN_SABySI14_SiteName,
    [ATN_SABySI15].[SiteName] AS ATN_SABySI15_SiteName,
    [ATN_SABySI16].[SiteName] AS ATN_SABySI16_SiteName,
    [ATN_SABySI17].[SiteName] AS ATN_SABySI17_SiteName,
    [ATN_SABySI18].[SiteName] AS ATN_SABySI18_SiteName,
    [ATN_SABySI19].[SiteName] AS ATN_SABySI19_SiteName,
    [ATN_SABySI20].[SiteName] AS ATN_SABySI20_SiteName,
    [ATN_SABySI21].[SiteName] AS ATN_SABySI21_SiteName,
    [ATN_SABySI22].[SiteName] AS ATN_SABySI22_SiteName,
    [ATN_SABySI23].[SiteName] AS ATN_SABySI23_SiteName,
    [ATN_SABySI24].[SiteName] AS ATN_SABySI24_SiteName,
    [ATN_SABySI25].[SiteName] AS ATN_SABySI25_SiteName,
    [ATN_SABySI26].[SiteName] AS ATN_SABySI26_SiteName,
    [ATN_SABySI27].[SiteName] AS ATN_SABySI27_SiteName,
    [ATN_SABySI28].[SiteName] AS ATN_SABySI28_SiteName,
    [ATN_SABySI29].[SiteName] AS ATN_SABySI29_SiteName,
    [ATN_SABySI30].[SiteName] AS ATN_SABySI30_SiteName,
    [ATN_SABySI31].[SiteName] AS ATN_SABySI31_SiteName,
    [ATN_SABySI2].[SiteName] AS ATN_SABySI2_SiteName 
  FROM [ATN_SiteAttendance] 
      INNER JOIN #PageIndex
          ON [ATN_SiteAttendance].[FinYear] = #PageIndex.FinYear
          AND [ATN_SiteAttendance].[MonthID] = #PageIndex.MonthID
          AND [ATN_SiteAttendance].[CardNo] = #PageIndex.CardNo
  LEFT OUTER JOIN [ATN_ApplicationStatus] AS [ATN_ApplicationStatus1]
    ON [ATN_SiteAttendance].[ATNStatusID] = [ATN_ApplicationStatus1].[ApplStatusID]
  INNER JOIN [ATN_FinYear] AS [ATN_FinYear2]
    ON [ATN_SiteAttendance].[FinYear] = [ATN_FinYear2].[FinYear]
  INNER JOIN [ATN_Months] AS [ATN_Months3]
    ON [ATN_SiteAttendance].[MonthID] = [ATN_Months3].[MonthID]
  LEFT OUTER JOIN [ATN_SAStatus] AS [ATN_SAStatus4]
    ON [ATN_SiteAttendance].[SAStatusID] = [ATN_SAStatus4].[StatusID]
  INNER JOIN [HRM_Employees] AS [HRM_Employees5]
    ON [ATN_SiteAttendance].[CardNo] = [HRM_Employees5].[CardNo]
  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees6]
    ON [ATN_SiteAttendance].[ApprovedBy] = [HRM_Employees6].[CardNo]
  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees7]
    ON [ATN_SiteAttendance].[PostedBy] = [HRM_Employees7].[CardNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI1]
    ON [ATN_SiteAttendance].[SN01] = [ATN_SABySI1].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI3]
    ON [ATN_SiteAttendance].[SN03] = [ATN_SABySI3].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI4]
    ON [ATN_SiteAttendance].[SN04] = [ATN_SABySI4].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI5]
    ON [ATN_SiteAttendance].[SN05] = [ATN_SABySI5].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI6]
    ON [ATN_SiteAttendance].[SN06] = [ATN_SABySI6].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI7]
    ON [ATN_SiteAttendance].[SN07] = [ATN_SABySI7].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI8]
    ON [ATN_SiteAttendance].[SN08] = [ATN_SABySI8].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI9]
    ON [ATN_SiteAttendance].[SN09] = [ATN_SABySI9].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI10]
    ON [ATN_SiteAttendance].[SN10] = [ATN_SABySI10].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI11]
    ON [ATN_SiteAttendance].[SN11] = [ATN_SABySI11].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI12]
    ON [ATN_SiteAttendance].[SN12] = [ATN_SABySI12].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI13]
    ON [ATN_SiteAttendance].[SN13] = [ATN_SABySI13].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI14]
    ON [ATN_SiteAttendance].[SN14] = [ATN_SABySI14].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI15]
    ON [ATN_SiteAttendance].[SN15] = [ATN_SABySI15].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI16]
    ON [ATN_SiteAttendance].[SN16] = [ATN_SABySI16].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI17]
    ON [ATN_SiteAttendance].[SN17] = [ATN_SABySI17].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI18]
    ON [ATN_SiteAttendance].[SN18] = [ATN_SABySI18].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI19]
    ON [ATN_SiteAttendance].[SN19] = [ATN_SABySI19].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI20]
    ON [ATN_SiteAttendance].[SN20] = [ATN_SABySI20].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI21]
    ON [ATN_SiteAttendance].[SN21] = [ATN_SABySI21].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI22]
    ON [ATN_SiteAttendance].[SN22] = [ATN_SABySI22].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI23]
    ON [ATN_SiteAttendance].[SN23] = [ATN_SABySI23].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI24]
    ON [ATN_SiteAttendance].[SN24] = [ATN_SABySI24].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI25]
    ON [ATN_SiteAttendance].[SN25] = [ATN_SABySI25].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI26]
    ON [ATN_SiteAttendance].[SN26] = [ATN_SABySI26].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI27]
    ON [ATN_SiteAttendance].[SN27] = [ATN_SABySI27].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI28]
    ON [ATN_SiteAttendance].[SN28] = [ATN_SABySI28].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI29]
    ON [ATN_SiteAttendance].[SN29] = [ATN_SABySI29].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI30]
    ON [ATN_SiteAttendance].[SN30] = [ATN_SABySI30].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI31]
    ON [ATN_SiteAttendance].[SN31] = [ATN_SABySI31].[SerialNo]
  LEFT OUTER JOIN [ATN_SABySI] AS [ATN_SABySI2]
    ON [ATN_SiteAttendance].[SN02] = [ATN_SABySI2].[SerialNo]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
