using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChannelAnalysis.API.Models
{
    [Table("FeedbackStorage")]
    public class FeedbackStorage
    {
        public int Id { get; set; }
        [Column("id_review")]
        [MaxLength(32)]
        public string ReviewId { get; set; }
        [Column("content")]
        [MaxLength(500)]
        public string Content { get; set; }
    }
}
