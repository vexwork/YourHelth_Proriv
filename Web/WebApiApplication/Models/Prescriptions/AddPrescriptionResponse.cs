using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiApplication.Models.Prescriptions
{
    [DataContract]
    public class AddPrescriptionResponse
    {
        [DataMember]
        public PrescriptionModel Prescription { get; set; }
    }
}