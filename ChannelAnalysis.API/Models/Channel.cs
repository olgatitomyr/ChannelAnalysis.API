using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChannelAnalysis.API.Models
{
    [Table("Channel")]
    public class Channel
    {
        [Column("id_channel")]
        public long Id { get; set; }
        public ChannelStatistics Statistics { get; set; }
        public ProrussianCoefficient ProrussianCoefficient { get; set; }
        [Column("channel_name")]
        [MaxLength(250)]
        public string ChannelName { get; set; }
    }
}
