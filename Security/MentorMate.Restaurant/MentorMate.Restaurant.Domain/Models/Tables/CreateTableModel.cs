using MentorMate.Restaurant.Domain.Consts;
using System.ComponentModel.DataAnnotations;

namespace MentorMate.Restaurant.Domain.Models.Tables
{
    public class CreateTableModel
    {
        [Range(3, 12, ErrorMessage = Messages.TableCapacity)]
        public int Capacity { get; set; }
    }
}
