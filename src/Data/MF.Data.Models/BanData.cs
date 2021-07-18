namespace MF.Data.Models
{
    using System;

    public class BanData
    {
        public int Id { get; set; }

        public DateTime BanFromDate { get; set; }
        = DateTime.UtcNow;

        public DateTime BanToDate { get; set; }
    }
}
