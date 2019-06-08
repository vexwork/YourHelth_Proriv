using System;
using System.Runtime.Serialization;

namespace WebApiApplication.Models.Patients
{
    [DataContract]
    public class SearchPatientsItem
    {
        [DataMember(Name = "guid")]
        public Guid Guid { get; set; }

        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        [DataMember(Name = "personalId")]
        public string PersonalId { get; set; }
    }
}