using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiApplication.Models.Conquests
{
    [DataContract]
    public class ConquestsResponse
    {
        [DataMember(Name = "conquests")]
        public List<ConquestModel> Conquests { get; set; }
    }

    [DataContract]
    public class ConquestModel
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        [DataMember(Name = "quests")]
        public List<QuestModel> Quests { get; set; }
    }
}