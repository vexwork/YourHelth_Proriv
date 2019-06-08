using System.Runtime.Serialization;

namespace WebApiApplication.Models
{
    [DataContract]
    public class HelloWorldResponse
    {
        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "status")]
        public Status Status { get; set; }
    }

    public enum Status
    {
        [EnumMember(Value = "ok")]
        Ok = 1,
        
        [EnumMember(Value = "error")]
        Error = 3,
    }
}