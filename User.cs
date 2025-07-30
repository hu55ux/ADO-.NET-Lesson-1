using Microsoft.Data.SqlClient;
namespace ADO_.NET_Lesson_1;

class User : UserService
{
    private readonly string connectionString = @"Server = (localdb)\MSSQLLocalDB; Database = Users; Integrated Security = SSPI; Trust Server Certificate=True";
    public User(string? username, string? password, string? firstName, string? lastName, short age, bool gender)
    {
        Username = username;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Gender = gender;
    }
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public short Age { get; set; }
    public bool Gender { get; set; }


    public void SignIn(string username, string password)
    {
        string query = $@"SELECT * FROM [USER] WHERE Username LIKE N'{username}' AND Password LIKE N'{password}'";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"Welcome {reader["Username"]}");
                }
            }
            else
            {
                Console.WriteLine("No user found with the provided credentials.");
            }
        }
    }

    public void SignUp(string username, string password, string firstName, string lastName, short age, bool gender)
    {
        if (!isValid(username))
        {
            Console.WriteLine("Username already exists. Please choose a different username.");
            return;
        }
        string query = $@"INSERT INTO [USER](Username,Password,FirstName,LastName,Age,Gender)
                        VALUES('{username}','{password}','{firstName}','{lastName}','{age}','{gender}')";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("User registered successfully.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Something went wrong while registering. Please try again later.");
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
    public bool isValid(string username)
    {
        string query = @$"SELECT * FROM [USER] WHERE Username = '{username}'";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            return !reader.HasRows;
        }
    }
}