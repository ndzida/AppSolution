USE [LoggingDB]
GO

DECLARE @old datetime = DATEADD(HOUR, 1, GETDATE()-730)

INSERT INTO [dbo].[Log_History]
		([LogId]
		,[ApplicationTitle]
		,[MessageText]
		,[MessageType]
		,[UserCreated]
		,[LogTimeStamp])
	SELECT
		 [LogId]
		,[ApplicationTitle]
		,[MessageText]
		,[MessageType]
		,[UserCreated]
		,[LogTimeStamp]
	FROM [LoggingDB].[dbo].[Log]
	WHERE [dbo].[Log].[LogTimeStamp] < @old

DELETE FROM dbo.Log
WHERE [dbo].[Log].[LogTimeStamp] < @old