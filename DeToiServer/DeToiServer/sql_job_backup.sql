DECLARE @backupFileName NVARCHAR(1000);
DECLARE @db_name NVARCHAR(20);
DECLARE @fileDate NVARCHAR(20);
DECLARE @commandtxt NVARCHAR(1000);

SET @db_name = 'DeToiVN';
SET @fileDate = REPLACE(CONVERT(NVARCHAR(10), GETDATE(), 112), '-', '');

SET @backupFileName = 'E:\Backups\' + @db_name + '-' + @fileDate + '.bak';

SET @commandtxt = 'BACKUP DATABASE ' + @db_name + ' TO DISK = N''' + @backupFileName + ''' WITH CHECKSUM';

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