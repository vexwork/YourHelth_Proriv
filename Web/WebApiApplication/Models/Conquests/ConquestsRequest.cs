using System;
using System.Runtime.Serialization;

namespace WebApiApplication.Models.Conquests
{
    [DataContract]
    public class ConquestsRequest
    {
        [DataMember(Name = "patient_id")]
        public Guid PatientId { get; set; }
    }
}