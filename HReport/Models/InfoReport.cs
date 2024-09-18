using System.ComponentModel.DataAnnotations;

namespace HReport.Models
{
    public class InfoReport
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        public string? Complaint { get; set; } = string.Empty;
        [Required]
        public string? Description { get; set; } = string.Empty;
        [Required]
        public DateTime? Date { get; set; } = DateTime.UtcNow;

        public bool IsChecked { get; set; }
    }
}
