using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChannelAnalysis.API.Models
{
    [Table("AnalysisQueue")]
    public class AnalysisQueue
    {
        public int Id { get; set; }
        [Column("channel_link")]
        public string ChannelLink { get; set; }
        [Column("priority")]
        public int Priority { get; set; }
    }
}
