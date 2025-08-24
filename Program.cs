using ADO_.NET_Lesson_1;

using var context = new UserContext();
context.Database.EnsureCreated();
IUserService user = new User(context);
while (true)
{
    Console.WriteLine("==== MENU ====");
    Console.WriteLine("1. Sign Up");
    Console.WriteLine("2. Sign In");
    Console.WriteLine("3. Exit");
    Console.Write("Seçiminizi edin: ");
    var choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.Write("Username: ");
        var username = Console.ReadLine();
        Console.Write("Password: ");
        var password = Console.ReadLine();
        Console.Write("First Name: ");
        var firstName = Console.ReadLine();
        Console.Write("Last Name: ");
        var lastName = Console.ReadLine();
        Console.Write("Age: ");
        short age = short.Parse(Console.ReadLine()!);
        Console.Write("Gender (1=Male, 0=Female): ");
        bool gender = Console.ReadLine() == "1";

        user.SignUp(username!, password!, firstName!, lastName!, age, gender);
    }
    else if (choice == "2")
    {
        Console.Write("Username: ");
        var username = Console.ReadLine();
        Console.Write("Password: ");
        var password = Console.ReadLine();

        user.SignIn(username!, password!);
    }
    else if (choice == "3")
    {
        break;
    }
}


































































