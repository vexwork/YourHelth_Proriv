using Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiApplication.Models.Conquests
{
    [DataContract]
    public class QuestModel
    {
        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        [DataMember(Name = "state")]
        public QuestState State { get; set; }

        [DataMember(Name = "time")]
        public DateTime Time { get; set; }

        [DataMember(Name = "prescription_title")]
        public string PrescriptionTitle { get; set; }
    }
}