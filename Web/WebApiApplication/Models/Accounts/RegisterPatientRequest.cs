using System;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;


namespace WebApiApplication.Models.Accounts
{
    
    /// <summary>
    /// Запрос данных на регистрацию пациента
    /// </summary>
    [DataContract]
    public class RegisterPatientRequest
    {
        /// <summary>
        /// СНИЛС
        /// </summary>
        [Required]
        [DataMember(Name = "personalId")]
        public string PersonalId { get; set; }

        
        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Required]
        [DataMember(Name = "lastName")]
        public string LastName { get; set; }
        
        /// <summary>
        /// Отчество
        /// </summary>
        [Required]        
        [DataMember(Name = "middleName")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        [Required]
        [DataMember(Name = "birthDate")]
        public DateTime  BirthDate { get; set; }
    }
}