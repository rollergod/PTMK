using Microsoft.EntityFrameworkCore;
using PTMK.Entities.Enum;

namespace PTMK.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateOnly Date { get; set; }
        public Gender Gender { get; set; }
    }
}
