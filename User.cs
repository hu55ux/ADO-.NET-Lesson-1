using Microsoft.Data.SqlClient;
namespace ADO_.NET_Lesson_1;

public class User : IUserService
{
    private readonly UserContext _context;
    public User(UserContext context)
    {
        _context = context;
    }
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public short Age { get; set; }
    public bool Gender { get; set; }

    public void SignUp(string username, string password, string firstName, string lastName, short age, bool gender)
    {
        if (_context.Users.Any(u => u.Username == username))
        {
            Console.WriteLine("Username already exists. Please choose another one!");
            return;
        }
        var newUser = new User(_context)
        {
            Username = username,
            Password = password,
            FirstName = firstName,
            LastName = lastName,
            Age = age,
            Gender = gender
        };
        _context.Users.Add(newUser);
        _context.SaveChanges();
        Console.WriteLine($"Dear {firstName}, you have successfully registered !!");
    }

    public void SignIn(string username, string password)
    {
       var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        if (user != null)
        {
            Console.WriteLine($"Welcome back, {user.FirstName}!");
        }
        else
        {
            Console.WriteLine("Invalid username or password. Please try again.");
        }
    }
}