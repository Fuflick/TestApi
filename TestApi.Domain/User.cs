using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace TestApi.Domain;

public class User
{
    [Key]
    public long Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;
    
    public string? Email { get; set; }

    public List<TaskEntity>? UsersTasks { get; set; }

    public static string ToHash(string password)
    {
        byte[] data = Encoding.Default.GetBytes(password);
        SHA1 sha = new SHA1CryptoServiceProvider();
        byte[] result = sha.ComputeHash(data);
        password = Convert.ToBase64String(result);
        return password;
    }
    public User(string login, string password, string email)
    {
        Login = login;
        Password = ToHash(password);
        Email = email;
    }
    
}