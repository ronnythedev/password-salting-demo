namespace PasswordSaltingDemo;
record User(string Username, string PasswordHash);

class Program
{
    // Simulate a database with a list
    static readonly List<User> Users = new();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nPassword Salting Demo");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Register();
                    break;
                case "2":
                    Login();
                    break;
                case "3":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
    
    static void Register()
    {
        Console.Write("Enter username: ");
        var username = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(username))
        {
            Console.WriteLine("Username cannot be empty!");
            return;
        }

        if (Users.Exists(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("Username already exists!");
            return;
        }

        Console.Write("Enter password: ");
        var password = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
        {
            Console.WriteLine("Password must be at least 8 characters!");
            return;
        }

        try
        {
            // Hash password with BCrypt
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password, 12);
            Users.Add(new User(username, passwordHash));
            Console.WriteLine("Registration successful!");
            Console.WriteLine("The hashed password is: " + passwordHash);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during registration: {ex.Message}");
        }
    }

    static void Login()
    {
        Console.Write("Enter username: ");
        var username = Console.ReadLine();

        Console.Write("Enter password: ");
        var password = Console.ReadLine();

        var user = Users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

        if (user == null)
        {
            Console.WriteLine("User not found!");
            return;
        }

        try
        {
            // Verify password
            var isValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            Console.WriteLine(isValid ? "Login successful!" : "Incorrect password!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during login: {ex.Message}");
        }
    }
}