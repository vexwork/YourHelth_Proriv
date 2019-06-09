using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WebApiApplication.Models.Accounts
{
    [DataContract]
    public class RegisterPatientResponse
    {
        /// <summary>
        /// Идентификатор вновь созданного пациента
        /// Если регистрация не удалась может быть null
        /// </summary>
        [DataMember(Name = "guid")]
        public Guid? Guid { get; set; }

        /// <summary>
        /// Статус результата операции
        /// </summary>
        [Required]
        [DataMember]
        public RegisterPatientStatus Status { get; set; }

        /// <summary>
        /// Сообщение, для дополнительной информации об ошибке
        /// </summary>
        [DataMember(Name = "message")]
        public string Message { get; set; }
        
        public static RegisterPatientResponse PersonalIdAlreadyExists => new RegisterPatientResponse
        {
            Guid = null,
            Message = "Пользователь с таким СНИЛС уже зарегистрирован в системе",
            Status = RegisterPatientStatus.PersonalIdAlreadyExists,
        };
    }
}