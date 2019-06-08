using System.Runtime.Serialization;

namespace WebApiApplication.Models.Patients
{
    [DataContract]
    public class SearchPatientsRequest
    {
        [DataMember(Name = "firstName")] 
        public string FirstName { get; set; }

        [DataMember(Name = "lastName")] 
        public string LastName { get; set; }

        [DataMember(Name = "personalId")] 
        public string PersonalId { get; set; }
    }
}