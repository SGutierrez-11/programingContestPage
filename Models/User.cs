using System.ComponentModel.DataAnnotations;

namespace programingContestPage.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Birthday { get; set; }

    }
}
