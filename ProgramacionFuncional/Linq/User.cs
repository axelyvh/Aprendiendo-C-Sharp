using System.Collections.Generic;

namespace Linq
{
    public class User
    {

        public User(int Id, string Username, int Age, string Gender)
        {
            this.Id = Id;
            this.Username = Username;
            this.Age = Age;
            this.Gender = Gender;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public static List<User> Users() {

            return new List<User>
            {
                new User(1, "britney",5,"female"),
                new User(2, "sylvio",42,"male"),
                new User(3, "lucht",30,"male"),
                new User(4, "thomsen",48,"male"),
                new User(5, "diego",30,"male"),
                new User(6, "jorgensen",55,"female"),
                new User(7, "travis",27,"male"),
                new User(8, "gerald",30,"male"),
                new User(9, "eduardo",22,"male"),
                new User(10, "renata",13,"female"),
                new User(11, "sther",5,"female")
            };

        }

    }
}
