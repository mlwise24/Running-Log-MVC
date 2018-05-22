using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RunnersLog.Models
{
    public class Run
    {
                 [Key]
                 public int Id { get; set; }
    
                 [Display(Name = "Distance run")] 
                 [Required(ErrorMessage = "A distance is required")] 
                 public int Distance { get; set; } 

                 [Display(Name = "Time in minutes")] 
                 public int Time { get; set; } 
         
 
                 [Display(Name = "Heart Rate")] 
                 public int HeartRate { get; set; } 

                 public int Calories { get; set; } 

                
                 [DataType(DataType.Date)]
                 [Required]
                 public DateTime Date { get; set; }


    }
}