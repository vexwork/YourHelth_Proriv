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

        [IgnoreDataMember]
        public List<TimeSpan> ActionTimes => new []{ Time1, Time2, Time3 }.Where(x => x.HasValue).Select(x => x.Value).ToList();
        
        #region 
        [DataMember(Name = "time1")]
        public TimeSpan? Time1 { get; set; }

        [DataMember(Name = "time2")]
        public TimeSpan? Time2 { get; set; }

        [DataMember(Name = "time3")]
        public TimeSpan? Time3 { get; set; }
        #endregion 
    }
}