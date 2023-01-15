using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChannelAnalysis.API.Models
{
    [Table("ProrussianCoefficient")]
    public class ProrussianCoefficient
    {
        public int Id { get; set; }
        [Column("calculated_coefficient")]
        public float CalculatedCoefficient { get; set; }
        [Column("id_channel")]
        public long ChannelId { get; set; }
        public Channel Channel { get; set; }
        [Column("last_publication_date")]
        public DateTime LastPublicationDate { get; set; }

    }
}

