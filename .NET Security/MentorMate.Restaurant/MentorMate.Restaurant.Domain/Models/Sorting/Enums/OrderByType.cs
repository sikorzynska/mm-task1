using System.Runtime.Serialization;

namespace MentorMate.Restaurant.Domain.Models.Sorting.Enums
{
    public enum OrderByType
    {
        [EnumMember(Value = "Name")]
        Name,
        [EnumMember(Value = "Category")]
        Category
    }
}
