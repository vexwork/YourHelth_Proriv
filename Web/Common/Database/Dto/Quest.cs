using Common.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Database.Dto
{
    public class Quest
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; protected set; }

        [Required]
        public Conquest Conquest { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public QuestState State { get; set; }

        [Required]
        public Prescription Prescription { get; set; }
    }
}
