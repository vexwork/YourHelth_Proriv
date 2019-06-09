using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiApplication.Models.Prescriptions
{
    [DataContract]
    public class AddConquestRequest
    {
        [DataMember(Name = "patient_id")]
        public Guid PatientId { get; set; }

        [DataMember(Name = "doctor_id")]
        public Guid DoctorId { get; set; }

        /// <summary>
        /// Заголовок конквеста
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "begin_time")]
        public DateTime BeginTime { get; set; }

        [DataMember(Name = "prescriptions")]
        public List<PrescriptionModel> Prescriptions { get; set; }
    }
}