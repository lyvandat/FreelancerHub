using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo.Agent;
using Microsoft.SqlServer.Management.Smo;

namespace DeToiServer.Services.CleanupService
{
    public class JobScheduler : IJobScheduler
    {
        private readonly string _serverName;
        private readonly Server _server;

        public JobScheduler(string serverName)
        {
            _serverName = serverName;
            var serverConnection = new ServerConnection(_serverName);
            _server = new Server(serverConnection);
        }

        public void ScheduleJob(string jobName, string databaseName, string procedureName, TimeSpan interval)
        {
            var job = CreateJob(jobName);
            var jobStep = CreateJobStep(job, databaseName, procedureName);
            var jobSchedule = CreateJobSchedule(job, interval);

            // Enable the job
            job.IsEnabled = true;
            job.Alter();
        }

        private Job CreateJob(string jobName)
        {
            var job = new Job(_server.JobServer, jobName);
            job.Create();
            return job;
        }

        private JobStep CreateJobStep(Job job, string databaseName, string procedureName)
        {
            var jobStep = new JobStep(job, $"{procedureName}Step");
            jobStep.DatabaseName = databaseName;
            jobStep.SubSystem = AgentSubSystem.TransactSql;
            jobStep.Command = $"EXEC {procedureName}";
            jobStep.Create();
            return jobStep;
        }

        private JobSchedule CreateJobSchedule(Job job, TimeSpan interval)
        {
            var jobSchedule = new JobSchedule(job, $"{job.Name}Schedule");
            jobSchedule.FrequencyTypes = FrequencyTypes.Daily;
            jobSchedule.FrequencyInterval = 1; // Run every 1 day
            jobSchedule.FrequencySubDayTypes = FrequencySubDayTypes.Hour;
            jobSchedule.FrequencySubDayInterval = (int)interval.TotalHours; // Convert TimeSpan to hours
            jobSchedule.Create();
            return jobSchedule;
        }

        private void TestUse()
        {
            string serverName = "YourServerName";
            string databaseName = "YourDatabaseName";
            string procedureName = "dbo.DeleteOldBiddingRecords";

            // Create job scheduler
            IJobScheduler jobScheduler = new JobScheduler(serverName);

            // Schedule job to run every 8 hours
            jobScheduler.ScheduleJob("DeleteOldBiddingRecordsJob", databaseName, procedureName, TimeSpan.FromHours(8));

            Console.WriteLine("SQL Server Agent job scheduled successfully.");
        }
    }
}
