using Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiApplication.Models.Prescriptions
{
    /// <summary>
    /// Назначение (рецепт)
    /// </summary>
    [DataContract]
    public class PrescriptionModel
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public PrescriptionTypes Type { get; set; }

        [DataMember]
        public int DurationInDays { get; set; }
        
        [DataMember]
        public List<TimeSpan> ActionTimes { get; set; }
    }
}