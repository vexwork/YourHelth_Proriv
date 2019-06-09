using Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiApplication.Models.Conquests
{
    [DataContract]
    public class QuestsRequest
    {
        [DataMember(Name = "patient_id")]
        public Guid PatientId { get; set; }

        /// <summary>
        /// null - все состояния
        /// </summary>
        [DataMember(Name = "state")]
        public QuestState? State { get; set; }
    }
}