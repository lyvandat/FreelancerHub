namespace DeToiServer.Services.CleanupService
{
    public interface IJobScheduler
    {
        void ScheduleJob(string jobName, string databaseName, string procedureName, TimeSpan interval);
    }
}
