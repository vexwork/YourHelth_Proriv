using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Database.Dto
{
    public class Conquest
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; protected set; }

        [Required]
        public Patient Patient { get; set; }

        //[Required]
        public Doctor Doctor { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime BeginTime { get; set; }

        public List<Prescription> Prescriptions { get; set; }

        public List<Quest> Quests { get; set; }
        
        
        public int? CompleteRate { get; set; }
    }
}
