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
        public DateTime BeginTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public List<Prescription> Prescriptions { get; set; }
    }
}
