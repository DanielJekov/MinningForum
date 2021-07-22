namespace MF.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class BanData
    {
        public int Id { get; set; }

        public DateTime BanFromDate { get; set; }
        = DateTime.UtcNow;

        public DateTime BanToDate { get; set; }

        public virtual ICollection<ReportProcessData> ReportsProcessData { get; set; }
        = new HashSet<ReportProcessData>();
    }
}
