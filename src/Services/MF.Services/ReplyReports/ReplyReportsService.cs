namespace MF.Services.ReportReplies
{
    using System;
    using System.Collections.Generic;

    using MF.Data;

    public class ReplyReportsService : IReplyReportsService
    {
        private readonly MFDbContext data;

        public ReplyReportsService(MFDbContext data)
        {
            this.data = data;
        }

        public void Create()
        {
            throw new NotImplementedException();
        }
    }
}
