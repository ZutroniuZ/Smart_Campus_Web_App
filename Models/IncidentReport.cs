using System;
using System.ComponentModel.DataAnnotations;
namespace Smart_Campus_Web_App.Models
{
    public class IncidentReports
    {
        [Key]
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public DateTime ReportedAt { get; set; }
    }
}
