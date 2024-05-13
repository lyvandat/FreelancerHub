USE msdb ;  
GO  
EXEC dbo.sp_add_job  
    @job_name = N'Weekly Sales Data Backup' ;  
GO  
EXEC sp_add_jobstep  
    @job_name = N'Weekly Sales Data Backup',  
    @step_name = N'Set database to read only',  
    @subsystem = N'TSQL',  
    @command = N'ALTER DATABASE SALES SET READ_ONLY',   
    @retry_attempts = 5,  
    @retry_interval = 5 ;  
GO  
EXEC dbo.sp_add_schedule  
    @schedule_name = N'RunOnce',  
    @freq_type = 1,  
    @active_start_time = 233000 ;  
USE msdb ;  
GO  
EXEC sp_attach_schedule  
   @job_name = N'Weekly Sales Data Backup',  
   @schedule_name = N'RunOnce';  
GO  
EXEC dbo.sp_add_jobserver  
    @job_name = N'Weekly Sales Data Backup';  
GO  