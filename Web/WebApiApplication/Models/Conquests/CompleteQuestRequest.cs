using System;
using System.Runtime.Serialization;
using Common.Data;

namespace WebApiApplication.Models.Conquests
{
    /// <summary>
    /// Запрос на завершение квеста
    /// </summary>
    [DataContract]
    public class CompleteQuestRequest
    {
        /// <summary>
        /// Идентификатор квеста
        /// </summary>
        [DataMember(Name = "guid")]
        public Guid Guid { get; set; }

        /// <summary>
        /// Состояние квеста, выполнил / не выполнил
        /// </summary>
        [DataMember(Name = "state")]
        public QuestState State { get; set; }
    }
}