using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Database.Dto
{
    public class Patient
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; protected set; }

        [Required]
        public string FirstName { get; set; } 

        [Required]
        public string LastName { get; set; } 

        /// <summary>
        /// —Õ»À—
        /// </summary>
        [Required]
        public string PersonalId { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Patronymic { get; set; } = string.Empty;

        public List<Conquest> Conquests { get; set; }
    }
}