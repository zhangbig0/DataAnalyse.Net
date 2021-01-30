using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DataAnalyze.Net.Entity
{
    [Keyless]
    public class TelecomRecord
    {
        public int CallerFlag { get; set; }
        public int TimeSpan { get; set; }
        public int TimeStamp { get; set; }
        public string Phone1 { get; set; }
        public string CallerSite1 { get; set; }
        public string Offset1 { get; set; }
        public string Phone2 { get; set; }
        public string CallerSite2 { get; set; }
        public string Offset2 { get; set; }
    }
}