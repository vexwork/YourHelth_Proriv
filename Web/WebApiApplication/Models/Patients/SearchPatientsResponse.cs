using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WebApiApplication.Models.Patients
{  
    [DataContract]
    public class SearchPatientsResponse
    {
        [DataMember(Name = "patientsItems")]
        public IList<SearchPatientsItem> PatientsItems { get; set; }
    }
}