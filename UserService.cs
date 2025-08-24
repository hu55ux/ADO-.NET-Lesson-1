namespace ADO_.NET_Lesson_1;

public interface IUserService
{
    void SignIn(string username, string password);
    void SignUp(string username, string password, string firstName, string lastName, short age, bool gender);
}