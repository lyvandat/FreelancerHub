use msdb;
go

--- DELTE BIDDING ORDERS JOB - EVERY 4 HOURS
-- Create the job
EXEC msdb.dbo.sp_add_job 
    @job_name = N'BiddingOrderCleanupJob', @enabled = 1;
GO

-- Add a job step
EXEC msdb.dbo.sp_add_jobstep
    @job_name = N'BiddingOrderCleanupJob',
    @step_name = N'Run Cleanup',
    @subsystem = N'TSQL',
    @command = N'DELETE FROM BiddingOrders WHERE EXISTS (
        SELECT 1
        FROM [Orders]
        WHERE BiddingOrders.OrderId = [Orders].Id
          AND [Orders].StartTime < DATEADD(DAY, -2, GETDATE())
    );',
    @retry_attempts = 5,  
    @retry_interval = 5;
GO

-- Schedule the job to run every 8 hours
EXEC msdb.dbo.sp_add_schedule
    @schedule_name = N'Every4HoursSchedule',
    @freq_type = 4, -- Daily
    @freq_interval = 1, -- Occurs every 1 day
    @freq_subday_type = 8, -- Hours
    @freq_subday_interval = 4, -- Every 4 hours
    @active_start_time = 020000; -- Start time: 08:00:00 (adjust as needed)
GO

-- Attach the schedule to your job
EXEC msdb.dbo.sp_attach_schedule 
    @job_name = N'BiddingOrderCleanupJob', 
    @schedule_name = N'Every4HoursSchedule';
GO

--- BACKUP DB JOB - EVERY DAY
DECLARE @backupFileName NVARCHAR(1000);
DECLARE @db_name NVARCHAR(20);
DECLARE @fileDate NVARCHAR(20);
DECLARE @commandtxt NVARCHAR(1000);

SET @db_name = 'DeToiVN';
SET @fileDate = REPLACE(CONVERT(NVARCHAR(10), GETDATE(), 112), '-', '');

SET @backupFileName = 'E:\Backups\' + @db_name + '-' + @fileDate + '.bak';

SET @commandtxt = 'BACKUP DATABASE ' + @db_name + ' TO DISK = N''' + @backupFileName + ''' WITH CHECKSUM';

EXEC dbo.sp_add_jobserver  
    @job_name = N'BiddingOrderCleanupJob';  
GO

-- Create a new SQL Server Agent job
EXEC msdb.dbo.sp_add_job @job_name = N'BackupDatabase', @enabled = 1;

-- Add a job step to perform the backup
EXEC msdb.dbo.sp_add_jobstep
    @job_name = N'BackupDatabase',
    @step_name = N'Run Backup',
    @subsystem = N'TSQL',
    @command = @commandtxt,
    @retry_attempts = 5,
    @retry_interval = 5;

-- Schedule the job to run daily
EXEC msdb.dbo.sp_add_schedule
    @schedule_name = N'DailyBackupSchedule',
    @freq_type = 4, -- Daily
    @freq_interval = 1, -- Occurs every 1 day
    @active_start_time = 020000; -- Start time (e.g., 02:00:00)

-- Attach the schedule to the job
EXEC msdb.dbo.sp_attach_schedule @job_name = N'BackupDatabase', @schedule_name = N'DailyBackupSchedule';
EXEC msdb.dbo.sp_add_jobserver @job_name = N'BackupDatabase'