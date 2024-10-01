namespace AlumniSpace.Models
{
    public class Alumnus
    {
        public int Id { get; set; } = 0;

        public int StudentNum { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int isActive { get; set; } = 1;

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
