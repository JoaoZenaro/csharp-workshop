public class Program
{
    delegate bool FindUser(User user);

    record User
    {
        public string Surname;
        public string LoginName;
        public string Location;

        public User(string surname, string loginName, string location)
        {
            this.Surname = surname;
            this.LoginName = loginName;
            this.Location = location;
        }
    }

    static User? Find(FindUser predicate, User[] users)
    {
        foreach (var user in users)
            if (predicate(user))
                return user;
        return null;
    }

    public static void Main()
    {
        User[] users = {
            new User("Luna", "Leigh", "Italy"),
            new User("Rowe", "Ima", "Germany"),
            new User("Bruce", "Declan", "Russia"),
            new User("Osborn", "Ria", "Brazil"),
            new User("Finley", "Caldwell", "India")
        };


        var user1 = Find(user => user.Surname == "Luna", users);
        var user2 = Find(user => user.LoginName == "Ria", users);
        var user3 = Find(user => user.Location == "India", users);

        Console.WriteLine($"{user1}\n{user2}\n{user3}");
    }
}