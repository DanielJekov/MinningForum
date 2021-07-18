using System;

namespace MF.Data.Models
{
    public class ReportProcessData
    {
        public int Id { get; set; }

        public string ProccesorId { get; set; }

        public MFUser Proccesor { get; set; }

        public DateTime ProcessedDate { get; set; }
    }
}
