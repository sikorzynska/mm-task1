using System.Runtime.Serialization;

namespace MentorMate.Restaurant.Domain.Models.Sorting.Enums
{
    public enum OrderType
    {
        [EnumMember(Value = "Ascending")]
        Ascending,
        [EnumMember(Value = "Descending")]
        Descending
    }
}
