using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Database.Dto
{
    public class Patient
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        /// <summary>
        /// —Õ»À—
        /// </summary>
        [Required]
        public string PersonalId { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Patronymic { get; set; }
    }
}