using ADO_.NET_Lesson_1;

User user =new User(null, null, null, null, 0, false);

Console.WriteLine("Choose an option:");
Console.WriteLine("1 - Sign Up");
Console.WriteLine("2 - Sign In");
Console.WriteLine("3 - Exit");
Console.Write("Your choice: ");
string? choice = Console.ReadLine();

if (choice == "1")
{
    Console.Write("Username: ");
    string username = Console.ReadLine();
    Console.Write("Password: ");
    string password = Console.ReadLine();
    Console.Write("First Name: ");
    string firstName = Console.ReadLine();
    Console.Write("Last Name: ");
    string lastName = Console.ReadLine();
    Console.Write("Age: ");
    short age = short.Parse(Console.ReadLine());
    Console.Write("Gender (1=Male, 0=Female): ");
    bool gender = Console.ReadLine() == "1";

    user.SignUp(username, password, firstName, lastName, age, gender);
}
else if (choice == "2")
{
    Console.Write("Username: ");
    string username = Console.ReadLine();
    Console.Write("Password: ");
    string password = Console.ReadLine();

    user.SignIn(username, password);
}
else
{
    Console.WriteLine("Exiting the application.");
    return;
}






