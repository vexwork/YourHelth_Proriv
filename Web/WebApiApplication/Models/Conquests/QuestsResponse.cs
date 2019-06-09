using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiApplication.Models.Conquests
{
    [DataContract]
    public class QuestsResponse
    {
        [DataMember(Name = "quests")]
        public List<QuestModel> Quests { get; set; }
    }
}