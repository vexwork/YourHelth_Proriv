using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Database.Dto
{
    public class ActionTime
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; protected set; }

        public Guid PrescriptionGuid { get; set; }

        /// <summary>
        /// Время действия в течение суток
        /// </summary>
        [Required]
        public TimeSpan Time { get; set; }
    }
}
