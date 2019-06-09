using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WebApiApplication.Models.Conquests
{
    /// <summary>
    /// Запрос на подверждение завершения конквеста
    /// </summary>
    [DataContract]
    public class CompleteConquestRequest
    {
        /// <summary>
        /// Идентификатон конквеста
        /// </summary>
        [DataMember(Name = "guid")]
        public Guid Guid { get; set; }

        /// <summary>
        /// Процент выполненности предписаний по шкале от 1 до 10
        /// </summary>
        [Range(1, 10, ErrorMessage = "Прогресс выполнения конвекста должен быть в диапазоне от 1 до 10")]
        [DataMember(Name = "completeRequest")]
        public int? CompleteRate { get; set; }
    }
}