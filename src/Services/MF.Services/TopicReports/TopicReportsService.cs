namespace MF.Services.ReportTopics
{
    using MF.Data;

    public class TopicReportsService : ITopicReportsService
    {
        private readonly MFDbContext data;

        public TopicReportsService(MFDbContext data)
        {
            this.data = data;
        }

        public void Create()
        {
            throw new System.NotImplementedException();
        }
    }
}
