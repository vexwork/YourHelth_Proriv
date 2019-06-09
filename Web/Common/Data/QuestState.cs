using System.Runtime.Serialization;

namespace Common.Data
{
    public enum QuestState
    {
        [EnumMember(Value = "waiting")]
        Waiting,
        [EnumMember(Value = "passed")]
        Passed,
        [EnumMember(Value = "failed")]
        Failed
    }
}
