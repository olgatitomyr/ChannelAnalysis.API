using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChannelAnalysis.API.Models
{
    [Table("ChannelStatistics")]
    public class ChannelStatistics
    {
        public int Id { get; set; }
        [Column("id_channel")]
        public long ChannelId { get; set; }
        public Channel Channel { get; set; }
        [Column("views_total_count")]
        public long ViewsTotalCount { get; set; }
        [Column("forwards_total_count")]
        public long ForwardsTotalCount { get; set; }
        [Column("reactions_total_count", TypeName = "jsonb")]
        public string Reactions { get; set; }
        [Column("last_publication_date")]
        public DateTime LastPublicationDate { get; set; }
    }
}
