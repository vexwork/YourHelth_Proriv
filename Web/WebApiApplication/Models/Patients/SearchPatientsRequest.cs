using System.Runtime.Serialization;

namespace WebApiApplication.Models.Patients
{
    /// <summary>
    /// Модель запроса на поиск пациентов
    /// </summary>
    [DataContract]
    public class SearchPatientsRequest
    {
        /// <summary>
        /// Поиск по имени 
        /// </summary>
        [DataMember(Name = "firstName")] 
        public string FirstName { get; set; }

        /// <summary>
        /// Поиск по фамилии
        /// </summary>
        [DataMember(Name = "lastName")] 
        public string LastName { get; set; }

        /// <summary>
        /// Поиск по СНИЛС
        /// </summary>
        [DataMember(Name = "personalId")] 
        public string PersonalId { get; set; }
    }
}