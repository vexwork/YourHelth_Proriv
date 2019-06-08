using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WebApiApplication.Models.Patients
{  
    /// <summary>
    /// Модель данных на запрос поиска пациентов 
    /// </summary>
    [DataContract]
    public class SearchPatientsResponse
    {
        /// <summary>
        /// Список пациентов попавших в выборку
        /// </summary>
        [DataMember(Name = "patientsItems")]
        public IList<PatientModel> PatientsItems { get; set; }
    }
}