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
        /// СНИЛС
        /// </summary>
        [Required]
        public string PersonalId { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Patronymic { get; set; } = string.Empty;

        public List<Conquest> Conquests { get; set; } = new List<Conquest>();

        /// <summary>
        /// Общий рейтинг в системе
        /// </summary>
        [Required]
        public double Rate { get; set; }
        
        [Required]
        public DateTime BirthDate { get; set; } 
        

    }
}