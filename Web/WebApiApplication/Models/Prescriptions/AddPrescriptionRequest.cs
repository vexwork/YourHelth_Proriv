using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiApplication.Models.Prescriptions
{
    [DataContract]
    public class AddPrescriptionRequest
    {
        [DataMember]
        public Guid PatientId { get; set; }

        [DataMember]
        public PrescriptionModel Prescription { get; set; }
    }
}