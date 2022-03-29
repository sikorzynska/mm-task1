using System.Runtime.Serialization;

namespace MentorMate.Restaurant.Data.Entities.Enums
{
    public enum TableStatus
    {
        [EnumMember(Value = "Active")]
        Active,
        [EnumMember(Value = "Free")]
        Free
    }
}
