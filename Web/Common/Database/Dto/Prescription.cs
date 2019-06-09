using Common.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Database.Dto
{
    public class Prescription
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; protected set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public PrescriptionTypes Type { get; set; }

        /// <summary>
        /// Время лечения
        /// </summary>
        [Required]
        public int DurationInDays { get; set; }

        public List<ActionTime> ActionTimes { get; set; }
    }
}
