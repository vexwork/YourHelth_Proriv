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

        public List<Quest> Quests { get; set; }
    }
}
