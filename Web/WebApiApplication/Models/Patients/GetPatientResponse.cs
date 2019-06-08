using System.Runtime.Serialization;

namespace WebApiApplication.Models.Patients
{
    /// <summary>
    /// Модель данных ответа на запрос получения пациента
    /// </summary>
    [DataContract]
    public class GetPatientResponse
    {
        /// <summary>
        /// Данные пациента
        /// </summary>
        [DataMember]
        public PatientModel Patient { get; set; }
    }
}