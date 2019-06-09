using System.Runtime.Serialization;

namespace Common.Data
{
    public enum PrescriptionTypes
    {
        /// <summary>
        /// Таблетки
        /// </summary>
        [EnumMember(Value = "drugs")]
        Drugs,
        /// <summary>
        /// Процедура
        /// </summary>
        [EnumMember(Value = "procedure")]
        Procedure,
        /// <summary>
        /// Анализ
        /// </summary>
        [EnumMember(Value = "analysis")]
        Analysis,
        /// <summary>
        /// Проверка чего-либо (например, курил сегодня?)
        /// </summary>
        [EnumMember(Value = "question")]
        Question,
    }
}
