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
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "type")]
        public PrescriptionTypes Type { get; set; }

        [DataMember(Name = "duration_in_days")]
        public int DurationInDays { get; set; }

        [DataMember(Name = "action_times")]
        public List<TimeSpan> ActionTimes { get; set; }
    }
}