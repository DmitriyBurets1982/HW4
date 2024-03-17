using System.ComponentModel.DataAnnotations;

namespace HW4.DataAccess.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
