using System.Runtime.Serialization;

namespace WebApiApplication.Models.Accounts
{
    /// <summary>
    /// Перичисление статусов резултата регистрации нового пациента в системе
    /// </summary>
    public enum RegisterPatientStatus
    {
        /// <summary>
        /// Регистрация успешна
        /// </summary>
        [EnumMember(Value = "ok")]
        Ok = 1,
        
        /// <summary>
        /// Пользователь с таким СНИЛС уже зарегистрирован
        /// </summary>
        [EnumMember(Value = "personalIdAlreadyExists")]
        PersonalIdAlreadyExists = 2,
    }
}