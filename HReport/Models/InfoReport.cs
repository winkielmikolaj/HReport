using System.ComponentModel.DataAnnotations;

namespace HReport.Models
{
    public class InfoReport
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        public string? Complaint { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public DateTime? Date { get; set; }
        
        public bool IsChecked { get; set; }
    }
}
