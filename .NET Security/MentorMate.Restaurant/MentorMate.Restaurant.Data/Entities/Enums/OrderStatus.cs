using System.Runtime.Serialization;

namespace MentorMate.Restaurant.Data.Entities.Enums
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Active")]
        Active,
        [EnumMember(Value = "Complete")]
        Complete
    }
}
