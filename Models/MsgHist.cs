using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
namespace Smart_Campus_Web_App.Models
{
    public class MsgHist
    {
        [Key]
        public int? id { get; set; }

        public string Username {  get; set; }

        
        [Required]
        public string Msg {  get; set; }
        
        
    }

    
}