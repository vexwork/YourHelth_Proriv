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
        [DataMember]
        public Guid PatientId { get; set; }

        [DataMember]
        public Guid DoctorId { get; set; }

        /// <summary>
        /// Заголовок конквеста
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DateTime BeginTime { get; set; }

        [DataMember]
        public List<PrescriptionModel> Prescriptions { get; set; }
    }
}