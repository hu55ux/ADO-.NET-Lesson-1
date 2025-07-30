namespace ADO_.NET_Lesson_1;

public interface UserService
{
    void SignIn(string username, string password);
    void SignUp(string username, string password, string firstName, string lastName, short age, bool gender);
    bool isValid(string username);

}